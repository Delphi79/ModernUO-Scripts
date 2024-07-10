using Server.Network;
using Server.Engines.Craft;
using Server.Items;

namespace Server.Gumps
{
    public class TailoringMenu : DynamicGump
    {
        private Mobile _from;
        private CraftSystem _craftSystem;
        private BaseTool _tool;

        public TailoringMenu(Mobile from, CraftSystem craftSystem, BaseTool tool)
            : base(150, 200)
        {
            _from = from;
            _craftSystem = craftSystem;
            _tool = tool;
        }

        protected override void BuildLayout(ref DynamicGumpBuilder builder)
        {
            builder.AddPage(0);

            builder.SetNoResize();
            builder.SetNoDispose();

            // Adding buttons hidden behind the items as "invisible" buttons
            int startX = 40;  // X position of the first button/item
            int startY = 45;  // Y position of the buttons/items
            int labelY = 65;  // Y position of labels
            int buttonID = 1; // Starting ButtonID

            //Shits
            builder.AddButton(startX, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Pants
            builder.AddButton(startX + 65 , startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Miscellaneous
            builder.AddButton(startX + 115, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Bolt of Cloth
            builder.AddButton(startX + 180, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);

            // Main Gump Menu Background
            builder.AddImage(0, 0, 2320);

            //Items and Labels

            //Shirts
            builder.AddItem(startX, startY, 5399);
            builder.AddLabel(startX, labelY, 0, "Shirts");
            startX += 60;

            //Pants
            builder.AddItem(startX, startY, 5433);
            builder.AddLabel(startX, labelY, 0, "Pants");
            startX += 60;

            //Miscellaneous
            builder.AddItem(startX, startY, 5437);
            builder.AddLabel(startX, labelY, 0, "Miscellaneous");
            startX += 60;

            //Bolt of Cloth
            builder.AddItem(startX, startY, 3990);
            builder.AddLabel(startX, labelY, 0, "Bolt of Cloth");

            // Menu Labels
            builder.AddLabel(55, 15, 0, @"What would you like to make?");
            builder.AddLabel(105, 100, 0, @"Tailoring");
        }

        public override void OnResponse(NetState sender, in RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 1:
                    _from.SendMessage(0, "Shirts.");
                    break;
                case 2:
                    _from.SendMessage(0, "Pants.");
                    break;
                case 3:
                    _from.SendMessage(0, "Miscellaneous.");
                    break;
                case 4:
                    _from.SendMessage(0, "Bolt of Cloth.");
                    break;
                default:
                    _from.SendMessage(0, "No action.");
                    break;
            }
        }
    }
}
