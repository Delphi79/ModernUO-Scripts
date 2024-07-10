using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt14Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt14", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt14_OnCommand));
		}

		[Usage("AddMisc2Pt14")]
		
		public static void AddMisc2Pt14_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt14Gump>();
			e.Mobile.SendGump(new AddMisc2Pt14Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(16153), new ItemInfo(16154), new ItemInfo(16155), new ItemInfo(16156), new ItemInfo(16157), new ItemInfo(16158), new ItemInfo(16159), new ItemInfo(16160), new ItemInfo(16161), 
            new ItemInfo(16162), new ItemInfo(16163), new ItemInfo(16164), new ItemInfo(16165), new ItemInfo(16166), new ItemInfo(16167), new ItemInfo(16168), new ItemInfo(16169), new ItemInfo(16170), 
            new ItemInfo(16171), new ItemInfo(16172), new ItemInfo(16173), new ItemInfo(16174), new ItemInfo(16175), new ItemInfo(16176), new ItemInfo(16177), new ItemInfo(16178), new ItemInfo(16179), 
            new ItemInfo(16180), new ItemInfo(16181), new ItemInfo(16182), new ItemInfo(16183), new ItemInfo(16184), new ItemInfo(16185), new ItemInfo(16186), new ItemInfo(16187), new ItemInfo(16188), 
            new ItemInfo(16189), new ItemInfo(16190), new ItemInfo(16191), new ItemInfo(16192), new ItemInfo(16193), new ItemInfo(16194), new ItemInfo(16195), new ItemInfo(16196), new ItemInfo(16197), 
            new ItemInfo(16198), new ItemInfo(16199), new ItemInfo(16200), new ItemInfo(16201), new ItemInfo(16202), new ItemInfo(16203), new ItemInfo(16204), new ItemInfo(16205), new ItemInfo(16206), 
            new ItemInfo(16207), new ItemInfo(16208), new ItemInfo(16209), new ItemInfo(16210), new ItemInfo(16211), new ItemInfo(16212), new ItemInfo(16213), new ItemInfo(16214), new ItemInfo(16215), 
            new ItemInfo(16216), new ItemInfo(16217), new ItemInfo(16218), new ItemInfo(16219), new ItemInfo(16220), new ItemInfo(16221), new ItemInfo(16222), new ItemInfo(16223), new ItemInfo(16224), 
            new ItemInfo(16225), new ItemInfo(16226), new ItemInfo(16227), new ItemInfo(16228), new ItemInfo(16229), new ItemInfo(16230), new ItemInfo(16231), new ItemInfo(16232), new ItemInfo(16233), 
            new ItemInfo(16234), new ItemInfo(16235), new ItemInfo(16236), new ItemInfo(16237), new ItemInfo(16238), new ItemInfo(16239), new ItemInfo(16240), new ItemInfo(16241), new ItemInfo(16242), 
            new ItemInfo(16243), new ItemInfo(16244), new ItemInfo(16245), new ItemInfo(16246), new ItemInfo(16247), new ItemInfo(16248), new ItemInfo(16249), new ItemInfo(16250), new ItemInfo(16251), 
            new ItemInfo(16252), new ItemInfo(16253), new ItemInfo(16254), new ItemInfo(16255), new ItemInfo(16256), new ItemInfo(16257), new ItemInfo(16258), new ItemInfo(16259), new ItemInfo(16260), 
            new ItemInfo(16261), new ItemInfo(16262), new ItemInfo(16263), new ItemInfo(16264), new ItemInfo(16265), new ItemInfo(16266), new ItemInfo(16267), new ItemInfo(16268), new ItemInfo(16269), 
            new ItemInfo(16270), new ItemInfo(16271), new ItemInfo(16272), new ItemInfo(16273), new ItemInfo(16274), new ItemInfo(16275), new ItemInfo(16276), new ItemInfo(16277), new ItemInfo(16278), 
            new ItemInfo(16279), new ItemInfo(16280), new ItemInfo(16281), new ItemInfo(16282), new ItemInfo(16283), new ItemInfo(16284), new ItemInfo(16285), new ItemInfo(16286), new ItemInfo(16287), 
            new ItemInfo(16288), new ItemInfo(16289), new ItemInfo(16290), new ItemInfo(16291), new ItemInfo(16292), new ItemInfo(16293), new ItemInfo(16294), new ItemInfo(16295), new ItemInfo(16296), 
            new ItemInfo(16297), new ItemInfo(16298), new ItemInfo(16299), new ItemInfo(16300), new ItemInfo(16301), new ItemInfo(16302), new ItemInfo(16303), new ItemInfo(16304), new ItemInfo(16305), 
            new ItemInfo(16306), new ItemInfo(16307), new ItemInfo(16308), new ItemInfo(16309), new ItemInfo(16310), new ItemInfo(16311), new ItemInfo(16312), new ItemInfo(16313), new ItemInfo(16314), 
            new ItemInfo(16315), new ItemInfo(16316), new ItemInfo(16317), new ItemInfo(16318), new ItemInfo(16319), new ItemInfo(16320), new ItemInfo(16321), new ItemInfo(16322), new ItemInfo(16323), 
            new ItemInfo(16324), new ItemInfo(16325), new ItemInfo(16326), new ItemInfo(16327), new ItemInfo(16328), new ItemInfo(16329), new ItemInfo(16330), new ItemInfo(16331), new ItemInfo(16332), 
            new ItemInfo(16333), new ItemInfo(16334), new ItemInfo(16335), new ItemInfo(16336), new ItemInfo(16337), new ItemInfo(16338), new ItemInfo(16339), new ItemInfo(16340), new ItemInfo(16341), 
            new ItemInfo(16342), new ItemInfo(16343), new ItemInfo(16344), new ItemInfo(16345), new ItemInfo(16346), new ItemInfo(16347), new ItemInfo(16348), new ItemInfo(16349), new ItemInfo(16350), 
            new ItemInfo(16351), new ItemInfo(16352), new ItemInfo(16353), new ItemInfo(16354), new ItemInfo(16355), new ItemInfo(16356), new ItemInfo(16357), new ItemInfo(16358), new ItemInfo(16359), 
            new ItemInfo(16360), new ItemInfo(16361), new ItemInfo(16362), new ItemInfo(16363), new ItemInfo(16364), new ItemInfo(16365), new ItemInfo(16366), new ItemInfo(16367), new ItemInfo(16368), 
            new ItemInfo(16369), new ItemInfo(16370), new ItemInfo(16371), new ItemInfo(16372), new ItemInfo(16373), new ItemInfo(16374), new ItemInfo(16375), new ItemInfo(16376), new ItemInfo(16377), 
            new ItemInfo(16378), new ItemInfo(16379), new ItemInfo(16380), new ItemInfo(16381), new ItemInfo(16382), new ItemInfo(16383), new ItemInfo(16388), new ItemInfo(16389), new ItemInfo(16390), 
            new ItemInfo(16391), new ItemInfo(16392), new ItemInfo(16393), new ItemInfo(16394), new ItemInfo(16395), new ItemInfo(16418), new ItemInfo(16421), new ItemInfo(16422), new ItemInfo(16503), 
            new ItemInfo(16504), new ItemInfo(16505), new ItemInfo(16506), new ItemInfo(16507), new ItemInfo(16508), new ItemInfo(16509), new ItemInfo(16539), new ItemInfo(16540), new ItemInfo(16541), 
            new ItemInfo(16542), new ItemInfo(16543), new ItemInfo(16544), new ItemInfo(16545), new ItemInfo(16546), new ItemInfo(16572), new ItemInfo(16573), new ItemInfo(16574), new ItemInfo(16575), 
            new ItemInfo(16576), new ItemInfo(16602), new ItemInfo(16603), new ItemInfo(16604), new ItemInfo(16605), new ItemInfo(16606), new ItemInfo(16607), new ItemInfo(16608), new ItemInfo(16609), 
            new ItemInfo(16610), new ItemInfo(16611), new ItemInfo(16612), new ItemInfo(16613), new ItemInfo(16614), new ItemInfo(16615), new ItemInfo(16616), new ItemInfo(16617), new ItemInfo(16618), 
            new ItemInfo(16619), new ItemInfo(16620), new ItemInfo(16621), new ItemInfo(16622), new ItemInfo(16623), new ItemInfo(16624), new ItemInfo(16625), new ItemInfo(16626), new ItemInfo(16627), 
            new ItemInfo(16628), new ItemInfo(16629), new ItemInfo(16630), new ItemInfo(16631), new ItemInfo(16632), new ItemInfo(16633), new ItemInfo(16634), new ItemInfo(16635), new ItemInfo(16636), 
            new ItemInfo(16637), new ItemInfo(16638), new ItemInfo(16639), new ItemInfo(16640), new ItemInfo(16641), new ItemInfo(16642), new ItemInfo(16643), new ItemInfo(16644), new ItemInfo(16645), 
            new ItemInfo(16646), new ItemInfo(16647), new ItemInfo(16648), new ItemInfo(16649), new ItemInfo(16650), new ItemInfo(16651), new ItemInfo(16652), new ItemInfo(16653), new ItemInfo(16654), 
            new ItemInfo(16655), new ItemInfo(16656), new ItemInfo(16657), new ItemInfo(16658), new ItemInfo(16659), new ItemInfo(16667), new ItemInfo(16668), new ItemInfo(16669), new ItemInfo(16670), 
            new ItemInfo(16671), new ItemInfo(16672), new ItemInfo(16673), new ItemInfo(16674), new ItemInfo(16678), new ItemInfo(16679), new ItemInfo(16680), new ItemInfo(16681), new ItemInfo(16682), 
            new ItemInfo(16683), new ItemInfo(16684), new ItemInfo(16685), new ItemInfo(16686), new ItemInfo(16687), new ItemInfo(16688), new ItemInfo(16689), new ItemInfo(16690), new ItemInfo(16691), 
            new ItemInfo(16692), new ItemInfo(16693), new ItemInfo(16694), new ItemInfo(16695), new ItemInfo(16696), new ItemInfo(16697), new ItemInfo(16698), new ItemInfo(16699), new ItemInfo(16700), 
            new ItemInfo(16701), new ItemInfo(16702), new ItemInfo(16703), new ItemInfo(16704), new ItemInfo(16705), new ItemInfo(16706), new ItemInfo(16707), new ItemInfo(16708), new ItemInfo(16709)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt14Gump()
			: this(0)
		{ }

		public AddMisc2Pt14Gump(int page) 
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

			from.SendGump(new AddMisc2Pt14Gump(page));
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
