using Server.Network;

namespace Server.Gumps
{
	public class AddAnimStPt6Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddAnimStPt6", AccessLevel.GameMaster, new CommandEventHandler(AddAnimStPt6_OnCommand));
		}

		[Usage("AddAnimStPt6")]
		public static void AddAnimStPt6_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddAnimStPt6Gump>();
			e.Mobile.SendGump(new AddAnimStPt6Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(0xA112), new ItemInfo(0xA136), new ItemInfo(0xA14B), new ItemInfo(0xA157), new ItemInfo(0xA15D), new ItemInfo(0xA164), new ItemInfo(0xA16B), new ItemInfo(0xA17B), new ItemInfo(0xA193), 
            new ItemInfo(0xA197), new ItemInfo(0xA19A), new ItemInfo(0xA1A0), new ItemInfo(0xA1B4), new ItemInfo(0xA1B7), new ItemInfo(0xA1BC), new ItemInfo(0xA1C1), new ItemInfo(0xA1CA), new ItemInfo(0xA1DF), 
            new ItemInfo(0xA1E2), new ItemInfo(0xA1E5), new ItemInfo(0xA1F4), new ItemInfo(0xA205), new ItemInfo(0xA20D), new ItemInfo(0xA210), new ItemInfo(0xA213), new ItemInfo(0xA222), new ItemInfo(0xA226), 
            new ItemInfo(0xA22F), new ItemInfo(0xA23A), new ItemInfo(0xA243), new ItemInfo(0xA25E), new ItemInfo(0xA266), new ItemInfo(0xA27E), new ItemInfo(0xA285), new ItemInfo(0xA28D), new ItemInfo(0xA292), 
            new ItemInfo(0xA298), new ItemInfo(0xA2A3), new ItemInfo(0xA2A7), new ItemInfo(0xA2AB), new ItemInfo(0xA2B9), new ItemInfo(0xA2BE), new ItemInfo(0xA574), new ItemInfo(0xA592), new ItemInfo(0xA595), 
            new ItemInfo(0xA598), new ItemInfo(0xA59B), new ItemInfo(0xA944), new ItemInfo(0xA948), new ItemInfo(0xA94D), new ItemInfo(0xA952), new ItemInfo(0xA956), new ItemInfo(0xA95A), new ItemInfo(0xA95E), 
            new ItemInfo(0xA962)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddAnimStPt6Gump()
			: this(0)
		{ }

		public AddAnimStPt6Gump(int page) 
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

			from.SendGump(new AddAnimStPt6Gump(page));
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
