using Server.Network;

namespace Server.Gumps
{
	public class AddRoofPt1Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddRoofPt1", AccessLevel.GameMaster, new CommandEventHandler(AddRoofPt1_OnCommand));
		}

		[Usage("AddRoofPt1")]
		
		public static void AddRoofPt1_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddRoofPt1Gump>();
			e.Mobile.SendGump(new AddRoofPt1Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Roofs
            new ItemInfo(1414), new ItemInfo(1415), new ItemInfo(1416), new ItemInfo(1417), new ItemInfo(1418), new ItemInfo(1419), new ItemInfo(1420), new ItemInfo(1421), 
            new ItemInfo(1422), new ItemInfo(1423), new ItemInfo(1424), new ItemInfo(1425), new ItemInfo(1426), new ItemInfo(1427), new ItemInfo(1428), new ItemInfo(1429), 
            new ItemInfo(1430), new ItemInfo(1431), new ItemInfo(1432), new ItemInfo(1433), new ItemInfo(1434), new ItemInfo(1435), new ItemInfo(1436), new ItemInfo(1437), 
            new ItemInfo(1438), new ItemInfo(1439), new ItemInfo(1440), new ItemInfo(1441), new ItemInfo(1442), new ItemInfo(1443), new ItemInfo(1444), new ItemInfo(1445), 
            new ItemInfo(1446), new ItemInfo(1447), new ItemInfo(1448), new ItemInfo(1449), new ItemInfo(1450), new ItemInfo(1451), new ItemInfo(1452), new ItemInfo(1453), 
            new ItemInfo(1454), new ItemInfo(1455), new ItemInfo(1456), new ItemInfo(1457), new ItemInfo(1458), new ItemInfo(1459), new ItemInfo(1460), new ItemInfo(1461), 
            new ItemInfo(1462), new ItemInfo(1463), new ItemInfo(1464), new ItemInfo(1465), new ItemInfo(1466), new ItemInfo(1467), new ItemInfo(1468), new ItemInfo(1469), 
            new ItemInfo(1470), new ItemInfo(1471), new ItemInfo(1472), new ItemInfo(1473), new ItemInfo(1474), new ItemInfo(1475), new ItemInfo(1476), new ItemInfo(1477), 
            new ItemInfo(1478), new ItemInfo(1479), new ItemInfo(1480), new ItemInfo(1481), new ItemInfo(1482), new ItemInfo(1483), new ItemInfo(1484), new ItemInfo(1485), 
            new ItemInfo(1486), new ItemInfo(1487), new ItemInfo(1488), new ItemInfo(1489), new ItemInfo(1490), new ItemInfo(1491), new ItemInfo(1492), new ItemInfo(1494), 
            new ItemInfo(1495), new ItemInfo(1496), new ItemInfo(1497), new ItemInfo(1498), new ItemInfo(1499), new ItemInfo(1500), new ItemInfo(1501), new ItemInfo(1502), 
            new ItemInfo(1503), new ItemInfo(1504), new ItemInfo(1505), new ItemInfo(1506), new ItemInfo(1507), new ItemInfo(1508), new ItemInfo(1509), new ItemInfo(1510), 
            new ItemInfo(1511), new ItemInfo(1512), new ItemInfo(1513), new ItemInfo(1514), new ItemInfo(1515), new ItemInfo(1516), new ItemInfo(1519), new ItemInfo(1520), 
            new ItemInfo(1521), new ItemInfo(1522), new ItemInfo(1523), new ItemInfo(1524), new ItemInfo(1525), new ItemInfo(1526), new ItemInfo(1527), new ItemInfo(1528), 
            new ItemInfo(1529), new ItemInfo(1530), new ItemInfo(1531), new ItemInfo(1532), new ItemInfo(1533), new ItemInfo(1534), new ItemInfo(1535), new ItemInfo(1536), 
            new ItemInfo(1537), new ItemInfo(1538), new ItemInfo(1539), new ItemInfo(1540), new ItemInfo(1541), new ItemInfo(1542), new ItemInfo(1543), new ItemInfo(1544), 
            new ItemInfo(1545), new ItemInfo(1546), new ItemInfo(1547), new ItemInfo(1548), new ItemInfo(1549), new ItemInfo(1550), new ItemInfo(1551), new ItemInfo(1552), 
            new ItemInfo(1553), new ItemInfo(1554), new ItemInfo(1555), new ItemInfo(1556), new ItemInfo(1557), new ItemInfo(1558), new ItemInfo(1559), new ItemInfo(1560), 
            new ItemInfo(1561), new ItemInfo(1562), new ItemInfo(1563), new ItemInfo(1564), new ItemInfo(1565), new ItemInfo(1566), new ItemInfo(1567), new ItemInfo(1568), 
            new ItemInfo(1569), new ItemInfo(1570), new ItemInfo(1571), new ItemInfo(1572), new ItemInfo(1573), new ItemInfo(1574), new ItemInfo(1575), new ItemInfo(1576), 
            new ItemInfo(1577), new ItemInfo(1578), new ItemInfo(1587), new ItemInfo(1588), new ItemInfo(1589), new ItemInfo(1590), new ItemInfo(1608), new ItemInfo(1609), 
            new ItemInfo(1610), new ItemInfo(1611), new ItemInfo(1612), new ItemInfo(1613), new ItemInfo(1614), new ItemInfo(1615), new ItemInfo(1616), new ItemInfo(1617)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddRoofPt1Gump()
			: this(0)
		{ }

		public AddRoofPt1Gump(int page) 
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

			from.SendGump(new AddRoofPt1Gump(page));
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
