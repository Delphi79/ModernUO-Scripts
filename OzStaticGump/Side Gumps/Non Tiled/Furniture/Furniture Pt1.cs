using Server.Network;

namespace Server.Gumps
{
	public class AddFurnPt1Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFurnPt1", AccessLevel.GameMaster, new CommandEventHandler(AddFurnPt1_OnCommand));
		}

		[Usage("AddFurnPt1")]
		public static void AddFurnPt1_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFurnPt1Gump>();
			e.Mobile.SendGump(new AddFurnPt1Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(2602), new ItemInfo(2603), new ItemInfo(2604), new ItemInfo(2605), new ItemInfo(2606), new ItemInfo(2607), new ItemInfo(2608), 
            new ItemInfo(2609), new ItemInfo(2610), new ItemInfo(2611), new ItemInfo(2612), new ItemInfo(2613), new ItemInfo(2614), new ItemInfo(2615), 
            new ItemInfo(2616), new ItemInfo(2617), new ItemInfo(2618), new ItemInfo(2619), new ItemInfo(2620), new ItemInfo(2621), new ItemInfo(2622), 
            new ItemInfo(2623), new ItemInfo(2624), new ItemInfo(2625), new ItemInfo(2626), new ItemInfo(2627), new ItemInfo(2628), new ItemInfo(2629), 
            new ItemInfo(2630), new ItemInfo(2631), new ItemInfo(2632), new ItemInfo(2633), new ItemInfo(2634), new ItemInfo(2635), new ItemInfo(2636), 
            new ItemInfo(2637), new ItemInfo(2638), new ItemInfo(2639), new ItemInfo(2640), new ItemInfo(2641), new ItemInfo(2642), new ItemInfo(2643), 
            new ItemInfo(2645), new ItemInfo(2646), new ItemInfo(2647), new ItemInfo(2648), new ItemInfo(2649), new ItemInfo(2650), new ItemInfo(2651), 
            new ItemInfo(2652), new ItemInfo(2653), new ItemInfo(2654), new ItemInfo(2655), new ItemInfo(2656), new ItemInfo(2657), new ItemInfo(2658), 
            new ItemInfo(2659), new ItemInfo(2660), new ItemInfo(2661), new ItemInfo(2662), new ItemInfo(2663), new ItemInfo(2664), new ItemInfo(2665), 
            new ItemInfo(2666), new ItemInfo(2667), new ItemInfo(2668), new ItemInfo(2669), new ItemInfo(2670), new ItemInfo(2671), new ItemInfo(2672), 
            new ItemInfo(2673), new ItemInfo(2674), new ItemInfo(2675), new ItemInfo(2676), new ItemInfo(2677), new ItemInfo(2678), new ItemInfo(2679), 
            new ItemInfo(2680), new ItemInfo(2681), new ItemInfo(2682), new ItemInfo(2683), new ItemInfo(2684), new ItemInfo(2685), new ItemInfo(2686), 
            new ItemInfo(2687), new ItemInfo(2688), new ItemInfo(2689), new ItemInfo(2690), new ItemInfo(2691), new ItemInfo(2692), new ItemInfo(2693),
            new ItemInfo(2694), new ItemInfo(2695), new ItemInfo(2696), new ItemInfo(2697), new ItemInfo(2698), new ItemInfo(2699), new ItemInfo(2700), 
            new ItemInfo(2701), new ItemInfo(2702), new ItemInfo(2703), new ItemInfo(2704), new ItemInfo(2705), new ItemInfo(2706), new ItemInfo(2707), 
            new ItemInfo(2708), new ItemInfo(2709), new ItemInfo(2711), new ItemInfo(2712), new ItemInfo(2713), new ItemInfo(2714), new ItemInfo(2715), 
            new ItemInfo(2716), new ItemInfo(2717), new ItemInfo(2718), new ItemInfo(2861), new ItemInfo(2862), new ItemInfo(2863), new ItemInfo(2864), 
            new ItemInfo(2865), new ItemInfo(2866), new ItemInfo(2867), new ItemInfo(2868), new ItemInfo(2869), new ItemInfo(2870), new ItemInfo(2871), 
            new ItemInfo(2872), new ItemInfo(2873), new ItemInfo(2874), new ItemInfo(2876), new ItemInfo(2877), new ItemInfo(2878), new ItemInfo(2879), 
            new ItemInfo(2880), new ItemInfo(2889), new ItemInfo(2890), new ItemInfo(2891), new ItemInfo(2892), new ItemInfo(2893), new ItemInfo(2894)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFurnPt1Gump()
			: this(0)
		{ }

		public AddFurnPt1Gump(int page) 
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

			from.SendGump(new AddFurnPt1Gump(page));
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
