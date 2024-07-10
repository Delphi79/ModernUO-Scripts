using Server.Network;

namespace Server.Gumps
{
	public class AddStairGump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddStair", AccessLevel.GameMaster, new CommandEventHandler(AddStair_OnCommand));
		}

		[Usage("AddStair")]
		
		public static void AddStair_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddStairGump>();
			e.Mobile.SendGump(new AddStairGump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
                        new ItemInfo(1006), new ItemInfo(1007), new ItemInfo(1008), new ItemInfo(1009), new ItemInfo(1010), new ItemInfo(1011), new ItemInfo(1012), new ItemInfo(1013), 
            new ItemInfo(1014), new ItemInfo(1015), new ItemInfo(1016), new ItemInfo(1017), new ItemInfo(1018), new ItemInfo(1019), new ItemInfo(1020), new ItemInfo(1021), 
            new ItemInfo(1022), new ItemInfo(1023), new ItemInfo(1024), new ItemInfo(1025), new ItemInfo(1026), new ItemInfo(1801), new ItemInfo(1802), new ItemInfo(1803), 
            new ItemInfo(1804), new ItemInfo(1805), new ItemInfo(1806), new ItemInfo(1807), new ItemInfo(1808), new ItemInfo(1809), new ItemInfo(1810), new ItemInfo(1811), 
            new ItemInfo(1812), new ItemInfo(1813), new ItemInfo(1814), new ItemInfo(1815), new ItemInfo(1816), new ItemInfo(1817), new ItemInfo(1818), new ItemInfo(1819), 
            new ItemInfo(1820), new ItemInfo(1821), new ItemInfo(1822), new ItemInfo(1823), new ItemInfo(1824), new ItemInfo(1825), new ItemInfo(1826), new ItemInfo(1827), 
            new ItemInfo(1828), new ItemInfo(1829), new ItemInfo(1830), new ItemInfo(1831), new ItemInfo(1832), new ItemInfo(1833), new ItemInfo(1834), new ItemInfo(1835), 
            new ItemInfo(1836), new ItemInfo(1837), new ItemInfo(1838), new ItemInfo(1839), new ItemInfo(1840), new ItemInfo(1841), new ItemInfo(1842), new ItemInfo(1843), 
            new ItemInfo(1844), new ItemInfo(1845), new ItemInfo(1846), new ItemInfo(1847), new ItemInfo(1848), new ItemInfo(1849), new ItemInfo(1850), new ItemInfo(1851), 
            new ItemInfo(1852), new ItemInfo(1853), new ItemInfo(1854), new ItemInfo(1855), new ItemInfo(1856), new ItemInfo(1857), new ItemInfo(1858), new ItemInfo(1859), 
            new ItemInfo(1860), new ItemInfo(1861), new ItemInfo(1862), new ItemInfo(1863), new ItemInfo(1864), new ItemInfo(1865), new ItemInfo(1866), new ItemInfo(1867), 
            new ItemInfo(1868), new ItemInfo(1869), new ItemInfo(1870), new ItemInfo(1871), new ItemInfo(1872), new ItemInfo(1873), new ItemInfo(1874), new ItemInfo(1875), 
            new ItemInfo(1876), new ItemInfo(1877), new ItemInfo(1878), new ItemInfo(1879), new ItemInfo(1880), new ItemInfo(1881), new ItemInfo(1882), new ItemInfo(1883), 
            new ItemInfo(1884), new ItemInfo(1885), new ItemInfo(1886), new ItemInfo(1887), new ItemInfo(1888), new ItemInfo(1889), new ItemInfo(1890), new ItemInfo(1891), 
            new ItemInfo(1892), new ItemInfo(1893), new ItemInfo(1894), new ItemInfo(1895), new ItemInfo(1896), new ItemInfo(1897), new ItemInfo(1898), new ItemInfo(1899), 
            new ItemInfo(1900), new ItemInfo(1901), new ItemInfo(1902), new ItemInfo(1903), new ItemInfo(1904), new ItemInfo(1905), new ItemInfo(1906), new ItemInfo(1907), 
            new ItemInfo(1908), new ItemInfo(1909), new ItemInfo(1910), new ItemInfo(1911), new ItemInfo(1912), new ItemInfo(1913), new ItemInfo(1914), new ItemInfo(1915), 
            new ItemInfo(1916), new ItemInfo(1917), new ItemInfo(1918), new ItemInfo(1919), new ItemInfo(1920), new ItemInfo(1921), new ItemInfo(1922), new ItemInfo(1923), 
            new ItemInfo(1924), new ItemInfo(1925), new ItemInfo(1926), new ItemInfo(1927), new ItemInfo(1928), new ItemInfo(1929), new ItemInfo(1930), new ItemInfo(1931), 
            new ItemInfo(1932), new ItemInfo(1933), new ItemInfo(1934), new ItemInfo(1935), new ItemInfo(1936), new ItemInfo(1937), new ItemInfo(1938), new ItemInfo(1939), 
            new ItemInfo(1940), new ItemInfo(1941), new ItemInfo(1942), new ItemInfo(1943), new ItemInfo(1944), new ItemInfo(1945), new ItemInfo(1946), new ItemInfo(1947), 
            new ItemInfo(1948), new ItemInfo(1949), new ItemInfo(1950), new ItemInfo(1951), new ItemInfo(1952), new ItemInfo(1953), new ItemInfo(1954), new ItemInfo(1955), 
            new ItemInfo(1956), new ItemInfo(1957), new ItemInfo(1958), new ItemInfo(1959), new ItemInfo(1960), new ItemInfo(1961), new ItemInfo(1962), new ItemInfo(1963), 
            new ItemInfo(1964), new ItemInfo(1965), new ItemInfo(1966), new ItemInfo(1967), new ItemInfo(1968), new ItemInfo(1969), new ItemInfo(1970), new ItemInfo(1975), 
            new ItemInfo(1976), new ItemInfo(1977), new ItemInfo(1978), new ItemInfo(1979), new ItemInfo(1980), new ItemInfo(1981), new ItemInfo(1982), new ItemInfo(1983), 
            new ItemInfo(1984), new ItemInfo(1985), new ItemInfo(1986), new ItemInfo(1987), new ItemInfo(1988), new ItemInfo(1989), new ItemInfo(1990), new ItemInfo(1991), 
            new ItemInfo(1992), new ItemInfo(2010), new ItemInfo(2015), new ItemInfo(2016), new ItemInfo(2100), new ItemInfo(2166), new ItemInfo(2325), new ItemInfo(2326), 
            new ItemInfo(2327), new ItemInfo(2328), new ItemInfo(4540), new ItemInfo(4541), new ItemInfo(4542), new ItemInfo(4543), new ItemInfo(16946), new ItemInfo(16947), 
            new ItemInfo(16948), new ItemInfo(16949), new ItemInfo(16950), new ItemInfo(16951), new ItemInfo(16952), new ItemInfo(16953), new ItemInfo(17120), new ItemInfo(17121), 
            new ItemInfo(17122), new ItemInfo(17123), new ItemInfo(17124), new ItemInfo(17125), new ItemInfo(17126), new ItemInfo(17127), new ItemInfo(17128), new ItemInfo(17129), 
            new ItemInfo(17130), new ItemInfo(17131), new ItemInfo(17132), new ItemInfo(17133), new ItemInfo(17134), new ItemInfo(17135), new ItemInfo(17136), new ItemInfo(17137), 
            new ItemInfo(17138), new ItemInfo(17139), new ItemInfo(17140), new ItemInfo(17141), new ItemInfo(17142), new ItemInfo(17143), new ItemInfo(17144), new ItemInfo(17145), 
            new ItemInfo(17146), new ItemInfo(17147), new ItemInfo(17148), new ItemInfo(17149), new ItemInfo(17150), new ItemInfo(17151), new ItemInfo(17152), new ItemInfo(17153), 
            new ItemInfo(17242), new ItemInfo(17243), new ItemInfo(17244), new ItemInfo(17245), new ItemInfo(17246), new ItemInfo(17247), new ItemInfo(17248), new ItemInfo(17249), 
            new ItemInfo(17250), new ItemInfo(17251), new ItemInfo(17252), new ItemInfo(17253), new ItemInfo(17254), new ItemInfo(17255), new ItemInfo(17256), new ItemInfo(17257), 
            new ItemInfo(17258), new ItemInfo(17259), new ItemInfo(17260), new ItemInfo(17261), new ItemInfo(17328), new ItemInfo(17329), new ItemInfo(17330), new ItemInfo(17331), 
            new ItemInfo(17332), new ItemInfo(17333), new ItemInfo(17334), new ItemInfo(17335), new ItemInfo(18096), new ItemInfo(18097), new ItemInfo(18180), new ItemInfo(18181), 
            new ItemInfo(19201), new ItemInfo(19202), new ItemInfo(19203), new ItemInfo(19204), new ItemInfo(19205), new ItemInfo(19250), new ItemInfo(19251), new ItemInfo(19252), 
            new ItemInfo(19262), new ItemInfo(19263), new ItemInfo(19264), new ItemInfo(19265), new ItemInfo(19754), new ItemInfo(19933), new ItemInfo(19938), new ItemInfo(19939), 
            new ItemInfo(19940), new ItemInfo(19941), new ItemInfo(20322), new ItemInfo(20323), new ItemInfo(20324), new ItemInfo(20325), new ItemInfo(30715), new ItemInfo(30716), 
            new ItemInfo(30717), new ItemInfo(30718), new ItemInfo(30719), new ItemInfo(30720), new ItemInfo(30721), new ItemInfo(30722), new ItemInfo(30727), new ItemInfo(30728), 
            new ItemInfo(30729), new ItemInfo(30730), new ItemInfo(30731), new ItemInfo(30732), new ItemInfo(30733), new ItemInfo(30734), new ItemInfo(30735), new ItemInfo(30738), 
            new ItemInfo(30739), new ItemInfo(30740), new ItemInfo(30741)/*,new ItemInfo(40358), new ItemInfo(40359), new ItemInfo(40360), new ItemInfo(40361), new ItemInfo(40362), 
            new ItemInfo(40363), new ItemInfo(40364), new ItemInfo(40365), new ItemInfo(40366), new ItemInfo(40367), new ItemInfo(40368), new ItemInfo(40369), new ItemInfo(40370), 
            new ItemInfo(40371), new ItemInfo(40372), new ItemInfo(40373), new ItemInfo(40374), new ItemInfo(40375), new ItemInfo(40376), new ItemInfo(41743), new ItemInfo(41744), 
            new ItemInfo(41745), new ItemInfo(41746), new ItemInfo(41747), new ItemInfo(41748), new ItemInfo(41749), new ItemInfo(41750), new ItemInfo(41751)  */

            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddStairGump()
			: this(0)
		{ }

		public AddStairGump(int page) 
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

			from.SendGump(new AddStairGump(page));
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
