using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt7Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt7", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt7_OnCommand));
		}

		[Usage("AddCustomPt7")]
		
		public static void AddCustomPt7_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt7Gump>();
			e.Mobile.SendGump(new AddCustomPt7Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(40301), new ItemInfo(40302), new ItemInfo(40303), new ItemInfo(40304), new ItemInfo(40305), new ItemInfo(40306), new ItemInfo(40307), new ItemInfo(40308), new ItemInfo(40309), 
			new ItemInfo(40310), new ItemInfo(40311), new ItemInfo(40312), new ItemInfo(40313), new ItemInfo(40314), new ItemInfo(40315), new ItemInfo(40316), new ItemInfo(40317), new ItemInfo(40318), 
			new ItemInfo(40319), new ItemInfo(40320), new ItemInfo(40321), new ItemInfo(40322), new ItemInfo(40323), new ItemInfo(40324), new ItemInfo(40325), new ItemInfo(40326), new ItemInfo(40327), 
			new ItemInfo(40328), new ItemInfo(40329), new ItemInfo(40330), new ItemInfo(40331), new ItemInfo(40332), new ItemInfo(40333), new ItemInfo(40334), new ItemInfo(40335), new ItemInfo(40336), 
			new ItemInfo(40337), new ItemInfo(40338), new ItemInfo(40339), new ItemInfo(40340), new ItemInfo(40341), new ItemInfo(40342), new ItemInfo(40343), new ItemInfo(40344), new ItemInfo(40345), 
			new ItemInfo(40346), new ItemInfo(40347), new ItemInfo(40348), new ItemInfo(40349), new ItemInfo(40350), new ItemInfo(40351), new ItemInfo(40352), new ItemInfo(40353), new ItemInfo(40354), 
			new ItemInfo(40355), new ItemInfo(40356), new ItemInfo(40358), new ItemInfo(40359), new ItemInfo(40360), new ItemInfo(40361), new ItemInfo(40362), new ItemInfo(40363), new ItemInfo(40364), 
			new ItemInfo(40365), new ItemInfo(40366), new ItemInfo(40367), new ItemInfo(40368), new ItemInfo(40369), new ItemInfo(40370), new ItemInfo(40371), new ItemInfo(40372), new ItemInfo(40373), 
			new ItemInfo(40374), new ItemInfo(40375), new ItemInfo(40376), new ItemInfo(40378), new ItemInfo(40379), new ItemInfo(40381), new ItemInfo(40382), new ItemInfo(40383), new ItemInfo(40384), 
			new ItemInfo(40385), new ItemInfo(40386), new ItemInfo(40387), new ItemInfo(40388), new ItemInfo(40389), new ItemInfo(40390), new ItemInfo(40391), new ItemInfo(40392), new ItemInfo(40393), 
			new ItemInfo(40394), new ItemInfo(40395), new ItemInfo(40396), new ItemInfo(40397), new ItemInfo(40398), new ItemInfo(40399), new ItemInfo(40400), new ItemInfo(40401), new ItemInfo(40402), 
			new ItemInfo(40403), new ItemInfo(40404), new ItemInfo(40405), new ItemInfo(40406), new ItemInfo(40407), new ItemInfo(40408), new ItemInfo(40410), new ItemInfo(40411), new ItemInfo(40412), 
			new ItemInfo(40413), new ItemInfo(40414), new ItemInfo(40415), new ItemInfo(40416), new ItemInfo(40417), new ItemInfo(40418), new ItemInfo(40419), new ItemInfo(40420), new ItemInfo(40421), 
			new ItemInfo(40422), new ItemInfo(40423), new ItemInfo(40424), new ItemInfo(40425), new ItemInfo(40426), new ItemInfo(40427), new ItemInfo(40428), new ItemInfo(40429), new ItemInfo(40430), 
			new ItemInfo(40431), new ItemInfo(40432), new ItemInfo(40433), new ItemInfo(40434), new ItemInfo(40435), new ItemInfo(40436), new ItemInfo(40438), new ItemInfo(40439), new ItemInfo(40440), 
			new ItemInfo(40441), new ItemInfo(40442), new ItemInfo(40443), new ItemInfo(40444), new ItemInfo(40445), new ItemInfo(40447), new ItemInfo(40448), new ItemInfo(40449), new ItemInfo(40450), 
			new ItemInfo(40451), new ItemInfo(40452), new ItemInfo(40453), new ItemInfo(40454), new ItemInfo(40455), new ItemInfo(40456), new ItemInfo(40457), new ItemInfo(40458), new ItemInfo(40459), 
			new ItemInfo(40460), new ItemInfo(40461), new ItemInfo(40462), new ItemInfo(40463), new ItemInfo(40464), new ItemInfo(40465), new ItemInfo(40466), new ItemInfo(40467), new ItemInfo(40468), 
			new ItemInfo(40469), new ItemInfo(40470), new ItemInfo(40471), new ItemInfo(40472), new ItemInfo(40473), new ItemInfo(40474), new ItemInfo(40475), new ItemInfo(40476), new ItemInfo(40477), 
			new ItemInfo(40478), new ItemInfo(40479), new ItemInfo(40480), new ItemInfo(40481), new ItemInfo(40482), new ItemInfo(40483), new ItemInfo(40484), new ItemInfo(40485), new ItemInfo(40486)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt7Gump()
			: this(0)
		{ }

		public AddCustomPt7Gump(int page) 
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

			from.SendGump(new AddCustomPt7Gump(page));
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
