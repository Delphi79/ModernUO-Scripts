using Server.Network;

namespace Server.Gumps
{
	public class AddArchGump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddArch", AccessLevel.GameMaster, new CommandEventHandler(AddArch_OnCommand));
		}

		[Usage("AddArch")]
		
		public static void AddArch_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddArchGump>();
			e.Mobile.SendGump(new AddArchGump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(40), new ItemInfo(41), new ItemInfo(42), new ItemInfo(43), new ItemInfo(44), 
            new ItemInfo(69), new ItemInfo(70), new ItemInfo(71), new ItemInfo(72), new ItemInfo(73), new ItemInfo(109), new ItemInfo(110), new ItemInfo(111), new ItemInfo(112), new ItemInfo(113), 
            new ItemInfo(114), new ItemInfo(115), new ItemInfo(116), new ItemInfo(117), new ItemInfo(118), new ItemInfo(119), new ItemInfo(120), new ItemInfo(121), new ItemInfo(122), new ItemInfo(123), 
            new ItemInfo(124), new ItemInfo(125), new ItemInfo(126), new ItemInfo(127), new ItemInfo(134), new ItemInfo(135), new ItemInfo(136), new ItemInfo(137), new ItemInfo(138), new ItemInfo(139), 
            new ItemInfo(198), new ItemInfo(205), new ItemInfo(206), new ItemInfo(207), new ItemInfo(208), new ItemInfo(209), new ItemInfo(210), new ItemInfo(211), new ItemInfo(212), new ItemInfo(213), 
            new ItemInfo(214), new ItemInfo(215), new ItemInfo(216), new ItemInfo(217), new ItemInfo(218), new ItemInfo(219), new ItemInfo(220), new ItemInfo(221), new ItemInfo(222), new ItemInfo(223), 
            new ItemInfo(224), new ItemInfo(225), new ItemInfo(226), new ItemInfo(227), new ItemInfo(228), new ItemInfo(229), new ItemInfo(230), new ItemInfo(231), new ItemInfo(232), new ItemInfo(233), 
            new ItemInfo(234), new ItemInfo(235), new ItemInfo(236), new ItemInfo(237), new ItemInfo(238), new ItemInfo(239), new ItemInfo(240), new ItemInfo(241), new ItemInfo(242), new ItemInfo(243), 
            new ItemInfo(244), new ItemInfo(245), new ItemInfo(246), new ItemInfo(247), new ItemInfo(274), new ItemInfo(275), new ItemInfo(276), new ItemInfo(277), new ItemInfo(278), new ItemInfo(279), 
            new ItemInfo(280), new ItemInfo(281), new ItemInfo(282), new ItemInfo(316), new ItemInfo(317), new ItemInfo(318), new ItemInfo(319), new ItemInfo(320), new ItemInfo(321), new ItemInfo(322), 
            new ItemInfo(323), new ItemInfo(324), new ItemInfo(325), new ItemInfo(326), new ItemInfo(327), new ItemInfo(328), new ItemInfo(329), new ItemInfo(330), new ItemInfo(331), new ItemInfo(364), 
            new ItemInfo(365), new ItemInfo(366), new ItemInfo(367), new ItemInfo(368), new ItemInfo(469), new ItemInfo(470), new ItemInfo(471), new ItemInfo(472), new ItemInfo(473), new ItemInfo(474), 
            new ItemInfo(475), new ItemInfo(476), new ItemInfo(477), new ItemInfo(478), new ItemInfo(479), new ItemInfo(549), new ItemInfo(581), new ItemInfo(582), new ItemInfo(583), new ItemInfo(584), new ItemInfo(585), 
            new ItemInfo(586), new ItemInfo(688), new ItemInfo(689), new ItemInfo(690), new ItemInfo(691), new ItemInfo(692), new ItemInfo(919), new ItemInfo(920), new ItemInfo(921), new ItemInfo(922), 
            new ItemInfo(923), new ItemInfo(924), new ItemInfo(925), new ItemInfo(926), new ItemInfo(927), new ItemInfo(928), new ItemInfo(1080), new ItemInfo(1081), new ItemInfo(1082), new ItemInfo(1083), 
            new ItemInfo(1084), new ItemInfo(1085), new ItemInfo(1086), new ItemInfo(1087), new ItemInfo(1088), new ItemInfo(1089), new ItemInfo(1090), new ItemInfo(1091), new ItemInfo(1092), new ItemInfo(1093), 
            new ItemInfo(1094), new ItemInfo(1095), new ItemInfo(1096), new ItemInfo(1097), new ItemInfo(1098), new ItemInfo(1099), new ItemInfo(1100), new ItemInfo(1101), new ItemInfo(1102), new ItemInfo(1103), 
            new ItemInfo(1104), new ItemInfo(1105), new ItemInfo(1106), new ItemInfo(1107), new ItemInfo(10716), new ItemInfo(10717), new ItemInfo(10718), new ItemInfo(10719), new ItemInfo(10720), new ItemInfo(10721), 
            new ItemInfo(10722), new ItemInfo(10723), new ItemInfo(10724), new ItemInfo(10725), new ItemInfo(11177), new ItemInfo(11178), new ItemInfo(11179), new ItemInfo(11180), new ItemInfo(11181), new ItemInfo(11203), 
            new ItemInfo(11204), new ItemInfo(11205), new ItemInfo(11206), new ItemInfo(11711), new ItemInfo(11712), new ItemInfo(11713), new ItemInfo(11714), new ItemInfo(12059), new ItemInfo(12060), new ItemInfo(12061), 
            new ItemInfo(12062), new ItemInfo(13838), new ItemInfo(13839), new ItemInfo(13840), new ItemInfo(13841), new ItemInfo(13842), new ItemInfo(16726), new ItemInfo(16727), new ItemInfo(16728), new ItemInfo(16729), 
            new ItemInfo(16740), new ItemInfo(16741), new ItemInfo(16748), new ItemInfo(16749), new ItemInfo(16750), new ItemInfo(16751), new ItemInfo(16752), new ItemInfo(16753), new ItemInfo(16754), new ItemInfo(16755), 
            new ItemInfo(16783), new ItemInfo(16800), new ItemInfo(16803), new ItemInfo(16804), new ItemInfo(30705), new ItemInfo(30706), new ItemInfo(30707), new ItemInfo(30708), new ItemInfo(30709)/*, new ItemInfo(39141), 
			new ItemInfo(39142), new ItemInfo(39143), new ItemInfo(39144), new ItemInfo(39213), new ItemInfo(39291), new ItemInfo(39292), new ItemInfo(39293), new ItemInfo(39294), new ItemInfo(39295), new ItemInfo(39296), 
			new ItemInfo(39297), new ItemInfo(39298), new ItemInfo(39478), new ItemInfo(39479), new ItemInfo(39480), new ItemInfo(39481), new ItemInfo(39482), new ItemInfo(40219), new ItemInfo(40220), new ItemInfo(40221), 
			new ItemInfo(40222), new ItemInfo(40223), new ItemInfo(40224), new ItemInfo(40225), new ItemInfo(40226), new ItemInfo(41721), new ItemInfo(41722), new ItemInfo(41728), new ItemInfo(41729), new ItemInfo(41730), 
			new ItemInfo(41762), new ItemInfo(41773), new ItemInfo(42512), new ItemInfo(42513), new ItemInfo(42514), new ItemInfo(42515), new ItemInfo(43188), new ItemInfo(43189), new ItemInfo(43190), new ItemInfo(43191), 
			new ItemInfo(43192)*/
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddArchGump()
			: this(0)
		{ }

		public AddArchGump(int page) 
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

			from.SendGump(new AddArchGump(page));
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
