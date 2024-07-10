using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt17Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt17", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt17_OnCommand));
		}

		[Usage("AddCustomPt17")]
		
		public static void AddCustomPt17_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt17Gump>();
			e.Mobile.SendGump(new AddCustomPt17Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(42504), new ItemInfo(42505), new ItemInfo(42506), new ItemInfo(42507), new ItemInfo(42508), new ItemInfo(42509), new ItemInfo(42510), new ItemInfo(42511), new ItemInfo(42512), 
			new ItemInfo(42513), new ItemInfo(42514), new ItemInfo(42515), new ItemInfo(42516), new ItemInfo(42517), new ItemInfo(42518), new ItemInfo(42519), new ItemInfo(42520), new ItemInfo(42521), 
			new ItemInfo(42522), new ItemInfo(42523), new ItemInfo(42524), new ItemInfo(42525), new ItemInfo(42526), new ItemInfo(42527), new ItemInfo(42528), new ItemInfo(42529), new ItemInfo(42530), 
			new ItemInfo(42531), new ItemInfo(42532), new ItemInfo(42533), new ItemInfo(42534), new ItemInfo(42535), new ItemInfo(42536), new ItemInfo(42537), new ItemInfo(42538), new ItemInfo(42539),
			new ItemInfo(42540), new ItemInfo(42541), new ItemInfo(42542), new ItemInfo(42543), new ItemInfo(42544), new ItemInfo(42545), new ItemInfo(42546), new ItemInfo(42547), new ItemInfo(42548), 
			new ItemInfo(42549), new ItemInfo(42550), new ItemInfo(42551), new ItemInfo(42552), new ItemInfo(42553), new ItemInfo(42554), new ItemInfo(42555), new ItemInfo(42556), new ItemInfo(42557), 
			new ItemInfo(42558), new ItemInfo(42559), new ItemInfo(42560), new ItemInfo(42561), new ItemInfo(42562), new ItemInfo(42563), new ItemInfo(42564), new ItemInfo(42565), new ItemInfo(42573), 
			new ItemInfo(42574), new ItemInfo(42575), new ItemInfo(42576), new ItemInfo(42577), new ItemInfo(42578), new ItemInfo(42579), new ItemInfo(42580), new ItemInfo(42582), new ItemInfo(42583), 
			new ItemInfo(42584), new ItemInfo(42585), new ItemInfo(42586), new ItemInfo(42587), new ItemInfo(42588), new ItemInfo(42589), new ItemInfo(42590), new ItemInfo(42591), new ItemInfo(42592), 
			new ItemInfo(42593), new ItemInfo(42594), new ItemInfo(42595), new ItemInfo(42596), new ItemInfo(42597), new ItemInfo(42598), new ItemInfo(42599), new ItemInfo(42600), new ItemInfo(42601), 
			new ItemInfo(42602), new ItemInfo(42603), new ItemInfo(42604), new ItemInfo(42605), new ItemInfo(42606), new ItemInfo(42607), new ItemInfo(42608), new ItemInfo(42609), new ItemInfo(42610), 
			new ItemInfo(42611), new ItemInfo(42612), new ItemInfo(42613), new ItemInfo(42614), new ItemInfo(42615), new ItemInfo(42616), new ItemInfo(42617), new ItemInfo(42618), new ItemInfo(42619), 
			new ItemInfo(42620), new ItemInfo(42621), new ItemInfo(42622), new ItemInfo(42623), new ItemInfo(42624), new ItemInfo(42625), new ItemInfo(42626), new ItemInfo(42627), new ItemInfo(42628), 
			new ItemInfo(42629), new ItemInfo(42630), new ItemInfo(42631), new ItemInfo(42632), new ItemInfo(42633), new ItemInfo(42634), new ItemInfo(42635), new ItemInfo(42636), new ItemInfo(42637), 
			new ItemInfo(42638), new ItemInfo(42639), new ItemInfo(42640), new ItemInfo(42641), new ItemInfo(42642), new ItemInfo(42643), new ItemInfo(42644), new ItemInfo(42645), new ItemInfo(42646), 
			new ItemInfo(42647), new ItemInfo(42648), new ItemInfo(42649), new ItemInfo(42650), new ItemInfo(42651), new ItemInfo(42652), new ItemInfo(42653), new ItemInfo(42656), new ItemInfo(42657), 
			new ItemInfo(42658), new ItemInfo(42659), new ItemInfo(42660), new ItemInfo(42661), new ItemInfo(42662), new ItemInfo(42663), new ItemInfo(42664), new ItemInfo(42665), new ItemInfo(42666), 
			new ItemInfo(42667), new ItemInfo(42668), new ItemInfo(42669), new ItemInfo(42670), new ItemInfo(42671), new ItemInfo(42672), new ItemInfo(42673), new ItemInfo(42674), new ItemInfo(42675), 
			new ItemInfo(42676), new ItemInfo(42677), new ItemInfo(42678), new ItemInfo(42679), new ItemInfo(42680), new ItemInfo(42681), new ItemInfo(42682), new ItemInfo(42683), new ItemInfo(42684), 
			new ItemInfo(42685), new ItemInfo(42686), new ItemInfo(42687), new ItemInfo(42688), new ItemInfo(42689), new ItemInfo(42690), new ItemInfo(42691), new ItemInfo(42692), new ItemInfo(42693), 
			new ItemInfo(42694), new ItemInfo(42695), new ItemInfo(42696), new ItemInfo(42697), new ItemInfo(42698), new ItemInfo(42699), new ItemInfo(42700), new ItemInfo(42703), new ItemInfo(42704), 
			new ItemInfo(42705), new ItemInfo(42706), new ItemInfo(42707), new ItemInfo(42708), new ItemInfo(42709), new ItemInfo(42710), new ItemInfo(42711), new ItemInfo(42712), new ItemInfo(42713), 
			new ItemInfo(42714), new ItemInfo(42715), new ItemInfo(42716), new ItemInfo(42717), new ItemInfo(42719), new ItemInfo(42720), new ItemInfo(42721), new ItemInfo(42722), new ItemInfo(42723), 
			new ItemInfo(42724), new ItemInfo(42725), new ItemInfo(42726), new ItemInfo(42727), new ItemInfo(42728), new ItemInfo(42729), new ItemInfo(42730), new ItemInfo(42731), new ItemInfo(42732), 
			new ItemInfo(42733), new ItemInfo(42734), new ItemInfo(42735), new ItemInfo(42736), new ItemInfo(42738), new ItemInfo(42739), new ItemInfo(42740), new ItemInfo(42741), new ItemInfo(42742)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt17Gump()
			: this(0)
		{ }

		public AddCustomPt17Gump(int page) 
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

			from.SendGump(new AddCustomPt17Gump(page));
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
