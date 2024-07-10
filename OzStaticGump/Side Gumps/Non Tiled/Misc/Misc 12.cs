using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt12Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt12", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt12_OnCommand));
		}

		[Usage("AddMiscPt12")]
		
		public static void AddMiscPt12_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt12Gump>();
			e.Mobile.SendGump(new AddMiscPt12Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(5699), new ItemInfo(5700), new ItemInfo(5701), new ItemInfo(5702), new ItemInfo(5703), new ItemInfo(5704), new ItemInfo(5705), new ItemInfo(5706), new ItemInfo(5707), 
            new ItemInfo(5708), new ItemInfo(5709), new ItemInfo(5710), new ItemInfo(5711), new ItemInfo(5712), new ItemInfo(5713), new ItemInfo(5714), new ItemInfo(5715), new ItemInfo(5716), 
            new ItemInfo(5717), new ItemInfo(5718), new ItemInfo(5719), new ItemInfo(5720), new ItemInfo(5721), new ItemInfo(5722), new ItemInfo(5723), new ItemInfo(5724), new ItemInfo(5725), 
            new ItemInfo(5726), new ItemInfo(5727), new ItemInfo(5728), new ItemInfo(5729), new ItemInfo(5730), new ItemInfo(5731), new ItemInfo(5732), new ItemInfo(5733), new ItemInfo(5734), 
            new ItemInfo(5735), new ItemInfo(5736), new ItemInfo(5737), new ItemInfo(5738), new ItemInfo(5739), new ItemInfo(5740), new ItemInfo(5741), new ItemInfo(5742), new ItemInfo(5743), 
            new ItemInfo(5744), new ItemInfo(5745), new ItemInfo(5746), new ItemInfo(5747), new ItemInfo(5748), new ItemInfo(5749), new ItemInfo(5750), new ItemInfo(5751), new ItemInfo(5752), 
            new ItemInfo(5753), new ItemInfo(5754), new ItemInfo(5755), new ItemInfo(5756), new ItemInfo(5757), new ItemInfo(5758), new ItemInfo(5759), new ItemInfo(5760), new ItemInfo(5761), 
            new ItemInfo(5762), new ItemInfo(5763), new ItemInfo(5764), new ItemInfo(5765), new ItemInfo(5766), new ItemInfo(5767), new ItemInfo(5768), new ItemInfo(5769), new ItemInfo(5770), 
            new ItemInfo(5771), new ItemInfo(5772), new ItemInfo(5773), new ItemInfo(5774), new ItemInfo(5775), new ItemInfo(5776), new ItemInfo(5777), new ItemInfo(5778), new ItemInfo(5779), 
            new ItemInfo(5780), new ItemInfo(5781), new ItemInfo(5782), new ItemInfo(5783), new ItemInfo(5784), new ItemInfo(5785), new ItemInfo(5786), new ItemInfo(5787), new ItemInfo(5788), 
            new ItemInfo(5789), new ItemInfo(5790), new ItemInfo(5791), new ItemInfo(5792), new ItemInfo(5793), new ItemInfo(5794), new ItemInfo(5795), new ItemInfo(5796), new ItemInfo(5797), 
            new ItemInfo(5798), new ItemInfo(5799), new ItemInfo(5800), new ItemInfo(5801), new ItemInfo(5802), new ItemInfo(5803), new ItemInfo(5804), new ItemInfo(5805), new ItemInfo(5806),
            new ItemInfo(5807), new ItemInfo(5808), new ItemInfo(5809), new ItemInfo(5810), new ItemInfo(5811), new ItemInfo(5812), new ItemInfo(5813), new ItemInfo(5814), new ItemInfo(5815), 
            new ItemInfo(5816), new ItemInfo(5817), new ItemInfo(5818), new ItemInfo(5819), new ItemInfo(5820), new ItemInfo(5821), new ItemInfo(5822), new ItemInfo(5823), new ItemInfo(5824), 
            new ItemInfo(5825), new ItemInfo(5826), new ItemInfo(5827), new ItemInfo(5828), new ItemInfo(5829), new ItemInfo(5830), new ItemInfo(5831), new ItemInfo(5832), new ItemInfo(5833), 
            new ItemInfo(5834), new ItemInfo(5835), new ItemInfo(5836), new ItemInfo(5837), new ItemInfo(5838), new ItemInfo(5839), new ItemInfo(5840), new ItemInfo(5841), new ItemInfo(5842), 
            new ItemInfo(5843), new ItemInfo(5844), new ItemInfo(5845), new ItemInfo(5846), new ItemInfo(5847), new ItemInfo(5848), new ItemInfo(5849), new ItemInfo(5850), new ItemInfo(5851), 
            new ItemInfo(5852), new ItemInfo(5853), new ItemInfo(5854), new ItemInfo(5855), new ItemInfo(5856), new ItemInfo(5857), new ItemInfo(5858), new ItemInfo(5859), new ItemInfo(5860), 
            new ItemInfo(5861), new ItemInfo(5862), new ItemInfo(5863), new ItemInfo(5864), new ItemInfo(5865), new ItemInfo(5866), new ItemInfo(5867), new ItemInfo(5868), new ItemInfo(5869), 
            new ItemInfo(5870), new ItemInfo(5871), new ItemInfo(5872), new ItemInfo(5873), new ItemInfo(5874), new ItemInfo(5875), new ItemInfo(5876), new ItemInfo(5877), new ItemInfo(5878), 
            new ItemInfo(5879), new ItemInfo(5880), new ItemInfo(5881), new ItemInfo(5882), new ItemInfo(5883), new ItemInfo(5884), new ItemInfo(5885), new ItemInfo(5886), new ItemInfo(5887), 
            new ItemInfo(5888), new ItemInfo(5889), new ItemInfo(5890), new ItemInfo(5891), new ItemInfo(5892), new ItemInfo(5893), new ItemInfo(5894), new ItemInfo(5895), new ItemInfo(5896), 
            new ItemInfo(5897), new ItemInfo(5898), new ItemInfo(5934), new ItemInfo(5935), new ItemInfo(5936), new ItemInfo(5937), new ItemInfo(5938), new ItemInfo(5939), new ItemInfo(5940), 
            new ItemInfo(5941), new ItemInfo(5942), new ItemInfo(5943), new ItemInfo(5944), new ItemInfo(5945), new ItemInfo(5946), new ItemInfo(5947), new ItemInfo(5948), new ItemInfo(5949), 
            new ItemInfo(5950), new ItemInfo(5951), new ItemInfo(5952), new ItemInfo(5953), new ItemInfo(5954), new ItemInfo(5955), new ItemInfo(5956), new ItemInfo(5957), new ItemInfo(5958)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt12Gump()
			: this(0)
		{ }

		public AddMiscPt12Gump(int page) 
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

			from.SendGump(new AddMiscPt12Gump(page));
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
