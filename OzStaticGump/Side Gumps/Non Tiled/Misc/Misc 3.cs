using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt3Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt3", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt3_OnCommand));
		}

		[Usage("AddMiscPt3")]
		
		public static void AddMiscPt3_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt3Gump>();
			e.Mobile.SendGump(new AddMiscPt3Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(2207), new ItemInfo(2208), new ItemInfo(2209), new ItemInfo(2210), new ItemInfo(2211), new ItemInfo(2212), new ItemInfo(2213), new ItemInfo(2214), new ItemInfo(2215),
            new ItemInfo(2216), new ItemInfo(2217), new ItemInfo(2218), new ItemInfo(2219), new ItemInfo(2220), new ItemInfo(2221), new ItemInfo(2255), new ItemInfo(2256), new ItemInfo(2257), 
            new ItemInfo(2258), new ItemInfo(2259), new ItemInfo(2260), new ItemInfo(2261), new ItemInfo(2262), new ItemInfo(2263), new ItemInfo(2264), new ItemInfo(2265), new ItemInfo(2266), 
            new ItemInfo(2267), new ItemInfo(2268), new ItemInfo(2269), new ItemInfo(2270), new ItemInfo(2271), new ItemInfo(2317), new ItemInfo(2318), new ItemInfo(2319), new ItemInfo(2320), 
            new ItemInfo(2321), new ItemInfo(2322), new ItemInfo(2323), new ItemInfo(2324), new ItemInfo(2329), new ItemInfo(2330), new ItemInfo(2331), new ItemInfo(2332), new ItemInfo(2333), 
            new ItemInfo(2334), new ItemInfo(2335), new ItemInfo(2336), new ItemInfo(2337), new ItemInfo(2338), new ItemInfo(2339), new ItemInfo(2340), new ItemInfo(2341), new ItemInfo(2342), 
            new ItemInfo(2343), new ItemInfo(2344), new ItemInfo(2345), new ItemInfo(2346), new ItemInfo(2347), new ItemInfo(2348), new ItemInfo(2349), new ItemInfo(2350), new ItemInfo(2351), 
            new ItemInfo(2352), new ItemInfo(2353), new ItemInfo(2354), new ItemInfo(2355), new ItemInfo(2356), new ItemInfo(2357), new ItemInfo(2358), new ItemInfo(2359), new ItemInfo(2360), 
            new ItemInfo(2361), new ItemInfo(2362), new ItemInfo(2363), new ItemInfo(2364), new ItemInfo(2365), new ItemInfo(2366), new ItemInfo(2367), new ItemInfo(2368), new ItemInfo(2369), 
            new ItemInfo(2370), new ItemInfo(2371), new ItemInfo(2372), new ItemInfo(2373), new ItemInfo(2374), new ItemInfo(2375), new ItemInfo(2376), new ItemInfo(2377), new ItemInfo(2378), 
            new ItemInfo(2379), new ItemInfo(2380), new ItemInfo(2381), new ItemInfo(2382), new ItemInfo(2383), new ItemInfo(2384), new ItemInfo(2385), new ItemInfo(2386), new ItemInfo(2387), 
            new ItemInfo(2388), new ItemInfo(2389), new ItemInfo(2390), new ItemInfo(2391), new ItemInfo(2392), new ItemInfo(2393), new ItemInfo(2394), new ItemInfo(2395), new ItemInfo(2396), 
            new ItemInfo(2397), new ItemInfo(2398), new ItemInfo(2399), new ItemInfo(2400), new ItemInfo(2401), new ItemInfo(2402), new ItemInfo(2403), new ItemInfo(2404), new ItemInfo(2405), 
            new ItemInfo(2406), new ItemInfo(2407), new ItemInfo(2408), new ItemInfo(2409), new ItemInfo(2410), new ItemInfo(2411), new ItemInfo(2412), new ItemInfo(2413), new ItemInfo(2414), 
            new ItemInfo(2415), new ItemInfo(2432), new ItemInfo(2433), new ItemInfo(2434), new ItemInfo(2435), new ItemInfo(2436), new ItemInfo(2437), new ItemInfo(2438), new ItemInfo(2439), 
            new ItemInfo(2440), new ItemInfo(2441), new ItemInfo(2442), new ItemInfo(2443), new ItemInfo(2472), new ItemInfo(2473), new ItemInfo(2474), new ItemInfo(2475), new ItemInfo(2590), 
            new ItemInfo(2591), new ItemInfo(2592), new ItemInfo(2593), new ItemInfo(2719), new ItemInfo(2720), new ItemInfo(2721), new ItemInfo(2722), new ItemInfo(2723), new ItemInfo(2724), 
            new ItemInfo(2725), new ItemInfo(2726), new ItemInfo(2727), new ItemInfo(2728), new ItemInfo(2729), new ItemInfo(2730), new ItemInfo(2731), new ItemInfo(2732), new ItemInfo(2733), 
            new ItemInfo(2734), new ItemInfo(2735), new ItemInfo(2736), new ItemInfo(2737), new ItemInfo(2738), new ItemInfo(2739), new ItemInfo(2740), new ItemInfo(2741), new ItemInfo(2742), 
            new ItemInfo(2743), new ItemInfo(2744), new ItemInfo(2745), new ItemInfo(2746), new ItemInfo(2747), new ItemInfo(2748), new ItemInfo(2749), new ItemInfo(2750), new ItemInfo(2751), 
            new ItemInfo(2752), new ItemInfo(2753), new ItemInfo(2754), new ItemInfo(2755), new ItemInfo(2756), new ItemInfo(2757), new ItemInfo(2758), new ItemInfo(2759), new ItemInfo(2760), 
            new ItemInfo(2761), new ItemInfo(2762), new ItemInfo(2763), new ItemInfo(2764), new ItemInfo(2765), new ItemInfo(2766), new ItemInfo(2767), new ItemInfo(2768), new ItemInfo(2769), 
            new ItemInfo(2770), new ItemInfo(2771), new ItemInfo(2772), new ItemInfo(2773), new ItemInfo(2774), new ItemInfo(2775), new ItemInfo(2776), new ItemInfo(2777), new ItemInfo(2778), 
            new ItemInfo(2779), new ItemInfo(2780), new ItemInfo(2781), new ItemInfo(2782), new ItemInfo(2783), new ItemInfo(2784), new ItemInfo(2785), new ItemInfo(2786), new ItemInfo(2787), 
            new ItemInfo(2788), new ItemInfo(2789), new ItemInfo(2790), new ItemInfo(2791), new ItemInfo(2792), new ItemInfo(2793), new ItemInfo(2794), new ItemInfo(2795), new ItemInfo(2796)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt3Gump()
			: this(0)
		{ }

		public AddMiscPt3Gump(int page) 
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

			from.SendGump(new AddMiscPt3Gump(page));
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
