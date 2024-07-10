using System;
using System.Collections.Generic;
using System.IO;
using Server;
using Server.Items;

public class ExportShopSignsCommand
{
    private static readonly int[] SignHangarTypes = new int[]
    {
        0x0B97, 0x0B98, 0x0B99, 0x0B9A,
        0x0B9B, 0x0B9C, 0x0B9D, 0x0B9E,
        0x0B9F, 0x0BA0, 0x0BA1, 0x0BA2
    };

    private static readonly string[] MapNames = new string[]
    {
        "Felucca", "Trammel", "Ilshenar", "Malas", "Tokuno", "TerMur"
    };

    [Usage("ExportShopSigns")]
    [Description("Exports shop signs and their details to a txt file grouped by maps.")]
    public static void Initialize()
    {
        CommandSystem.Register("ExportShopSigns", AccessLevel.GameMaster, new CommandEventHandler(ExportShopSigns_OnCommand));
    }

    private static void ExportShopSigns_OnCommand(CommandEventArgs e)
    {
        var outputFilePath = Path.Combine(Core.BaseDirectory, "shop_signs.txt");
        var signsByMap = new Dictionary<string, List<string>>();
        var hangarsWithoutSignsByMap = new Dictionary<string, List<string>>();
        var hangarsByMap = new Dictionary<string, List<string>>();

        var totalHangars = 0;
        var totalHangarsWithSigns = 0;
        var totalHangarsWithoutSigns = 0;
        var hangarCountByMap = new Dictionary<string, int>();
        var hangarWithSignsCountByMap = new Dictionary<string, int>();
        var hangarWithoutSignsCountByMap = new Dictionary<string, int>();

        foreach (var map in Map.AllMaps)
        {
            if (map == null || map == Map.Internal)
                continue;

            var mapSigns = new List<string>();
            var hangarsWithoutSigns = new List<string>();
            var hangars = new List<string>();
            int hangarCount = 0;
            int countWithSigns = 0;

            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    var tiles = map.Tiles.GetStaticTiles(x, y);

                    foreach (var tile in tiles)
                    {
                        if (Array.IndexOf(SignHangarTypes, tile.ID) >= 0)
                        {
                            hangarCount++;
                            totalHangars++;
                            bool hasSign = false;

                            foreach (Item item in map.GetItemsInRange(new Point3D(x, y, tile.Z), 1))
                            {
                                if (item is LocalizedSign localizedSign)
                                {
                                    countWithSigns++;
                                    totalHangarsWithSigns++;
                                    hasSign = true;
                                    string name = Localization.GetText(localizedSign.Number);
                                    string signDetails = $"Name: {name}\n" +
                                                         $"Map: {map}\n" +
                                                         $"ItemID: 0x{localizedSign.ItemID:X}\n" +
                                                         $"Location: {localizedSign.X} {localizedSign.Y} {localizedSign.Z}\n";
                                    mapSigns.Add(signDetails);
                                }
                            }

                            if (!hasSign)
                            {
                                string hangarDetails = $"Static ItemID: 0x{tile.ID:X}\n" +
                                                       $"Location: {x} {y} {tile.Z}\n";
                                hangarsWithoutSigns.Add(hangarDetails);
                                totalHangarsWithoutSigns++;
                            }

                            hangars.Add($"Static ItemID: 0x{tile.ID:X}\n" +
                                        $"Location: {x} {y} {tile.Z}\n");
                        }
                    }
                }
            }

            hangarCountByMap[map.Name] = hangarCount;
            hangarWithSignsCountByMap[map.Name] = countWithSigns;
            hangarWithoutSignsCountByMap[map.Name] = hangarCount - countWithSigns;

            if (mapSigns.Count > 0)
            {
                signsByMap.Add(map.Name, mapSigns);
            }

            if (hangarsWithoutSigns.Count > 0)
            {
                hangarsWithoutSignsByMap.Add(map.Name, hangarsWithoutSigns);
            }

            if (hangars.Count > 0)
            {
                hangarsByMap.Add(map.Name, hangars);
            }
        }

        using (var writer = new StreamWriter(outputFilePath, false))
        {
            writer.WriteLine("##Static Sign Hangars");
            writer.WriteLine($"Total Count: {totalHangars}");
            foreach (var mapName in MapNames)
            {
                writer.WriteLine($"{mapName}: {hangarCountByMap.GetValueOrDefault(mapName, 0)}");
            }
            writer.WriteLine();

            foreach (var mapEntry in hangarsByMap)
            {
                writer.WriteLine($"##MapSSH: {mapEntry.Key}");
                writer.WriteLine();
                foreach (var hangar in mapEntry.Value)
                {
                    writer.WriteLine(hangar);
                }
                writer.WriteLine();
            }

            writer.WriteLine("##Static Hangars Missing Signs");
            writer.WriteLine($"Total Count: {totalHangarsWithoutSigns}");
            foreach (var mapName in MapNames)
            {
                writer.WriteLine($"{mapName}: {hangarWithoutSignsCountByMap.GetValueOrDefault(mapName, 0)}");
            }
            writer.WriteLine();

            foreach (var mapEntry in hangarsWithoutSignsByMap)
            {
                writer.WriteLine($"##MapSHMS: {mapEntry.Key}");
                writer.WriteLine();
                foreach (var hangar in mapEntry.Value)
                {
                    writer.WriteLine(hangar);
                }
                writer.WriteLine();
            }

            writer.WriteLine("##Static Hangars With Signs");
            writer.WriteLine($"Total Count: {totalHangarsWithSigns}");
            foreach (var mapName in MapNames)
            {
                writer.WriteLine($"{mapName}: {hangarWithSignsCountByMap.GetValueOrDefault(mapName, 0)}");
            }
            writer.WriteLine();

            foreach (var mapEntry in signsByMap)
            {
                writer.WriteLine($"##MapSHWS: {mapEntry.Key}");
                writer.WriteLine();
                foreach (var sign in mapEntry.Value)
                {
                    writer.WriteLine(sign);
                }
                writer.WriteLine();
            }
        }

        e.Mobile.SendMessage(0x35, "Shop signs and hangars have been exported successfully.");
    }
}
