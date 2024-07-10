using Server.Network;

namespace Server.Gumps
{
	public class AddFloorPt8Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFloorPt8", AccessLevel.GameMaster, new CommandEventHandler(AddFloorPt8_OnCommand));
		}

		[Usage("AddFloorPt8")]
		
		public static void AddFloorPt8_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFloorPt8Gump>();
			e.Mobile.SendGump(new AddFloorPt8Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(20995), new ItemInfo(20996), new ItemInfo(20997), new ItemInfo(20998), new ItemInfo(20999), new ItemInfo(21000), new ItemInfo(21001), new ItemInfo(21002), 
            new ItemInfo(21003), new ItemInfo(21004), new ItemInfo(21005), new ItemInfo(21006), new ItemInfo(21007), new ItemInfo(21008), new ItemInfo(21009), new ItemInfo(21010), 
            new ItemInfo(21011), new ItemInfo(21012), new ItemInfo(21013), new ItemInfo(21014), new ItemInfo(21015), new ItemInfo(21016), new ItemInfo(21017), new ItemInfo(21018), 
            new ItemInfo(21019), new ItemInfo(21020), new ItemInfo(21021), new ItemInfo(21022), new ItemInfo(21023), new ItemInfo(21024), new ItemInfo(21025), new ItemInfo(21026), 
            new ItemInfo(21027), new ItemInfo(21028), new ItemInfo(21029), new ItemInfo(21030), new ItemInfo(21031), new ItemInfo(21032), new ItemInfo(21033), new ItemInfo(21034), 
            new ItemInfo(21035), new ItemInfo(21036), new ItemInfo(21037), new ItemInfo(21038), new ItemInfo(21039), new ItemInfo(21040), new ItemInfo(21041), new ItemInfo(21042), 
            new ItemInfo(21043), new ItemInfo(21044), new ItemInfo(21045), new ItemInfo(21046), new ItemInfo(21047), new ItemInfo(21048), new ItemInfo(21049), new ItemInfo(21050), 
            new ItemInfo(21051), new ItemInfo(21052), new ItemInfo(21053), new ItemInfo(21054), new ItemInfo(21055), new ItemInfo(21056), new ItemInfo(21057), new ItemInfo(21058), 
            new ItemInfo(21059), new ItemInfo(21060), new ItemInfo(21061), new ItemInfo(21062), new ItemInfo(21063), new ItemInfo(21064), new ItemInfo(21065), new ItemInfo(21066), 
            new ItemInfo(21067), new ItemInfo(21068), new ItemInfo(21069), new ItemInfo(21070), new ItemInfo(21071), new ItemInfo(21072), new ItemInfo(21073), new ItemInfo(21074), 
            new ItemInfo(21075), new ItemInfo(21076), new ItemInfo(21077), new ItemInfo(21078), new ItemInfo(21079), new ItemInfo(21080), new ItemInfo(21081), new ItemInfo(21082), 
            new ItemInfo(21083), new ItemInfo(21084), new ItemInfo(21085), new ItemInfo(21086), new ItemInfo(21087), new ItemInfo(21088), new ItemInfo(21089), new ItemInfo(21090), 
            new ItemInfo(21091), new ItemInfo(21092), new ItemInfo(21093), new ItemInfo(21094), new ItemInfo(21095), new ItemInfo(21096), new ItemInfo(21097), new ItemInfo(21098), 
            new ItemInfo(21099), new ItemInfo(21100), new ItemInfo(21101), new ItemInfo(21102), new ItemInfo(21103), new ItemInfo(21104), new ItemInfo(21105), new ItemInfo(21106), 
            new ItemInfo(21107), new ItemInfo(21108), new ItemInfo(21109), new ItemInfo(21110), new ItemInfo(21111), new ItemInfo(21112), new ItemInfo(21113), new ItemInfo(21114), 
            new ItemInfo(21115), new ItemInfo(21116), new ItemInfo(21117), new ItemInfo(21118), new ItemInfo(21119), new ItemInfo(21120), new ItemInfo(21121), new ItemInfo(21122), 
            new ItemInfo(21123), new ItemInfo(21124), new ItemInfo(21125), new ItemInfo(21126), new ItemInfo(21127), new ItemInfo(21128), new ItemInfo(21129), new ItemInfo(21131), 
            new ItemInfo(21132), new ItemInfo(21133), new ItemInfo(21134), new ItemInfo(21135), new ItemInfo(21136), new ItemInfo(21137), new ItemInfo(21138), new ItemInfo(21139), 
            new ItemInfo(21140), new ItemInfo(21141), new ItemInfo(21142), new ItemInfo(21143), new ItemInfo(21144), new ItemInfo(21145), new ItemInfo(21146), new ItemInfo(21147), 
            new ItemInfo(21148), new ItemInfo(21152), new ItemInfo(21153), new ItemInfo(21154), new ItemInfo(21155), new ItemInfo(21156), new ItemInfo(21157), new ItemInfo(21158), 
            new ItemInfo(21159), new ItemInfo(21160), new ItemInfo(21161), new ItemInfo(21162), new ItemInfo(21163), new ItemInfo(21164), new ItemInfo(21165), new ItemInfo(21166), 
            new ItemInfo(21167), new ItemInfo(21173), new ItemInfo(21174), new ItemInfo(21175), new ItemInfo(21176), new ItemInfo(21177), new ItemInfo(21178), new ItemInfo(21179), 
            new ItemInfo(21180), new ItemInfo(21181), new ItemInfo(21182), new ItemInfo(21183), new ItemInfo(21184), new ItemInfo(21185), new ItemInfo(21186), new ItemInfo(21194), 
            new ItemInfo(21195), new ItemInfo(21196), new ItemInfo(21197), new ItemInfo(21198), new ItemInfo(21199), new ItemInfo(21200), new ItemInfo(21201), new ItemInfo(21202), 
            new ItemInfo(21203), new ItemInfo(21204), new ItemInfo(21205)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFloorPt8Gump()
			: this(0)
		{ }

		public AddFloorPt8Gump(int page) 
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

			from.SendGump(new AddFloorPt8Gump(page));
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
