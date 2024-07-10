using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt2Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt2", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt2_OnCommand));
		}

		[Usage("AddMiscPt2")]
		
		public static void AddMiscPt2_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt2Gump>();
			e.Mobile.SendGump(new AddMiscPt2Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(1665), new ItemInfo(1666), new ItemInfo(1667), new ItemInfo(1668), new ItemInfo(1669), new ItemInfo(1670), new ItemInfo(1671), new ItemInfo(1672), new ItemInfo(1673), 
            new ItemInfo(1674), new ItemInfo(1675), new ItemInfo(1676), new ItemInfo(1677), new ItemInfo(1678), new ItemInfo(1679), new ItemInfo(1680), new ItemInfo(1681), new ItemInfo(1682), 
            new ItemInfo(1683), new ItemInfo(1684), new ItemInfo(1685), new ItemInfo(1686), new ItemInfo(1687), new ItemInfo(1688), new ItemInfo(1689), new ItemInfo(1690), new ItemInfo(1691), 
            new ItemInfo(1692), new ItemInfo(1693), new ItemInfo(1694), new ItemInfo(1695), new ItemInfo(1696), new ItemInfo(1697), new ItemInfo(1698), new ItemInfo(1699), new ItemInfo(1700), 
            new ItemInfo(1701), new ItemInfo(1702), new ItemInfo(1703), new ItemInfo(1704), new ItemInfo(1705), new ItemInfo(1706), new ItemInfo(1707), new ItemInfo(1708), new ItemInfo(1709), 
            new ItemInfo(1710), new ItemInfo(1711), new ItemInfo(1712), new ItemInfo(1713), new ItemInfo(1714), new ItemInfo(1715), new ItemInfo(1716), new ItemInfo(1717), new ItemInfo(1718), 
            new ItemInfo(1719), new ItemInfo(1720), new ItemInfo(1721), new ItemInfo(1722), new ItemInfo(1723), new ItemInfo(1724), new ItemInfo(1725), new ItemInfo(1726), new ItemInfo(1727), 
            new ItemInfo(1728), new ItemInfo(1729), new ItemInfo(1730), new ItemInfo(1731), new ItemInfo(1732), new ItemInfo(1733), new ItemInfo(1734), new ItemInfo(1735), new ItemInfo(1736),
            new ItemInfo(1737), new ItemInfo(1738), new ItemInfo(1739), new ItemInfo(1740), new ItemInfo(1741), new ItemInfo(1742), new ItemInfo(1743), new ItemInfo(1744), new ItemInfo(1745), 
            new ItemInfo(1746), new ItemInfo(1747), new ItemInfo(1748), new ItemInfo(1749), new ItemInfo(1750), new ItemInfo(1751), new ItemInfo(1752), new ItemInfo(1753), new ItemInfo(1754), 
            new ItemInfo(1755), new ItemInfo(1756), new ItemInfo(1757), new ItemInfo(1758), new ItemInfo(1759), new ItemInfo(1760), new ItemInfo(1761), new ItemInfo(1762), new ItemInfo(1763), 
            new ItemInfo(1764), new ItemInfo(1765), new ItemInfo(1766), new ItemInfo(1767), new ItemInfo(1768), new ItemInfo(1769), new ItemInfo(1770), new ItemInfo(1771), new ItemInfo(1772), 
            new ItemInfo(1773), new ItemInfo(1774), new ItemInfo(1775), new ItemInfo(1776), new ItemInfo(1777), new ItemInfo(1778), new ItemInfo(1779), new ItemInfo(1780), new ItemInfo(1781), 
            new ItemInfo(1782), new ItemInfo(1783), new ItemInfo(1784), new ItemInfo(1785), new ItemInfo(1786), new ItemInfo(1787), new ItemInfo(1971), new ItemInfo(1972), new ItemInfo(1973), 
            new ItemInfo(1974), new ItemInfo(2003), new ItemInfo(2004), new ItemInfo(2005), new ItemInfo(2006), new ItemInfo(2007), new ItemInfo(2008), new ItemInfo(2009), new ItemInfo(2011), 
            new ItemInfo(2012), new ItemInfo(2013), new ItemInfo(2014), new ItemInfo(2017), new ItemInfo(2018), new ItemInfo(2019), new ItemInfo(2020), new ItemInfo(2021), new ItemInfo(2022), 
            new ItemInfo(2023), new ItemInfo(2024), new ItemInfo(2025), new ItemInfo(2026), new ItemInfo(2027), new ItemInfo(2028), new ItemInfo(2029), new ItemInfo(2030), new ItemInfo(2031), 
            new ItemInfo(2032), new ItemInfo(2033), new ItemInfo(2034), new ItemInfo(2035), new ItemInfo(2036), new ItemInfo(2037), new ItemInfo(2038), new ItemInfo(2039), new ItemInfo(2040), 
            new ItemInfo(2041), new ItemInfo(2042), new ItemInfo(2043), new ItemInfo(2044), new ItemInfo(2045), new ItemInfo(2046), new ItemInfo(2047), new ItemInfo(2048), new ItemInfo(2049), 
            new ItemInfo(2050), new ItemInfo(2051), new ItemInfo(2052), new ItemInfo(2053), new ItemInfo(2054), new ItemInfo(2055), new ItemInfo(2056), new ItemInfo(2057), new ItemInfo(2058), 
            new ItemInfo(2059), new ItemInfo(2060), new ItemInfo(2061), new ItemInfo(2062), new ItemInfo(2063), new ItemInfo(2064), new ItemInfo(2065), new ItemInfo(2066), new ItemInfo(2067), 
            new ItemInfo(2068), new ItemInfo(2069), new ItemInfo(2070), new ItemInfo(2071), new ItemInfo(2072), new ItemInfo(2073), new ItemInfo(2074), new ItemInfo(2075), new ItemInfo(2076), 
            new ItemInfo(2077), new ItemInfo(2078), new ItemInfo(2079), new ItemInfo(2080), new ItemInfo(2170), new ItemInfo(2171), new ItemInfo(2172), new ItemInfo(2173), new ItemInfo(2188), 
            new ItemInfo(2189), new ItemInfo(2190), new ItemInfo(2191), new ItemInfo(2192), new ItemInfo(2193), new ItemInfo(2194), new ItemInfo(2195), new ItemInfo(2196), new ItemInfo(2197), 
            new ItemInfo(2198), new ItemInfo(2199), new ItemInfo(2200), new ItemInfo(2201), new ItemInfo(2202), new ItemInfo(2203), new ItemInfo(2204), new ItemInfo(2205), new ItemInfo(2206)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt2Gump()
			: this(0)
		{ }

		public AddMiscPt2Gump(int page) 
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

			from.SendGump(new AddMiscPt2Gump(page));
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
