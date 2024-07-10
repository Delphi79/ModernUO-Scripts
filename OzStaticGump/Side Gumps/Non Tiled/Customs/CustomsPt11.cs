using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt11Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt11", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt11_OnCommand));
		}

		[Usage("AddCustomPt11")]
		
		public static void AddCustomPt11_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt11Gump>();
			e.Mobile.SendGump(new AddCustomPt11Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(41094), new ItemInfo(41095), new ItemInfo(41096), new ItemInfo(41097), new ItemInfo(41098), new ItemInfo(41099), new ItemInfo(41100), new ItemInfo(41101), new ItemInfo(41102), 
			new ItemInfo(41103), new ItemInfo(41104), new ItemInfo(41105), new ItemInfo(41106), new ItemInfo(41107), new ItemInfo(41108), new ItemInfo(41109), new ItemInfo(41110), new ItemInfo(41111), 
			new ItemInfo(41112), new ItemInfo(41113), new ItemInfo(41114), new ItemInfo(41115), new ItemInfo(41116), new ItemInfo(41117), new ItemInfo(41118), new ItemInfo(41119), new ItemInfo(41120), 
			new ItemInfo(41121), new ItemInfo(41122), new ItemInfo(41123), new ItemInfo(41124), new ItemInfo(41125), new ItemInfo(41126), new ItemInfo(41127), new ItemInfo(41128), new ItemInfo(41129), 
			new ItemInfo(41130), new ItemInfo(41131), new ItemInfo(41132), new ItemInfo(41133), new ItemInfo(41134), new ItemInfo(41135), new ItemInfo(41136), new ItemInfo(41137), new ItemInfo(41138), 
			new ItemInfo(41139), new ItemInfo(41140), new ItemInfo(41141), new ItemInfo(41142), new ItemInfo(41143), new ItemInfo(41144), new ItemInfo(41145), new ItemInfo(41146), new ItemInfo(41147), 
			new ItemInfo(41148), new ItemInfo(41149), new ItemInfo(41150), new ItemInfo(41151), new ItemInfo(41152), new ItemInfo(41153), new ItemInfo(41154), new ItemInfo(41155), new ItemInfo(41156), 
			new ItemInfo(41157), new ItemInfo(41158), new ItemInfo(41159), new ItemInfo(41160), new ItemInfo(41161), new ItemInfo(41162), new ItemInfo(41163), new ItemInfo(41164), new ItemInfo(41165), 
			new ItemInfo(41166), new ItemInfo(41167), new ItemInfo(41168), new ItemInfo(41169), new ItemInfo(41170), new ItemInfo(41171), new ItemInfo(41172), new ItemInfo(41173), new ItemInfo(41174), 
			new ItemInfo(41175), new ItemInfo(41176), new ItemInfo(41177), new ItemInfo(41178), new ItemInfo(41179), new ItemInfo(41180), new ItemInfo(41181), new ItemInfo(41182), new ItemInfo(41183), 
			new ItemInfo(41184), new ItemInfo(41185), new ItemInfo(41186), new ItemInfo(41187), new ItemInfo(41188), new ItemInfo(41189), new ItemInfo(41190), new ItemInfo(41191), new ItemInfo(41192), 
			new ItemInfo(41193), new ItemInfo(41194), new ItemInfo(41195), new ItemInfo(41196), new ItemInfo(41197), new ItemInfo(41198), new ItemInfo(41199), new ItemInfo(41200), new ItemInfo(41201), 
			new ItemInfo(41202), new ItemInfo(41203), new ItemInfo(41204), new ItemInfo(41205), new ItemInfo(41206), new ItemInfo(41207), new ItemInfo(41208), new ItemInfo(41209), new ItemInfo(41210), 
			new ItemInfo(41211), new ItemInfo(41212), new ItemInfo(41213), new ItemInfo(41214), new ItemInfo(41215), new ItemInfo(41216), new ItemInfo(41217), new ItemInfo(41218), new ItemInfo(41219), 
			new ItemInfo(41220), new ItemInfo(41221), new ItemInfo(41222), new ItemInfo(41223), new ItemInfo(41224), new ItemInfo(41225), new ItemInfo(41226), new ItemInfo(41227), new ItemInfo(41228), 
			new ItemInfo(41229), new ItemInfo(41230), new ItemInfo(41231), new ItemInfo(41232), new ItemInfo(41233), new ItemInfo(41234), new ItemInfo(41235), new ItemInfo(41236), new ItemInfo(41237), 
			new ItemInfo(41238), new ItemInfo(41239), new ItemInfo(41240), new ItemInfo(41241), new ItemInfo(41242), new ItemInfo(41243), new ItemInfo(41244), new ItemInfo(41245), new ItemInfo(41246), 
			new ItemInfo(41247), new ItemInfo(41248), new ItemInfo(41249), new ItemInfo(41250), new ItemInfo(41251), new ItemInfo(41252), new ItemInfo(41253), new ItemInfo(41254), new ItemInfo(41255), 
			new ItemInfo(41256), new ItemInfo(41257), new ItemInfo(41258), new ItemInfo(41259), new ItemInfo(41270), new ItemInfo(41271), new ItemInfo(41272), new ItemInfo(41273), new ItemInfo(41274), 
			new ItemInfo(41275), new ItemInfo(41276), new ItemInfo(41277), new ItemInfo(41278), new ItemInfo(41279), new ItemInfo(41280), new ItemInfo(41281), new ItemInfo(41282), new ItemInfo(41283), 
			new ItemInfo(41284), new ItemInfo(41285), new ItemInfo(41286), new ItemInfo(41287), new ItemInfo(41288), new ItemInfo(41289), new ItemInfo(41290), new ItemInfo(41291), new ItemInfo(41292), 
			new ItemInfo(41293), new ItemInfo(41294), new ItemInfo(41295), new ItemInfo(41296), new ItemInfo(41297), new ItemInfo(41298), new ItemInfo(41299), new ItemInfo(41300), new ItemInfo(41301), 
			new ItemInfo(41302), new ItemInfo(41303), new ItemInfo(41304), new ItemInfo(41305), new ItemInfo(41306), new ItemInfo(41307), new ItemInfo(41308), new ItemInfo(41309), new ItemInfo(41310), 
			new ItemInfo(41311), new ItemInfo(41312), new ItemInfo(41313), new ItemInfo(41314), new ItemInfo(41315), new ItemInfo(41316), new ItemInfo(41317), new ItemInfo(41318), new ItemInfo(41319), 
			new ItemInfo(41320), new ItemInfo(41321), new ItemInfo(41322), new ItemInfo(41323), new ItemInfo(41324), new ItemInfo(41325), new ItemInfo(41326), new ItemInfo(41327), new ItemInfo(41328), 
			new ItemInfo(41329), new ItemInfo(41330), new ItemInfo(41331), new ItemInfo(41332), new ItemInfo(41333), new ItemInfo(41334), new ItemInfo(41335), new ItemInfo(41336), new ItemInfo(41337), 
			new ItemInfo(41338), new ItemInfo(41339), new ItemInfo(41340), new ItemInfo(41341), new ItemInfo(41342), new ItemInfo(41343), new ItemInfo(41344), new ItemInfo(41345), new ItemInfo(41346), 
			new ItemInfo(41347), new ItemInfo(41348), new ItemInfo(41349), new ItemInfo(41353), new ItemInfo(41354), new ItemInfo(41355), new ItemInfo(41356), new ItemInfo(41357), new ItemInfo(41358), 
			new ItemInfo(41359), new ItemInfo(41360), new ItemInfo(41361), new ItemInfo(41362), new ItemInfo(41363), new ItemInfo(41364), new ItemInfo(41365), new ItemInfo(41366), new ItemInfo(41367), 
			new ItemInfo(41368), new ItemInfo(41369), new ItemInfo(41370), new ItemInfo(41371), new ItemInfo(41372), new ItemInfo(41373), new ItemInfo(41374), new ItemInfo(41375), new ItemInfo(41376)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt11Gump()
			: this(0)
		{ }

		public AddCustomPt11Gump(int page) 
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

			from.SendGump(new AddCustomPt11Gump(page));
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
