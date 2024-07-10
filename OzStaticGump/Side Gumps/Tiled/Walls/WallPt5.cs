using Server.Network;

namespace Server.Gumps
{
	public class AddWallPt5Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddWallPt5", AccessLevel.GameMaster, new CommandEventHandler(AddWallPt5_OnCommand));
		}

		[Usage("AddWallPt5")]
		public static void AddWallPt5_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddWallPt5Gump>();
			e.Mobile.SendGump(new AddWallPt5Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(19759), new ItemInfo(19760), new ItemInfo(19761), new ItemInfo(19762), new ItemInfo(19763), new ItemInfo(19764), new ItemInfo(19765), new ItemInfo(19766), 
            new ItemInfo(19767), new ItemInfo(19768), new ItemInfo(19769), new ItemInfo(19770), new ItemInfo(19771), new ItemInfo(19772), new ItemInfo(19773), new ItemInfo(19774), 
            new ItemInfo(19775), new ItemInfo(19776), new ItemInfo(19777), new ItemInfo(19778), new ItemInfo(19779), new ItemInfo(19780), new ItemInfo(19781), new ItemInfo(19782), 
            new ItemInfo(19783), new ItemInfo(19784), new ItemInfo(19785), new ItemInfo(19786), new ItemInfo(19787), new ItemInfo(19788), new ItemInfo(19789), new ItemInfo(19790), 
            new ItemInfo(19791), new ItemInfo(19792), new ItemInfo(19793), new ItemInfo(19794), new ItemInfo(19795), new ItemInfo(19796), new ItemInfo(19797), new ItemInfo(19798), 
            new ItemInfo(19799), new ItemInfo(19800), new ItemInfo(19801), new ItemInfo(19802), new ItemInfo(19803), new ItemInfo(19804), new ItemInfo(19805), new ItemInfo(19806), 
            new ItemInfo(19807), new ItemInfo(19808), new ItemInfo(19809), new ItemInfo(19810), new ItemInfo(19811), new ItemInfo(19812), new ItemInfo(19813), new ItemInfo(19814), 
            new ItemInfo(19815), new ItemInfo(19816), new ItemInfo(19817), new ItemInfo(19818), new ItemInfo(19819), new ItemInfo(19820), new ItemInfo(19821), new ItemInfo(19822), 
            new ItemInfo(19823), new ItemInfo(19824), new ItemInfo(19825), new ItemInfo(19826), new ItemInfo(19827), new ItemInfo(19828), new ItemInfo(19829), new ItemInfo(19830), 
            new ItemInfo(19831), new ItemInfo(19832), new ItemInfo(19833), new ItemInfo(19834), new ItemInfo(19835), new ItemInfo(19836), new ItemInfo(19837), new ItemInfo(19838), 
            new ItemInfo(19839), new ItemInfo(19840), new ItemInfo(19841), new ItemInfo(19842), new ItemInfo(19843), new ItemInfo(19844), new ItemInfo(19845), new ItemInfo(19846), 
            new ItemInfo(19847), new ItemInfo(19848), new ItemInfo(19849), new ItemInfo(19850), new ItemInfo(19851), new ItemInfo(19852), new ItemInfo(19853), new ItemInfo(19854), 
            new ItemInfo(19855), new ItemInfo(19856), new ItemInfo(19857), new ItemInfo(19858), new ItemInfo(19859), new ItemInfo(19860), new ItemInfo(19861), new ItemInfo(19862), 
            new ItemInfo(19863), new ItemInfo(19864), new ItemInfo(19865), new ItemInfo(19866), new ItemInfo(19867), new ItemInfo(19868), new ItemInfo(19869), new ItemInfo(19870), 
            new ItemInfo(19871), new ItemInfo(19872), new ItemInfo(19873), new ItemInfo(19874), new ItemInfo(19875), new ItemInfo(19876), new ItemInfo(19877), new ItemInfo(19878), 
            new ItemInfo(19879), new ItemInfo(19880), new ItemInfo(19881), new ItemInfo(19882), new ItemInfo(19883), new ItemInfo(19884), new ItemInfo(19885), new ItemInfo(19886), 
            new ItemInfo(19887), new ItemInfo(19888), new ItemInfo(19889), new ItemInfo(19890), new ItemInfo(19891), new ItemInfo(19892), new ItemInfo(19893), new ItemInfo(19894), 
            new ItemInfo(19895), new ItemInfo(19896), new ItemInfo(19897), new ItemInfo(19898), new ItemInfo(19899), new ItemInfo(19900), new ItemInfo(19901), new ItemInfo(19902), 
            new ItemInfo(19903), new ItemInfo(19904), new ItemInfo(19905), new ItemInfo(19906), new ItemInfo(19907), new ItemInfo(19908), new ItemInfo(19909), new ItemInfo(19910), 
            new ItemInfo(19911), new ItemInfo(19912), new ItemInfo(19913), new ItemInfo(19914), new ItemInfo(19915), new ItemInfo(19916), new ItemInfo(19917), new ItemInfo(19918), 
            new ItemInfo(19919), new ItemInfo(19920), new ItemInfo(19921), new ItemInfo(19922), new ItemInfo(19923), new ItemInfo(19924), new ItemInfo(19925), new ItemInfo(19926), 
            new ItemInfo(19927), new ItemInfo(19928), new ItemInfo(19929), new ItemInfo(19930), new ItemInfo(19931), new ItemInfo(19932), new ItemInfo(19933), new ItemInfo(19934), 
            new ItemInfo(19935), new ItemInfo(20698), new ItemInfo(20699), new ItemInfo(20700), new ItemInfo(20701), new ItemInfo(20733), new ItemInfo(20734), new ItemInfo(20735), 
            new ItemInfo(20736), new ItemInfo(20737), new ItemInfo(20738), new ItemInfo(20739), new ItemInfo(20740), new ItemInfo(20741), new ItemInfo(20742), new ItemInfo(20743), 
            new ItemInfo(20744), new ItemInfo(20745), new ItemInfo(20746), new ItemInfo(20747), new ItemInfo(20748), new ItemInfo(20749), new ItemInfo(20750), new ItemInfo(20751), 
            new ItemInfo(20752), new ItemInfo(20753), new ItemInfo(20754), new ItemInfo(20755), new ItemInfo(20756), new ItemInfo(20757), new ItemInfo(20758), new ItemInfo(20759), 
            new ItemInfo(20760), new ItemInfo(20761), new ItemInfo(20762), new ItemInfo(20763), new ItemInfo(20764), new ItemInfo(20765), new ItemInfo(20766), new ItemInfo(20767), 
            new ItemInfo(20768), new ItemInfo(20769), new ItemInfo(20770), new ItemInfo(20775), new ItemInfo(20776), new ItemInfo(20777), new ItemInfo(20778), new ItemInfo(20779), 
            new ItemInfo(20780), new ItemInfo(20781), new ItemInfo(20782), new ItemInfo(20783), new ItemInfo(20784), new ItemInfo(20785), new ItemInfo(20786), new ItemInfo(20787), 
            new ItemInfo(20788), new ItemInfo(20789), new ItemInfo(20790), new ItemInfo(20791), new ItemInfo(20792), new ItemInfo(20793), new ItemInfo(20794), new ItemInfo(20795), 
            new ItemInfo(20796), new ItemInfo(20797), new ItemInfo(20798), new ItemInfo(20799), new ItemInfo(20800), new ItemInfo(20801), new ItemInfo(30694), new ItemInfo(30695), 
            new ItemInfo(30696), new ItemInfo(30697), new ItemInfo(30698), new ItemInfo(30699), new ItemInfo(30700), new ItemInfo(30701), new ItemInfo(30702), new ItemInfo(30703), 
            new ItemInfo(30704), new ItemInfo(30710), new ItemInfo(30711), new ItemInfo(30712), new ItemInfo(30713), new ItemInfo(30714), new ItemInfo(30723), new ItemInfo(30724), 
            new ItemInfo(30725), new ItemInfo(30726), new ItemInfo(30736), new ItemInfo(30737)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddWallPt5Gump()
			: this(0)
		{ }

		public AddWallPt5Gump(int page) 
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

			from.SendGump(new AddWallPt5Gump(page));
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
