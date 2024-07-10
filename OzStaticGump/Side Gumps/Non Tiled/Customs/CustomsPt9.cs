using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt9Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt9", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt9_OnCommand));
		}

		[Usage("AddCustomPt9")]
		
		public static void AddCustomPt9_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt9Gump>();
			e.Mobile.SendGump(new AddCustomPt9Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(40667), new ItemInfo(40668), new ItemInfo(40669), new ItemInfo(40670), new ItemInfo(40671), new ItemInfo(40672), new ItemInfo(40673), new ItemInfo(40674), new ItemInfo(40675), 
			new ItemInfo(40676), new ItemInfo(40677), new ItemInfo(40678), new ItemInfo(40679), new ItemInfo(40680), new ItemInfo(40681), new ItemInfo(40682), new ItemInfo(40683), new ItemInfo(40684), 
			new ItemInfo(40685), new ItemInfo(40686), new ItemInfo(40687), new ItemInfo(40688), new ItemInfo(40689), new ItemInfo(40690), new ItemInfo(40691), new ItemInfo(40692), new ItemInfo(40693), 
			new ItemInfo(40694), new ItemInfo(40695), new ItemInfo(40696), new ItemInfo(40697), new ItemInfo(40698), new ItemInfo(40699), new ItemInfo(40700), new ItemInfo(40701), new ItemInfo(40702), 
			new ItemInfo(40703), new ItemInfo(40704), new ItemInfo(40705), new ItemInfo(40706), new ItemInfo(40707), new ItemInfo(40708), new ItemInfo(40709), new ItemInfo(40710), new ItemInfo(40711), 
			new ItemInfo(40712), new ItemInfo(40713), new ItemInfo(40714), new ItemInfo(40715), new ItemInfo(40716), new ItemInfo(40717), new ItemInfo(40718), new ItemInfo(40719), new ItemInfo(40720), 
			new ItemInfo(40721), new ItemInfo(40722), new ItemInfo(40723), new ItemInfo(40724), new ItemInfo(40725), new ItemInfo(40726), new ItemInfo(40727), new ItemInfo(40728), new ItemInfo(40729), 
			new ItemInfo(40730), new ItemInfo(40731), new ItemInfo(40732), new ItemInfo(40733), new ItemInfo(40734), new ItemInfo(40735), new ItemInfo(40736), new ItemInfo(40737), new ItemInfo(40738), 
			new ItemInfo(40739), new ItemInfo(40740), new ItemInfo(40741), new ItemInfo(40742), new ItemInfo(40743), new ItemInfo(40744), new ItemInfo(40745), new ItemInfo(40746), new ItemInfo(40747), 
			new ItemInfo(40748), new ItemInfo(40749), new ItemInfo(40750), new ItemInfo(40751), new ItemInfo(40752), new ItemInfo(40753), new ItemInfo(40754), new ItemInfo(40755), new ItemInfo(40756), 
			new ItemInfo(40757), new ItemInfo(40758), new ItemInfo(40759), new ItemInfo(40760), new ItemInfo(40761), new ItemInfo(40762), new ItemInfo(40763), new ItemInfo(40764), new ItemInfo(40765), 
			new ItemInfo(40766), new ItemInfo(40767), new ItemInfo(40768), new ItemInfo(40769), new ItemInfo(40770), new ItemInfo(40771), new ItemInfo(40772), new ItemInfo(40773), new ItemInfo(40774), 
			new ItemInfo(40775), new ItemInfo(40776), new ItemInfo(40777), new ItemInfo(40778), new ItemInfo(40779), new ItemInfo(40780), new ItemInfo(40781), new ItemInfo(40782), new ItemInfo(40783), 
			new ItemInfo(40784), new ItemInfo(40787), new ItemInfo(40790), new ItemInfo(40791), new ItemInfo(40792), new ItemInfo(40793), new ItemInfo(40794), new ItemInfo(40795), new ItemInfo(40796), 
			new ItemInfo(40797), new ItemInfo(40798), new ItemInfo(40799), new ItemInfo(40800), new ItemInfo(40801), new ItemInfo(40802), new ItemInfo(40803), new ItemInfo(40804), new ItemInfo(40805), 
			new ItemInfo(40806), new ItemInfo(40807), new ItemInfo(40808), new ItemInfo(40809), new ItemInfo(40810), new ItemInfo(40811), new ItemInfo(40812), new ItemInfo(40813), new ItemInfo(40814), 
			new ItemInfo(40815), new ItemInfo(40816), new ItemInfo(40817), new ItemInfo(40818), new ItemInfo(40819), new ItemInfo(40820), new ItemInfo(40821), new ItemInfo(40822), new ItemInfo(40823), 
			new ItemInfo(40824), new ItemInfo(40825), new ItemInfo(40826), new ItemInfo(40827), new ItemInfo(40828), new ItemInfo(40829), new ItemInfo(40830), new ItemInfo(40831), new ItemInfo(40832), 
			new ItemInfo(40833), new ItemInfo(40834), new ItemInfo(40835), new ItemInfo(40836), new ItemInfo(40837), new ItemInfo(40838), new ItemInfo(40839), new ItemInfo(40840), new ItemInfo(40841), 
			new ItemInfo(40842), new ItemInfo(40843), new ItemInfo(40844), new ItemInfo(40845), new ItemInfo(40846), new ItemInfo(40847), new ItemInfo(40848), new ItemInfo(40849), new ItemInfo(40850)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt9Gump()
			: this(0)
		{ }

		public AddCustomPt9Gump(int page) 
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

			from.SendGump(new AddCustomPt9Gump(page));
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
