using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt11Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt11", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt11_OnCommand));
		}

		[Usage("AddMisc2Pt11")]
		
		public static void AddMisc2Pt11_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt11Gump>();
			e.Mobile.SendGump(new AddMisc2Pt11Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(14093), new ItemInfo(14094), new ItemInfo(14095), new ItemInfo(14096), new ItemInfo(14097), new ItemInfo(14098), new ItemInfo(14099), new ItemInfo(14100), new ItemInfo(14101), 
            new ItemInfo(14102), new ItemInfo(14103), new ItemInfo(14104), new ItemInfo(14105), new ItemInfo(14106), new ItemInfo(14107), new ItemInfo(14108), new ItemInfo(14109), new ItemInfo(14110), 
            new ItemInfo(14111), new ItemInfo(14112), new ItemInfo(14113), new ItemInfo(14114), new ItemInfo(14115), new ItemInfo(14116), new ItemInfo(14117), new ItemInfo(14118), new ItemInfo(14119), 
            new ItemInfo(14120), new ItemInfo(14121), new ItemInfo(14122), new ItemInfo(14123), new ItemInfo(14124), new ItemInfo(14125), new ItemInfo(14126), new ItemInfo(14127), new ItemInfo(14128), 
            new ItemInfo(14129), new ItemInfo(14130), new ItemInfo(14131), new ItemInfo(14132), new ItemInfo(14133), new ItemInfo(14134), new ItemInfo(14135), new ItemInfo(14136), new ItemInfo(14137), 
            new ItemInfo(14138), new ItemInfo(14139), new ItemInfo(14140), new ItemInfo(14141), new ItemInfo(14142), new ItemInfo(14143), new ItemInfo(14144), new ItemInfo(14145), new ItemInfo(14146), 
            new ItemInfo(14147), new ItemInfo(14148), new ItemInfo(14149), new ItemInfo(14150), new ItemInfo(14151), new ItemInfo(14152), new ItemInfo(14153), new ItemInfo(14154), new ItemInfo(14155), 
            new ItemInfo(14156), new ItemInfo(14157), new ItemInfo(14158), new ItemInfo(14159), new ItemInfo(14160), new ItemInfo(14161), new ItemInfo(14162), new ItemInfo(14163), new ItemInfo(14164), 
            new ItemInfo(14165), new ItemInfo(14166), new ItemInfo(14167), new ItemInfo(14168), new ItemInfo(14169), new ItemInfo(14170), new ItemInfo(14171), new ItemInfo(14172), new ItemInfo(14173), 
            new ItemInfo(14174), new ItemInfo(14175), new ItemInfo(14176), new ItemInfo(14177), new ItemInfo(14178), new ItemInfo(14179), new ItemInfo(14180), new ItemInfo(14181), new ItemInfo(14182), 
            new ItemInfo(14183), new ItemInfo(14184), new ItemInfo(14185), new ItemInfo(14186), new ItemInfo(14187), new ItemInfo(14188), new ItemInfo(14189), new ItemInfo(14190), new ItemInfo(14191), 
            new ItemInfo(14192), new ItemInfo(14193), new ItemInfo(14194), new ItemInfo(14195), new ItemInfo(14196), new ItemInfo(14197), new ItemInfo(14198), new ItemInfo(14199), new ItemInfo(14200), 
            new ItemInfo(14201), new ItemInfo(14202), new ItemInfo(14203), new ItemInfo(14204), new ItemInfo(14205), new ItemInfo(14206), new ItemInfo(14207), new ItemInfo(14208), new ItemInfo(14209), 
            new ItemInfo(14210), new ItemInfo(14211), new ItemInfo(14212), new ItemInfo(14213), new ItemInfo(14214), new ItemInfo(14215), new ItemInfo(14216), new ItemInfo(14217), new ItemInfo(14218), 
            new ItemInfo(14219), new ItemInfo(14220), new ItemInfo(14221), new ItemInfo(14222), new ItemInfo(14223), new ItemInfo(14224), new ItemInfo(14225), new ItemInfo(14226), new ItemInfo(14227), 
            new ItemInfo(14228), new ItemInfo(14229), new ItemInfo(14230), new ItemInfo(14231), new ItemInfo(14232), new ItemInfo(14233), new ItemInfo(14234), new ItemInfo(14235), new ItemInfo(14236), 
            new ItemInfo(14237), new ItemInfo(14238), new ItemInfo(14239), new ItemInfo(14240), new ItemInfo(14241), new ItemInfo(14242), new ItemInfo(14243), new ItemInfo(14244), new ItemInfo(14245), 
            new ItemInfo(14246), new ItemInfo(14247), new ItemInfo(14248), new ItemInfo(14249), new ItemInfo(14250), new ItemInfo(14251), new ItemInfo(14252), new ItemInfo(14253), new ItemInfo(14254), 
            new ItemInfo(14255), new ItemInfo(14256), new ItemInfo(14257), new ItemInfo(14258), new ItemInfo(14259), new ItemInfo(14260), new ItemInfo(14261), new ItemInfo(14262), new ItemInfo(14263), 
            new ItemInfo(14264), new ItemInfo(14265), new ItemInfo(14266), new ItemInfo(14267), new ItemInfo(14268), new ItemInfo(14269), new ItemInfo(14270), new ItemInfo(14271), new ItemInfo(14272), 
            new ItemInfo(14273), new ItemInfo(14274), new ItemInfo(14275), new ItemInfo(14276), new ItemInfo(14277), new ItemInfo(14278), new ItemInfo(14279), new ItemInfo(14280), new ItemInfo(14281), 
            new ItemInfo(14282), new ItemInfo(14283), new ItemInfo(14284), new ItemInfo(14285), new ItemInfo(14286), new ItemInfo(14287), new ItemInfo(14288), new ItemInfo(14289), new ItemInfo(14290), 
            new ItemInfo(14291), new ItemInfo(14292), new ItemInfo(14293), new ItemInfo(14294), new ItemInfo(14295), new ItemInfo(14296), new ItemInfo(14297), new ItemInfo(14298), new ItemInfo(14299), 
            new ItemInfo(14300), new ItemInfo(14301), new ItemInfo(14302), new ItemInfo(14303), new ItemInfo(14304), new ItemInfo(14305), new ItemInfo(14306), new ItemInfo(14307), new ItemInfo(14308), 
            new ItemInfo(14309), new ItemInfo(14310), new ItemInfo(14311), new ItemInfo(14312), new ItemInfo(14313), new ItemInfo(14314), new ItemInfo(14315), new ItemInfo(14316), new ItemInfo(14317), 
            new ItemInfo(14318), new ItemInfo(14319), new ItemInfo(14320), new ItemInfo(14321), new ItemInfo(14322), new ItemInfo(14323), new ItemInfo(14324), new ItemInfo(14325), new ItemInfo(14326), 
            new ItemInfo(14327), new ItemInfo(14328), new ItemInfo(14329), new ItemInfo(14330), new ItemInfo(14331), new ItemInfo(14332), new ItemInfo(14333), new ItemInfo(14334), new ItemInfo(14335), 
            new ItemInfo(14336), new ItemInfo(14337), new ItemInfo(14338), new ItemInfo(14339), new ItemInfo(14340), new ItemInfo(14341), new ItemInfo(14342), new ItemInfo(14343), new ItemInfo(14344), 
            new ItemInfo(14345), new ItemInfo(14346), new ItemInfo(14347), new ItemInfo(14348), new ItemInfo(14349), new ItemInfo(14350), new ItemInfo(14351), new ItemInfo(14352), new ItemInfo(14353), 
            new ItemInfo(14354), new ItemInfo(14355), new ItemInfo(14356), new ItemInfo(14357), new ItemInfo(14358), new ItemInfo(14359), new ItemInfo(14360), new ItemInfo(14361), new ItemInfo(14362), 
            new ItemInfo(14363), new ItemInfo(14364), new ItemInfo(14365), new ItemInfo(14366), new ItemInfo(14367), new ItemInfo(14368), new ItemInfo(14369), new ItemInfo(14370), new ItemInfo(14371), 
            new ItemInfo(14372), new ItemInfo(14373), new ItemInfo(14374), new ItemInfo(14375), new ItemInfo(14376), new ItemInfo(14377), new ItemInfo(14378), new ItemInfo(14379), new ItemInfo(14380), 
            new ItemInfo(14381), new ItemInfo(14382), new ItemInfo(14383), new ItemInfo(14384), new ItemInfo(14385), new ItemInfo(14386), new ItemInfo(14387), new ItemInfo(14388), new ItemInfo(14389), 
            new ItemInfo(14390), new ItemInfo(14391), new ItemInfo(14392), new ItemInfo(14393), new ItemInfo(14394), new ItemInfo(14395), new ItemInfo(14396), new ItemInfo(14397), new ItemInfo(14398), 
            new ItemInfo(14399), new ItemInfo(14400), new ItemInfo(14401), new ItemInfo(14402), new ItemInfo(14403), new ItemInfo(14404), new ItemInfo(14405), new ItemInfo(14406), new ItemInfo(14407), 
            new ItemInfo(14408), new ItemInfo(14409), new ItemInfo(14410), new ItemInfo(14411), new ItemInfo(14412), new ItemInfo(14413), new ItemInfo(14414), new ItemInfo(14415), new ItemInfo(14416), 
            new ItemInfo(14417), new ItemInfo(14418), new ItemInfo(14419), new ItemInfo(14420), new ItemInfo(14421), new ItemInfo(14422), new ItemInfo(14423), new ItemInfo(14424), new ItemInfo(14425), 
            new ItemInfo(14426), new ItemInfo(14427), new ItemInfo(14428), new ItemInfo(14429), new ItemInfo(14430), new ItemInfo(14431), new ItemInfo(14432), new ItemInfo(14433), new ItemInfo(14434), 
            new ItemInfo(14435), new ItemInfo(14436), new ItemInfo(14437), new ItemInfo(14438), new ItemInfo(14439), new ItemInfo(14440), new ItemInfo(14441), new ItemInfo(14442), new ItemInfo(14443), 
            new ItemInfo(14444), new ItemInfo(14445), new ItemInfo(14446), new ItemInfo(14447), new ItemInfo(14448), new ItemInfo(14449), new ItemInfo(14450), new ItemInfo(14451), new ItemInfo(14452)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt11Gump()
			: this(0)
		{ }

		public AddMisc2Pt11Gump(int page) 
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

			from.SendGump(new AddMisc2Pt11Gump(page));
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
