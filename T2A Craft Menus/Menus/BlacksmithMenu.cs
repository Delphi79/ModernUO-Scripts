using System;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.Engines.Craft
{
    public class BlacksmithMenu : DynamicGump
    {
        private const int LabelHue = 1152;
        private readonly CraftSystem _craftSystem;
        private readonly Mobile _from;
        private readonly BaseTool _tool;
        private readonly string _category;
        private readonly int _currentPage;

        private const int ItemsPerPage = 4;

        public BlacksmithMenu(Mobile from, CraftSystem craftSystem, BaseTool tool, string category = "Main", int currentPage = 0)
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
            int startY = 50;

            // Get items and names based on the current category
            var (itemIDs, itemNames) = GetItemsForCategory(_category);
            int itemStartIndex = _currentPage * ItemsPerPage;
            int itemEndIndex = Math.Min(itemStartIndex + ItemsPerPage, itemIDs.Length);

            for (int i = itemStartIndex; i < itemEndIndex; i++)
            {
                if (i >= itemIDs.Length || i >= itemNames.Length)
                {
                    // Prevent accessing out-of-bounds indices
                    break;
                }

                builder.AddButton(startX, startY, 2260, 2260, GetButtonID(i), GumpButtonType.Reply, 0);
                builder.AddTooltip(1042971, itemNames[i]); // Add tooltip with the item name
                startX += 50;
            }

            builder.AddImage(0, 0, 2320);

            startX = 40;
            for (int i = itemStartIndex; i < itemEndIndex; i++)
            {
                if (i >= itemIDs.Length)
                {
                    // Prevent accessing out-of-bounds indices
                    break;
                }

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
            builder.AddLabel(110, 100, LabelHue, _category == "Main" ? @"Blacksmithing" : _category);
        }

        private int GetButtonID(int itemIndex)
        {
            return itemIndex + 1; // +1 because button IDs start from 1
        }

        private (int[], string[]) GetItemsForCategory(string category)
        {
            switch (category)
            {
                case "Shields":
                    return GetShieldsItems();
                case "Armor":
                    return GetArmorItems();
                case "Weapons":
                    return GetWeaponsItems();
                case "Ringmail":
                    return GetRingmailItems();
                case "Chainmail":
                    return GetChainmailItems();
                case "Platemail":
                    return GetPlatemailItems();
                case "Helmets":
                    return GetHelmetItems();
                case "Bladed":
                    return GetBladedWeapons();
                case "Axes":
                    return GetAxeWeapons();
                case "Polearms":
                    return GetPolearmWeapons();
                default: // Main Menu
                    return GetMainMenuItems();
            }
        }

        private (int[], string[]) GetMainMenuItems()
        {
            return (
                new int[] { 0x0FAF, 0x1B72, 0x1415, 0x13B9 },
                new string[] { "Repair", "Shields", "Armor", "Weapons" }
            );
        }

        private (int[], string[]) GetArmorItems()
        {
            return (
                new int[] { 0x13EC, 5055, 0x1415, 0x1412 },
                new string[] { "Ringmail", "Chainmail", "Platemail", "Helmets" }
            );
        }

        private (int[], string[]) GetShieldsItems()
        {
            return (
                new int[] { 0x1B73, 0x1B72, 0x1B76, 0x1B7B, 0x1B74, 0x1B78 },
                new string[] { "Buckler", "Bronze Shield", "Heater Shield", "Metal Shield", "Metal Kite Shield", "Wooden Kite Shield" }
            );
        }

        private (int[], string[]) GetWeaponsItems()
        {
            return (
                new int[] { 5047, 5048, 2869 },
                new string[] { "Bladed", "Axes", "Polearms" }
            );
        }

        private (int[], string[]) GetRingmailItems()
        {
            return (
                new int[] { 0x13EB, 0x13F0, 0x13EE, 0x13EC },
                new string[] { "Ringmail Gloves", "Ringmail Legs", "Ringmail Arms", "Ringmail Chest" }
            );
        }

        private (int[], string[]) GetChainmailItems()
        {
            return (
                new int[] { 0x13BB, 0x13BE, 5055 },
                new string[] { "Chain Coif", "Chainmail Leggings", "Chainmail Tunic" }
            );
        }

        private (int[], string[]) GetPlatemailItems()
        {
            return (
                new int[] { 0x1410, 0x1414, 0x1413, 0x1411, 0x1415, 0x1C04 },
                new string[] { "Plate Arms", "Plate Gloves", "Plate Gorget", "Plate Leggings", "Plate Chest", "Female Plate Chest" }
            );
        }

        private (int[], string[]) GetHelmetItems()
        {
            return (
                new int[] { 0x140C, 0x1408, 0x140A, 0x140E, 0x1412 },
                new string[] { "Bascinet", "Close Helm", "Helmet", "Norse Helm", "Plate Helm" }
            );
        }

        private (int[], string[]) GetBladedWeapons()
        {
            return (
                new int[] { 0x1440, 0x0F51, 0x13FE, 0x1400, 0x0F60, 0x13B5, 0x13B9 },
                new string[] { "Cutlass", "Dagger", "Katana", "Kryss", "Longsword", "Scimitar", "Viking Sword" }
            );
        }

        private (int[], string[]) GetAxeWeapons()
        {
            return (
                new int[] { 0x0F49, 0x0F47, 0x0F4B, 0xF45, 0x13FA, 0x1442, 0x13AF },
                new string[] { "Axe", "Battle Axe", "Double Axe", "Executioner's Axe", "Large Battle Axe", "Two-Handed Axe", "War Axe" }
            );
        }

        private (int[], string[]) GetPolearmWeapons()
        {
            return (
                new int[] { 0x143F, 0x26C2, 0x26BF, 0x143E, 0x26C0, 0x26BD, 0x26C1, 0x26BB, 0x1404, 0x1405 },
                new string[] { "Bardiche", "Bladed Staff", "Double Bladed Staff", "Halberd", "Lance", "Pike", "Short Spear", "Scythe", "Spear", "War Fork" }
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
                        case "Shields":
                            _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, "Shields"));
                            break;
                        case "Armor":
                            _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, "Armor"));
                            break;
                        case "Weapons":
                            _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, "Weapons"));
                            break;
                        case "Repair":
                            if (_craftSystem.Repair)
                            {
                                StartRepair();
                            }
                            break;
                    }
                }
                else if (_category == "Armor")
                {
                    switch (itemNames[itemIndex])
                    {
                        case "Ringmail":
                            _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, "Ringmail"));
                            break;
                        case "Chainmail":
                            _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, "Chainmail"));
                            break;
                        case "Platemail":
                            _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, "Platemail"));
                            break;
                        case "Helmets":
                            _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, "Helmets"));
                            break;
                    }
                }
                else if (_category == "Weapons")
                {
                    switch (itemNames[itemIndex])
                    {
                        case "Bladed":
                            _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, "Bladed"));
                            break;
                        case "Axes":
                            _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, "Axes"));
                            break;
                        case "Polearms":
                            _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, "Polearms"));
                            break;
                    }
                }
                else if (_category == "Shields")
                {
                    _from.SendMessage(0, $"Crafting {itemNames[itemIndex]}");
                    CraftShield(itemNames[itemIndex]);
                }
                else
                {
                    _from.SendMessage(0, $"{itemNames[itemIndex]} Selected.");
                }
            }
            else
            {
                switch (info.ButtonID)
                {
                    case 1000:
                        _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, _category, _currentPage - 1)); // Previous page
                        break;
                    case 1001:
                        _from.SendGump(new BlacksmithMenu(_from, _craftSystem, _tool, _category, _currentPage + 1)); // Next page
                        break;
                    default:
                        _from.SendMessage(0, "No action.");
                        break;
                }
            }
        }

        private void StartRepair()
        {
            _from.Target = new RepairTarget(_craftSystem, _tool, this);
            _from.SendLocalizedMessage(1044276); // Target an item to repair.
        }

        private void CraftShield(string shieldName)
        {
            _from.SendMessage(0, $"Starting craft for {shieldName}");
            Type shieldType = null;

            switch (shieldName)
            {
                case "Buckler":
                    shieldType = typeof(Buckler);
                    break;
                case "Bronze Shield":
                    shieldType = typeof(BronzeShield);
                    break;
                case "Heater Shield":
                    shieldType = typeof(HeaterShield);
                    break;
                case "Metal Shield":
                    shieldType = typeof(MetalShield);
                    break;
                case "Metal Kite Shield":
                    shieldType = typeof(MetalKiteShield);
                    break;
                case "Wooden Kite Shield":
                    shieldType = typeof(WoodenKiteShield);
                    break;
            }

            if (shieldType != null)
            {
                _from.SendMessage(0, $"Found shield type: {shieldType.Name}");
                var craftItem = _craftSystem.CraftItems.SearchForSubclass(shieldType);
                if (craftItem != null)
                {
                    _from.SendMessage(0, $"Found craft item for: {shieldType.Name}");

                    // Check for the appropriate crafting tool in the player's backpack
                    var tool = _from.Backpack.FindItemByType<BaseTool>(true, t => t is Tongs || t is SmithHammer);
                    if (tool == null)
                    {
                        _from.SendMessage(0, "You need a blacksmithing tool (e.g., smith's hammer, tongs) in your backpack to craft this item.");
                        return;
                    }

                    _from.SendMessage($"Target the ingots you want to use for {shieldName}.");
                    _from.Target = new CraftingTarget(craftItem, _craftSystem, _tool, shieldType, this);
                }
                else
                {
                    _from.SendMessage(0, $"No craft item found for: {shieldType.Name}");
                }
            }
            else
            {
                _from.SendMessage(0, $"Invalid shield type: {shieldName}");
            }
        }

        private class RepairTarget : Target
        {
            private readonly CraftSystem _craftSystem;
            private readonly BaseTool _tool;
            private readonly BlacksmithMenu _menu;

            public RepairTarget(CraftSystem craftSystem, BaseTool tool, BlacksmithMenu menu) : base(2, false, TargetFlags.None)
            {
                _craftSystem = craftSystem;
                _tool = tool;
                _menu = menu;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Item item)
                {
                    int number;
                    bool toDelete = false;

                    if (_craftSystem.CanCraft(from, _tool, item.GetType()) == 1044267)
                    {
                        number = 1044282; // You must be near a forge and an anvil to repair items.
                    }
                    else if (item is BaseWeapon weapon)
                    {
                        number = RepairItem(from, weapon, _craftSystem.MainSkill);
                    }
                    else if (item is BaseArmor armor)
                    {
                        number = RepairItem(from, armor, _craftSystem.MainSkill);
                    }
                    else
                    {
                        number = 500426; // You can't repair that.
                    }

                    from.SendLocalizedMessage(number);

                    if (toDelete)
                    {
                        item.Delete();
                    }
                }
                else
                {
                    from.SendMessage("That is not a valid item.");
                }

                from.SendGump(new BlacksmithMenu(from, _craftSystem, _tool, _menu._category, _menu._currentPage));
            }

            private int RepairItem(Mobile from, Item item, SkillName skill)
            {
                if (item is BaseWeapon weapon)
                {
                    if (weapon.MaxHitPoints <= 0 || weapon.HitPoints == weapon.MaxHitPoints)
                    {
                        return 1044281; // That item is in full repair.
                    }

                    _craftSystem.PlayCraftEffect(from);

                    if (from.CheckSkill(skill, 0.0, 100.0))
                    {
                        weapon.HitPoints = weapon.MaxHitPoints;
                        return 1044279; // You repair the item.
                    }
                    else
                    {
                        return 1044280; // You fail to repair the item.
                    }
                }
                else if (item is BaseArmor armor)
                {
                    if (armor.MaxHitPoints <= 0 || armor.HitPoints == armor.MaxHitPoints)
                    {
                        return 1044281; // That item is in full repair.
                    }

                    _craftSystem.PlayCraftEffect(from);

                    if (from.CheckSkill(skill, 0.0, 100.0))
                    {
                        armor.HitPoints = armor.MaxHitPoints;
                        return 1044279; // You repair the item.
                    }
                    else
                    {
                        return 1044280; // You fail to repair the item.
                    }
                }

                return 500426; // You can't repair that.
            }
        }

        private class CraftingTarget : Target
        {
            private readonly CraftItem _craftItem;
            private readonly CraftSystem _craftSystem;
            private readonly BaseTool _tool;
            private readonly Type _typeRes;
            private readonly BlacksmithMenu _menu;

            public CraftingTarget(CraftItem craftItem, CraftSystem craftSystem, BaseTool tool, Type typeRes, BlacksmithMenu menu)
                : base(2, false, TargetFlags.None)
            {
                _craftItem = craftItem;
                _craftSystem = craftSystem;
                _tool = tool;
                _typeRes = typeRes;
                _menu = menu;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is BaseIngot ingot)
                {
                    var craftItem = _craftItem;
                    var craftSystem = _craftSystem;
                    var tool = _tool;
                    var typeRes = _typeRes;
                    var menu = _menu;

                    var context = craftSystem.GetContext(from);

                    if (context == null)
                    {
                        from.SendGump(new BlacksmithMenu(from, craftSystem, tool, menu._category, menu._currentPage));
                        return;
                    }

                    var resHue = ingot.Hue;
                    var maxAmount = ingot.Amount;

                    TextDefinition message = null;
                    if (!craftItem.ConsumeRes(from, typeRes, craftSystem, ref resHue, ref maxAmount, ConsumeType.All, ref message))
                    {
                        from.SendLocalizedMessage(502925); // You don't have the resources required to make that item.
                        from.SendGump(new BlacksmithMenu(from, craftSystem, tool, menu._category, menu._currentPage));
                        return;
                    }

                    var quality = 1;
                    var allRequiredSkills = true;

                    if (craftItem.CheckSkills(from, typeRes, craftSystem, ref quality, out allRequiredSkills))
                    {
                        Item item = craftItem.ItemType.CreateInstance<Item>();

                        if (item != null)
                        {
                            if (item is ICraftable craftable)
                            {
                                quality = craftable.OnCraft(quality, false, from, craftSystem, typeRes, tool, craftItem, resHue);
                            }

                            from.AddToBackpack(item);

                            from.PlaySound(0x57);
                        }
                    }
                    else
                    {
                        from.SendLocalizedMessage(1044153); // You don't have the required skills to attempt this item.
                    }

                    from.SendGump(new BlacksmithMenu(from, craftSystem, tool, menu._category, menu._currentPage));
                }
                else
                {
                    from.SendMessage("You must target ingots to craft this item.");
                    from.SendGump(new BlacksmithMenu(from, _craftSystem, _tool, _menu._category, _menu._currentPage));
                }
            }
        }
    }
}
