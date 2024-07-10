using Server.Network;
using Server.Engines.Craft;
using Server.Items;

namespace Server.Gumps
{
    public class CartographyMenu : DynamicGump
    {
        private Mobile _from;
        private CraftSystem _craftSystem;
        private BaseTool _tool;

        public CartographyMenu(Mobile from, CraftSystem craftSystem, BaseTool tool)
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

            //Repair Button
            builder.AddButton(startX, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Shields Button
            builder.AddButton(startX + 65 , startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Armor Button
            builder.AddButton(startX + 115, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Weapons Button
            builder.AddButton(startX + 180, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);

            // Main Gump Menu Background
            builder.AddImage(0, 0, 2320);

            //Items and Labels

            //Local Map
            builder.AddItem(startX, startY, 5356);
            builder.AddLabel(startX, labelY, 0, "Local Map");
            startX += 60;

            //City Map
            builder.AddItem(startX, startY, 5356);
            builder.AddLabel(startX, labelY, 0, "City Map");
            startX += 60;

            //Sea Chart
            builder.AddItem(startX, startY, 5356);
            builder.AddLabel(startX, labelY, 0, "Sea Chart");
            startX += 60;

            //World Map
            builder.AddItem(startX, startY, 5356);
            builder.AddLabel(startX, labelY, 0, "World Map");

            // Menu Labels
            builder.AddLabel(55, 15, 0, @"What would you like to make?");
            builder.AddLabel(105, 100, 0, @"Cartography");
        }

        public override void OnResponse(NetState sender, in RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 1:
                    _from.SendMessage(0, "Local Map.");
                    break;
                case 2:
                    _from.SendMessage(0, "City Map.");
                    break;
                case 3:
                    _from.SendMessage(0, "Sea Chart.");
                    break;
                case 4:
                    _from.SendMessage(0, "World Map.");
                    break;
                default:
                    _from.SendMessage(0, "No action.");
                    break;
            }
        }
    }
}
