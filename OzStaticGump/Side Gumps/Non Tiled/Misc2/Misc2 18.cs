using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt18Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt18", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt18_OnCommand));
		}

		[Usage("AddMisc2Pt18")]
		
		public static void AddMisc2Pt18_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt18Gump>();
			e.Mobile.SendGump(new AddMisc2Pt18Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(18713), new ItemInfo(18714), new ItemInfo(18715), new ItemInfo(18716), new ItemInfo(18717), new ItemInfo(18718), new ItemInfo(18719), new ItemInfo(18720), new ItemInfo(18721), 
            new ItemInfo(18722), new ItemInfo(18723), new ItemInfo(18724), new ItemInfo(18725), new ItemInfo(18726), new ItemInfo(18727), new ItemInfo(18728), new ItemInfo(18729), new ItemInfo(18730), 
            new ItemInfo(18731), new ItemInfo(18732), new ItemInfo(18733), new ItemInfo(18734), new ItemInfo(18735), new ItemInfo(18736), new ItemInfo(18737), new ItemInfo(18738), new ItemInfo(18739), 
            new ItemInfo(18740), new ItemInfo(18741), new ItemInfo(18742), new ItemInfo(18743), new ItemInfo(18744), new ItemInfo(18745), new ItemInfo(18746), new ItemInfo(18747), new ItemInfo(18748), 
            new ItemInfo(18749), new ItemInfo(18750), new ItemInfo(18751), new ItemInfo(18752), new ItemInfo(18753), new ItemInfo(18754), new ItemInfo(18755), new ItemInfo(18756), new ItemInfo(18757), 
            new ItemInfo(18758), new ItemInfo(18759), new ItemInfo(18760), new ItemInfo(18761), new ItemInfo(18762), new ItemInfo(18763), new ItemInfo(18764), new ItemInfo(18765), new ItemInfo(18766), 
            new ItemInfo(18767), new ItemInfo(18768), new ItemInfo(18769), new ItemInfo(18770), new ItemInfo(18771), new ItemInfo(18772), new ItemInfo(18773), new ItemInfo(18774), new ItemInfo(18775), 
            new ItemInfo(18776), new ItemInfo(18777), new ItemInfo(18778), new ItemInfo(18779), new ItemInfo(18780), new ItemInfo(18781), new ItemInfo(18782), new ItemInfo(18783), new ItemInfo(18784), 
            new ItemInfo(18785), new ItemInfo(18786), new ItemInfo(18787), new ItemInfo(18788), new ItemInfo(18789), new ItemInfo(18790), new ItemInfo(18791), new ItemInfo(18792), new ItemInfo(18793), 
            new ItemInfo(18794), new ItemInfo(18795), new ItemInfo(18796), new ItemInfo(18797), new ItemInfo(18798), new ItemInfo(18799), new ItemInfo(18800), new ItemInfo(18802), new ItemInfo(18803), 
            new ItemInfo(18804), new ItemInfo(18805), new ItemInfo(18806), new ItemInfo(18807), new ItemInfo(18808), new ItemInfo(18809), new ItemInfo(18810), new ItemInfo(18811), new ItemInfo(18812), 
            new ItemInfo(18813), new ItemInfo(18814), new ItemInfo(18815), new ItemInfo(18816), new ItemInfo(18817), new ItemInfo(18818), new ItemInfo(18819), new ItemInfo(18820), new ItemInfo(18821), 
            new ItemInfo(18822), new ItemInfo(18823), new ItemInfo(18825), new ItemInfo(18826), new ItemInfo(18827), new ItemInfo(18828), new ItemInfo(18829), new ItemInfo(18830), new ItemInfo(18832), 
            new ItemInfo(18833), new ItemInfo(18834), new ItemInfo(18835), new ItemInfo(18836), new ItemInfo(18837), new ItemInfo(18838), new ItemInfo(18839), new ItemInfo(18840), new ItemInfo(18841), 
            new ItemInfo(18842), new ItemInfo(18843), new ItemInfo(18844), new ItemInfo(18846), new ItemInfo(18847), new ItemInfo(18848), new ItemInfo(18849), new ItemInfo(18850), new ItemInfo(18851), 
            new ItemInfo(18852), new ItemInfo(18853), new ItemInfo(18854), new ItemInfo(18855), new ItemInfo(18856), new ItemInfo(18857), new ItemInfo(18858), new ItemInfo(18859), new ItemInfo(18860), 
            new ItemInfo(18861), new ItemInfo(18862), new ItemInfo(18863), new ItemInfo(18864), new ItemInfo(18865), new ItemInfo(18866), new ItemInfo(18867), new ItemInfo(18868), new ItemInfo(18869), 
            new ItemInfo(18870), new ItemInfo(18871), new ItemInfo(18872), new ItemInfo(18873), new ItemInfo(18874), new ItemInfo(18875), new ItemInfo(18876), new ItemInfo(18877), new ItemInfo(18878), 
            new ItemInfo(18879), new ItemInfo(18880), new ItemInfo(18884), new ItemInfo(18885), new ItemInfo(18886), new ItemInfo(18887), new ItemInfo(18888), new ItemInfo(18889), new ItemInfo(18890), 
            new ItemInfo(18891), new ItemInfo(18892), new ItemInfo(18893), new ItemInfo(18894), new ItemInfo(18895), new ItemInfo(18896), new ItemInfo(18897), new ItemInfo(18898), new ItemInfo(18899), 
            new ItemInfo(18900), new ItemInfo(18901), new ItemInfo(18902), new ItemInfo(18903), new ItemInfo(18904), new ItemInfo(18905), new ItemInfo(18906), new ItemInfo(18907), new ItemInfo(18908), 
            new ItemInfo(18909), new ItemInfo(18910), new ItemInfo(18911), new ItemInfo(18912), new ItemInfo(18913), new ItemInfo(18914), new ItemInfo(18915), new ItemInfo(18916), new ItemInfo(18917), 
            new ItemInfo(18918), new ItemInfo(18919), new ItemInfo(18920), new ItemInfo(18921), new ItemInfo(18922), new ItemInfo(18923), new ItemInfo(18924), new ItemInfo(18925), new ItemInfo(18926), 
            new ItemInfo(18927), new ItemInfo(18928), new ItemInfo(18929), new ItemInfo(18930), new ItemInfo(18931), new ItemInfo(18932), new ItemInfo(18933), new ItemInfo(18934), new ItemInfo(18935), 
            new ItemInfo(18936), new ItemInfo(18937), new ItemInfo(18938), new ItemInfo(18939), new ItemInfo(19096), new ItemInfo(19097), new ItemInfo(19108), new ItemInfo(19109), new ItemInfo(19110), 
            new ItemInfo(19111), new ItemInfo(19112), new ItemInfo(19113), new ItemInfo(19124), new ItemInfo(19125), new ItemInfo(19126), new ItemInfo(19127), new ItemInfo(19128), new ItemInfo(19198), 
            new ItemInfo(19199), new ItemInfo(19228), new ItemInfo(19229), new ItemInfo(19230), new ItemInfo(19231), new ItemInfo(19232), new ItemInfo(19233), new ItemInfo(19234), new ItemInfo(19235), 
            new ItemInfo(19236), new ItemInfo(19237), new ItemInfo(19238), new ItemInfo(19239), new ItemInfo(19240), new ItemInfo(19241), new ItemInfo(19242), new ItemInfo(19248), new ItemInfo(19249), 
            new ItemInfo(19261), new ItemInfo(19268), new ItemInfo(19269), new ItemInfo(19270), new ItemInfo(19271), new ItemInfo(19272), new ItemInfo(19273), new ItemInfo(19274), new ItemInfo(19275), 
            new ItemInfo(19276), new ItemInfo(19277), new ItemInfo(19278), new ItemInfo(19279), new ItemInfo(19280), new ItemInfo(19281), new ItemInfo(19282), new ItemInfo(19283), new ItemInfo(19284), 
            new ItemInfo(19285), new ItemInfo(19286), new ItemInfo(19287), new ItemInfo(19288), new ItemInfo(19289), new ItemInfo(19290), new ItemInfo(19291), new ItemInfo(19292), new ItemInfo(19293), 
            new ItemInfo(19294), new ItemInfo(19295), new ItemInfo(19296), new ItemInfo(19297), new ItemInfo(19298), new ItemInfo(19299), new ItemInfo(19300), new ItemInfo(19301), new ItemInfo(19302), 
            new ItemInfo(19303), new ItemInfo(19304), new ItemInfo(19305), new ItemInfo(19306), new ItemInfo(19307), new ItemInfo(19308), new ItemInfo(19309), new ItemInfo(19310), new ItemInfo(19311), 
            new ItemInfo(19312), new ItemInfo(19313), new ItemInfo(19314), new ItemInfo(19315), new ItemInfo(19316), new ItemInfo(19317), new ItemInfo(19318), new ItemInfo(19319), new ItemInfo(19320), 
            new ItemInfo(19321), new ItemInfo(19322), new ItemInfo(19323), new ItemInfo(19324), new ItemInfo(19325), new ItemInfo(19326), new ItemInfo(19327), new ItemInfo(19328), new ItemInfo(19329), 
            new ItemInfo(19330), new ItemInfo(19331), new ItemInfo(19332), new ItemInfo(19333), new ItemInfo(19334), new ItemInfo(19335), new ItemInfo(19336), new ItemInfo(19337), new ItemInfo(19338), 
            new ItemInfo(19339), new ItemInfo(19340), new ItemInfo(19341), new ItemInfo(19342), new ItemInfo(19357), new ItemInfo(19358), new ItemInfo(19359), new ItemInfo(19360), new ItemInfo(19361), 
            new ItemInfo(19362), new ItemInfo(19365), new ItemInfo(19366), new ItemInfo(19367), new ItemInfo(19368), new ItemInfo(19419), new ItemInfo(19420), new ItemInfo(19421), new ItemInfo(19422), 
            new ItemInfo(19423), new ItemInfo(19424), new ItemInfo(19425), new ItemInfo(19426), new ItemInfo(19427), new ItemInfo(19428), new ItemInfo(19429), new ItemInfo(19430), new ItemInfo(19431), 
            new ItemInfo(19432), new ItemInfo(19433), new ItemInfo(19434), new ItemInfo(19435), new ItemInfo(19436), new ItemInfo(19437), new ItemInfo(19438), new ItemInfo(19439), new ItemInfo(19440)

            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt18Gump()
			: this(0)
		{ }

		public AddMisc2Pt18Gump(int page) 
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

			from.SendGump(new AddMisc2Pt18Gump(page));
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
