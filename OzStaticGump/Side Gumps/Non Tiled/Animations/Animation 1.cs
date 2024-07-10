using Server.Network;

namespace Server.Gumps
{
	public class AddAnimStPt1Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddAnimStPt1", AccessLevel.GameMaster, new CommandEventHandler(AddAnimStPt1_OnCommand));
		}

		[Usage("AddAnimStPt1")]
		public static void AddAnimStPt1_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddAnimStPt1Gump>();
			e.Mobile.SendGump(new AddAnimStPt1Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(0x6D), new ItemInfo(0x6E), new ItemInfo(0x6F), new ItemInfo(0xB1), new ItemInfo(0xB2), new ItemInfo(0xB3), new ItemInfo(0xB4), new ItemInfo(0x3AE), new ItemInfo(0x3AF), 
            new ItemInfo(0x3B0), new ItemInfo(0x3C3), new ItemInfo(0x462), new ItemInfo(0x46C), new ItemInfo(0x475), new ItemInfo(0x47B), new ItemInfo(0x47C), new ItemInfo(0x482), new ItemInfo(0x489), 
            new ItemInfo(0x48B), new ItemInfo(0x48D), new ItemInfo(0x48F), new ItemInfo(0x491), new ItemInfo(0x493), new ItemInfo(0x90D), new ItemInfo(0x91B), new ItemInfo(0x91C), new ItemInfo(0x91D), 
            new ItemInfo(0x91F), new ItemInfo(0x920), new ItemInfo(0x921), new ItemInfo(0x922), new ItemInfo(0x923), new ItemInfo(0x92C), new ItemInfo(0x931), new ItemInfo(0x937), new ItemInfo(0x93D), 
            new ItemInfo(0x945), new ItemInfo(0x94B), new ItemInfo(0x953), new ItemInfo(0x959), new ItemInfo(0x961), new ItemInfo(0x967), new ItemInfo(0x970), new ItemInfo(0x9D7), new ItemInfo(0x9D8), 
            new ItemInfo(0x9FD), new ItemInfo(0x9FE), new ItemInfo(0x9FF), new ItemInfo(0xA02), new ItemInfo(0xA03), new ItemInfo(0xA04), new ItemInfo(0xA07), new ItemInfo(0xA08), new ItemInfo(0xA09), 
            new ItemInfo(0xA0C), new ItemInfo(0xA0D), new ItemInfo(0xA0E), new ItemInfo(0xA0F), new ItemInfo(0xA10), new ItemInfo(0xA11), new ItemInfo(0xA12), new ItemInfo(0xA13), new ItemInfo(0xA14), 
            new ItemInfo(0xA15), new ItemInfo(0xA16), new ItemInfo(0xA17), new ItemInfo(0xA1A), new ItemInfo(0xA1B), new ItemInfo(0xA1C), new ItemInfo(0xB1A), new ItemInfo(0xB1B), new ItemInfo(0xB1C), 
            new ItemInfo(0xB1D), new ItemInfo(0xB1F), new ItemInfo(0xB26), new ItemInfo(0xB27), new ItemInfo(0xB28), new ItemInfo(0xB2A), new ItemInfo(0xDDA), new ItemInfo(0xDDB), new ItemInfo(0xDDC), 
            new ItemInfo(0xDDD), new ItemInfo(0xDDE), new ItemInfo(0xDE3), new ItemInfo(0xE2E), new ItemInfo(0xE31), new ItemInfo(0xE5C), new ItemInfo(0xE5F), new ItemInfo(0xE62), new ItemInfo(0xE65), 
            new ItemInfo(0xE68), new ItemInfo(0xF6C), new ItemInfo(0x1016), new ItemInfo(0x101A), new ItemInfo(0x101D), new ItemInfo(0x1071), new ItemInfo(0x1072), new ItemInfo(0x1074), new ItemInfo(0x1075), 
            new ItemInfo(0x1076), new ItemInfo(0x1077), new ItemInfo(0x10A5), new ItemInfo(0x10DA), new ItemInfo(0x10DB), new ItemInfo(0x10DC), new ItemInfo(0x10F6), new ItemInfo(0x10F7), new ItemInfo(0x10FC), 
            new ItemInfo(0x10FE), new ItemInfo(0x1104), new ItemInfo(0x1107), new ItemInfo(0x1109), new ItemInfo(0x110D), new ItemInfo(0x110F), new ItemInfo(0x1111), new ItemInfo(0x1117), new ItemInfo(0x111A), 
            new ItemInfo(0x111C), new ItemInfo(0x1120), new ItemInfo(0x1126), new ItemInfo(0x112C), new ItemInfo(0x1130), new ItemInfo(0x1133), new ItemInfo(0x113A), new ItemInfo(0x113B), new ItemInfo(0x1140), 
            new ItemInfo(0x1143), new ItemInfo(0x1145), new ItemInfo(0x114C), new ItemInfo(0x1153), new ItemInfo(0x1158), new ItemInfo(0x1193), new ItemInfo(0x1194), new ItemInfo(0x119A), new ItemInfo(0x119B), 
            new ItemInfo(0x119E), new ItemInfo(0x11A1), new ItemInfo(0x11A4), new ItemInfo(0x11A6), new ItemInfo(0x11AD), new ItemInfo(0x11B0), new ItemInfo(0x11B2), new ItemInfo(0x11B5), new ItemInfo(0x11B6), 
            new ItemInfo(0x11C1), new ItemInfo(0x1245), new ItemInfo(0x1249), new ItemInfo(0x12DA), new ItemInfo(0x12DE), new ItemInfo(0x12E5), new ItemInfo(0x12E9), new ItemInfo(0x12EE), new ItemInfo(0x12F4), 
            new ItemInfo(0x12FA), new ItemInfo(0x1300), new ItemInfo(0x1305), new ItemInfo(0x1306), new ItemInfo(0x130C), new ItemInfo(0x1311), new ItemInfo(0x1312), new ItemInfo(0x1318), new ItemInfo(0x131E), 
            new ItemInfo(0x1321), new ItemInfo(0x1324), new ItemInfo(0x1327), new ItemInfo(0x132A), new ItemInfo(0x132D), new ItemInfo(0x1330), new ItemInfo(0x1333), new ItemInfo(0x1336), new ItemInfo(0x1339), 
            new ItemInfo(0x133C), new ItemInfo(0x133F), new ItemInfo(0x1342), new ItemInfo(0x1345), new ItemInfo(0x1348), new ItemInfo(0x134B), new ItemInfo(0x136E), new ItemInfo(0x137A), new ItemInfo(0x1384)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddAnimStPt1Gump()
			: this(0)
		{ }

		public AddAnimStPt1Gump(int page) 
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

			from.SendGump(new AddAnimStPt1Gump(page));
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
