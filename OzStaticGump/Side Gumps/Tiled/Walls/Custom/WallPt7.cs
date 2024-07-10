using Server.Network;

namespace Server.Gumps
{
	public class AddWallPt7Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddWallPt7", AccessLevel.GameMaster, new CommandEventHandler(AddWallPt7_OnCommand));
		}

		[Usage("AddWallPt7")]
		
		public static void AddWallPt7_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddWallPt7Gump>();
			e.Mobile.SendGump(new AddWallPt7Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(39214), new ItemInfo(39215), new ItemInfo(39216), new ItemInfo(39217), new ItemInfo(39218), new ItemInfo(39219), new ItemInfo(39220), new ItemInfo(39221), 
            new ItemInfo(39222), new ItemInfo(39223), new ItemInfo(39224), new ItemInfo(39225), new ItemInfo(39226), new ItemInfo(39227), new ItemInfo(39228), new ItemInfo(39229), 
            new ItemInfo(39230), new ItemInfo(39231), new ItemInfo(39232), new ItemInfo(39233), new ItemInfo(39234), new ItemInfo(39235), new ItemInfo(39236), new ItemInfo(39237), 
            new ItemInfo(39238), new ItemInfo(39239), new ItemInfo(39240), new ItemInfo(39241), new ItemInfo(39242), new ItemInfo(39243), new ItemInfo(39244), new ItemInfo(39245), 
            new ItemInfo(39246), new ItemInfo(39247), new ItemInfo(39248), new ItemInfo(39249), new ItemInfo(39250), new ItemInfo(39251), new ItemInfo(39252), new ItemInfo(39253), 
            new ItemInfo(39254), new ItemInfo(39255), new ItemInfo(39256), new ItemInfo(39257), new ItemInfo(39258), new ItemInfo(39259), new ItemInfo(39260), new ItemInfo(39261), 
            new ItemInfo(39262), new ItemInfo(39263), new ItemInfo(39264), new ItemInfo(39265), new ItemInfo(39266), new ItemInfo(39267), new ItemInfo(39268), new ItemInfo(39269), 
            new ItemInfo(39270), new ItemInfo(39271), new ItemInfo(39272), new ItemInfo(39273), new ItemInfo(39274), new ItemInfo(39275), new ItemInfo(39276), new ItemInfo(39277), 
            new ItemInfo(39278), new ItemInfo(39279), new ItemInfo(39280), new ItemInfo(39281), new ItemInfo(39282), new ItemInfo(39283), new ItemInfo(39284), new ItemInfo(39285), 
            new ItemInfo(39286), new ItemInfo(39287), new ItemInfo(39288), new ItemInfo(39289), new ItemInfo(39290), new ItemInfo(39299), new ItemInfo(39300), new ItemInfo(39301), 
            new ItemInfo(39302), new ItemInfo(39303), new ItemInfo(39304), new ItemInfo(39305), new ItemInfo(39306), new ItemInfo(39307), new ItemInfo(39308), new ItemInfo(39309), 
            new ItemInfo(39310), new ItemInfo(39311), new ItemInfo(39312), new ItemInfo(39313), new ItemInfo(39314), new ItemInfo(39315), new ItemInfo(39316), new ItemInfo(39317), 
            new ItemInfo(39318), new ItemInfo(39319), new ItemInfo(39320), new ItemInfo(39321), new ItemInfo(39322), new ItemInfo(39323), new ItemInfo(39324), new ItemInfo(39325), 
            new ItemInfo(39326), new ItemInfo(39327), new ItemInfo(39328), new ItemInfo(39329), new ItemInfo(39330), new ItemInfo(39331), new ItemInfo(39332), new ItemInfo(39333), 
            new ItemInfo(39334), new ItemInfo(39335), new ItemInfo(39336), new ItemInfo(39337), new ItemInfo(39338), new ItemInfo(39339), new ItemInfo(39340), new ItemInfo(39341), 
            new ItemInfo(39342), new ItemInfo(39343), new ItemInfo(39344), new ItemInfo(39345), new ItemInfo(39346), new ItemInfo(39347), new ItemInfo(39348), new ItemInfo(39349), 
            new ItemInfo(39350), new ItemInfo(39351), new ItemInfo(39352), new ItemInfo(39353), new ItemInfo(39354), new ItemInfo(39355), new ItemInfo(39356), new ItemInfo(39357), 
            new ItemInfo(39358), new ItemInfo(39359), new ItemInfo(39360), new ItemInfo(39361), new ItemInfo(39362), new ItemInfo(39363), new ItemInfo(39364), new ItemInfo(39365), 
            new ItemInfo(39366), new ItemInfo(39367), new ItemInfo(39368), new ItemInfo(39369), new ItemInfo(39370), new ItemInfo(39371), new ItemInfo(39372), new ItemInfo(39373), 
            new ItemInfo(39374), new ItemInfo(39375), new ItemInfo(39376), new ItemInfo(39377), new ItemInfo(39378), new ItemInfo(39379), new ItemInfo(39380), new ItemInfo(39381), 
            new ItemInfo(39382), new ItemInfo(39383), new ItemInfo(39384), new ItemInfo(39385), new ItemInfo(39386), new ItemInfo(39387), new ItemInfo(39388), new ItemInfo(39389), 
            new ItemInfo(39390), new ItemInfo(39391), new ItemInfo(39392), new ItemInfo(39393), new ItemInfo(39394), new ItemInfo(39395), new ItemInfo(39396), new ItemInfo(39397), 
            new ItemInfo(39398), new ItemInfo(39399), new ItemInfo(39400), new ItemInfo(39401), new ItemInfo(39402), new ItemInfo(39403), new ItemInfo(39404), new ItemInfo(39405), 
            new ItemInfo(39406), new ItemInfo(39407), new ItemInfo(39408), new ItemInfo(39409), new ItemInfo(39410), new ItemInfo(39411), new ItemInfo(39412), new ItemInfo(39413), 
            new ItemInfo(39414), new ItemInfo(39415), new ItemInfo(39416), new ItemInfo(39417), new ItemInfo(39418), new ItemInfo(39419), new ItemInfo(39420), new ItemInfo(39421), 
            new ItemInfo(39422), new ItemInfo(39423), new ItemInfo(39424), new ItemInfo(39425), new ItemInfo(39426), new ItemInfo(39427), new ItemInfo(39428), new ItemInfo(39429), 
            new ItemInfo(39430), new ItemInfo(39431), new ItemInfo(39432), new ItemInfo(39433), new ItemInfo(39434), new ItemInfo(39435), new ItemInfo(39436), new ItemInfo(39437), 
            new ItemInfo(39438), new ItemInfo(39439), new ItemInfo(39440), new ItemInfo(39441), new ItemInfo(39442), new ItemInfo(39443), new ItemInfo(39444), new ItemInfo(39445), 
            new ItemInfo(39446), new ItemInfo(39447), new ItemInfo(39448), new ItemInfo(39449), new ItemInfo(39450), new ItemInfo(39451), new ItemInfo(39452), new ItemInfo(39453), 
            new ItemInfo(39454), new ItemInfo(39455), new ItemInfo(39456), new ItemInfo(39457), new ItemInfo(39458), new ItemInfo(39459), new ItemInfo(39460), new ItemInfo(39461), 
            new ItemInfo(39462), new ItemInfo(39463), new ItemInfo(39464), new ItemInfo(39465), new ItemInfo(39466), new ItemInfo(39467), new ItemInfo(39468), new ItemInfo(39469), 
            new ItemInfo(39470), new ItemInfo(39471), new ItemInfo(39472), new ItemInfo(39473), new ItemInfo(39474), new ItemInfo(39475), new ItemInfo(39476), new ItemInfo(39477), 
            new ItemInfo(39499), new ItemInfo(39500), new ItemInfo(39501), new ItemInfo(39502), new ItemInfo(39503), new ItemInfo(39504), new ItemInfo(39505), new ItemInfo(39506), 
            new ItemInfo(39507), new ItemInfo(39508), new ItemInfo(39509), new ItemInfo(39510), new ItemInfo(39511), new ItemInfo(39512), new ItemInfo(39513), new ItemInfo(39514), 
            new ItemInfo(39515), new ItemInfo(40194), new ItemInfo(40195), new ItemInfo(40196), new ItemInfo(40197), new ItemInfo(40198), new ItemInfo(40199), new ItemInfo(40200), 
            new ItemInfo(40201), new ItemInfo(40202), new ItemInfo(40203), new ItemInfo(40204), new ItemInfo(40205), new ItemInfo(40206), new ItemInfo(40207), new ItemInfo(40208), 
            new ItemInfo(40209), new ItemInfo(40210), new ItemInfo(40211), new ItemInfo(40212), new ItemInfo(40213), new ItemInfo(40214), new ItemInfo(40215), new ItemInfo(40216), 
            new ItemInfo(40217), new ItemInfo(40218), new ItemInfo(40231), new ItemInfo(40232), new ItemInfo(40233), new ItemInfo(40234), new ItemInfo(40235), new ItemInfo(40236), 
            new ItemInfo(40237), new ItemInfo(40238), new ItemInfo(40239), new ItemInfo(40240), new ItemInfo(40241), new ItemInfo(40242), new ItemInfo(40243), new ItemInfo(40244), 
            new ItemInfo(40245), new ItemInfo(40246), new ItemInfo(40247), new ItemInfo(40248), new ItemInfo(40249), new ItemInfo(40250), new ItemInfo(40251), new ItemInfo(40252), 
            new ItemInfo(40253), new ItemInfo(40256), new ItemInfo(40257), new ItemInfo(40258), new ItemInfo(40259), new ItemInfo(40260), new ItemInfo(40261), new ItemInfo(40262), 
            new ItemInfo(40263), new ItemInfo(41691), new ItemInfo(41692), new ItemInfo(41693), new ItemInfo(41694), new ItemInfo(41695), new ItemInfo(41696), new ItemInfo(41697), 
            new ItemInfo(41698), new ItemInfo(41699), new ItemInfo(41700), new ItemInfo(41701), new ItemInfo(41702), new ItemInfo(41703), new ItemInfo(41704), new ItemInfo(41705), 
            new ItemInfo(41706), new ItemInfo(41707), new ItemInfo(41708), new ItemInfo(41709), new ItemInfo(41710), new ItemInfo(41711), new ItemInfo(41712), new ItemInfo(41713)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddWallPt7Gump()
			: this(0)
		{ }

		public AddWallPt7Gump(int page) 
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

			from.SendGump(new AddWallPt7Gump(page));
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
