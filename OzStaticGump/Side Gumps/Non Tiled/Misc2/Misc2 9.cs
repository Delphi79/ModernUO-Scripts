using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt9Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt9", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt9_OnCommand));
		}

		[Usage("AddMisc2Pt9")]
		
		public static void AddMisc2Pt9_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt9Gump>();
			e.Mobile.SendGump(new AddMisc2Pt9Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(12079), new ItemInfo(12080), new ItemInfo(12081), new ItemInfo(12082), new ItemInfo(12083), new ItemInfo(12084), new ItemInfo(12085), new ItemInfo(12086), new ItemInfo(12087), 
            new ItemInfo(12088), new ItemInfo(12089), new ItemInfo(12090), new ItemInfo(12091), new ItemInfo(12092), new ItemInfo(12093), new ItemInfo(12094), new ItemInfo(12095), new ItemInfo(12096), 
            new ItemInfo(12097), new ItemInfo(12098), new ItemInfo(12099), new ItemInfo(12100), new ItemInfo(12101), new ItemInfo(12102), new ItemInfo(12103), new ItemInfo(12104), new ItemInfo(12105), 
            new ItemInfo(12106), new ItemInfo(12107), new ItemInfo(12108), new ItemInfo(12109), new ItemInfo(12110), new ItemInfo(12111), new ItemInfo(12112), new ItemInfo(12113), new ItemInfo(12114), 
            new ItemInfo(12115), new ItemInfo(12116), new ItemInfo(12117), new ItemInfo(12118), new ItemInfo(12119), new ItemInfo(12120), new ItemInfo(12121), new ItemInfo(12122), new ItemInfo(12123), 
            new ItemInfo(12124), new ItemInfo(12125), new ItemInfo(12126), new ItemInfo(12127), new ItemInfo(12128), new ItemInfo(12129), new ItemInfo(12214), new ItemInfo(12219), new ItemInfo(12220), 
            new ItemInfo(12221), new ItemInfo(12222), new ItemInfo(12223), new ItemInfo(12224), new ItemInfo(12225), new ItemInfo(12226), new ItemInfo(12236), new ItemInfo(12237), new ItemInfo(12238), 
            new ItemInfo(12239), new ItemInfo(12240), new ItemInfo(12241), new ItemInfo(12242), new ItemInfo(12243), new ItemInfo(12244), new ItemInfo(12245), new ItemInfo(12246), new ItemInfo(12249), 
            new ItemInfo(12250), new ItemInfo(12251), new ItemInfo(12252), new ItemInfo(12253), new ItemInfo(12254), new ItemInfo(12255), new ItemInfo(12256), new ItemInfo(12257), new ItemInfo(12258), 
            new ItemInfo(12259), new ItemInfo(12260), new ItemInfo(12261), new ItemInfo(12262), new ItemInfo(12263), new ItemInfo(12264), new ItemInfo(12265), new ItemInfo(12266), new ItemInfo(12267), 
            new ItemInfo(12268), new ItemInfo(12269), new ItemInfo(12270), new ItemInfo(12271), new ItemInfo(12272), new ItemInfo(12273), new ItemInfo(12274), new ItemInfo(12275), new ItemInfo(12276), 
            new ItemInfo(12277), new ItemInfo(12278), new ItemInfo(12279), new ItemInfo(12280), new ItemInfo(12281), new ItemInfo(12282), new ItemInfo(12283), new ItemInfo(12284), new ItemInfo(12285), 
            new ItemInfo(12286), new ItemInfo(12287), new ItemInfo(12288), new ItemInfo(12289), new ItemInfo(12290), new ItemInfo(12291), new ItemInfo(12296), new ItemInfo(12297), new ItemInfo(12298), 
            new ItemInfo(12299), new ItemInfo(12300), new ItemInfo(12301), new ItemInfo(12302), new ItemInfo(12303), new ItemInfo(12304), new ItemInfo(12305), new ItemInfo(12306), new ItemInfo(12307), 
            new ItemInfo(12308), new ItemInfo(12309), new ItemInfo(12310), new ItemInfo(12311), new ItemInfo(12312), new ItemInfo(12313), new ItemInfo(12314), new ItemInfo(12315), new ItemInfo(12316), 
            new ItemInfo(12317), new ItemInfo(12318), new ItemInfo(12319), new ItemInfo(12320), new ItemInfo(12321), new ItemInfo(12322), new ItemInfo(12323), new ItemInfo(12324), new ItemInfo(12325), 
            new ItemInfo(12326), new ItemInfo(12327), new ItemInfo(12328), new ItemInfo(12329), new ItemInfo(12330), new ItemInfo(12331), new ItemInfo(12332), new ItemInfo(12333), new ItemInfo(12334), 
            new ItemInfo(12335), new ItemInfo(12336), new ItemInfo(12337), new ItemInfo(12338), new ItemInfo(12339), new ItemInfo(12340), new ItemInfo(12341), new ItemInfo(12342), new ItemInfo(12343), 
            new ItemInfo(12344), new ItemInfo(12345), new ItemInfo(12346), new ItemInfo(12347), new ItemInfo(12348), new ItemInfo(12349), new ItemInfo(12350), new ItemInfo(12351), new ItemInfo(12352), 
            new ItemInfo(12353), new ItemInfo(12354), new ItemInfo(12355), new ItemInfo(12356), new ItemInfo(12357), new ItemInfo(12358), new ItemInfo(12359), new ItemInfo(12360), new ItemInfo(12361), 
            new ItemInfo(12362), new ItemInfo(12363), new ItemInfo(12378), new ItemInfo(12379), new ItemInfo(12380), new ItemInfo(12381), new ItemInfo(12382), new ItemInfo(12383), new ItemInfo(12384), 
            new ItemInfo(12385), new ItemInfo(12386), new ItemInfo(12387), new ItemInfo(12388), new ItemInfo(12389), new ItemInfo(12390), new ItemInfo(12391), new ItemInfo(12392), new ItemInfo(12393), 
            new ItemInfo(12394), new ItemInfo(12395), new ItemInfo(12396), new ItemInfo(12397), new ItemInfo(12398), new ItemInfo(12399), new ItemInfo(12400), new ItemInfo(12401), new ItemInfo(12402), 
            new ItemInfo(12403), new ItemInfo(12404), new ItemInfo(12405), new ItemInfo(12406), new ItemInfo(12407), new ItemInfo(12408), new ItemInfo(12409), new ItemInfo(12410), new ItemInfo(12411), 
            new ItemInfo(12412), new ItemInfo(12413), new ItemInfo(12414), new ItemInfo(12415), new ItemInfo(12416), new ItemInfo(12417), new ItemInfo(12418), new ItemInfo(12419), new ItemInfo(12570), 
            new ItemInfo(12571), new ItemInfo(12572), new ItemInfo(12573), new ItemInfo(12574), new ItemInfo(12575), new ItemInfo(12576), new ItemInfo(12577), new ItemInfo(12581), new ItemInfo(12582), 
            new ItemInfo(12583), new ItemInfo(12584), new ItemInfo(12585), new ItemInfo(12586), new ItemInfo(12587), new ItemInfo(12588), new ItemInfo(12589), new ItemInfo(12590), new ItemInfo(12591), 
            new ItemInfo(12592), new ItemInfo(12593), new ItemInfo(12594), new ItemInfo(12595), new ItemInfo(12596), new ItemInfo(12597), new ItemInfo(12598), new ItemInfo(12599), new ItemInfo(12600), 
            new ItemInfo(12601), new ItemInfo(12602), new ItemInfo(12603), new ItemInfo(12604), new ItemInfo(12605), new ItemInfo(12606), new ItemInfo(12607), new ItemInfo(12608), new ItemInfo(12609), 
            new ItemInfo(12610), new ItemInfo(12611), new ItemInfo(12612), new ItemInfo(12613), new ItemInfo(12614), new ItemInfo(12615), new ItemInfo(12616), new ItemInfo(12617), new ItemInfo(12618), 
            new ItemInfo(12619), new ItemInfo(12620), new ItemInfo(12621), new ItemInfo(12622), new ItemInfo(12623), new ItemInfo(12624), new ItemInfo(12625), new ItemInfo(12626), new ItemInfo(12627), 
            new ItemInfo(12628), new ItemInfo(12629), new ItemInfo(12630), new ItemInfo(12631), new ItemInfo(12632), new ItemInfo(12633), new ItemInfo(12634), new ItemInfo(12635), new ItemInfo(12636), 
            new ItemInfo(12637), new ItemInfo(12674), new ItemInfo(12675), new ItemInfo(12676), new ItemInfo(12677), new ItemInfo(12678), new ItemInfo(12679), new ItemInfo(12680), new ItemInfo(12681), 
            new ItemInfo(12682), new ItemInfo(12683), new ItemInfo(12684), new ItemInfo(12685), new ItemInfo(12686), new ItemInfo(12687), new ItemInfo(12688), new ItemInfo(12689), new ItemInfo(12690), 
            new ItemInfo(12691), new ItemInfo(12692), new ItemInfo(12693), new ItemInfo(12694), new ItemInfo(12695), new ItemInfo(12696), new ItemInfo(12697), new ItemInfo(12700), new ItemInfo(12701), 
            new ItemInfo(12702), new ItemInfo(12703), new ItemInfo(12704), new ItemInfo(12705), new ItemInfo(12706), new ItemInfo(12707), new ItemInfo(12708), new ItemInfo(12709), new ItemInfo(12710), 
            new ItemInfo(12711), new ItemInfo(12712), new ItemInfo(12713), new ItemInfo(12714), new ItemInfo(12715), new ItemInfo(12716), new ItemInfo(12717), new ItemInfo(12718), new ItemInfo(12719), 
            new ItemInfo(12720), new ItemInfo(12721), new ItemInfo(12722), new ItemInfo(12723), new ItemInfo(12724), new ItemInfo(12725), new ItemInfo(12726), new ItemInfo(12727), new ItemInfo(12728), 
            new ItemInfo(12729), new ItemInfo(12730), new ItemInfo(12731), new ItemInfo(12732), new ItemInfo(12733), new ItemInfo(12734), new ItemInfo(12735), new ItemInfo(12736), new ItemInfo(12978), 
            new ItemInfo(12979), new ItemInfo(12980), new ItemInfo(12981), new ItemInfo(12982), new ItemInfo(12983), new ItemInfo(12984), new ItemInfo(12985), new ItemInfo(12986), new ItemInfo(12987)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt9Gump()
			: this(0)
		{ }

		public AddMisc2Pt9Gump(int page) 
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

			from.SendGump(new AddMisc2Pt9Gump(page));
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
