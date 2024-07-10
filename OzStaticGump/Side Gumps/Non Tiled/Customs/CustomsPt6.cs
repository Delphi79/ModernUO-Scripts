using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt6Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt6", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt6_OnCommand));
		}

		[Usage("AddCustomPt6")]
		
		public static void AddCustomPt6_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt6Gump>();
			e.Mobile.SendGump(new AddCustomPt6Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(40115), new ItemInfo(40116), new ItemInfo(40117), new ItemInfo(40118), new ItemInfo(40119), new ItemInfo(40120), new ItemInfo(40121), new ItemInfo(40122), new ItemInfo(40123), 
			new ItemInfo(40124), new ItemInfo(40125), new ItemInfo(40126), new ItemInfo(40127), new ItemInfo(40128), new ItemInfo(40129), new ItemInfo(40130), new ItemInfo(40131), new ItemInfo(40132), 
			new ItemInfo(40133), new ItemInfo(40134), new ItemInfo(40135), new ItemInfo(40136), new ItemInfo(40137), new ItemInfo(40138), new ItemInfo(40139), new ItemInfo(40140), new ItemInfo(40141), 
			new ItemInfo(40142), new ItemInfo(40143), new ItemInfo(40144), new ItemInfo(40145), new ItemInfo(40146), new ItemInfo(40147), new ItemInfo(40148), new ItemInfo(40149), new ItemInfo(40150), 
			new ItemInfo(40151), new ItemInfo(40152), new ItemInfo(40153), new ItemInfo(40154), new ItemInfo(40155), new ItemInfo(40156), new ItemInfo(40157), new ItemInfo(40158), new ItemInfo(40159), 
			new ItemInfo(40160), new ItemInfo(40161), new ItemInfo(40162), new ItemInfo(40163), new ItemInfo(40164), new ItemInfo(40165), new ItemInfo(40166), new ItemInfo(40167), new ItemInfo(40168), 
			new ItemInfo(40169), new ItemInfo(40170), new ItemInfo(40171), new ItemInfo(40172), new ItemInfo(40173), new ItemInfo(40174), new ItemInfo(40175), new ItemInfo(40176), new ItemInfo(40177), 
			new ItemInfo(40178), new ItemInfo(40179), new ItemInfo(40180), new ItemInfo(40181), new ItemInfo(40182), new ItemInfo(40183), new ItemInfo(40184), new ItemInfo(40185), new ItemInfo(40188), 
			new ItemInfo(40189), new ItemInfo(40190), new ItemInfo(40191), new ItemInfo(40192), new ItemInfo(40193), new ItemInfo(40194), new ItemInfo(40195), new ItemInfo(40196), new ItemInfo(40197), 
			new ItemInfo(40198), new ItemInfo(40199), new ItemInfo(40200), new ItemInfo(40201), new ItemInfo(40202), new ItemInfo(40203), new ItemInfo(40204), new ItemInfo(40205), new ItemInfo(40206), 
			new ItemInfo(40207), new ItemInfo(40208), new ItemInfo(40209), new ItemInfo(40210), new ItemInfo(40211), new ItemInfo(40212), new ItemInfo(40213), new ItemInfo(40214), new ItemInfo(40215), 
			new ItemInfo(40216), new ItemInfo(40217), new ItemInfo(40218), new ItemInfo(40219), new ItemInfo(40220), new ItemInfo(40221), new ItemInfo(40222), new ItemInfo(40223), new ItemInfo(40224), 
			new ItemInfo(40225), new ItemInfo(40226), new ItemInfo(40227), new ItemInfo(40228), new ItemInfo(40229), new ItemInfo(40230), new ItemInfo(40231), new ItemInfo(40232), new ItemInfo(40233), 
			new ItemInfo(40234), new ItemInfo(40235), new ItemInfo(40236), new ItemInfo(40237), new ItemInfo(40238), new ItemInfo(40239), new ItemInfo(40240), new ItemInfo(40241), new ItemInfo(40242), 
			new ItemInfo(40243), new ItemInfo(40244), new ItemInfo(40245), new ItemInfo(40246), new ItemInfo(40247), new ItemInfo(40248), new ItemInfo(40249), new ItemInfo(40250), new ItemInfo(40251), 
			new ItemInfo(40252), new ItemInfo(40253), new ItemInfo(40254), new ItemInfo(40255), new ItemInfo(40256), new ItemInfo(40257), new ItemInfo(40258), new ItemInfo(40259), new ItemInfo(40260), 
			new ItemInfo(40261), new ItemInfo(40262), new ItemInfo(40263), new ItemInfo(40265), new ItemInfo(40266), new ItemInfo(40267), new ItemInfo(40268), new ItemInfo(40269), new ItemInfo(40270), 
			new ItemInfo(40271), new ItemInfo(40272), new ItemInfo(40273), new ItemInfo(40274), new ItemInfo(40275), new ItemInfo(40276), new ItemInfo(40277), new ItemInfo(40278), new ItemInfo(40280), 
			new ItemInfo(40281), new ItemInfo(40282), new ItemInfo(40283), new ItemInfo(40284), new ItemInfo(40285), new ItemInfo(40286), new ItemInfo(40287), new ItemInfo(40288), new ItemInfo(40289), 
			new ItemInfo(40290), new ItemInfo(40291), new ItemInfo(40292), new ItemInfo(40294), new ItemInfo(40295), new ItemInfo(40297), new ItemInfo(40298), new ItemInfo(40299), new ItemInfo(40300)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt6Gump()
			: this(0)
		{ }

		public AddCustomPt6Gump(int page) 
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

			from.SendGump(new AddCustomPt6Gump(page));
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
