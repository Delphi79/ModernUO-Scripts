using Server.Network;

namespace Server.Gumps
{
	public class AddRoofPt3Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddRoofPt3", AccessLevel.GameMaster, new CommandEventHandler(AddRoofPt3_OnCommand));
		}

		[Usage("AddRoofPt3")]
		
		public static void AddRoofPt3_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddRoofPt3Gump>();
			e.Mobile.SendGump(new AddRoofPt3Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Roofs
            new ItemInfo(10536), new ItemInfo(10537), new ItemInfo(10538), new ItemInfo(10539), new ItemInfo(10540), new ItemInfo(10541), new ItemInfo(10542), new ItemInfo(10543), 
            new ItemInfo(10544), new ItemInfo(10545), new ItemInfo(10546), new ItemInfo(10547), new ItemInfo(10548), new ItemInfo(10549), new ItemInfo(11137), new ItemInfo(11138), 
            new ItemInfo(11139), new ItemInfo(11140), new ItemInfo(11141), new ItemInfo(11142), new ItemInfo(11143), new ItemInfo(11144), new ItemInfo(11145), new ItemInfo(11146), 
            new ItemInfo(11147), new ItemInfo(11148), new ItemInfo(11149), new ItemInfo(11150), new ItemInfo(11151), new ItemInfo(11152), new ItemInfo(11153), new ItemInfo(11154), 
            new ItemInfo(11155), new ItemInfo(11156), new ItemInfo(11157), new ItemInfo(11158), new ItemInfo(11159), new ItemInfo(11160), new ItemInfo(11161), new ItemInfo(11162), 
            new ItemInfo(11163), new ItemInfo(11164), new ItemInfo(11165), new ItemInfo(11166), new ItemInfo(11167), new ItemInfo(11168), new ItemInfo(11169), new ItemInfo(11170), 
            new ItemInfo(11171), new ItemInfo(11172), new ItemInfo(11173), new ItemInfo(11174), new ItemInfo(11175), new ItemInfo(11176), new ItemInfo(11300), new ItemInfo(11301), 
            new ItemInfo(11302), new ItemInfo(11303), new ItemInfo(11304), new ItemInfo(11305), new ItemInfo(11306), new ItemInfo(11307), new ItemInfo(11308), new ItemInfo(11309), 
            new ItemInfo(11310), new ItemInfo(11311), new ItemInfo(11312), new ItemInfo(11313), new ItemInfo(11314), new ItemInfo(11315), new ItemInfo(11316), new ItemInfo(11317), 
            new ItemInfo(11318), new ItemInfo(11319), new ItemInfo(11320), new ItemInfo(11321), new ItemInfo(11322), new ItemInfo(11323), new ItemInfo(11324), new ItemInfo(11325), 
            new ItemInfo(11326), new ItemInfo(11327), new ItemInfo(11328), new ItemInfo(11329), new ItemInfo(11330), new ItemInfo(11331), new ItemInfo(11332), new ItemInfo(11333), 
            new ItemInfo(11334), new ItemInfo(11335), new ItemInfo(11336), new ItemInfo(11337), new ItemInfo(11338), new ItemInfo(11339), new ItemInfo(11340), new ItemInfo(11341), 
            new ItemInfo(11342), new ItemInfo(11343), new ItemInfo(11344), new ItemInfo(11345), new ItemInfo(11346), new ItemInfo(11347), new ItemInfo(11348), new ItemInfo(11349), 
            new ItemInfo(11350), new ItemInfo(11351), new ItemInfo(11352), new ItemInfo(11353), new ItemInfo(11354), new ItemInfo(11355), new ItemInfo(11356), new ItemInfo(11357), 
            new ItemInfo(11358), new ItemInfo(11359), new ItemInfo(11360), new ItemInfo(11361), new ItemInfo(11362), new ItemInfo(11363), new ItemInfo(11364), new ItemInfo(11365), 
            new ItemInfo(11366), new ItemInfo(11367), new ItemInfo(11368), new ItemInfo(11369), new ItemInfo(11370), new ItemInfo(11371), new ItemInfo(11372), new ItemInfo(11373), 
            new ItemInfo(11374), new ItemInfo(11375), new ItemInfo(11376), new ItemInfo(11377), new ItemInfo(11378), new ItemInfo(11379), new ItemInfo(11380), new ItemInfo(11381), 
            new ItemInfo(11382), new ItemInfo(11383), new ItemInfo(11384), new ItemInfo(11385), new ItemInfo(11386), new ItemInfo(11387), new ItemInfo(11388), new ItemInfo(11389), 
            new ItemInfo(12063), new ItemInfo(12064), new ItemInfo(12065), new ItemInfo(12066), new ItemInfo(12067), new ItemInfo(12068), new ItemInfo(12069), new ItemInfo(12070), 
            new ItemInfo(12071), new ItemInfo(12072), new ItemInfo(12758), new ItemInfo(12759), new ItemInfo(12760), new ItemInfo(12761), new ItemInfo(12762), new ItemInfo(12763), 
            new ItemInfo(12764), new ItemInfo(12765), new ItemInfo(12766), new ItemInfo(12767), new ItemInfo(12768), new ItemInfo(12769), new ItemInfo(12770), new ItemInfo(12771), 
            new ItemInfo(12772), new ItemInfo(12773), new ItemInfo(12774), new ItemInfo(12775), new ItemInfo(12776), new ItemInfo(12777), new ItemInfo(13859), new ItemInfo(13860), 
            new ItemInfo(13861), new ItemInfo(13862), new ItemInfo(13863), new ItemInfo(13864), new ItemInfo(13865), new ItemInfo(13866), new ItemInfo(13867), new ItemInfo(13868), 
            new ItemInfo(13869), new ItemInfo(13870), new ItemInfo(13871), new ItemInfo(13872), new ItemInfo(13873), new ItemInfo(13874), new ItemInfo(13875), new ItemInfo(13876), 
            new ItemInfo(13877)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddRoofPt3Gump()
			: this(0)
		{ }

		public AddRoofPt3Gump(int page) 
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

			from.SendGump(new AddRoofPt3Gump(page));
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
