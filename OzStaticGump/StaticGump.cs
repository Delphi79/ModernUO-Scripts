/*Thanks goes to Vorspire who helped with keeping the pages on the same page.  Thanks goes to Espcevan as he was the one who originally made AddWall and AddStair.  Though the script has changed a bit
if it wasn't for his original AdcWall and AddStair command this would never have been possible.

And Finally, Thanks goes to Pyro for helping make the main Static gump far more functional.  If it wasn't for any of these people, this tool wouldn't have been made to be the way it is today.

Pyro ensured that the text entries were possible as well as making it easier to add commands as buttons.

This tool was made by TheArt/Oz'Thoth

Please give us all credit if you intend to update this tool to work with a future version of ServUO or any other Ultima Online Shard/Server Emulator.*/
using System;
using Server.Network;

namespace Server.Gumps
{
    public class OzStaticToolGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("StaticsTool", AccessLevel.GameMaster, new CommandEventHandler(OzThothsStatic_OnCommand));
            CommandSystem.Register("STool", AccessLevel.GameMaster, new CommandEventHandler(OzThothsStatic_OnCommand));
            CommandSystem.Register("ST", AccessLevel.GameMaster, new CommandEventHandler(OzThothsStatic_OnCommand));
        }

        [Usage("StaticTool")]
        [Description("Makes a call to an in game static tool")]
        private static void OzThothsStatic_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            from.CloseGump<OzStaticToolGump>();
            from.SendGump(new OzStaticToolGump());
        }

        private static readonly int separatorLineHue = 1461;
        private static readonly string fontStyle = $"<basefont size=5 color=#140B00>";
        private static readonly string signlabel = "<center>Oz'Thoth's Static Tool v.4";

        private static readonly CommandPair[] commonCommands = new CommandPair[]
        {
            new CommandPair("Item ID", "Get ItemID"), new CommandPair("Props", "Props"),
            new CommandPair("Wipe", "Wipe"), new CommandPair("Delete", "Delete")
        };

        private static readonly CommandPair[] staticItemCommands = new CommandPair[]
        {
            new CommandPair("Arches", "AddArch"), new CommandPair("Doors", "AddDoor"), new CommandPair("Fences", "AddFence"), 
            new CommandPair("Floors", "AddFloor"),new CommandPair("Food", "AddCookingStatic"),new CommandPair("Furniture", "AddFurniture"), 
            new CommandPair("Gear", "AddGearStatic"), new CommandPair("Ground", "AddGroundSt"), new CommandPair("Light", "AddLightsStatic"), 
            new CommandPair("Plants", "AddPlants"), new CommandPair("Rocks", "AddRock"), new CommandPair("Roofs", "AddRoof"), 
            new CommandPair("Sign Post", "AddSignPStatic"), new CommandPair("Signs", "AddSign"), new CommandPair("Stairs", "AddStair"), 
            new CommandPair("Walls", "AddWall"), new CommandPair("Misc 1", "AddMiscStatic1"), new CommandPair("Misc 2", "AddMiscStatic2"), 
            new CommandPair("Custom", "AddCustomsStatic"), new CommandPair("Anim", "AddAnimationStatic")/*, 
            new CommandPair("Custom Command", "AddCustomCommand"),new CommandPair("Custom Command", "AddCustomCommand")*/ //You can add 2 custom commands here or change the commands around a bit.
        };

        private int HeightSingle;
        private int HeightArea;
        private int DirectionSingle;
        private int DirectionArea;

        public OzStaticToolGump(int heightSingle = 1, int heightArea = 1, int directionSingle = 1, int directionArea = 1) : base(0, 0)
        {
            Closable = false;
            Disposable = false;
            Draggable = true;
            Resizable = false;

            HeightSingle = heightSingle;
            HeightArea = heightArea;
            DirectionSingle = directionSingle;
            DirectionArea = directionArea;

            AddPage(0);
            AddImageTiled(49, 46, 570, 376, 2524, 170, 112, 796);   // hue title bar
            AddBackground(282, 65, 198, 355, 9350);                 // center background
            AddBackground(469, 161, 150, 260, 9300);                // right background
            AddBackground(48, 65, 243, 357, 3500);                  // left background

            #region sign with signature
            AddImage(469, 66, 100, 1938); // used to widen the area
            AddImage(474, 66, 100, 1938); // sign
            AddHtml(492, 87, 99, 59, $"<basefont size=5 color=#332b00>{signlabel}", false, false); // part 1 of the font effect
            AddHtml(493, 88, 99, 59, $"<basefont size=5 color=#b29600>{signlabel}", false, false); // part 2 of the font effect
            AddHtml(494, 89, 99, 59, $"<basefont size=5 color=#e5c100>{signlabel}", false, false); // part 3 of the font effect
            #endregion sign with signature

            # region minimize and close
            AddButton(578, 47, 2710, 2711, 1, GumpButtonType.Reply, 0); // minimize
            AddButton(598, 47, 2708, 2709, 0, GumpButtonType.Reply, 0); // close
            #endregion

            #region help area
            AddHtml(471, 173, 145, 26, $"{fontStyle}<center>Helpful Tips", false, false);
            AddImageTiled(474, 196, 140, 16, 58, 16, 16, separatorLineHue);
            AddHtml(471, 212, 145, 192, $"{fontStyle}" +
            "[Add Static ItemID<br/>" +
            "[Tile Static ItemID<br/>" +
            "[TileZ # Static ItemID for Height</br>"+
            "To Randomize statics add number after ItemID<br/>" +
            "To do multiple Deletes:<br/>" +
            "[M Delete"
            , false, false);
            #endregion help area

            #region height
            AddHtml(345, 82, 62, 26, $"{fontStyle}Height", false, false);   // Label for Height
            AddImageTiled(311, 99, 131, 16, 58, 16, 16, separatorLineHue);  // Line under Height
            AddHtml(306, 109, 57, 26, $"{fontStyle}<center>Single", false, false);  // Label Single
            AddButton(326, 137, 5600, 5604, 2, GumpButtonType.Reply, 0);    // Up
            AddImageTiled(318, 154, 32, 20, 9304);                          // backround text area height, single
            AddButton(326, 177, 5602, 5606, 3, GumpButtonType.Reply, 0);    // Down
            AddTextEntry(315, 153, 36, 20, directionArea == 0 ? 1461 : 0, 0, $"{heightSingle}");    // Number of steps for height single

            AddHtml(396, 110, 44, 26, $"{fontStyle}<center>Area", false, false);    // Label Area
            AddButton(411, 138, 5600, 5604, 4, GumpButtonType.Reply, 0);    // Up
            AddImageTiled(402, 154, 32, 20, 9304);                          // backround text area height, area
            AddButton(411, 178, 5602, 5606, 5, GumpButtonType.Reply, 0);    // Down
            AddTextEntry(400, 154, 36, 20, directionArea == 0 ? 1461 : 0, 1, $"{heightArea}");// Number of steps for height single
            #endregion height

            #region direction
            AddImageTiled(311, 199, 131, 16, 58, 16, 16, separatorLineHue);
            AddHtml(289, 212, 174, 26, $"{fontStyle}<center>Direction", false, false);  // Moving direction
            AddImageTiled(311, 229, 131, 16, 58, 16, 16, separatorLineHue);
            AddHtml(306, 239, 57, 26, $"{fontStyle}<center>Single", false, false);      // Label Single
            AddButton(326, 270, 5600, 5604, 9, GumpButtonType.Reply, 0);                // North
            AddButton(295, 294, 5603, 5607, 7, GumpButtonType.Reply, 0);                // West
            AddImageTiled(318, 292, 32, 20, 9304);                                      // backround text area direction, single
            AddButton(354, 294, 5601, 5605, 8, GumpButtonType.Reply, 0);                // East
            AddButton(326, 319, 5602, 5606, 6, GumpButtonType.Reply, 0);                // South
            AddTextEntry(316, 292, 36, 20, directionArea == 0 ? 1461 : 0, 2, $"{directionSingle}"); // Number of steps for direction single

            AddHtml(396, 239, 44, 26, $"{fontStyle}<center>Area", false, false);        // Label Area
            AddButton(411, 270, 5600, 5604, 13, GumpButtonType.Reply, 0);               // North
            AddButton(382, 294, 5603, 5607, 11, GumpButtonType.Reply, 0);               // West
            AddImageTiled(402, 292, 32, 20, 9304);                                      // backround text area direction, area
            AddButton(437, 294, 5601, 5605, 12, GumpButtonType.Reply, 0);               // East
            AddButton(411, 319, 5602, 5606, 10, GumpButtonType.Reply, 0);               // South
            AddTextEntry(400, 292, 36, 20, directionArea == 0 ? 1461 : 0, 3, $"{directionArea}", 5); // Number of steps for direction area
            #endregion direction

            int start = 14;

            #region Common / Builder Commands
            for (int i = 0; i < commonCommands.Length; i++)
            {
                int columnspacing = i % 2 == 1 ? 90 : 0;
                int rowspacing = i / 2 == 1 ? 30 : 0;

                AddButton(300 + columnspacing, 353 + rowspacing, 22153 + (i / 2 == 1 ? -2 : 0), 22155 + (i / 2 == 1 ? -3 : 0), start + i, GumpButtonType.Reply, 0);
                AddHtml(318 + columnspacing, 351 + rowspacing, 62, 26, $"{fontStyle}{commonCommands[i].Name}", false, false);
            }
            #endregion

            start += commonCommands.Length;

            #region Adding Items Commands
            int x = 65;
            int startY = 84;
            int y = startY;

            for (int i = 0; i < staticItemCommands.Length; i++)
            {
                if (i > 0 && i % 11 == 0)
                {
                    x += 110;
                    y = startY;
                }
                AddButton(x, y, 5601, 5605, start + i, GumpButtonType.Reply, 0);
                AddHtml(x + 21, y - 2, 84, 26, $"{fontStyle}{staticItemCommands[i].Name}", false, false);
                y += 30;
            }
            #endregion Adding Items Commands
        }

        public void AddImageTiled(int x, int y, int width, int height, int gumpID, int gumpWidth, int gumpHeight, int hue)
        {
            for (int xi = 0; xi < width; xi += gumpWidth)
            {
                for (int yi = 0; yi < height; yi += gumpHeight)
                {
                    AddImage(Math.Min(x + xi, x + width - gumpWidth), Math.Min(y + yi, y + height - gumpHeight), gumpID, hue);
                }
            }
        }

        public override void OnResponse(NetState sender, in RelayInfo info)
        {
            Mobile from = sender.Mobile;
            int id = info.ButtonID;

            if (id == 0 || from.AccessLevel < AccessLevel.GameMaster)
            {
                from.CloseGump<OzStaticToolGump>();
                return;
            }

            if (!int.TryParse(info.GetTextEntry(0), out HeightSingle))
            {
                HeightSingle = 1;
            }
            if (!int.TryParse(info.GetTextEntry(1), out HeightArea))
            {
                HeightArea = 1;
            }
            if (!int.TryParse(info.GetTextEntry(2), out DirectionSingle))
            {
                DirectionSingle = 1;
            }
            if (!int.TryParse(info.GetTextEntry(3), out DirectionArea))
            {
                DirectionArea = 1;
            }

            switch (info.ButtonID)
            {
                //Send for Minimized Gump version
                case 1:
                {
                    from.SendGump(new MinimizedOzGump());
                    return;
                }
                //height adjustment
                case 2:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Inc z {HeightSingle}");
                    break;
                }
                case 3:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Inc z -{HeightSingle}");
                    break;
                }
                case 4:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Area Inc z {HeightArea}");
                    break;
                }
                case 5:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Area Inc z -{HeightArea}");
                    break;
                }
                //direction adjustment
                case 6:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Inc y {DirectionSingle}");
                    break;
                }
                case 7:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Inc x -{DirectionSingle}");
                    break;
                }
                case 8:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Inc x {DirectionSingle}");
                    break;
                }
                case 9:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Inc y -{DirectionSingle}");
                    break;
                }
                case 10:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Area Inc y {DirectionArea}");
                    break;
                }
                case 11:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Area Inc x -{DirectionArea}");
                    break;
                }
                case 12:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Area Inc x {DirectionArea}");
                    break;
                }
                case 13:
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}Area Inc y -{DirectionArea}");
                    break;
                }
            }
            int start = 14;

            //Commands
            if (id >= start && id < start + commonCommands.Length)
            {
                CommandSystem.Handle(from, $"{CommandSystem.Prefix}{commonCommands[id-start].Command}");
            }
            else
            {
                start += commonCommands.Length;
                if(id >= start && id < start + staticItemCommands.Length)
                {
                    CommandSystem.Handle(from, $"{CommandSystem.Prefix}{staticItemCommands[id - start].Command}");
                }
            }
            from.SendGump(new OzStaticToolGump(HeightSingle, HeightArea, DirectionSingle, DirectionArea));
        }
    }

    public class MinimizedOzGump : Gump
    {
        public Mobile m_From;

        public MinimizedOzGump() : base(0, 0)
        {
            Closable = false;
            Disposable = false;
            Draggable = true;
            Resizable = false;

            AddPage(0);
            AddBackground(16, 11, 110, 26, 9350);
            AddButton(106, 17, 2118, 2117, 1, GumpButtonType.Reply, 0);
            AddHtml(19, 16, 83, 16, "<basefont size=5 color=#140B00>Static Tool", false, false);
        }

        public override void OnResponse(NetState sender, in RelayInfo info)
        {
            Mobile from = sender.Mobile;

            switch (info.ButtonID)
            {
                case 1:
                {
                    from.SendGump(new OzStaticToolGump());
                    from.CloseGump<MinimizedOzGump>();
                    break;
                }
            }
        }
    }
    public class CommandPair
    {
        public string Name { get; set; }
        public string Command { get; set; }

        public CommandPair(string name, string command)
        {
            Name = name;
            Command = command;
        }
    }
}
