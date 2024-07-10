using System;
using Server;

public class SignHangarCountCommand
{
    // List of sign hangar types and their corresponding item IDs
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

    [Usage("Signcount")]
    [Description("Counts the number of specific sign hangar types on each map.")]
    public static void Initialize()
    {
        CommandSystem.Register("Signcount", AccessLevel.GameMaster, new CommandEventHandler(Signcount_OnCommand));
    }

    private static void Signcount_OnCommand(CommandEventArgs e)
    {
        Map[] maps = { Map.Felucca, Map.Trammel, Map.Ilshenar, Map.Malas, Map.Tokuno, Map.TerMur };

        for (int i = 0; i < maps.Length; i++)
        {
            if (maps[i] == null)
                continue;

            int count = CountStaticItems(maps[i]);

            e.Mobile.SendMessage(0x35, $"There are {count} sign hangars on the map {MapNames[i]}.");
        }
    }

    private static int CountStaticItems(Map map)
    {
        int count = 0;

        // Iterate through each sector on the map
        for (int x = 0; x < map.Width; x++)
        {
            for (int y = 0; y < map.Height; y++)
            {
                var tiles = map.Tiles.GetStaticTiles(x, y);

                foreach (var tile in tiles)
                {
                    if (Array.IndexOf(SignHangarTypes, tile.ID) >= 0)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
}
