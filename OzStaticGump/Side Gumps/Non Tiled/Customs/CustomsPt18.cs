using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt18Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt18", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt18_OnCommand));
		}

		[Usage("AddCustomPt18")]
		
		public static void AddCustomPt18_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt18Gump>();
			e.Mobile.SendGump(new AddCustomPt18Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
           new ItemInfo(42743), new ItemInfo(42744), new ItemInfo(42745), new ItemInfo(42746), new ItemInfo(42747), new ItemInfo(42748), new ItemInfo(42749), new ItemInfo(42750), new ItemInfo(42751), 
			new ItemInfo(42752), new ItemInfo(42753), new ItemInfo(42754), new ItemInfo(42755), new ItemInfo(42757), new ItemInfo(42758), new ItemInfo(42759), new ItemInfo(42760), new ItemInfo(42761), 
			new ItemInfo(42762), new ItemInfo(42763), new ItemInfo(42764), new ItemInfo(42765), new ItemInfo(42766), new ItemInfo(42767), new ItemInfo(42768), new ItemInfo(42769), new ItemInfo(42770), 
			new ItemInfo(42771), new ItemInfo(42772), new ItemInfo(42773), new ItemInfo(42774), new ItemInfo(42775), new ItemInfo(42776), new ItemInfo(42777), new ItemInfo(42778), new ItemInfo(42779), 
			new ItemInfo(42780), new ItemInfo(42781), new ItemInfo(42782), new ItemInfo(42783), new ItemInfo(42784), new ItemInfo(42785), new ItemInfo(42786), new ItemInfo(42787), new ItemInfo(42788), 
			new ItemInfo(42789), new ItemInfo(42790), new ItemInfo(42791), new ItemInfo(42792), new ItemInfo(42793), new ItemInfo(42794), new ItemInfo(42795), new ItemInfo(42796), new ItemInfo(42798), 
			new ItemInfo(42799), new ItemInfo(42800), new ItemInfo(42801), new ItemInfo(42802), new ItemInfo(42803), new ItemInfo(42804), new ItemInfo(42805), new ItemInfo(42806), new ItemInfo(42807), 
			new ItemInfo(42808), new ItemInfo(42809), new ItemInfo(42810), new ItemInfo(42811), new ItemInfo(42812), new ItemInfo(42813), new ItemInfo(42814), new ItemInfo(42815), new ItemInfo(42816), 
			new ItemInfo(42817), new ItemInfo(42818), new ItemInfo(42819), new ItemInfo(42820), new ItemInfo(42821), new ItemInfo(42822), new ItemInfo(42823), new ItemInfo(42824), new ItemInfo(42825), 
			new ItemInfo(42826), new ItemInfo(42827), new ItemInfo(42828), new ItemInfo(42829), new ItemInfo(42830), new ItemInfo(42831), new ItemInfo(42832), new ItemInfo(42833), new ItemInfo(42834), 
			new ItemInfo(42835), new ItemInfo(42836), new ItemInfo(42837), new ItemInfo(42839), new ItemInfo(42840), new ItemInfo(42841), new ItemInfo(42842), new ItemInfo(42843), new ItemInfo(42844), 
			new ItemInfo(42845), new ItemInfo(42846), new ItemInfo(42847), new ItemInfo(42848), new ItemInfo(42849), new ItemInfo(42850), new ItemInfo(42851), new ItemInfo(42852), new ItemInfo(42853), 
			new ItemInfo(42854), new ItemInfo(42855), new ItemInfo(42856), new ItemInfo(42857), new ItemInfo(42858), new ItemInfo(42859), new ItemInfo(42860), new ItemInfo(42861), new ItemInfo(42862), 
			new ItemInfo(42863), new ItemInfo(42864), new ItemInfo(42865), new ItemInfo(42866), new ItemInfo(42867), new ItemInfo(42868), new ItemInfo(42869), new ItemInfo(42870), new ItemInfo(42871), 
			new ItemInfo(42872), new ItemInfo(42873), new ItemInfo(42874), new ItemInfo(42875), new ItemInfo(42876), new ItemInfo(42877), new ItemInfo(42878), new ItemInfo(42880), new ItemInfo(42881), 
			new ItemInfo(42882), new ItemInfo(42883), new ItemInfo(42884), new ItemInfo(42885), new ItemInfo(42886), new ItemInfo(42887), new ItemInfo(42888), new ItemInfo(42889), new ItemInfo(42890), 
			new ItemInfo(42891), new ItemInfo(42892), new ItemInfo(42893), new ItemInfo(42894), new ItemInfo(42895), new ItemInfo(42896), new ItemInfo(42897), new ItemInfo(42898), new ItemInfo(42899), 
			new ItemInfo(42900), new ItemInfo(42901), new ItemInfo(42902), new ItemInfo(42903), new ItemInfo(42904), new ItemInfo(42905), new ItemInfo(42906), new ItemInfo(42907), new ItemInfo(42908), 
			new ItemInfo(42909), new ItemInfo(42910), new ItemInfo(42911), new ItemInfo(42912), new ItemInfo(42913), new ItemInfo(42914), new ItemInfo(42915), new ItemInfo(42916), new ItemInfo(42917), 
			new ItemInfo(42918), new ItemInfo(42919), new ItemInfo(42920), new ItemInfo(42921), new ItemInfo(42922), new ItemInfo(42923), new ItemInfo(42924), new ItemInfo(42925), new ItemInfo(42926), 
			new ItemInfo(42927), new ItemInfo(42928), new ItemInfo(42929), new ItemInfo(42930), new ItemInfo(42931), new ItemInfo(42932), new ItemInfo(42933), new ItemInfo(42934), new ItemInfo(42935), 
			new ItemInfo(42936), new ItemInfo(42937), new ItemInfo(42938), new ItemInfo(42939), new ItemInfo(42940), new ItemInfo(42941), new ItemInfo(42942), new ItemInfo(42943), new ItemInfo(42944), 
			new ItemInfo(42945), new ItemInfo(42946), new ItemInfo(42947), new ItemInfo(42948), new ItemInfo(42949), new ItemInfo(42950), new ItemInfo(42951), new ItemInfo(42952), new ItemInfo(42953), 
			new ItemInfo(42954), new ItemInfo(42955), new ItemInfo(42956), new ItemInfo(42957), new ItemInfo(42958), new ItemInfo(42959), new ItemInfo(42961), new ItemInfo(42962), new ItemInfo(42963), 
			new ItemInfo(42964), new ItemInfo(42965), new ItemInfo(42966), new ItemInfo(42967), new ItemInfo(42968), new ItemInfo(42969), new ItemInfo(42970), new ItemInfo(42971), new ItemInfo(42972)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt18Gump()
			: this(0)
		{ }

		public AddCustomPt18Gump(int page) 
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

			from.SendGump(new AddCustomPt18Gump(page));
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
