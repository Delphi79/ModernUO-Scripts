using System;
using Server.Gumps;
using Server.Items;
using Server.Network;

namespace Server.Engines.Craft;

public class CarpentryMenu : DynamicGump
{
    private const int LabelHue = 1152;
    private readonly CraftSystem _craftSystem;
    private readonly Mobile _from;
    private readonly BaseTool _tool;
    private readonly string _category;
    private readonly int _currentPage;

    private const int ItemsPerPage = 4;

    public CarpentryMenu(Mobile from, CraftSystem craftSystem, BaseTool tool, string category = "Main", int currentPage = 0)
        : base(150, 200)
    {
        _from = from;
        _craftSystem = craftSystem;
        _tool = tool;
        _category = category;
        _currentPage = currentPage;
    }

    protected override void BuildLayout(ref DynamicGumpBuilder builder)
    {
        builder.AddPage(0);
        builder.SetNoResize();
        builder.SetNoDispose();

        int startX = 40;
        int startY = 40;

        // Get items and names based on the current category
        var (itemIDs, itemNames) = GetItemsForCategory(_category);
        int itemStartIndex = _currentPage * ItemsPerPage;
        int itemEndIndex = Math.Min(itemStartIndex + ItemsPerPage, itemIDs.Length);

        for (int i = itemStartIndex; i < itemEndIndex; i++)
        {
            builder.AddButton(startX, startY, 2260, 2260, GetButtonID(i), GumpButtonType.Reply, 0);
            builder.AddTooltip(1042971, itemNames[i]); // Add tooltip with the item name
            startX += 50;
        }

        builder.AddImage(0, 0, 2320);

        startX = 40;
        for (int i = itemStartIndex; i < itemEndIndex; i++)
        {
            builder.AddItem(startX, startY, itemIDs[i]);
            startX += 50;
        }

        if (_currentPage > 0)
        {
            builder.AddButton(10, 60, 9909, 9910, 1000, GumpButtonType.Reply, 0); // Previous page button
        }

        if (itemEndIndex < itemIDs.Length)
        {
            builder.AddButton(265, 60, 9903, 9904, 1001, GumpButtonType.Reply, 0); // Next page button
        }

        builder.AddLabel(55, 15, LabelHue, @"What would you like to make?");
        builder.AddLabel(110, 100, LabelHue, _category == "Main" ? @"Carpentry" : _category);
    }

    private int GetButtonID(int itemIndex)
    {
        return itemIndex + 1; // +1 because button IDs start from 1
    }

    private (int[], string[]) GetItemsForCategory(string category)
    {
        switch (category)
        {
            case "Chairs":
                return GetChairsItems();
            case "Tables":
                return GetTablesItems();
            case "Misc":
                return GetMiscItems();
            case "Containers":
                return GetContainersItems();
            default: // Main Menu
                return GetMainMenuItems();
        }
    }

    private (int[], string[]) GetMainMenuItems()
    {
        return (
            new int[] { 2902, 2869, 3650, 3649 },
            new string[] { "Chairs", "Tables", "Miscellaneous", "Containers" }
        );
    }

    private (int[], string[]) GetChairsItems()
    {
        return (
            new int[] { 2902, 2897, 2906, 2898, 2899, 2900, 2901, 2903, 2904, 2905, 2907, 2908, 2909, 2910, 2911 },
            new string[] { "Chair", "Fancy Wooden Chair", "Bamboo Chair", "Wooden Throne", "Wooden Bench", "Foot Stool", "Stool", "Low Stool", "Wooden Chair", "Wooden Chair", "Wooden Chair", "Wooden Chair", "Wooden Chair", "Wooden Chair", "Wooden Chair" }
        );
    }

    private (int[], string[]) GetTablesItems()
    {
        return (
            new int[] { 2869, 2889, 2959, 2960, 2950, 2951, 2952, 2953, 2954, 2955 },
            new string[] { "Table", "Writing Table", "Yew Wood Table", "Large Table", "Small Table", "Small Round Table", "Large Round Table", "Large Square Table", "Large Square Table", "Large Square Table" }
        );
    }

    private (int[], string[]) GetMiscItems()
    {
        return (
            new int[] { 3650, 7034, 3651, 3652, 3653, 3654, 3655, 3656, 3657 },
            new string[] { "Misc Item 1", "Misc Item 2", "Misc Item 3", "Misc Item 4", "Misc Item 5", "Misc Item 6", "Misc Item 7", "Misc Item 8", "Misc Item 9" }
        );
    }

    private (int[], string[]) GetContainersItems()
    {
        return (
            new int[] { 3649, 3648, 3647, 3646, 3645, 3644, 3643, 3642, 3641 },
            new string[] { "Wooden Chest", "Wooden Box", "Wooden Crate", "Small Wooden Crate", "Large Wooden Crate", "Barrel", "Open Barrel", "Closed Barrel", "Half Barrel" }
        );
    }

    public override void OnResponse(NetState sender, in RelayInfo info)
    {
        int itemIndex = info.ButtonID - 1;

        var (itemIDs, itemNames) = GetItemsForCategory(_category);

        if (itemIndex >= 0 && itemIndex < itemIDs.Length)
        {
            if (_category == "Main")
            {
                switch (itemNames[itemIndex])
                {
                    case "Chairs":
                        _from.SendGump(new CarpentryMenu(_from, _craftSystem, _tool, "Chairs"));
                        break;
                    case "Tables":
                        _from.SendGump(new CarpentryMenu(_from, _craftSystem, _tool, "Tables"));
                        break;
                    case "Miscellaneous":
                        _from.SendGump(new CarpentryMenu(_from, _craftSystem, _tool, "Misc"));
                        break;
                    case "Containers":
                        _from.SendGump(new CarpentryMenu(_from, _craftSystem, _tool, "Containers"));
                        break;
                    default:
                        _from.SendMessage(0, $"{itemNames[itemIndex]} Selected.");
                        break;
                }
            }
            else
            {
                _from.SendMessage(0, $"{itemNames[itemIndex]} Selected.");
                // Add crafting logic here
            }
        }
        else
        {
            switch (info.ButtonID)
            {
                case 1000:
                    _from.SendGump(new CarpentryMenu(_from, _craftSystem, _tool, _category, _currentPage - 1)); // Previous page
                    break;
                case 1001:
                    _from.SendGump(new CarpentryMenu(_from, _craftSystem, _tool, _category, _currentPage + 1)); // Next page
                    break;
                default:
                    _from.SendMessage(0, "No action.");
                    break;
            }
        }
    }
}
