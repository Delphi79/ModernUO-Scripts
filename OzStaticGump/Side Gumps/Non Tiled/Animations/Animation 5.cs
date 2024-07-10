using Server.Network;

namespace Server.Gumps
{
	public class AddAnimStPt5Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddAnimStPt5", AccessLevel.GameMaster, new CommandEventHandler(AddAnimStPt5_OnCommand));
		}

		[Usage("AddAnimStPt5")]
		public static void AddAnimStPt5_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddAnimStPt5Gump>();
			e.Mobile.SendGump(new AddAnimStPt5Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(0x483E), new ItemInfo(0x4841), new ItemInfo(0x4844), new ItemInfo(0x4847), new ItemInfo(0x484A), new ItemInfo(0x484D), new ItemInfo(0x4850), new ItemInfo(0x4853), new ItemInfo(0x4856), 
            new ItemInfo(0x4859), new ItemInfo(0x485C), new ItemInfo(0x485F), new ItemInfo(0x4862), new ItemInfo(0x4865), new ItemInfo(0x4868), new ItemInfo(0x486B), new ItemInfo(0x486E), new ItemInfo(0x4871), 
            new ItemInfo(0x4874), new ItemInfo(0x4877), new ItemInfo(0x487A), new ItemInfo(0x487D), new ItemInfo(0x4880), new ItemInfo(0x4883), new ItemInfo(0x48D4), new ItemInfo(0x48D8), new ItemInfo(0x49CC), 
            new ItemInfo(0x49D0), new ItemInfo(0x5675), new ItemInfo(0x5683), new ItemInfo(0x571C), new ItemInfo(0x5722), new ItemInfo(0x5728), new ItemInfo(0x572D), new ItemInfo(0x5732), new ItemInfo(0x573E), 
            new ItemInfo(0x981D), new ItemInfo(0x9822), new ItemInfo(0x9DBD), new ItemInfo(0x9DC9), new ItemInfo(0x9DCD), new ItemInfo(0x9DDA), new ItemInfo(0x9DE5), new ItemInfo(0x9DE9), new ItemInfo(0x9FA1), 
            new ItemInfo(0x9FA4)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddAnimStPt5Gump()
			: this(0)
		{ }

		public AddAnimStPt5Gump(int page) 
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

			from.SendGump(new AddAnimStPt5Gump(page));
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
