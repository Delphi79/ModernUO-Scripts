using Server.Network;

namespace Server.Gumps
{
	public class AddRoofPt5Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddRoofPt5", AccessLevel.GameMaster, new CommandEventHandler(AddRoofPt5_OnCommand));
		}

		[Usage("AddRoofPt5")]
		
		public static void AddRoofPt5_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddRoofPt5Gump>();
			e.Mobile.SendGump(new AddRoofPt5Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Roofs
            new ItemInfo(1789), new ItemInfo(1790), new ItemInfo(1791), new ItemInfo(1792), 
			new ItemInfo(40297), new ItemInfo(40298), 
            new ItemInfo(40299), new ItemInfo(40300), new ItemInfo(40301), new ItemInfo(40302), new ItemInfo(40303), new ItemInfo(40304), new ItemInfo(40305), new ItemInfo(40306), 
            new ItemInfo(40307), new ItemInfo(40308), new ItemInfo(40309), new ItemInfo(40310), new ItemInfo(40311), new ItemInfo(40312), new ItemInfo(40313), new ItemInfo(40314), 
            new ItemInfo(40315), new ItemInfo(40316), new ItemInfo(40317), new ItemInfo(40318), new ItemInfo(40319), new ItemInfo(40320), new ItemInfo(40321), new ItemInfo(40322), 
            new ItemInfo(40323), new ItemInfo(40324), new ItemInfo(40325), new ItemInfo(40326), new ItemInfo(40327), new ItemInfo(40328), new ItemInfo(40329), new ItemInfo(40330), 
            new ItemInfo(40331), new ItemInfo(40332), new ItemInfo(40333), new ItemInfo(40334), new ItemInfo(40335), new ItemInfo(40336), new ItemInfo(40337), new ItemInfo(40338), 
            new ItemInfo(40339), new ItemInfo(40340), new ItemInfo(40341), new ItemInfo(40342), new ItemInfo(40343), new ItemInfo(40344), new ItemInfo(40345), new ItemInfo(40346), 
            new ItemInfo(40347), new ItemInfo(40348), new ItemInfo(40349), new ItemInfo(40350), new ItemInfo(40351), new ItemInfo(40352), new ItemInfo(40353), new ItemInfo(40354), 
            new ItemInfo(40355), new ItemInfo(40356)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddRoofPt5Gump()
			: this(0)
		{ }

		public AddRoofPt5Gump(int page) 
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

				CommandSystem.Handle(from, string.Format("{0}Tile Static {1}", CommandSystem.Prefix, m_Types[button].m_BaseID));
			}
			else if (button >= 10000)
			{
				button -= 10000;

				page = button;
			}

			from.SendGump(new AddRoofPt5Gump(page));
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
