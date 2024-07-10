using Server.Network;
using Server.Engines.Craft;
using Server.Items;

namespace Server.Gumps
{
    public class FletchingMenu : DynamicGump
    {
        private Mobile _from;
        private CraftSystem _craftSystem;
        private BaseTool _tool;

        public FletchingMenu(Mobile from, CraftSystem craftSystem, BaseTool tool)
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

            //Kindling Button
            builder.AddButton(startX, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Arrow Shafts Button
            builder.AddButton(startX + 65 , startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Bows Button
            builder.AddButton(startX + 115, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Crossbows Button
            builder.AddButton(startX + 180, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Heavy Crossbows Button
            builder.AddButton(startX + 180, startY, 2260, 2260, buttonID, GumpButtonType.Reply, 0);


            // Main Gump Menu Background
            builder.AddImage(0, 0, 2320);

            //Items and Labels

            //Kindling => Kindling
            builder.AddItem(startX, startY, 3553);
            builder.AddLabel(startX, labelY, 0, "Kindling");
            startX += 60;

            //Shafts => Arrow Shafts
            builder.AddItem(startX, startY, 7124);
            builder.AddLabel(startX, labelY, 0, "Arrow Shaft");
            startX += 60;

            //Bow => Bows
            builder.AddItem(startX, startY, 5042);
            builder.AddLabel(startX, labelY, 0, "Bows");
            startX += 60;

            //Crossbow => Crossbows
            builder.AddItem(startX, startY, 3920);
            builder.AddLabel(startX, labelY, 0, "Crossbows");
            startX += 60;

            //Heavy CB => Heavy CB
            builder.AddItem(startX, startY, 5117);
            builder.AddLabel(startX, labelY, 0, "Heavy Crossbow");

            // Menu Labels
            builder.AddLabel(55, 15, 0, @"What would you like to make?");
            builder.AddLabel(105, 100, 0, @"Fletching");
        }

        public override void OnResponse(NetState sender, in RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 1:
                    _from.SendMessage(0, "Kindling.");
                    break;
                case 2:
                    _from.SendMessage(0, "Arrow Shafts.");
                    break;
                case 3:
                    _from.SendMessage(0, "Bows.");
                    break;
                case 4:
                    _from.SendMessage(0, "Crossbow.");
                    break;
                case 5:
                    _from.SendMessage(0, "Heavy Crossbow.");
                    break;
                default:
                    _from.SendMessage(0, "No action.");
                    break;
            }
        }
    }
}
