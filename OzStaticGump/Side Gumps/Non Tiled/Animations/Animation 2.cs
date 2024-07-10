using Server.Network;

namespace Server.Gumps
{
	public class AddAnimStPt2Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddAnimStPt2", AccessLevel.GameMaster, new CommandEventHandler(AddAnimStPt2_OnCommand));
		}

		[Usage("AddAnimStPt2")]
		public static void AddAnimStPt2_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddAnimStPt2Gump>();
			e.Mobile.SendGump(new AddAnimStPt2Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(0x1390), new ItemInfo(0x140C), new ItemInfo(0x142C), new ItemInfo(0x142E), new ItemInfo(0x1430), new ItemInfo(0x1434), new ItemInfo(0x1508), new ItemInfo(0x1512), new ItemInfo(0x151A), 
            new ItemInfo(0x151C), new ItemInfo(0x1541), new ItemInfo(0x1545), new ItemInfo(0x154D), new ItemInfo(0x1551), new ItemInfo(0x163D), new ItemInfo(0x1541), new ItemInfo(0x168E), new ItemInfo(0x1739), 
            new ItemInfo(0x173D), new ItemInfo(0x173F), new ItemInfo(0x1741), new ItemInfo(0x1811), new ItemInfo(0x183E), new ItemInfo(0x183F), new ItemInfo(0x1840), new ItemInfo(0x1841), new ItemInfo(0x1842), 
            new ItemInfo(0x1843), new ItemInfo(0x1844), new ItemInfo(0x1845), new ItemInfo(0x1846), new ItemInfo(0x184A), new ItemInfo(0x184E), new ItemInfo(0x1854), new ItemInfo(0x1858), new ItemInfo(0x18A3), 
            new ItemInfo(0x18A4), new ItemInfo(0x18A5), new ItemInfo(0x18A6), new ItemInfo(0x18A7), new ItemInfo(0x18A8), new ItemInfo(0x18A9), new ItemInfo(0x18AA), new ItemInfo(0x18AB), new ItemInfo(0x18AC), 
            new ItemInfo(0x18AD), new ItemInfo(0x18B2), new ItemInfo(0x18F4), new ItemInfo(0x18F5), new ItemInfo(0x18F6), new ItemInfo(0x18F7), new ItemInfo(0x18F8), new ItemInfo(0x18F9), new ItemInfo(0x18FA), 
            new ItemInfo(0x18FB), new ItemInfo(0x1905), new ItemInfo(0x190A), new ItemInfo(0x1926), new ItemInfo(0x1928), new ItemInfo(0x1932), new ItemInfo(0x1934), new ItemInfo(0x1951), new ItemInfo(0x1954), 
            new ItemInfo(0x197A), new ItemInfo(0x197E), new ItemInfo(0x1982), new ItemInfo(0x1986), new ItemInfo(0x198A), new ItemInfo(0x199E), new ItemInfo(0x1992), new ItemInfo(0x1996), new ItemInfo(0x19AB), 
            new ItemInfo(0x19AC), new ItemInfo(0x19AD), new ItemInfo(0x19AE), new ItemInfo(0x19AF), new ItemInfo(0x19B0), new ItemInfo(0x19B1), new ItemInfo(0x19B2), new ItemInfo(0x19B3), new ItemInfo(0x19B4), 
            new ItemInfo(0x19B5), new ItemInfo(0x19B6), new ItemInfo(0x19D3), new ItemInfo(0x1A19), new ItemInfo(0x1A1E), new ItemInfo(0x1A23), new ItemInfo(0x1A28), new ItemInfo(0x1A2D), new ItemInfo(0x1A32), 
            new ItemInfo(0x1A37), new ItemInfo(0x1A3B), new ItemInfo(0x1A3F), new ItemInfo(0x1A43), new ItemInfo(0x1A47), new ItemInfo(0x1A4C), new ItemInfo(0x1A51), new ItemInfo(0x1A56), new ItemInfo(0x1A5B), 
            new ItemInfo(0x1A60), new ItemInfo(0x1A65), new ItemInfo(0x1A69), new ItemInfo(0x1A6D), new ItemInfo(0x1A71), new ItemInfo(0x1A75), new ItemInfo(0x1AAD), new ItemInfo(0x1AB0), new ItemInfo(0x1AB3), 
            new ItemInfo(0x1AB6), new ItemInfo(0x1ABE), new ItemInfo(0x1AC1), new ItemInfo(0x1AC4), new ItemInfo(0x1AC7), new ItemInfo(0x1AD0), new ItemInfo(0x1AF3), new ItemInfo(0x1B7C), new ItemInfo(0x1B7F), 
            new ItemInfo(0x1C14), new ItemInfo(0x1C19), new ItemInfo(0x1D99), new ItemInfo(0x1EA8), new ItemInfo(0x1EA9), new ItemInfo(0x1EAB), new ItemInfo(0x1EAD), new ItemInfo(0x1EC1), new ItemInfo(0x1EC2), 
            new ItemInfo(0x1EC3), new ItemInfo(0x1EC4), new ItemInfo(0x1EC5), new ItemInfo(0x1EC6), new ItemInfo(0x1ECD), new ItemInfo(0x1ED0), new ItemInfo(0x1ED3), new ItemInfo(0x1ED9), new ItemInfo(0x1EE1), 
            new ItemInfo(0x1EE2), new ItemInfo(0x1EEC), new ItemInfo(0x1EF3), new ItemInfo(0x1EF4), new ItemInfo(0x1F19), new ItemInfo(0x1F1C), new ItemInfo(0x1F1F), new ItemInfo(0x1FA3), new ItemInfo(0x1FA4), 
            new ItemInfo(0x1FA5), new ItemInfo(0x1FA6), new ItemInfo(0x1FA7), new ItemInfo(0x1FA8), new ItemInfo(0x1FA9), new ItemInfo(0x1FAA), new ItemInfo(0x1FAB), new ItemInfo(0x1FAC), new ItemInfo(0x1FAD), 
            new ItemInfo(0x1FAE), new ItemInfo(0x1FAF), new ItemInfo(0x1FB0), new ItemInfo(0x1FB2), new ItemInfo(0x1FB3), new ItemInfo(0x1FB4), new ItemInfo(0x1FB5), new ItemInfo(0x1FB6), new ItemInfo(0x1FB7), 
            new ItemInfo(0x1FB8), new ItemInfo(0x1FB9), new ItemInfo(0x1FBA), new ItemInfo(0x1FBC), new ItemInfo(0x1FBD), new ItemInfo(0x1FBE), new ItemInfo(0x1FBF), new ItemInfo(0x1FC0), new ItemInfo(0x1FC1), 
            new ItemInfo(0x1FC2), new ItemInfo(0x1FC3), new ItemInfo(0x1FC4), new ItemInfo(0x1FC5), new ItemInfo(0x1FC6), new ItemInfo(0x1FC7), new ItemInfo(0x1FC8), new ItemInfo(0x1FC9), new ItemInfo(0x1FCA)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddAnimStPt2Gump()
			: this(0)
		{ }

		public AddAnimStPt2Gump(int page) 
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

			from.SendGump(new AddAnimStPt2Gump(page));
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
