using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt1Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt1", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt1_OnCommand));
		}

		[Usage("AddMiscPt1")]
		
		public static void AddMiscPt1_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt1Gump>();
			e.Mobile.SendGump(new AddMiscPt1Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(2), new ItemInfo(3), new ItemInfo(4), new ItemInfo(5), new ItemInfo(525), new ItemInfo(526), new ItemInfo(540), new ItemInfo(570), new ItemInfo(571), 
            new ItemInfo(572), new ItemInfo(573), new ItemInfo(574), new ItemInfo(575), new ItemInfo(576), new ItemInfo(587), new ItemInfo(604), new ItemInfo(605), new ItemInfo(606), 
            new ItemInfo(607), new ItemInfo(608), new ItemInfo(609), new ItemInfo(610), new ItemInfo(611), new ItemInfo(612), new ItemInfo(613), new ItemInfo(614), new ItemInfo(615), 
            new ItemInfo(616), new ItemInfo(617), new ItemInfo(618), new ItemInfo(619), new ItemInfo(620), new ItemInfo(621), new ItemInfo(622), new ItemInfo(623), new ItemInfo(624), 
            new ItemInfo(625), new ItemInfo(626), new ItemInfo(627), new ItemInfo(628), new ItemInfo(629), new ItemInfo(630), new ItemInfo(637), new ItemInfo(638), new ItemInfo(639), 
            new ItemInfo(640), new ItemInfo(730), new ItemInfo(749), new ItemInfo(750), new ItemInfo(751), new ItemInfo(752), new ItemInfo(753), new ItemInfo(754), new ItemInfo(755), 
            new ItemInfo(756), new ItemInfo(882), new ItemInfo(883), new ItemInfo(884), new ItemInfo(885), new ItemInfo(886), new ItemInfo(887), new ItemInfo(888), new ItemInfo(889), 
            new ItemInfo(890), new ItemInfo(891), new ItemInfo(892), new ItemInfo(893), new ItemInfo(930), new ItemInfo(931), new ItemInfo(932), new ItemInfo(933), new ItemInfo(934), 
            new ItemInfo(935), new ItemInfo(936), new ItemInfo(937), new ItemInfo(938), new ItemInfo(939), new ItemInfo(940), new ItemInfo(941), new ItemInfo(942), new ItemInfo(943), 
            new ItemInfo(944), new ItemInfo(945), new ItemInfo(946), new ItemInfo(995), new ItemInfo(996), new ItemInfo(997), new ItemInfo(998), new ItemInfo(999), new ItemInfo(1027), 
            new ItemInfo(1028), new ItemInfo(1029), new ItemInfo(1030), new ItemInfo(1031), new ItemInfo(1032), new ItemInfo(1033), new ItemInfo(1034), new ItemInfo(1035), new ItemInfo(1036), 
            new ItemInfo(1037), new ItemInfo(1038), new ItemInfo(1039), new ItemInfo(1040), new ItemInfo(1041), new ItemInfo(1042), new ItemInfo(1043), new ItemInfo(1044), new ItemInfo(1045), 
            new ItemInfo(1046), new ItemInfo(1047), new ItemInfo(1048), new ItemInfo(1049), new ItemInfo(1050), new ItemInfo(1051), new ItemInfo(1052), new ItemInfo(1053), new ItemInfo(1054), 
            new ItemInfo(1055), new ItemInfo(1056), new ItemInfo(1057), new ItemInfo(1058), new ItemInfo(1059), new ItemInfo(1060), new ItemInfo(1061), new ItemInfo(1062), new ItemInfo(1063), 
            new ItemInfo(1064), new ItemInfo(1065), new ItemInfo(1066), new ItemInfo(1067), new ItemInfo(1068), new ItemInfo(1069), new ItemInfo(1070), new ItemInfo(1071), new ItemInfo(1072), 
            new ItemInfo(1073), new ItemInfo(1074), new ItemInfo(1075), new ItemInfo(1076), new ItemInfo(1077), new ItemInfo(1113), new ItemInfo(1114), new ItemInfo(1115), new ItemInfo(1116), 
            new ItemInfo(1117), new ItemInfo(1118), new ItemInfo(1119), new ItemInfo(1120), new ItemInfo(1121), new ItemInfo(1122), new ItemInfo(1123), new ItemInfo(1124), new ItemInfo(1125), 
            new ItemInfo(1126), new ItemInfo(1127), new ItemInfo(1130), new ItemInfo(1131), new ItemInfo(1132), new ItemInfo(1133), new ItemInfo(1134), new ItemInfo(1135), new ItemInfo(1136), 
            new ItemInfo(1137), new ItemInfo(1138), new ItemInfo(1139), new ItemInfo(1140), new ItemInfo(1141), new ItemInfo(1142), new ItemInfo(1143), new ItemInfo(1144), new ItemInfo(1145), 
            new ItemInfo(1146), new ItemInfo(1147), new ItemInfo(1148), new ItemInfo(1149), new ItemInfo(1150), new ItemInfo(1151), new ItemInfo(1152), new ItemInfo(1153), new ItemInfo(1154), 
            new ItemInfo(1155), new ItemInfo(1156), new ItemInfo(1157), new ItemInfo(1158), new ItemInfo(1159), new ItemInfo(1160), new ItemInfo(1161), new ItemInfo(1162), new ItemInfo(1163), 
            new ItemInfo(1164), new ItemInfo(1165), new ItemInfo(1166), new ItemInfo(1167), new ItemInfo(1326), new ItemInfo(1360), new ItemInfo(1361), new ItemInfo(1362), new ItemInfo(1363), 
            new ItemInfo(1493), new ItemInfo(1517), new ItemInfo(1518), new ItemInfo(1618), new ItemInfo(1619), new ItemInfo(1620), new ItemInfo(1621), new ItemInfo(1622), new ItemInfo(1623), 
            new ItemInfo(1624), new ItemInfo(1625), new ItemInfo(1626), new ItemInfo(1627), new ItemInfo(1628), new ItemInfo(1629), new ItemInfo(1653), new ItemInfo(1654), new ItemInfo(1655), 
            new ItemInfo(1656), new ItemInfo(1657), new ItemInfo(1658), new ItemInfo(1659), new ItemInfo(1660), new ItemInfo(1661), new ItemInfo(1662), new ItemInfo(1663), new ItemInfo(1664)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt1Gump()
			: this(0)
		{ }

		public AddMiscPt1Gump(int page) 
			: base(0, 0)
		{
			int pageCount = 1 + (m_Types.Length / 12);

			if (page >= pageCount)
				page = pageCount - 1;
			else if (page < 0)
				page = 0;

			m_Page = page;

			Closable = true;
			Disposable = true;
			Draggable = true;
			Resizable = false;

			AddPage(0);

			AddBackground(0, 0, 720, 180, 3500);

			AddHtmlLocalized(15, 15, 60, 20, 1042971, page.ToString(), 0x1, false, false); // #

			AddHtmlLocalized(20, 38, 60, 20, 1043353, 0x1, false, false); // Next

			if (page + 1 < pageCount)
				AddButton(15, 55, 0xFA5, 0xFA7, 10000 + (page + 1), GumpButtonType.Reply, 0);
			else
				AddButton(15, 55, 0xFA5, 0xFA7, 10000, GumpButtonType.Reply, 0);

			AddHtmlLocalized(20, 93, 60, 20, 1011393, 0x1, false, false); // Back

			if (page > 0)
				AddButton(15, 110, 0xFAE, 0xFB0, 10000 + (page - 1), GumpButtonType.Reply, 0);
			else
				AddButton(15, 110, 0xFAE, 0xFB0, 10000, GumpButtonType.Reply, 0);

			for (int i = 0; i < 12; ++i)
			{
				int index = (page * 12) + i;
				if(index >= m_Types.Length) break;

				int button = 1000000 + index;
				int offset = (i + 1) * 50;

				if (m_Types[index].m_BaseID > 0)
				{
					AddButton(45 + offset, 20, 0x2624, 0x2625, button, GumpButtonType.Reply, m_Types[index].m_BaseID);
					AddItem(50 + offset, 40, m_Types[index].m_BaseID);
				}
				else
				{
					AddImage(25 + offset, 20, 0x2625, 900);
				}
			}
		}

		public override void OnResponse(NetState sender, in RelayInfo info)
		{
			Mobile from = sender.Mobile;

			int button = info.ButtonID;

			if (button <= 0)
				return;

			int page = m_Page;

			if (button >= 1000000)
			{
				button -= 1000000;

				CommandSystem.Handle(from, string.Format("{0}M Add Static {1}", CommandSystem.Prefix, m_Types[button].m_BaseID));
			}
			else if (button >= 10000)
			{
				button -= 10000;

				page = button;
			}

			from.SendGump(new AddMiscPt1Gump(page));
		}

		public class ItemInfo
		{
			public int m_BaseID;

			public ItemInfo(int baseID)
			{
				m_BaseID = baseID;
			}
		}
	}
}
