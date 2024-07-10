using Server.Network;

namespace Server.Gumps
{
	public class AddRoofPt2Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddRoofPt2", AccessLevel.GameMaster, new CommandEventHandler(AddRoofPt2_OnCommand));
		}

		[Usage("AddRoofPt2")]
		
		public static void AddRoofPt2_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddRoofPt2Gump>();
			e.Mobile.SendGump(new AddRoofPt2Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Roofs
            new ItemInfo(1630), new ItemInfo(1631), new ItemInfo(1632), new ItemInfo(1633), new ItemInfo(1634), new ItemInfo(1635), new ItemInfo(1636), new ItemInfo(1637), 
            new ItemInfo(1638), new ItemInfo(1639), new ItemInfo(1640), new ItemInfo(1641), new ItemInfo(1642), new ItemInfo(1643), new ItemInfo(1644), new ItemInfo(1645), 
            new ItemInfo(1646), new ItemInfo(1647), new ItemInfo(1648), new ItemInfo(1649), new ItemInfo(1650), new ItemInfo(1651), new ItemInfo(1652), new ItemInfo(6457), 
            new ItemInfo(6458), new ItemInfo(6459), new ItemInfo(6460), new ItemInfo(6461), new ItemInfo(6462), new ItemInfo(9946), new ItemInfo(9947), new ItemInfo(9948), 
            new ItemInfo(9949), new ItemInfo(9950), new ItemInfo(9951), new ItemInfo(9952), new ItemInfo(9953), new ItemInfo(9954), new ItemInfo(9955), new ItemInfo(9956), 
            new ItemInfo(9957), new ItemInfo(9958), new ItemInfo(9959), new ItemInfo(9960), new ItemInfo(9961), new ItemInfo(9962), new ItemInfo(9963), new ItemInfo(9964), 
            new ItemInfo(9976), new ItemInfo(9977), new ItemInfo(9978), new ItemInfo(9979), new ItemInfo(9980), new ItemInfo(9981), new ItemInfo(9982), new ItemInfo(9983), 
            new ItemInfo(9984), new ItemInfo(9985), new ItemInfo(9986), new ItemInfo(9987), new ItemInfo(9988), new ItemInfo(9989), new ItemInfo(9990), new ItemInfo(9991), 
            new ItemInfo(9992), new ItemInfo(9993), new ItemInfo(9994), new ItemInfo(9995), new ItemInfo(9996),new ItemInfo(10416), new ItemInfo(10417), new ItemInfo(10418), 
            new ItemInfo(10419), new ItemInfo(10420), new ItemInfo(10421), new ItemInfo(10422), new ItemInfo(10423), new ItemInfo(10424), new ItemInfo(10425), new ItemInfo(10426), 
            new ItemInfo(10427), new ItemInfo(10428), new ItemInfo(10429), new ItemInfo(10430), new ItemInfo(10431), new ItemInfo(10432), new ItemInfo(10433), new ItemInfo(10434), 
            new ItemInfo(10435), new ItemInfo(10436), new ItemInfo(10437), new ItemInfo(10438), new ItemInfo(10439), new ItemInfo(10440), new ItemInfo(10441), new ItemInfo(10442), 
            new ItemInfo(10443), new ItemInfo(10444), new ItemInfo(10445), new ItemInfo(10446), new ItemInfo(10447), new ItemInfo(10448), new ItemInfo(10449), new ItemInfo(10450), 
            new ItemInfo(10451), new ItemInfo(10452), new ItemInfo(10453), new ItemInfo(10454), new ItemInfo(10455), new ItemInfo(10456), new ItemInfo(10457), new ItemInfo(10458), 
            new ItemInfo(10459), new ItemInfo(10468), new ItemInfo(10469), new ItemInfo(10470), new ItemInfo(10471), new ItemInfo(10472), new ItemInfo(10473), new ItemInfo(10474), 
            new ItemInfo(10475), new ItemInfo(10476), new ItemInfo(10477), new ItemInfo(10478), new ItemInfo(10480), new ItemInfo(10481), new ItemInfo(10482), new ItemInfo(10483), 
            new ItemInfo(10484), new ItemInfo(10485), new ItemInfo(10486), new ItemInfo(10487), new ItemInfo(10488), new ItemInfo(10489), new ItemInfo(10490), new ItemInfo(10491), 
            new ItemInfo(10492), new ItemInfo(10493), new ItemInfo(10494), new ItemInfo(10495), new ItemInfo(10496), new ItemInfo(10497), new ItemInfo(10498), new ItemInfo(10499), 
            new ItemInfo(10500), new ItemInfo(10501), new ItemInfo(10502), new ItemInfo(10503), new ItemInfo(10504), new ItemInfo(10505), new ItemInfo(10506), new ItemInfo(10507), 
            new ItemInfo(10508), new ItemInfo(10509), new ItemInfo(10510), new ItemInfo(10511), new ItemInfo(10512), new ItemInfo(10513), new ItemInfo(10514), new ItemInfo(10515), 
            new ItemInfo(10516), new ItemInfo(10517), new ItemInfo(10518), new ItemInfo(10519), new ItemInfo(10520), new ItemInfo(10521), new ItemInfo(10522), new ItemInfo(10523), 
            new ItemInfo(10528), new ItemInfo(10529), new ItemInfo(10530), new ItemInfo(10531), new ItemInfo(10532), new ItemInfo(10533), new ItemInfo(10534), new ItemInfo(10535)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddRoofPt2Gump()
			: this(0)
		{ }

		public AddRoofPt2Gump(int page) 
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

			from.SendGump(new AddRoofPt2Gump(page));
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
