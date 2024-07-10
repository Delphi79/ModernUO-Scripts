using Server.Network;

namespace Server.Gumps
{
	public class AddFloorPt10Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFloorPt10", AccessLevel.GameMaster, new CommandEventHandler(AddFloorPt10_OnCommand));
		}

		[Usage("AddFloorPt10")]
		
		public static void AddFloorPt10_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFloorPt10Gump>();
			e.Mobile.SendGump(new AddFloorPt10Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(39693), new ItemInfo(39694), new ItemInfo(39695), new ItemInfo(39696), new ItemInfo(39697), new ItemInfo(39698), new ItemInfo(39699), new ItemInfo(39700), 
            new ItemInfo(39701), new ItemInfo(39702), new ItemInfo(39703), new ItemInfo(39704), new ItemInfo(39705), new ItemInfo(39706), new ItemInfo(39707), new ItemInfo(39708), 
            new ItemInfo(39709), new ItemInfo(39710), new ItemInfo(39711), new ItemInfo(39712), new ItemInfo(39713), new ItemInfo(39714), new ItemInfo(39715), new ItemInfo(39716), 
            new ItemInfo(39717), new ItemInfo(39718), new ItemInfo(39719), new ItemInfo(39720), new ItemInfo(39721), new ItemInfo(39722), new ItemInfo(39723), new ItemInfo(39724), 
            new ItemInfo(39725), new ItemInfo(39726), new ItemInfo(39727), new ItemInfo(39728), new ItemInfo(39729), new ItemInfo(39730), new ItemInfo(39731), new ItemInfo(39732), 
            new ItemInfo(39733), new ItemInfo(39734), new ItemInfo(39735), new ItemInfo(39736), new ItemInfo(39737), new ItemInfo(39738), new ItemInfo(39739), new ItemInfo(39740), 
            new ItemInfo(39741), new ItemInfo(39742), new ItemInfo(39743), new ItemInfo(39744), new ItemInfo(39745), new ItemInfo(39746), new ItemInfo(39747), new ItemInfo(39748), 
            new ItemInfo(39749), new ItemInfo(39750), new ItemInfo(39751), new ItemInfo(39752), new ItemInfo(39753), new ItemInfo(39754), new ItemInfo(39755), new ItemInfo(39756), 
            new ItemInfo(39757), new ItemInfo(39758), new ItemInfo(39759), new ItemInfo(39760), new ItemInfo(39761), new ItemInfo(39762), new ItemInfo(39763), new ItemInfo(39764), 
            new ItemInfo(39765), new ItemInfo(39766), new ItemInfo(39767), new ItemInfo(39768), new ItemInfo(39769), new ItemInfo(39770), new ItemInfo(39771), new ItemInfo(39772), 
            new ItemInfo(39773), new ItemInfo(39774), new ItemInfo(39775), new ItemInfo(39776), new ItemInfo(39777), new ItemInfo(39778), new ItemInfo(39779), new ItemInfo(39780), 
            new ItemInfo(39781), new ItemInfo(39782), new ItemInfo(39783), new ItemInfo(39784), new ItemInfo(39785), new ItemInfo(39786), new ItemInfo(39787), new ItemInfo(39788), 
            new ItemInfo(39789), new ItemInfo(39790), new ItemInfo(39791), new ItemInfo(39792), new ItemInfo(39793), new ItemInfo(39794), new ItemInfo(39795), new ItemInfo(39796), 
            new ItemInfo(39797), new ItemInfo(39798), new ItemInfo(39799), new ItemInfo(39800), new ItemInfo(39801), new ItemInfo(39802), new ItemInfo(39803), new ItemInfo(39804), 
            new ItemInfo(39805), new ItemInfo(39806), new ItemInfo(39807), new ItemInfo(39808), new ItemInfo(39809), new ItemInfo(39810), new ItemInfo(39811), new ItemInfo(39812), 
            new ItemInfo(39813), new ItemInfo(39814), new ItemInfo(39815), new ItemInfo(39816), new ItemInfo(39817), new ItemInfo(39818), new ItemInfo(39819), new ItemInfo(39820), 
            new ItemInfo(39821), new ItemInfo(39822), new ItemInfo(39823), new ItemInfo(39824), new ItemInfo(39825), new ItemInfo(39826), new ItemInfo(39827), new ItemInfo(39828), 
            new ItemInfo(39829), new ItemInfo(39830), new ItemInfo(39831), new ItemInfo(39832), new ItemInfo(39833), new ItemInfo(39834), new ItemInfo(39835), new ItemInfo(39836), 
            new ItemInfo(39837), new ItemInfo(39838), new ItemInfo(39839), new ItemInfo(39840), new ItemInfo(39841), new ItemInfo(39842), new ItemInfo(39843), new ItemInfo(39844), 
            new ItemInfo(39845), new ItemInfo(39846), new ItemInfo(39847), new ItemInfo(39848), new ItemInfo(39849), new ItemInfo(39850), new ItemInfo(39851), new ItemInfo(39852), 
            new ItemInfo(39853), new ItemInfo(39854), new ItemInfo(39855), new ItemInfo(39856), new ItemInfo(39857), new ItemInfo(39858), new ItemInfo(39859), new ItemInfo(39860), 
            new ItemInfo(39861), new ItemInfo(39862), new ItemInfo(39863), new ItemInfo(39864), new ItemInfo(39865), new ItemInfo(39866), new ItemInfo(39867), new ItemInfo(39868)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFloorPt10Gump()
			: this(0)
		{ }

		public AddFloorPt10Gump(int page) 
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

			from.SendGump(new AddFloorPt10Gump(page));
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
