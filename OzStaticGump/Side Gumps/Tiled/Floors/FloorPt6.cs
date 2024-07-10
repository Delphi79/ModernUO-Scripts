using Server.Network;

namespace Server.Gumps
{
	public class AddFloorPt6Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFloorPt6", AccessLevel.GameMaster, new CommandEventHandler(AddFloorPt6_OnCommand));
		}

		[Usage("AddFloorPt6")]
		
		public static void AddFloorPt6_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFloorPt6Gump>();
			e.Mobile.SendGump(new AddFloorPt6Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(17600), new ItemInfo(18124), new ItemInfo(18125), new ItemInfo(18126), new ItemInfo(18127), new ItemInfo(18326), new ItemInfo(18327), new ItemInfo(18328), 
            new ItemInfo(18329), new ItemInfo(18410), new ItemInfo(18411), new ItemInfo(18412), new ItemInfo(18413), new ItemInfo(18414), new ItemInfo(18415), new ItemInfo(18416), 
            new ItemInfo(18417), new ItemInfo(18418), new ItemInfo(18419), new ItemInfo(18420), new ItemInfo(18421), new ItemInfo(18422), new ItemInfo(18423), new ItemInfo(18424), 
            new ItemInfo(18425), new ItemInfo(18426), new ItemInfo(18427), new ItemInfo(18428), new ItemInfo(18429), new ItemInfo(18430), new ItemInfo(18431), new ItemInfo(18432), 
            new ItemInfo(18433), new ItemInfo(18434), new ItemInfo(18435), new ItemInfo(18436), new ItemInfo(18437), new ItemInfo(18438), new ItemInfo(18439), new ItemInfo(18440), 
            new ItemInfo(18441), new ItemInfo(18442), new ItemInfo(18443), new ItemInfo(18444), new ItemInfo(18445), new ItemInfo(18446), new ItemInfo(18447), new ItemInfo(18448), 
            new ItemInfo(18449), new ItemInfo(18450), new ItemInfo(18451), new ItemInfo(18452), new ItemInfo(18453), new ItemInfo(18454), new ItemInfo(18455), new ItemInfo(18456), 
            new ItemInfo(18457), new ItemInfo(18458), new ItemInfo(18459), new ItemInfo(18460), new ItemInfo(18461), new ItemInfo(18462), new ItemInfo(18463), new ItemInfo(18464), 
            new ItemInfo(18465), new ItemInfo(18466), new ItemInfo(18467), new ItemInfo(18468), new ItemInfo(18469), new ItemInfo(18470), new ItemInfo(18471), new ItemInfo(18472), 
            new ItemInfo(18473), new ItemInfo(18474), new ItemInfo(18475), new ItemInfo(18476), new ItemInfo(18477), new ItemInfo(18478), new ItemInfo(18479), new ItemInfo(18480), 
            new ItemInfo(18481), new ItemInfo(18482), new ItemInfo(18483), new ItemInfo(18484), new ItemInfo(18485), new ItemInfo(18486), new ItemInfo(18487), new ItemInfo(18488), 
            new ItemInfo(18489), new ItemInfo(18490), new ItemInfo(19755), new ItemInfo(19756), new ItemInfo(19757), new ItemInfo(19758), new ItemInfo(19942), new ItemInfo(19943), 
            new ItemInfo(19944), new ItemInfo(19945), new ItemInfo(19946), new ItemInfo(19947), new ItemInfo(19948), new ItemInfo(19949), new ItemInfo(19950), new ItemInfo(19951), 
            new ItemInfo(19952), new ItemInfo(19953), new ItemInfo(19954), new ItemInfo(20328), new ItemInfo(20329), new ItemInfo(20330), new ItemInfo(20331), new ItemInfo(20332), 
            new ItemInfo(20333), new ItemInfo(20334), new ItemInfo(20335), new ItemInfo(20336), new ItemInfo(20337), new ItemInfo(20338), new ItemInfo(20339), new ItemInfo(20340), 
            new ItemInfo(20341), new ItemInfo(20342), new ItemInfo(20343), new ItemInfo(20344), new ItemInfo(20345), new ItemInfo(20702), new ItemInfo(20703), new ItemInfo(20704), 
            new ItemInfo(20705), new ItemInfo(20706), new ItemInfo(20707), new ItemInfo(20708), new ItemInfo(20709), new ItemInfo(20710), new ItemInfo(20711), new ItemInfo(20712), 
            new ItemInfo(20713), new ItemInfo(20714), new ItemInfo(20715), new ItemInfo(20716), new ItemInfo(20717), new ItemInfo(20718), new ItemInfo(20719), new ItemInfo(20720), 
            new ItemInfo(20721), new ItemInfo(20722), new ItemInfo(20723), new ItemInfo(20724), new ItemInfo(20725), new ItemInfo(20726), new ItemInfo(20727), new ItemInfo(20810), 
            new ItemInfo(20811), new ItemInfo(20812), new ItemInfo(20813), new ItemInfo(20814), new ItemInfo(20815), new ItemInfo(20816), new ItemInfo(20817), new ItemInfo(20818), 
            new ItemInfo(20819), new ItemInfo(20820), new ItemInfo(20821), new ItemInfo(20822), new ItemInfo(20823), new ItemInfo(20824), new ItemInfo(20825), new ItemInfo(20826)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFloorPt6Gump()
			: this(0)
		{ }

		public AddFloorPt6Gump(int page) 
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

			from.SendGump(new AddFloorPt6Gump(page));
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
