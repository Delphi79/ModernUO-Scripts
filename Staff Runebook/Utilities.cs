/****************************************
 * Author: Joeku                        *
 * Revised for MUO: Nerun & Delphi      *
 * For use with ModernUO                *
 * Client Tested with: 7.0.102.3        *
 * Version: 1.10                        *
 * Initial Release: 11/25/2007          *
 * Revision Date: 06/07/2024            *
 **************************************/

using System;
using System.Collections.Generic;
using Server;
using Server.Accounting;
using Server.Gumps;

namespace Joeku.SR
{
    public class SR_Utilities
    {
        public static bool FindItem(Type type, Point3D p, Map map)
        {
            return FindEntity<Item>(type, p, map);
        }

        public static bool FindMobile(Type type, Point3D p, Map map)
        {
            return FindEntity<Mobile>(type, p, map);
        }

        private static bool FindEntity<T>(Type type, Point3D p, Map map) where T : class
        {
            ArgumentNullException.ThrowIfNull(type);
            ArgumentNullException.ThrowIfNull(map);

            IEnumerable<T> loc = null;
            Rectangle2D rect = new Rectangle2D(p.X, p.Y, 1, 1);

            if (typeof(T) == typeof(Mobile))
            {
                var mobiles = map.GetMobilesInBounds(rect);
                List<Mobile> mobileList = new List<Mobile>();

                foreach (Mobile mobile in mobiles)
                {
                    mobileList.Add(mobile);
                }

                loc = mobileList as IEnumerable<T>;
            }
            else if (typeof(T) == typeof(Item))
            {
                var items = map.GetItemsInBounds(rect);
                List<Item> itemList = new List<Item>();

                foreach (Item item in items)
                {
                    itemList.Add(item);
                }

                loc = itemList as IEnumerable<T>;
            }

            if (loc == null)
            {
                return false;
            }

            bool found = false;

            try
            {
                foreach (var o in loc)
                {
                    if (o != null && (o.GetType() == type || o.GetType().IsSubclassOf(type)))
                    {
                        found = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                Console.WriteLine($"Exception occurred while iterating: {ex.Message}");
            }

            return found;
        }

        public static SR_RuneAccount FetchInfo(IAccount acc)
        {
            ArgumentNullException.ThrowIfNull(acc);
            return FetchInfo(acc as Account);
        }

        public static SR_RuneAccount FetchInfo(Account acc)
        {
            ArgumentNullException.ThrowIfNull(acc);
            return FetchInfo(acc.Username);
        }

        public static SR_RuneAccount FetchInfo(string username)
        {
            ArgumentNullException.ThrowIfNull(username);

            SR_RuneAccount runeAcc = null;

            for (int i = 0; i < SR_Main.Count; i++)
            {
                if (string.Equals(SR_Main.Info[i].Username, username, StringComparison.OrdinalIgnoreCase))
                {
                    runeAcc = SR_Main.Info[i];
                    break;
                }
            }

            if (runeAcc == null)
            {
                runeAcc = new SR_RuneAccount(username);
                NewRuneAcc(runeAcc);
            }

            return runeAcc;
        }

        public static int RunebookID = 8901;
        public static int RuneID = 7956;

        public static int ItemOffsetY(SR_Rune rune)
        {
            ArgumentNullException.ThrowIfNull(rune);
            return rune.IsRunebook ? -1 : 3;
        }

        public static int ItemOffsetX(SR_Rune rune)
        {
            ArgumentNullException.ThrowIfNull(rune);
            return rune.IsRunebook ? -1 : -2;
        }

        public static int ItemHue(SR_Rune rune)
        {
            ArgumentNullException.ThrowIfNull(rune);
            return rune.IsRunebook ? 1121 : RuneHues[MapInt(rune.TargetMap)];
        }

        private static int[] RuneHues = { 0, 50, 1102, 1102, 1154, 0x66D, 0x47F, 0x55F, 0x55F, 0x47F };

        public static bool CheckValid(Point3D? loc, Map map)
        {
            ArgumentNullException.ThrowIfNull(map);

            if (loc == null) return false;

            Point2D dim = MapDimensions[MapInt(map)];

            return loc.Value.X >= 0 && loc.Value.Y >= 0 && loc.Value.X <= dim.X && loc.Value.Y <= dim.Y;
        }

        private static Point2D[] MapDimensions = {
            new Point2D(7168, 4096), // Felucca
            new Point2D(7168, 4096), // Trammel
            new Point2D(2304, 1600), // Ilshenar
            new Point2D(1448, 1448), // Tokuno
            new Point2D(1280, 4096)  // TerMur
        };

        public static int MapInt(Map map)
        {
            ArgumentNullException.ThrowIfNull(map);

            return map switch
            {
                { } when map == Map.Felucca => 0,
                { } when map == Map.Trammel => 1,
                { } when map == Map.Ilshenar => 2,
                { } when map == Map.Malas => 3,
                { } when map == Map.Tokuno => 4,
                { } when map == Map.TerMur => 5,
                _ => throw new ArgumentOutOfRangeException(nameof(map), "Invalid map")
            };
        }

        public static void NewRuneAcc(SR_RuneAccount acc)
        {
            ArgumentNullException.ThrowIfNull(acc);

            acc.Clear();

            try
            {
                acc.AddRune(AddTree(Map.Felucca));

                acc.AddRune(AddTree(Map.Trammel));

                acc.AddRune(AddTree(Map.Ilshenar));

                acc.AddRune(AddTree(Map.Malas));

                acc.AddRune(AddTree(Map.Tokuno));

                acc.AddRune(AddTree(Map.TerMur));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException: {ex.ParamName} is null.");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred in NewRuneAcc: {ex.Message}");
                throw;
            }
        }

        private static SR_Rune AddTree(Map map)
        {
            ArgumentNullException.ThrowIfNull(map);

            LocationTree tree = GoLocations.GetLocations(map);

            SR_Rune runeBook = new SR_Rune(map.ToString(), true);

            try
            {
                // Log the state of the LocationTree

                if (tree.Root != null)
                {
                    if (tree.Root.Categories != null)
                    {
                        for (int i = 0; i < tree.Root.Categories.Length; i++)
                        {
                            runeBook.AddRune(AddNode(tree.Root.Categories[i], map));
                        }
                    }

                    if (tree.Root.Locations != null)
                    {
                        for (int i = 0; i < tree.Root.Locations.Length; i++)
                        {
                            runeBook.AddRune(new SR_Rune(tree.Root.Locations[i].Name, map, tree.Root.Locations[i].Location));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                Console.WriteLine($"Exception occurred in AddTree: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Optionally, rethrow the exception if needed
                throw;
            }

            return runeBook;
        }

        private static SR_Rune AddNode(GoCategory category, Map map)
        {
            ArgumentNullException.ThrowIfNull(category);
            ArgumentNullException.ThrowIfNull(map);

            SR_Rune runeBook = new SR_Rune(category.Name, true);

            if (category.Categories != null)
            {
                for (int i = 0; i < category.Categories.Length; i++)
                {
                    runeBook.AddRune(AddNode(category.Categories[i], map));
                }
            }

            if (category.Locations != null)
            {
                for (int i = 0; i < category.Locations.Length; i++)
                {
                    runeBook.AddRune(new SR_Rune(category.Locations[i].Name, map, category.Locations[i].Location));
                }
            }

            return runeBook;
        }
    }
}
