using Server.Network;

namespace Server.Gumps
{
	public class AddGroundStPt2Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddGroundStPt2", AccessLevel.GameMaster, new CommandEventHandler(AddGroundStPt2_OnCommand));
		}

		[Usage("AddGroundStPt2")]
		
		public static void AddGroundStPt2_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddGroundStPt2Gump>();
			e.Mobile.SendGump(new AddGroundStPt2Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region GroundSts
            new ItemInfo(11075), new ItemInfo(11078), new ItemInfo(11082), new ItemInfo(11084), new ItemInfo(11085), new ItemInfo(11087), new ItemInfo(11088), new ItemInfo(11090), 
            new ItemInfo(11091), new ItemInfo(11092), new ItemInfo(11094), new ItemInfo(11096), new ItemInfo(11100), new ItemInfo(11102), new ItemInfo(11104), new ItemInfo(11105), 
            new ItemInfo(11106), new ItemInfo(11107), new ItemInfo(11108), new ItemInfo(11109), new ItemInfo(11778), new ItemInfo(11779), new ItemInfo(11780), new ItemInfo(11781), 
            new ItemInfo(11782), new ItemInfo(11783), new ItemInfo(11784), new ItemInfo(11785), new ItemInfo(11786), new ItemInfo(11787), new ItemInfo(11788), new ItemInfo(11789), 
            new ItemInfo(11790), new ItemInfo(11791), new ItemInfo(11792), new ItemInfo(11793), new ItemInfo(11794), new ItemInfo(11795), new ItemInfo(11796), new ItemInfo(11797), 
            new ItemInfo(11798), new ItemInfo(11799), new ItemInfo(11800), new ItemInfo(11801), new ItemInfo(11802), new ItemInfo(11803), new ItemInfo(11804), new ItemInfo(11805), 
            new ItemInfo(11806), new ItemInfo(11807), new ItemInfo(11808), new ItemInfo(11809), new ItemInfo(11810), new ItemInfo(11811), new ItemInfo(11812), new ItemInfo(11813), 
            new ItemInfo(11814), new ItemInfo(11815), new ItemInfo(11816), new ItemInfo(11817), new ItemInfo(11818), new ItemInfo(11819), new ItemInfo(11820), new ItemInfo(11821), 
            new ItemInfo(11822), new ItemInfo(11823), new ItemInfo(11824), new ItemInfo(11825), new ItemInfo(11826), new ItemInfo(11827), new ItemInfo(11828), new ItemInfo(11829), 
            new ItemInfo(11830), new ItemInfo(11831), new ItemInfo(11832), new ItemInfo(11833), new ItemInfo(11834), new ItemInfo(11835), new ItemInfo(11840), new ItemInfo(11841), 
            new ItemInfo(11842), new ItemInfo(11843), new ItemInfo(11844), new ItemInfo(11845), new ItemInfo(11881), new ItemInfo(11882), new ItemInfo(11883), new ItemInfo(11884), 
            new ItemInfo(11885), new ItemInfo(11886), new ItemInfo(11887), new ItemInfo(11888), new ItemInfo(11889), new ItemInfo(11890), new ItemInfo(11891), new ItemInfo(11892), 
            new ItemInfo(11893), new ItemInfo(11894), new ItemInfo(11895), new ItemInfo(11896), new ItemInfo(11897), new ItemInfo(11898), new ItemInfo(11899), new ItemInfo(11900), 
            new ItemInfo(11901), new ItemInfo(11902), new ItemInfo(11903), new ItemInfo(11904), new ItemInfo(11905), new ItemInfo(11906), new ItemInfo(11907), new ItemInfo(11908), 
            new ItemInfo(11909), new ItemInfo(11910), new ItemInfo(11911), new ItemInfo(11912), new ItemInfo(11913), new ItemInfo(11914), new ItemInfo(11915), new ItemInfo(11916), 
            new ItemInfo(11917), new ItemInfo(11918), new ItemInfo(11919), new ItemInfo(11920), new ItemInfo(11921), new ItemInfo(11922), new ItemInfo(11923), new ItemInfo(11924), 
            new ItemInfo(11925), new ItemInfo(11926), new ItemInfo(11927), new ItemInfo(11928), new ItemInfo(11929), new ItemInfo(11930), new ItemInfo(11931), new ItemInfo(11932), 
            new ItemInfo(11933), new ItemInfo(11934), new ItemInfo(11935), new ItemInfo(11936), new ItemInfo(11937), new ItemInfo(11938), new ItemInfo(11939), new ItemInfo(11940), 
            new ItemInfo(11941), new ItemInfo(11942), new ItemInfo(11943), new ItemInfo(11944), new ItemInfo(11945), new ItemInfo(11946), new ItemInfo(11947), new ItemInfo(11948), 
            new ItemInfo(11949), new ItemInfo(11950), new ItemInfo(11951), new ItemInfo(11952), new ItemInfo(11953), new ItemInfo(11954), new ItemInfo(11955), new ItemInfo(11956), 
            new ItemInfo(11957), new ItemInfo(11958), new ItemInfo(11959), new ItemInfo(11960), new ItemInfo(11961), new ItemInfo(11962), new ItemInfo(11963), new ItemInfo(11964), 
            new ItemInfo(11965), new ItemInfo(11966), new ItemInfo(11967), new ItemInfo(11968), new ItemInfo(11969), new ItemInfo(11970), new ItemInfo(11971), new ItemInfo(11972)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddGroundStPt2Gump()
			: this(0)
		{ }

		public AddGroundStPt2Gump(int page) 
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

			from.SendGump(new AddGroundStPt2Gump(page));
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
