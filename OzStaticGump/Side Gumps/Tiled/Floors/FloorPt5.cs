using Server.Network;

namespace Server.Gumps
{
	public class AddFloorPt5Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFloorPt5", AccessLevel.GameMaster, new CommandEventHandler(AddFloorPt5_OnCommand));
		}

		[Usage("AddFloorPt5")]
		
		public static void AddFloorPt5_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFloorPt5Gump>();
			e.Mobile.SendGump(new AddFloorPt5Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(17424), new ItemInfo(17425), new ItemInfo(17426), new ItemInfo(17427), new ItemInfo(17428), new ItemInfo(17429), new ItemInfo(17430), new ItemInfo(17431), 
            new ItemInfo(17432), new ItemInfo(17433), new ItemInfo(17434), new ItemInfo(17435), new ItemInfo(17436), new ItemInfo(17437), new ItemInfo(17438), new ItemInfo(17439), 
            new ItemInfo(17440), new ItemInfo(17441), new ItemInfo(17442), new ItemInfo(17443), new ItemInfo(17444), new ItemInfo(17445), new ItemInfo(17446), new ItemInfo(17447), 
            new ItemInfo(17448), new ItemInfo(17449), new ItemInfo(17450), new ItemInfo(17451), new ItemInfo(17452), new ItemInfo(17453), new ItemInfo(17454), new ItemInfo(17455), 
            new ItemInfo(17456), new ItemInfo(17457), new ItemInfo(17458), new ItemInfo(17459), new ItemInfo(17460), new ItemInfo(17461), new ItemInfo(17462), new ItemInfo(17463), 
            new ItemInfo(17464), new ItemInfo(17465), new ItemInfo(17466), new ItemInfo(17467), new ItemInfo(17468), new ItemInfo(17469), new ItemInfo(17470), new ItemInfo(17471), 
            new ItemInfo(17472), new ItemInfo(17473), new ItemInfo(17474), new ItemInfo(17475), new ItemInfo(17476), new ItemInfo(17477), new ItemInfo(17478), new ItemInfo(17479), 
            new ItemInfo(17480), new ItemInfo(17481), new ItemInfo(17482), new ItemInfo(17483), new ItemInfo(17484), new ItemInfo(17485), new ItemInfo(17486), new ItemInfo(17487), 
            new ItemInfo(17488), new ItemInfo(17489), new ItemInfo(17490), new ItemInfo(17491), new ItemInfo(17492), new ItemInfo(17493), new ItemInfo(17494), new ItemInfo(17495), 
            new ItemInfo(17496), new ItemInfo(17497), new ItemInfo(17498), new ItemInfo(17499), new ItemInfo(17500), new ItemInfo(17501), new ItemInfo(17502), new ItemInfo(17503), 
            new ItemInfo(17504), new ItemInfo(17505), new ItemInfo(17506), new ItemInfo(17507), new ItemInfo(17508), new ItemInfo(17509), new ItemInfo(17510), new ItemInfo(17511), 
            new ItemInfo(17512), new ItemInfo(17513), new ItemInfo(17514), new ItemInfo(17515), new ItemInfo(17516), new ItemInfo(17517), new ItemInfo(17518), new ItemInfo(17519), 
            new ItemInfo(17520), new ItemInfo(17521), new ItemInfo(17522), new ItemInfo(17523), new ItemInfo(17524), new ItemInfo(17525), new ItemInfo(17526), new ItemInfo(17527), 
            new ItemInfo(17528), new ItemInfo(17529), new ItemInfo(17530), new ItemInfo(17531), new ItemInfo(17532), new ItemInfo(17533), new ItemInfo(17534), new ItemInfo(17535), 
            new ItemInfo(17536), new ItemInfo(17537), new ItemInfo(17538), new ItemInfo(17539), new ItemInfo(17540), new ItemInfo(17541), new ItemInfo(17542), new ItemInfo(17543), 
            new ItemInfo(17544), new ItemInfo(17545), new ItemInfo(17546), new ItemInfo(17547), new ItemInfo(17548), new ItemInfo(17549), new ItemInfo(17550), new ItemInfo(17551), 
            new ItemInfo(17552), new ItemInfo(17553), new ItemInfo(17554), new ItemInfo(17555), new ItemInfo(17556), new ItemInfo(17557), new ItemInfo(17558), new ItemInfo(17559), 
            new ItemInfo(17560), new ItemInfo(17561), new ItemInfo(17562), new ItemInfo(17563), new ItemInfo(17564), new ItemInfo(17565), new ItemInfo(17566), new ItemInfo(17567), 
            new ItemInfo(17568), new ItemInfo(17569), new ItemInfo(17570), new ItemInfo(17571), new ItemInfo(17572), new ItemInfo(17573), new ItemInfo(17574), new ItemInfo(17575), 
            new ItemInfo(17576), new ItemInfo(17577), new ItemInfo(17578), new ItemInfo(17579), new ItemInfo(17580), new ItemInfo(17581), new ItemInfo(17582), new ItemInfo(17583), 
            new ItemInfo(17584), new ItemInfo(17585), new ItemInfo(17586), new ItemInfo(17587), new ItemInfo(17588), new ItemInfo(17589), new ItemInfo(17590), new ItemInfo(17591), 
            new ItemInfo(17592), new ItemInfo(17593), new ItemInfo(17594), new ItemInfo(17595), new ItemInfo(17596), new ItemInfo(17597), new ItemInfo(17598), new ItemInfo(17599) 
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFloorPt5Gump()
			: this(0)
		{ }

		public AddFloorPt5Gump(int page) 
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

			from.SendGump(new AddFloorPt5Gump(page));
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
