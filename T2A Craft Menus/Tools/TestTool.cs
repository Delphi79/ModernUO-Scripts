using Server.Gumps;
using Server.Network;
using Server.Engines.Craft;
using ModernUO.Serialization;

namespace Server.Items
{
    [SerializationGenerator(0, false)]
    public partial class CraftingKit : BaseTool
    {
        [Constructible]
        public CraftingKit() : base(3997)  // Using the item ID for a sewing kit as a placeholder
        {
            Weight = 2.0;
        }

        [Constructible]
        public CraftingKit(int uses) : base(uses, 3997)  // Using the item ID for a sewing kit as a placeholder
        {
            Weight = 2.0;
        }

        public override CraftSystem CraftSystem => DefTailoring.CraftSystem;  // This might not be relevant if it's just a hub tool

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                from.SendGump(new CraftingHubGump(from));
            }
            else
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
        }
    }

    public class CraftingHubGump : Gump
    {
        public CraftingHubGump(Mobile from) : base(50, 50)
        {
            AddPage(0);
            AddBackground(0, 0, 300, 350, 5054);
            AddLabel(75, 20, 0, "Select Crafting Menu");

            string[] labels = { "Blacksmithing", "Carpentry", "Cartography", "Fletching", "Inscription", "Tailoring", "Tinkering" };
            int yPos = 50;

            for (int i = 0; i < labels.Length; i++)
            {
                AddButton(50, yPos, 4005, 4007, i + 1, GumpButtonType.Reply, 0);
                AddLabel(85, yPos, 0, labels[i]);
                yPos += 30;
            }
        }

        public override void OnResponse(NetState sender, in RelayInfo info)
        {
            Mobile from = sender.Mobile;
            if (info.ButtonID == 0)
                return; // No action on close/cancel

            // Assuming each button opens a different crafting menu - these instances need to be adjusted according to actual implementation
            BaseTool tool = new CraftingKit(); // Placeholder for demonstration. Each menu might require a specific tool.

            switch (info.ButtonID)
            {
                case 1:
                    from.SendGump(new BlacksmithMenu(from, DefBlacksmithy.CraftSystem, tool));
                    break;
                case 2:
                    from.SendGump(new CarpentryMenu(from, DefCarpentry.CraftSystem, tool));
                    break;
                case 3:
                    from.SendGump(new CartographyMenu(from, DefCartography.CraftSystem, tool));
                    break;
                case 4:
                    from.SendGump(new FletchingMenu(from, DefBowFletching.CraftSystem, tool));
                    break;
                case 5:
                    from.SendGump(new InscriptionMenu(from, DefInscription.CraftSystem, tool));
                    break;
                case 6:
                    from.SendGump(new TailoringMenu(from, DefTailoring.CraftSystem, tool));
                    break;
                case 7:
                    from.SendGump(new TinkeringMenu(from, DefTinkering.CraftSystem, tool));
                    break;
            }
        }
    }
}
