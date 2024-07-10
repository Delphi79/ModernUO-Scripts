using Server.Network;
using Server.Engines.Craft;
using Server.Items;

namespace Server.Gumps
{
    public class InscriptionMenu : DynamicGump
    {
        private Mobile _from;
        private CraftSystem _craftSystem;
        private BaseTool _tool;

        public InscriptionMenu(Mobile from, CraftSystem craftSystem, BaseTool tool)
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

            //First Circle
            builder.AddButton(startX, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Second Circle
            builder.AddButton(startX + 65 , startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Third Circle
            builder.AddButton(startX + 115, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Fourth Circle
            builder.AddButton(startX + 180, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Fifth Circle
            builder.AddButton(startX + 245, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Sixth Circle
            builder.AddButton(startX + 310, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Seventh Circle
            builder.AddButton(startX + 375, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);
            //Eighth Circle
            builder.AddButton(startX + 440, startY, 2260, 2260, buttonID++, GumpButtonType.Reply, 0);

            // Main Gump Menu Background
            builder.AddImage(0, 0, 2320);

            //Items and Labels

            //First Circle
            builder.AddItem(startX, startY, 8384);
            builder.AddLabel(startX, labelY, 0, "First Circle");
            startX += 60;

            //Second Circle
            builder.AddItem(startX, startY, 8385);
            builder.AddLabel(startX, labelY, 0, "Second Circle");
            startX += 60;

            //Third Circle
            builder.AddItem(startX, startY, 8386);
            builder.AddLabel(startX, labelY, 0, "Third Circle");
            startX += 60;

            //Fourth Circle
            builder.AddItem(startX, startY, 8387);
            builder.AddLabel(startX, labelY, 0, "Fourth Circle");
            startX += 60;

            //Fifth Circle
            builder.AddItem(startX, startY, 8388);
            builder.AddLabel(startX, labelY, 0, "Fifth Circle");
            startX += 60;

            //Sixth Circle
            builder.AddItem(startX, startY, 8389);
            builder.AddLabel(startX, labelY, 0, "Sixth Circle");
            startX += 60;

            //Seventh Circle
            builder.AddItem(startX, startY, 8390);
            builder.AddLabel(startX, labelY, 0, "Seventh Circle");
            startX += 60;

            //Eighth Circle
            builder.AddItem(startX, startY, 8391);
            builder.AddLabel(startX, labelY, 0, "Eighth Circle");

            // Menu Labels
            builder.AddLabel(55, 15, 0, @"What would you like to make?");
            builder.AddLabel(105, 100, 0, @"Inscription");
        }

        public override void OnResponse(NetState sender, in RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 1:
                    _from.SendMessage(0, "Repair Selected.");
                    break;
                case 2:
                    _from.SendMessage(0, "Shields Selected.");
                    break;
                case 3:
                    _from.SendMessage(0, "Armor Selected.");
                    break;
                case 4:
                    _from.SendMessage(0, "Weapons Selected.");
                    break;
                default:
                    _from.SendMessage(0, "No action.");
                    break;
            }
        }
    }
}
