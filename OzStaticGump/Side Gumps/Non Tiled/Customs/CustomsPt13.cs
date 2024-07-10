using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt13Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt13", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt13_OnCommand));
		}

		[Usage("AddCustomPt13")]
		
		public static void AddCustomPt13_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt13Gump>();
			e.Mobile.SendGump(new AddCustomPt13Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(41602), new ItemInfo(41603), new ItemInfo(41604), new ItemInfo(41605), new ItemInfo(41606), new ItemInfo(41607), new ItemInfo(41608), new ItemInfo(41609), new ItemInfo(41610), 
			new ItemInfo(41611), new ItemInfo(41612), new ItemInfo(41613), new ItemInfo(41614), new ItemInfo(41615), new ItemInfo(41616), new ItemInfo(41617), new ItemInfo(41618), new ItemInfo(41619), 
			new ItemInfo(41620), new ItemInfo(41621), new ItemInfo(41622), new ItemInfo(41623), new ItemInfo(41624), new ItemInfo(41625), new ItemInfo(41626), new ItemInfo(41627), new ItemInfo(41628), 
			new ItemInfo(41629), new ItemInfo(41630), new ItemInfo(41631), new ItemInfo(41632), new ItemInfo(41633), new ItemInfo(41634), new ItemInfo(41635), new ItemInfo(41636), new ItemInfo(41637), 
			new ItemInfo(41638), new ItemInfo(41639), new ItemInfo(41640), new ItemInfo(41641), new ItemInfo(41642), new ItemInfo(41643), new ItemInfo(41644), new ItemInfo(41645), new ItemInfo(41646), 
			new ItemInfo(41647), new ItemInfo(41648), new ItemInfo(41649), new ItemInfo(41650), new ItemInfo(41651), new ItemInfo(41652), new ItemInfo(41653), new ItemInfo(41654), new ItemInfo(41655), 
			new ItemInfo(41656), new ItemInfo(41657), new ItemInfo(41658), new ItemInfo(41659), new ItemInfo(41660), new ItemInfo(41661), new ItemInfo(41662), new ItemInfo(41663), new ItemInfo(41664), 
			new ItemInfo(41665), new ItemInfo(41666), new ItemInfo(41667), new ItemInfo(41668), new ItemInfo(41669), new ItemInfo(41670), new ItemInfo(41671), new ItemInfo(41672), new ItemInfo(41673), 
			new ItemInfo(41674), new ItemInfo(41675), new ItemInfo(41676), new ItemInfo(41677), new ItemInfo(41678), new ItemInfo(41679), new ItemInfo(41680), new ItemInfo(41681), new ItemInfo(41682), 
			new ItemInfo(41683), new ItemInfo(41684), new ItemInfo(41685), new ItemInfo(41686), new ItemInfo(41687), new ItemInfo(41688), new ItemInfo(41689), new ItemInfo(41690), new ItemInfo(41691), 
			new ItemInfo(41692), new ItemInfo(41693), new ItemInfo(41694), new ItemInfo(41695), new ItemInfo(41696), new ItemInfo(41697), new ItemInfo(41698), new ItemInfo(41699), new ItemInfo(41700), 
			new ItemInfo(41701), new ItemInfo(41702), new ItemInfo(41703), new ItemInfo(41704), new ItemInfo(41705), new ItemInfo(41706), new ItemInfo(41707), new ItemInfo(41708), new ItemInfo(41709), 
			new ItemInfo(41710), new ItemInfo(41711), new ItemInfo(41712), new ItemInfo(41713), new ItemInfo(41714), new ItemInfo(41715), new ItemInfo(41716), new ItemInfo(41717), new ItemInfo(41718), 
			new ItemInfo(41719), new ItemInfo(41720), new ItemInfo(41721), new ItemInfo(41722), new ItemInfo(41723), new ItemInfo(41724), new ItemInfo(41725), new ItemInfo(41726), new ItemInfo(41727), 
			new ItemInfo(41728), new ItemInfo(41729), new ItemInfo(41730), new ItemInfo(41731), new ItemInfo(41732), new ItemInfo(41733), new ItemInfo(41734), new ItemInfo(41735), new ItemInfo(41736), 
			new ItemInfo(41737), new ItemInfo(41738), new ItemInfo(41739), new ItemInfo(41740), new ItemInfo(41741), new ItemInfo(41742), new ItemInfo(41743), new ItemInfo(41744), new ItemInfo(41745), 
			new ItemInfo(41746), new ItemInfo(41747), new ItemInfo(41748), new ItemInfo(41749), new ItemInfo(41750), new ItemInfo(41751), new ItemInfo(41752), new ItemInfo(41753), new ItemInfo(41754), 
			new ItemInfo(41755), new ItemInfo(41756), new ItemInfo(41757), new ItemInfo(41758), new ItemInfo(41759), new ItemInfo(41760), new ItemInfo(41761), new ItemInfo(41762), new ItemInfo(41763), 
			new ItemInfo(41764), new ItemInfo(41765), new ItemInfo(41766), new ItemInfo(41767), new ItemInfo(41768), new ItemInfo(41769), new ItemInfo(41770), new ItemInfo(41771), new ItemInfo(41772), 
			new ItemInfo(41773), new ItemInfo(41774), new ItemInfo(41775), new ItemInfo(41776), new ItemInfo(41777), new ItemInfo(41778), new ItemInfo(41779), new ItemInfo(41780), new ItemInfo(41781), 
			new ItemInfo(41782), new ItemInfo(41783), new ItemInfo(41784), new ItemInfo(41785), new ItemInfo(41786), new ItemInfo(41787), new ItemInfo(41788), new ItemInfo(41789), new ItemInfo(41790), 
			new ItemInfo(41791), new ItemInfo(41792), new ItemInfo(41793), new ItemInfo(41794), new ItemInfo(41795), new ItemInfo(41796), new ItemInfo(41797), new ItemInfo(41798), new ItemInfo(41799), 
			new ItemInfo(41800), new ItemInfo(41801), new ItemInfo(41802), new ItemInfo(41803), new ItemInfo(41804), new ItemInfo(41805), new ItemInfo(41806), new ItemInfo(41807), new ItemInfo(41808), 
			new ItemInfo(41809), new ItemInfo(41810), new ItemInfo(41811), new ItemInfo(41812), new ItemInfo(41813), new ItemInfo(41814), new ItemInfo(41815), new ItemInfo(41816), new ItemInfo(41817), 
			new ItemInfo(41818), new ItemInfo(41819), new ItemInfo(41820), new ItemInfo(41821), new ItemInfo(41822), new ItemInfo(41823), new ItemInfo(41824), new ItemInfo(41825), new ItemInfo(41826)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt13Gump()
			: this(0)
		{ }

		public AddCustomPt13Gump(int page) 
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

			from.SendGump(new AddCustomPt13Gump(page));
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
