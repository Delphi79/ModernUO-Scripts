using Server.Network;

namespace Server.Gumps
{
	public class AddWallPt8Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddWallPt8", AccessLevel.GameMaster, new CommandEventHandler(AddWallPt8_OnCommand));
		}

		[Usage("AddWallPt8")]
		
		public static void AddWallPt8_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddWallPt8Gump>();
			e.Mobile.SendGump(new AddWallPt8Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(41714), new ItemInfo(41715), new ItemInfo(41716), new ItemInfo(41717), new ItemInfo(41718), new ItemInfo(41719), new ItemInfo(41720), new ItemInfo(41723), 
            new ItemInfo(41724), new ItemInfo(41725), new ItemInfo(41726), new ItemInfo(41727), new ItemInfo(42370), new ItemInfo(42371), new ItemInfo(42372), new ItemInfo(42373), 
            new ItemInfo(42374), new ItemInfo(42375), new ItemInfo(42376), new ItemInfo(42377), new ItemInfo(42378), new ItemInfo(42379), new ItemInfo(42380), new ItemInfo(42381), 
            new ItemInfo(42448), new ItemInfo(42449), new ItemInfo(42450), new ItemInfo(42451), new ItemInfo(42452), new ItemInfo(42453), new ItemInfo(42454), new ItemInfo(42455), 
            new ItemInfo(42456), new ItemInfo(42457), new ItemInfo(42458), new ItemInfo(42459), new ItemInfo(42460), new ItemInfo(42461), new ItemInfo(42462), new ItemInfo(42463), 
            new ItemInfo(42464), new ItemInfo(42465), new ItemInfo(42466), new ItemInfo(42467), new ItemInfo(42468), new ItemInfo(42469), new ItemInfo(42470), new ItemInfo(42471), 
            new ItemInfo(42473), new ItemInfo(42474), new ItemInfo(42475), new ItemInfo(42476), new ItemInfo(42477), new ItemInfo(42478), new ItemInfo(42479), new ItemInfo(42480), 
            new ItemInfo(42481), new ItemInfo(42482), new ItemInfo(42483), new ItemInfo(42484), new ItemInfo(42485), new ItemInfo(42486), new ItemInfo(42487), new ItemInfo(42488), 
            new ItemInfo(42489), new ItemInfo(42490), new ItemInfo(42491), new ItemInfo(42492), new ItemInfo(42493), new ItemInfo(42494), new ItemInfo(42495), new ItemInfo(42496), 
            new ItemInfo(42497), new ItemInfo(42498), new ItemInfo(42499), new ItemInfo(42500), new ItemInfo(42501), new ItemInfo(42502), new ItemInfo(42503), new ItemInfo(42504), 
            new ItemInfo(42505), new ItemInfo(42506), new ItemInfo(42507), new ItemInfo(42508), new ItemInfo(42509), new ItemInfo(42510), new ItemInfo(42511), new ItemInfo(42516), 
            new ItemInfo(42517), new ItemInfo(42518), new ItemInfo(42519), new ItemInfo(42520), new ItemInfo(42521), new ItemInfo(42522), new ItemInfo(42523), new ItemInfo(42524), 
            new ItemInfo(42525), new ItemInfo(42526), new ItemInfo(42527), new ItemInfo(42528), new ItemInfo(42529), new ItemInfo(42530), new ItemInfo(42531), new ItemInfo(42532), 
            new ItemInfo(42533), new ItemInfo(42534), new ItemInfo(42535), new ItemInfo(42536), new ItemInfo(42537), new ItemInfo(42538), new ItemInfo(42539), new ItemInfo(42540), 
            new ItemInfo(42541), new ItemInfo(42542), new ItemInfo(42543), new ItemInfo(42544), new ItemInfo(42545), new ItemInfo(42546), new ItemInfo(42547), new ItemInfo(42548), 
            new ItemInfo(42549), new ItemInfo(42550), new ItemInfo(42551), new ItemInfo(42552), new ItemInfo(42553), new ItemInfo(42554), new ItemInfo(42555), new ItemInfo(42556), 
            new ItemInfo(42557), new ItemInfo(42558), new ItemInfo(42559), new ItemInfo(42560), new ItemInfo(42561), new ItemInfo(42562), new ItemInfo(42563), new ItemInfo(42564), 
            new ItemInfo(42582), new ItemInfo(42583), new ItemInfo(42584), new ItemInfo(42585), new ItemInfo(42586), new ItemInfo(42587), new ItemInfo(42588), new ItemInfo(42589), 
            new ItemInfo(42590), new ItemInfo(42591), new ItemInfo(42592), new ItemInfo(42593), new ItemInfo(42594), new ItemInfo(42595), new ItemInfo(42596), new ItemInfo(42597), 
            new ItemInfo(42598), new ItemInfo(42599), new ItemInfo(42600), new ItemInfo(42601), new ItemInfo(42602), new ItemInfo(42603), new ItemInfo(42604), new ItemInfo(42605), 
            new ItemInfo(42606), new ItemInfo(42607), new ItemInfo(42608), new ItemInfo(42609), new ItemInfo(42610), new ItemInfo(42611), new ItemInfo(42612), new ItemInfo(42613), 
            new ItemInfo(42614), new ItemInfo(42615), new ItemInfo(42616), new ItemInfo(42617), new ItemInfo(42618), new ItemInfo(42619), new ItemInfo(42620), new ItemInfo(42621), 
            new ItemInfo(42622), new ItemInfo(42623), new ItemInfo(42624), new ItemInfo(42625), new ItemInfo(42626), new ItemInfo(42627), new ItemInfo(42628), new ItemInfo(42629), 
            new ItemInfo(42630), new ItemInfo(42631), new ItemInfo(42632), new ItemInfo(42633), new ItemInfo(42634), new ItemInfo(42635), new ItemInfo(42636), new ItemInfo(42637), 
            new ItemInfo(42638), new ItemInfo(42639), new ItemInfo(42640), new ItemInfo(42641), new ItemInfo(42642), new ItemInfo(42643), new ItemInfo(42644), new ItemInfo(42645), 
            new ItemInfo(42646), new ItemInfo(42647), new ItemInfo(42648), new ItemInfo(42649), new ItemInfo(42650), new ItemInfo(42651), new ItemInfo(42652), new ItemInfo(42653), 
            new ItemInfo(43162), new ItemInfo(43163), new ItemInfo(43164), new ItemInfo(43165), new ItemInfo(43166), new ItemInfo(43167), new ItemInfo(43168), new ItemInfo(43169), 
            new ItemInfo(43170), new ItemInfo(43171), new ItemInfo(43172), new ItemInfo(43173), new ItemInfo(43174), new ItemInfo(43175), new ItemInfo(43176), new ItemInfo(43177), 
            new ItemInfo(43178), new ItemInfo(43179), new ItemInfo(43180), new ItemInfo(43181), new ItemInfo(43182), new ItemInfo(43183), new ItemInfo(43184), new ItemInfo(43185), 
            new ItemInfo(43186), new ItemInfo(43187), new ItemInfo(43193), new ItemInfo(43194), new ItemInfo(43195), new ItemInfo(43196), new ItemInfo(43197), new ItemInfo(43198), 
            new ItemInfo(43199), new ItemInfo(43200), new ItemInfo(43201), new ItemInfo(43202), new ItemInfo(43203), new ItemInfo(43204), new ItemInfo(43205), new ItemInfo(43206), 
            new ItemInfo(43207), new ItemInfo(43208), new ItemInfo(43209), new ItemInfo(43210), new ItemInfo(43211), new ItemInfo(43212), new ItemInfo(43213), new ItemInfo(43214), 
            new ItemInfo(43215), new ItemInfo(43216), new ItemInfo(43217), new ItemInfo(43218), new ItemInfo(43219), new ItemInfo(43220), new ItemInfo(43221), new ItemInfo(43222), 
            new ItemInfo(43223), new ItemInfo(43224), new ItemInfo(43225), new ItemInfo(43226), new ItemInfo(43227), new ItemInfo(43228), new ItemInfo(43229), new ItemInfo(43230), 
            new ItemInfo(43231), new ItemInfo(43232), new ItemInfo(43233), new ItemInfo(43234), new ItemInfo(43235), new ItemInfo(43236), new ItemInfo(43237), new ItemInfo(43238), 
            new ItemInfo(43239), new ItemInfo(43240), new ItemInfo(43241), new ItemInfo(43242), new ItemInfo(43243), new ItemInfo(43244), new ItemInfo(43245), new ItemInfo(43246), 
            new ItemInfo(43247), new ItemInfo(43248), new ItemInfo(43249), new ItemInfo(43250), new ItemInfo(43251), new ItemInfo(43252), new ItemInfo(43253), new ItemInfo(43254), 
            new ItemInfo(43255), new ItemInfo(43256), new ItemInfo(43257), new ItemInfo(43258), new ItemInfo(43259), new ItemInfo(43260), new ItemInfo(43261), new ItemInfo(43262), 
            new ItemInfo(43263), new ItemInfo(43264), new ItemInfo(43265), new ItemInfo(43283), new ItemInfo(43284), new ItemInfo(43285), new ItemInfo(43286), new ItemInfo(43287), 
            new ItemInfo(43288), new ItemInfo(43289), new ItemInfo(43290), new ItemInfo(43291), new ItemInfo(43292), new ItemInfo(43293), new ItemInfo(43294), new ItemInfo(43295), 
            new ItemInfo(43296), new ItemInfo(43297), new ItemInfo(43298)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddWallPt8Gump()
			: this(0)
		{ }

		public AddWallPt8Gump(int page) 
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

			from.SendGump(new AddWallPt8Gump(page));
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
