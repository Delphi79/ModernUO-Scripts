using Server.Network;

namespace Server.Gumps
{
	public class AddGroundStPt5Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddGroundStPt5", AccessLevel.GameMaster, new CommandEventHandler(AddGroundStPt5_OnCommand));
		}

		[Usage("AddGroundStPt5")]
		
		public static void AddGroundStPt5_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddGroundStPt5Gump>();
			e.Mobile.SendGump(new AddGroundStPt5Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region GroundSts
            new ItemInfo(13372), new ItemInfo(13373), new ItemInfo(13374), new ItemInfo(13375), new ItemInfo(13376), new ItemInfo(13377), new ItemInfo(13378), new ItemInfo(13379), 
            new ItemInfo(13380), new ItemInfo(13381), new ItemInfo(13384), new ItemInfo(13385), new ItemInfo(13386), new ItemInfo(13387), new ItemInfo(13388), new ItemInfo(13390), 
            new ItemInfo(13391), new ItemInfo(13392), new ItemInfo(13393), new ItemInfo(13394), new ItemInfo(13395), new ItemInfo(13396), new ItemInfo(13397), new ItemInfo(13398), 
            new ItemInfo(13399), new ItemInfo(13401), new ItemInfo(13402), new ItemInfo(13403), new ItemInfo(13404), new ItemInfo(13405), new ItemInfo(13406), new ItemInfo(13407), 
            new ItemInfo(13408), new ItemInfo(13410), new ItemInfo(13411), new ItemInfo(13412), new ItemInfo(13413), new ItemInfo(13414), new ItemInfo(13415), new ItemInfo(13416), 
            new ItemInfo(13417), new ItemInfo(13418), new ItemInfo(13419), new ItemInfo(13420), new ItemInfo(13422), new ItemInfo(13423), new ItemInfo(13424), new ItemInfo(13425), 
            new ItemInfo(13426), new ItemInfo(13427), new ItemInfo(13428), new ItemInfo(13429), new ItemInfo(13430), new ItemInfo(13431), new ItemInfo(13432), new ItemInfo(13433), 
            new ItemInfo(13434), new ItemInfo(13435), new ItemInfo(13436), new ItemInfo(13437), new ItemInfo(13438), new ItemInfo(13439), new ItemInfo(13440), new ItemInfo(13441), 
            new ItemInfo(13442), new ItemInfo(13443), new ItemInfo(13444), new ItemInfo(13445), new ItemInfo(13456), new ItemInfo(13457), new ItemInfo(13458), new ItemInfo(13459), 
            new ItemInfo(13460), new ItemInfo(13461), new ItemInfo(13462), new ItemInfo(13463), new ItemInfo(13464), new ItemInfo(13465), new ItemInfo(13466), new ItemInfo(13467), 
            new ItemInfo(13468), new ItemInfo(13469), new ItemInfo(13470), new ItemInfo(13471), new ItemInfo(13472), new ItemInfo(13473), new ItemInfo(13474), new ItemInfo(13475), 
            new ItemInfo(13476), new ItemInfo(13477), new ItemInfo(13478), new ItemInfo(13479), new ItemInfo(13480), new ItemInfo(13481), new ItemInfo(13482), new ItemInfo(13483), 
            new ItemInfo(13493), new ItemInfo(13494), new ItemInfo(13495), new ItemInfo(13496), new ItemInfo(13497), new ItemInfo(13498), new ItemInfo(13499), new ItemInfo(13501), 
            new ItemInfo(13502), new ItemInfo(13503), new ItemInfo(13504), new ItemInfo(13506), new ItemInfo(13507), new ItemInfo(13508), new ItemInfo(13509), new ItemInfo(13511), 
            new ItemInfo(13512), new ItemInfo(13513), new ItemInfo(13514), new ItemInfo(13521), new ItemInfo(13522), new ItemInfo(13523), new ItemInfo(13524), new ItemInfo(13525), 
            new ItemInfo(13613), new ItemInfo(13614), new ItemInfo(13615), new ItemInfo(13616), new ItemInfo(13638), new ItemInfo(13639), new ItemInfo(13640), new ItemInfo(13641), 
            new ItemInfo(13642), new ItemInfo(13643), new ItemInfo(13644), new ItemInfo(13645), new ItemInfo(13646), new ItemInfo(13647), new ItemInfo(13648), new ItemInfo(13649), 
            new ItemInfo(13650), new ItemInfo(13651), new ItemInfo(13652), new ItemInfo(13653), new ItemInfo(13654), new ItemInfo(13655), new ItemInfo(13656), new ItemInfo(13657), 
            new ItemInfo(13658), new ItemInfo(13659), new ItemInfo(13660), new ItemInfo(13661), new ItemInfo(13662), new ItemInfo(13663), new ItemInfo(13664), new ItemInfo(13665),
            new ItemInfo(15088), new ItemInfo(15089), new ItemInfo(15090), new ItemInfo(15091), new ItemInfo(15092), new ItemInfo(15093), new ItemInfo(15094), new ItemInfo(15095), 
            new ItemInfo(15096), new ItemInfo(15126), new ItemInfo(15127), new ItemInfo(15128), new ItemInfo(15129), new ItemInfo(15130), new ItemInfo(15131), new ItemInfo(15132), 
            new ItemInfo(15133), new ItemInfo(15134), new ItemInfo(15135), new ItemInfo(15136), new ItemInfo(15137), new ItemInfo(15138), new ItemInfo(15139), new ItemInfo(15140), 
            new ItemInfo(15141), new ItemInfo(15142), new ItemInfo(15143), new ItemInfo(15144), new ItemInfo(15145), new ItemInfo(15146), new ItemInfo(15147), new ItemInfo(15148), 
            new ItemInfo(15149), new ItemInfo(15150), new ItemInfo(15151), new ItemInfo(15152), new ItemInfo(15153), new ItemInfo(15154), new ItemInfo(15155), new ItemInfo(15156), 
            new ItemInfo(15157), new ItemInfo(15158), new ItemInfo(15159)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddGroundStPt5Gump()
			: this(0)
		{ }

		public AddGroundStPt5Gump(int page) 
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

			from.SendGump(new AddGroundStPt5Gump(page));
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
