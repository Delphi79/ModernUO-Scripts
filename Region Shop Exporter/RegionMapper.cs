using System;
using System.Collections.Generic;
using System.IO;
using Server;
using Server.Items;
using Server.Network;

public class ExportShopRegionsCommand
{
    private static readonly int[] SignHangarTypes = new int[]
    {
        0x0B97, 0x0B98, 0x0B99, 0x0B9A,
        0x0B9B, 0x0B9C, 0x0B9D, 0x0B9E,
        0x0B9F, 0x0BA0, 0x0BA1, 0x0BA2
    };

    private static readonly Map[] MapsToSearch = new Map[]
    {
        Map.Felucca, Map.Trammel, Map.Ilshenar, Map.Malas, Map.Tokuno, Map.TerMur
    };

    [Usage("ExportShopRegions")]
    [Description("Exports shop regions and their details to a text file.")]
    public static void Initialize()
    {
        CommandSystem.Register("ExportShopRegions", AccessLevel.GameMaster, new CommandEventHandler(ExportShopRegions_OnCommand));
    }

    private static void ExportShopRegions_OnCommand(CommandEventArgs e)
    {
        var outputFilePath = Path.Combine(Core.BaseDirectory, "shop_regions.txt");
        var regionsByMap = new Dictionary<string, List<string>>();

        Console.ForegroundColor = ConsoleColor.Green; // Set console color to green

        foreach (var map in MapsToSearch)
        {
            if (map == null)
                continue;

            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            e.Mobile.SendMessage(0x35, $"Searching map: {map.Name}");
            Console.WriteLine($"[{timestamp}] Begin Mapping {map.Name}");
            Console.WriteLine($"[{timestamp}] Connected Clients: {NetState.Instances.Count}");

            var signLocations = FindSignLocations(map, e.Mobile);
            var mapRegions = new List<string>();

            foreach (var signLocation in signLocations)
            {
                var boundingBoxes = MapBuilding(map, signLocation, e.Mobile);
                if (!string.IsNullOrEmpty(boundingBoxes))
                {
                    string regionDetails = $"Type: ShopRegion\n" +
                                           $"Map: {map}\n" +
                                           $"Name: {signLocation.Name}\n" +
                                           $"Go Location: {signLocation.Location.X} {signLocation.Location.Y} {signLocation.Location.Z}\n" +
                                           $"Area: {boundingBoxes}\n";
                    mapRegions.Add(regionDetails);
                }

                // Flush all pending network data to keep the client connection alive
                NetState.FlushAll();
            }

            if (mapRegions.Count > 0)
            {
                regionsByMap.Add(map.Name, mapRegions);
            }

            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Console.WriteLine($"[{timestamp}] Mapping {map.Name} Done!");
        }

        using (var writer = new StreamWriter(outputFilePath, false))
        {
            foreach (var mapEntry in regionsByMap)
            {
                writer.WriteLine($"##Map: {mapEntry.Key}");
                writer.WriteLine();
                foreach (var region in mapEntry.Value)
                {
                    writer.WriteLine(region);
                }
                writer.WriteLine();
            }
        }

        Console.ResetColor(); // Reset console color to default
        e.Mobile.SendMessage(0x35, "Shop regions have been exported successfully.");
    }

    private static List<SignLocation> FindSignLocations(Map map, Mobile from)
    {
        var signLocations = new List<SignLocation>();

        from.SendMessage(0x35, $"Scanning map: {map.Name}");

        for (int x = 0; x < map.Width; x++)
        {
            for (int y = 0; y < map.Height; y++)
            {
                foreach (var tile in new Map.StaticTileEnumerable(map, new Point2D(x, y)))
                {
                    if (Array.IndexOf(SignHangarTypes, tile.ID) >= 0)
                    {
                        var signHangarPosition = new Point3D(x, y, tile.Z);
                        List<Item> items = new List<Item>();

                        foreach (var item in map.GetItemsInRange<Item>(signHangarPosition, 1))
                        {
                            items.Add(item);
                        }

                        foreach (Item item in items)
                        {
                            if (item is LocalizedSign locSign)
                            {
                                string name = Localization.GetText(locSign.Number);
                                signLocations.Add(new SignLocation { Location = new Point3D(x, y, tile.Z), Name = name });
                                // Place MappingHelper at the sign location
                                PlaceMappingHelper(map, x, y, tile.Z, from);
                            }
                        }
                    }
                }

                // Progress indicator
                if (x % 100 == 0 && y == 0)
                {
                    from.SendMessage(0x35, $"Progress: {x}/{map.Width}");
                    var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    Console.WriteLine($"[{timestamp}] Progress: {x}/{map.Width} on {map.Name}");
                }

                // Flush all pending network data to keep the client connection alive
                NetState.FlushAll();
            }
        }

        return signLocations;
    }

    private static string MapBuilding(Map map, SignLocation signLocation, Mobile from)
    {
        var visited = new HashSet<Point3D>();
        var toVisit = new Queue<Point3D>();
        toVisit.Enqueue(signLocation.Location);

        int minX = signLocation.Location.X, minY = signLocation.Location.Y, maxX = signLocation.Location.X, maxY = signLocation.Location.Y;

        while (toVisit.Count > 0)
        {
            var p = toVisit.Dequeue();
            if (!visited.Add(p)) continue;

            bool isBuildingTile = IsBuildingTile(map, p, from);

            if (isBuildingTile)
            {
                minX = Math.Min(minX, p.X);
                minY = Math.Min(minY, p.Y);
                maxX = Math.Max(maxX, p.X);
                maxY = Math.Max(maxY, p.Y);

                foreach (var neighbor in GetNeighbors(p))
                {
                    if (!visited.Contains(neighbor))
                    {
                        toVisit.Enqueue(neighbor);
                    }
                }
            }

            // Flush all pending network data to keep the client connection alive
            NetState.FlushAll();
        }

        // Place MappingHelpers at the detected edges (inside walls)
        for (int x = minX; x <= maxX; x++)
        {
            if (IsBuildingTile(map, new Point3D(x, minY, signLocation.Location.Z), from))
                PlaceMappingHelper(map, x, minY, signLocation.Location.Z, from);
            if (IsBuildingTile(map, new Point3D(x, maxY, signLocation.Location.Z), from))
                PlaceMappingHelper(map, x, maxY, signLocation.Location.Z, from);
        }

        for (int y = minY; y <= maxY; y++)
        {
            if (IsBuildingTile(map, new Point3D(minX, y, signLocation.Location.Z), from))
                PlaceMappingHelper(map, minX, y, signLocation.Location.Z, from);
            if (IsBuildingTile(map, new Point3D(maxX, y, signLocation.Location.Z), from))
                PlaceMappingHelper(map, maxX, y, signLocation.Location.Z, from);
        }

        // Debug output to verify calculated boundaries
        from?.SendMessage(0x35, $"Calculated boundaries: x1={minX}, y1={minY}, x2={maxX}, y2={maxY}");
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        Console.WriteLine($"[{timestamp}] Calculated boundaries: x1={minX}, y1={minY}, x2={maxX}, y2={maxY}");

        return minX == maxX && minY == maxY ? null : $"[{{\"x1\": {minX}, \"y1\": {minY}, \"x2\": {maxX}, \"y2\": {maxY}}}]";
    }

    private static bool IsBuildingTile(Map map, Point3D p, Mobile from)
    {
        foreach (var tile in new Map.StaticTileEnumerable(map, new Point2D(p.X, p.Y)))
        {
            var itemData = TileData.ItemTable[tile.ID & TileData.MaxItemValue];
            if (itemData.Flags.HasFlag(TileFlag.Wall) || itemData.Flags.HasFlag(TileFlag.Impassable))
            {
                from?.SendMessage(0x35, $"Tile at ({p.X}, {p.Y}, {p.Z}) is a building tile.");
                return true;
            }
        }

        foreach (var item in map.GetItemsInRange<Item>(p, 1))
        {
            var itemData = item.ItemData;
            if (itemData.Flags.HasFlag(TileFlag.Wall) || itemData.Flags.HasFlag(TileFlag.Impassable))
            {
                from?.SendMessage(0x35, $"Item at ({p.X}, {p.Y}, {p.Z}) is a building item.");
                return true;
            }
        }

        from?.SendMessage(0x35, $"Tile at ({p.X}, {p.Y}, {p.Z}) is not a building tile.");
        return false;
    }

    private static IEnumerable<Point3D> GetNeighbors(Point3D point)
    {
        int buffer = 1; // Adjust buffer as needed
        for (int dx = -buffer; dx <= buffer; dx++)
        {
            for (int dy = -buffer; dy <= buffer; dy++)
            {
                if (dx != 0 || dy != 0)
                {
                    yield return new Point3D(point.X + dx, point.Y + dy, point.Z);
                }
            }
        }
    }

    private static void PlaceMappingHelper(Map map, int x, int y, int z, Mobile from)
    {
        var helper = new MappingHelper
        {
            Movable = false
        };

        helper.MoveToWorld(new Point3D(x, y, z), map);

        if (from != null)
        {
            from.SendMessage(0x35, $"MappingHelper placed at ({x}, {y}, {z})");
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Console.WriteLine($"[{timestamp}] MappingHelper placed at ({x}, {y}, {z})");
        }
    }
}

public class SignLocation
{
    public Point3D Location { get; set; }
    public string Name { get; set; }
}
