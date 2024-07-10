using Server.Network;

namespace Server.Gumps
{
	public class AddFenceGump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFence", AccessLevel.GameMaster, new CommandEventHandler(AddFence_OnCommand));
		}

		[Usage("AddFence")]
		[Description("Displays a menu from which you can interactively add Walls.")]
		public static void AddFence_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFenceGump>();
			e.Mobile.SendGump(new AddFenceGump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(2081), new ItemInfo(2082), new ItemInfo(2083), new ItemInfo(2084), new ItemInfo(2085), new ItemInfo(2086), new ItemInfo(2087), new ItemInfo(2088), new ItemInfo(2089), 
            new ItemInfo(2090), new ItemInfo(2091), new ItemInfo(2092), new ItemInfo(2093), new ItemInfo(2094), new ItemInfo(2095), new ItemInfo(2096), new ItemInfo(2097), new ItemInfo(2098), 
            new ItemInfo(2099), new ItemInfo(2101), new ItemInfo(2102), new ItemInfo(2103), new ItemInfo(2104), new ItemInfo(2105), new ItemInfo(2106), new ItemInfo(2107), 
            new ItemInfo(2108), new ItemInfo(2109), new ItemInfo(2110), new ItemInfo(2111), new ItemInfo(2112), new ItemInfo(2113), new ItemInfo(2114), new ItemInfo(2115), new ItemInfo(2116), 
            new ItemInfo(2117), new ItemInfo(2118), new ItemInfo(2119), new ItemInfo(2120), new ItemInfo(2121), new ItemInfo(2122), new ItemInfo(2123), new ItemInfo(2124), new ItemInfo(2125), 
            new ItemInfo(2126), new ItemInfo(2127), new ItemInfo(2128), new ItemInfo(2129), new ItemInfo(2130), new ItemInfo(2131), new ItemInfo(2132), new ItemInfo(2133), new ItemInfo(2134), 
            new ItemInfo(2135), new ItemInfo(2136), new ItemInfo(2137), new ItemInfo(2138), new ItemInfo(2139), new ItemInfo(2140), new ItemInfo(2141), new ItemInfo(2142), new ItemInfo(2143), 
            new ItemInfo(2144), new ItemInfo(2145), new ItemInfo(2146), new ItemInfo(2147), new ItemInfo(2148), new ItemInfo(2149), new ItemInfo(2150), new ItemInfo(2151), new ItemInfo(2152), 
            new ItemInfo(2153), new ItemInfo(2154), new ItemInfo(2155), new ItemInfo(2156), new ItemInfo(2157), new ItemInfo(2158), new ItemInfo(2159), new ItemInfo(2160), new ItemInfo(2161), 
            new ItemInfo(2162), new ItemInfo(2163), new ItemInfo(2164), new ItemInfo(2165), new ItemInfo(2167), new ItemInfo(2168), new ItemInfo(2174), new ItemInfo(2175), new ItemInfo(2176), 
            new ItemInfo(2177), new ItemInfo(2178), new ItemInfo(2179), new ItemInfo(2180), new ItemInfo(2181), new ItemInfo(2182), new ItemInfo(2183), new ItemInfo(2184), new ItemInfo(2185), 
            new ItemInfo(2186), new ItemInfo(2187), new ItemInfo(2222), new ItemInfo(2223), new ItemInfo(2224), new ItemInfo(2225), new ItemInfo(2226), new ItemInfo(2227), new ItemInfo(2228), 
            new ItemInfo(2229), new ItemInfo(2230), new ItemInfo(2231), new ItemInfo(2232), new ItemInfo(2233), new ItemInfo(2234), new ItemInfo(2235), new ItemInfo(2236), new ItemInfo(2237), 
            new ItemInfo(2238), new ItemInfo(2239), new ItemInfo(2240), new ItemInfo(2241), new ItemInfo(2242), new ItemInfo(2243), new ItemInfo(2244), new ItemInfo(2245), new ItemInfo(2246), 
            new ItemInfo(2247), new ItemInfo(2248), new ItemInfo(2249), new ItemInfo(2250), new ItemInfo(2251), new ItemInfo(2252), new ItemInfo(2253), new ItemInfo(2254), new ItemInfo(2283), 
            new ItemInfo(2284), new ItemInfo(2285), new ItemInfo(2286), new ItemInfo(2287), new ItemInfo(2288), new ItemInfo(2289), new ItemInfo(2290), new ItemInfo(2291), new ItemInfo(2292), 
            new ItemInfo(2293), new ItemInfo(2294), new ItemInfo(2295), new ItemInfo(2296), new ItemInfo(2297), new ItemInfo(2298), new ItemInfo(2299), new ItemInfo(2300), new ItemInfo(20316), 
            new ItemInfo(20317), new ItemInfo(20318), new ItemInfo(20319), new ItemInfo(20320), new ItemInfo(20321)/*, new ItemInfo(39483), new ItemInfo(39484), new ItemInfo(39485), new ItemInfo(39486), 
            new ItemInfo(39487), new ItemInfo(39488), new ItemInfo(39489), new ItemInfo(39490), new ItemInfo(39491), new ItemInfo(39492), new ItemInfo(39493), new ItemInfo(39494), new ItemInfo(39495), 
            new ItemInfo(39496), new ItemInfo(39497), new ItemInfo(39498), new ItemInfo(40227), new ItemInfo(40228), new ItemInfo(40229), new ItemInfo(40230), new ItemInfo(40293), new ItemInfo(40294), 
			new ItemInfo(40295)*/
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFenceGump()
			: this(0)
		{ }

		public AddFenceGump(int page) 
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

			from.SendGump(new AddFenceGump(page));
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
