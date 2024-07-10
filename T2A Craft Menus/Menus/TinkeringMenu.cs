using Server.Network;
using Server.Engines.Craft;
using Server.Items;

namespace Server.Gumps
{
    public class TinkeringMenu : DynamicGump
    {
        private Mobile _from;
        private CraftSystem _craftSystem;
        private BaseTool _tool;

        public TinkeringMenu(Mobile from, CraftSystem craftSystem, BaseTool tool)
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

            //Anvil => Repair
            builder.AddItem(startX, startY, 4015);
            builder.AddLabel(startX, labelY, 0, "Repair");
            startX += 60;

            //Bronze Shield => Shields
            builder.AddItem(startX, startY, 7026);
            builder.AddLabel(startX, labelY, 0, "Shields");
            startX += 60;

            //Plate Chest => Armor
            builder.AddItem(startX, startY, 5141);
            builder.AddLabel(startX, labelY, 0, "Armor");
            startX += 60;

            //Viking Sword => Weapons
            builder.AddItem(startX, startY, 5049);
            builder.AddLabel(startX, labelY, 0, "Weapons");

            // Menu Labels
            builder.AddLabel(55, 15, 0, @"What would you like to make?");
            builder.AddLabel(105, 100, 0, @"Tinkering");
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
