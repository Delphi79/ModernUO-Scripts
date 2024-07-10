using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt4Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt4", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt4_OnCommand));
		}

		[Usage("AddCustomPt4")]
		
		public static void AddCustomPt4_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt4Gump>();
			e.Mobile.SendGump(new AddCustomPt4Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(39755), new ItemInfo(39756), new ItemInfo(39757), new ItemInfo(39758), new ItemInfo(39759), new ItemInfo(39760), new ItemInfo(39761), new ItemInfo(39762), new ItemInfo(39763), 
			new ItemInfo(39764), new ItemInfo(39765), new ItemInfo(39766), new ItemInfo(39767), new ItemInfo(39768), new ItemInfo(39769), new ItemInfo(39770), new ItemInfo(39771), new ItemInfo(39772), 
			new ItemInfo(39773), new ItemInfo(39774), new ItemInfo(39775), new ItemInfo(39776), new ItemInfo(39777), new ItemInfo(39778), new ItemInfo(39779), new ItemInfo(39780), new ItemInfo(39781), 
			new ItemInfo(39782), new ItemInfo(39783), new ItemInfo(39784), new ItemInfo(39785), new ItemInfo(39786), new ItemInfo(39787), new ItemInfo(39788), new ItemInfo(39789), new ItemInfo(39790), 
			new ItemInfo(39791), new ItemInfo(39792), new ItemInfo(39793), new ItemInfo(39794), new ItemInfo(39795), new ItemInfo(39796), new ItemInfo(39797), new ItemInfo(39798), new ItemInfo(39799), 
			new ItemInfo(39800), new ItemInfo(39801), new ItemInfo(39802), new ItemInfo(39803), new ItemInfo(39804), new ItemInfo(39805), new ItemInfo(39806), new ItemInfo(39807), new ItemInfo(39808), 
			new ItemInfo(39809), new ItemInfo(39810), new ItemInfo(39811), new ItemInfo(39812), new ItemInfo(39813), new ItemInfo(39814), new ItemInfo(39815), new ItemInfo(39816), new ItemInfo(39817), 
			new ItemInfo(39818), new ItemInfo(39819), new ItemInfo(39820), new ItemInfo(39821), new ItemInfo(39822), new ItemInfo(39823), new ItemInfo(39824), new ItemInfo(39825), new ItemInfo(39826), 
			new ItemInfo(39827), new ItemInfo(39828), new ItemInfo(39829), new ItemInfo(39830), new ItemInfo(39831), new ItemInfo(39832), new ItemInfo(39833), new ItemInfo(39834), new ItemInfo(39835), 
			new ItemInfo(39836), new ItemInfo(39837), new ItemInfo(39838), new ItemInfo(39839), new ItemInfo(39840), new ItemInfo(39841), new ItemInfo(39842), new ItemInfo(39843), new ItemInfo(39844), 
			new ItemInfo(39845), new ItemInfo(39846), new ItemInfo(39847), new ItemInfo(39848), new ItemInfo(39849), new ItemInfo(39850), new ItemInfo(39851), new ItemInfo(39852), new ItemInfo(39853), 
			new ItemInfo(39854), new ItemInfo(39855), new ItemInfo(39856), new ItemInfo(39857), new ItemInfo(39858), new ItemInfo(39859), new ItemInfo(39860), new ItemInfo(39861), new ItemInfo(39862), 
			new ItemInfo(39863), new ItemInfo(39864), new ItemInfo(39865), new ItemInfo(39866), new ItemInfo(39867), new ItemInfo(39868), new ItemInfo(39869), new ItemInfo(39870), new ItemInfo(39871), 
			new ItemInfo(39872), new ItemInfo(39873), new ItemInfo(39874), new ItemInfo(39875), new ItemInfo(39876), new ItemInfo(39877), new ItemInfo(39878), new ItemInfo(39879), new ItemInfo(39880), 
			new ItemInfo(39881), new ItemInfo(39882), new ItemInfo(39883), new ItemInfo(39884), new ItemInfo(39885), new ItemInfo(39886), new ItemInfo(39887), new ItemInfo(39888), new ItemInfo(39889), 
			new ItemInfo(39890), new ItemInfo(39891), new ItemInfo(39892), new ItemInfo(39893), new ItemInfo(39894), new ItemInfo(39895), new ItemInfo(39896), new ItemInfo(39897), new ItemInfo(39898), 
			new ItemInfo(39899), new ItemInfo(39900), new ItemInfo(39901), new ItemInfo(39902), new ItemInfo(39903), new ItemInfo(39904), new ItemInfo(39905), new ItemInfo(39906), new ItemInfo(39907), 
			new ItemInfo(39908), new ItemInfo(39909), new ItemInfo(39910), new ItemInfo(39911), new ItemInfo(39912), new ItemInfo(39913), new ItemInfo(39914), new ItemInfo(39915), new ItemInfo(39916), 
			new ItemInfo(39917), new ItemInfo(39918), new ItemInfo(39919), new ItemInfo(39920), new ItemInfo(39921), new ItemInfo(39922), new ItemInfo(39923), new ItemInfo(39924), new ItemInfo(39925), 
			new ItemInfo(39926), new ItemInfo(39927), new ItemInfo(39928), new ItemInfo(39929), new ItemInfo(39930), new ItemInfo(39931), new ItemInfo(39932), new ItemInfo(39933), new ItemInfo(39934)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt4Gump()
			: this(0)
		{ }

		public AddCustomPt4Gump(int page) 
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

			from.SendGump(new AddCustomPt4Gump(page));
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
