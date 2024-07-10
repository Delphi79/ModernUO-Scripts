using Server.Network;

namespace Server.Gumps
{
	public class AddCookingStaticGump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCookingStatic", AccessLevel.GameMaster, new CommandEventHandler(AddCookingStatic_OnCommand));
		}

		[Usage("AddCookingStatic")]
		[Description("Displays a menu from which you can interactively add Walls.")]
		public static void AddCookingStatic_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCookingStaticGump>();
			e.Mobile.SendGump(new AddCookingStaticGump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(539), new ItemInfo(2416), new ItemInfo(2417), new ItemInfo(2418), new ItemInfo(2419), new ItemInfo(2420), new ItemInfo(2421), new ItemInfo(2422), 
            new ItemInfo(2423), new ItemInfo(2424), new ItemInfo(2425), new ItemInfo(2426), new ItemInfo(2427), new ItemInfo(2428), new ItemInfo(2429), new ItemInfo(2430), 
            new ItemInfo(2431), new ItemInfo(2444), new ItemInfo(2445), new ItemInfo(2446), new ItemInfo(2448), new ItemInfo(2449), new ItemInfo(2450), new ItemInfo(2451), 
            new ItemInfo(2452), new ItemInfo(2453), new ItemInfo(2454), new ItemInfo(2455), new ItemInfo(2456), new ItemInfo(2457), new ItemInfo(2458), new ItemInfo(2459), 
            new ItemInfo(2460), new ItemInfo(2461), new ItemInfo(2462), new ItemInfo(2463), new ItemInfo(2464), new ItemInfo(2465), new ItemInfo(2466), new ItemInfo(2467), 
            new ItemInfo(2468), new ItemInfo(2469), new ItemInfo(2470), new ItemInfo(2471), new ItemInfo(2476), new ItemInfo(2477), new ItemInfo(2478), new ItemInfo(2479), 
            new ItemInfo(2480), new ItemInfo(2481), new ItemInfo(2482), new ItemInfo(2483), new ItemInfo(2484), new ItemInfo(2485), new ItemInfo(2486), new ItemInfo(2487), 
            new ItemInfo(2488), new ItemInfo(2489), new ItemInfo(2490), new ItemInfo(2491), new ItemInfo(2492), new ItemInfo(2493), new ItemInfo(2494), new ItemInfo(2495), 
            new ItemInfo(2496), new ItemInfo(2497), new ItemInfo(2498), new ItemInfo(2499), new ItemInfo(2500), new ItemInfo(2501), new ItemInfo(2502), new ItemInfo(2503), 
            new ItemInfo(2504), new ItemInfo(2505), new ItemInfo(2506), new ItemInfo(2507), new ItemInfo(2508), new ItemInfo(2509), new ItemInfo(2510), new ItemInfo(2511), 
            new ItemInfo(2512), new ItemInfo(2513), new ItemInfo(2514), new ItemInfo(2515), new ItemInfo(2516), new ItemInfo(2517), new ItemInfo(2518), new ItemInfo(2519), 
            new ItemInfo(2520), new ItemInfo(2521), new ItemInfo(2522), new ItemInfo(2523), new ItemInfo(2524), new ItemInfo(2525), new ItemInfo(2526), new ItemInfo(2527), 
            new ItemInfo(2528), new ItemInfo(2529), new ItemInfo(2530), new ItemInfo(2531), new ItemInfo(2532), new ItemInfo(2533), new ItemInfo(2534), new ItemInfo(2535), 
            new ItemInfo(2536), new ItemInfo(2537), new ItemInfo(2538), new ItemInfo(2539), new ItemInfo(2540), new ItemInfo(2541), new ItemInfo(2542), new ItemInfo(2543), 
            new ItemInfo(2544), new ItemInfo(2545), new ItemInfo(2546), new ItemInfo(2547), new ItemInfo(2548), new ItemInfo(2549), new ItemInfo(2550), new ItemInfo(2551), 
            new ItemInfo(2552), new ItemInfo(2553), new ItemInfo(2554), new ItemInfo(3164), new ItemInfo(3165), new ItemInfo(3172), new ItemInfo(3173), new ItemInfo(3174), 
            new ItemInfo(3175), new ItemInfo(3178), new ItemInfo(3179), new ItemInfo(3180), new ItemInfo(3181), new ItemInfo(3182), new ItemInfo(3184), new ItemInfo(3185), 
            new ItemInfo(3186), new ItemInfo(3187), new ItemInfo(3188), new ItemInfo(3189), new ItemInfo(3191), new ItemInfo(3192), new ItemInfo(3193), new ItemInfo(3194), 
            new ItemInfo(3195), new ItemInfo(3196), new ItemInfo(3199), new ItemInfo(3200), new ItemInfo(3201), new ItemInfo(3202), new ItemInfo(3354), new ItemInfo(3542), 
            new ItemInfo(3543), new ItemInfo(3544), new ItemInfo(3545), new ItemInfo(4086), new ItemInfo(4087), new ItemInfo(4088), new ItemInfo(4089), new ItemInfo(4090), 
            new ItemInfo(4091), new ItemInfo(4092), new ItemInfo(4093), new ItemInfo(4094), new ItemInfo(4095), new ItemInfo(4096), new ItemInfo(4097), new ItemInfo(4098), 
            new ItemInfo(4099), new ItemInfo(4100), new ItemInfo(4101), new ItemInfo(4102), new ItemInfo(4103), new ItemInfo(4104), new ItemInfo(4105), new ItemInfo(4153), 
            new ItemInfo(4154), new ItemInfo(4155), new ItemInfo(4156), new ItemInfo(4157), new ItemInfo(4158), new ItemInfo(4159), new ItemInfo(4160), new ItemInfo(4161), 
            new ItemInfo(4162), new ItemInfo(4163), new ItemInfo(4164), new ItemInfo(4165), new ItemInfo(4166), new ItemInfo(4227), new ItemInfo(5628), new ItemInfo(5629), 
            new ItemInfo(5630), new ItemInfo(5631), new ItemInfo(5632), new ItemInfo(5633), new ItemInfo(5634), new ItemInfo(5635), new ItemInfo(5636), new ItemInfo(5637), 
            new ItemInfo(5638), new ItemInfo(5639), new ItemInfo(5640), new ItemInfo(5641), new ItemInfo(5642), new ItemInfo(5643), new ItemInfo(5644), new ItemInfo(5917), 
            new ItemInfo(5918), new ItemInfo(5919), new ItemInfo(5920), new ItemInfo(5921), new ItemInfo(5922), new ItemInfo(5923), new ItemInfo(5924), new ItemInfo(5925), 
            new ItemInfo(5926), new ItemInfo(5927), new ItemInfo(5928), new ItemInfo(5929), new ItemInfo(5930), new ItemInfo(5931), new ItemInfo(5932), new ItemInfo(5933), 
            new ItemInfo(7701), new ItemInfo(7702), new ItemInfo(7703), new ItemInfo(7704), new ItemInfo(7705), new ItemInfo(7706), new ItemInfo(7707), new ItemInfo(7708), 
            new ItemInfo(7709), new ItemInfo(7710), new ItemInfo(7711), new ItemInfo(7811), new ItemInfo(7812), new ItemInfo(7813), new ItemInfo(7814), new ItemInfo(7815), 
            new ItemInfo(7816), new ItemInfo(7817), new ItemInfo(7818), new ItemInfo(7819), new ItemInfo(7820), new ItemInfo(7821), new ItemInfo(7822), new ItemInfo(7823), 
            new ItemInfo(7824), new ItemInfo(7825), new ItemInfo(7826), new ItemInfo(7827), new ItemInfo(7828), new ItemInfo(7829), new ItemInfo(7830), new ItemInfo(7831), 
            new ItemInfo(7832), new ItemInfo(7833), new ItemInfo(9448), new ItemInfo(9449), new ItemInfo(10302), new ItemInfo(10303), new ItemInfo(10304), new ItemInfo(10305), 
            new ItemInfo(10315), new ItemInfo(10316), new ItemInfo(10317), new ItemInfo(10318), new ItemInfo(10319), new ItemInfo(10320), new ItemInfo(12247), new ItemInfo(12248), 
            new ItemInfo(15641), new ItemInfo(15642), new ItemInfo(15643), new ItemInfo(15644), new ItemInfo(18060), new ItemInfo(18061), new ItemInfo(18062), new ItemInfo(18063), 
            new ItemInfo(18064), new ItemInfo(18077), new ItemInfo(18078), new ItemInfo(18079), new ItemInfo(18080), new ItemInfo(18081)/*, new ItemInfo(19363), new ItemInfo(19364), 
            new ItemInfo(18824), new ItemInfo(18831), new ItemInfo(19371), new ItemInfo(19372), new ItemInfo(19417), new ItemInfo(19418), new ItemInfo(19458), new ItemInfo(19459), 
            new ItemInfo(19460), new ItemInfo(19468), new ItemInfo(19469), new ItemInfo(38978), new ItemInfo(38979), new ItemInfo(40745), new ItemInfo(40746), new ItemInfo(40747), 
            new ItemInfo(40748), new ItemInfo(40749), new ItemInfo(40750), new ItemInfo(40751), new ItemInfo(40752), new ItemInfo(40753), new ItemInfo(40754), new ItemInfo(40755), 
            new ItemInfo(40756), new ItemInfo(40757), new ItemInfo(40758), new ItemInfo(40759), new ItemInfo(40760), new ItemInfo(40761), new ItemInfo(40762), new ItemInfo(40763), 
            new ItemInfo(40764), new ItemInfo(40765), new ItemInfo(40766), new ItemInfo(40767), new ItemInfo(40768), new ItemInfo(40769), new ItemInfo(40770), new ItemInfo(40771), 
            new ItemInfo(40772), new ItemInfo(40773), new ItemInfo(40774), new ItemInfo(40775), new ItemInfo(40776), new ItemInfo(40777), new ItemInfo(40778), new ItemInfo(40779), 
            new ItemInfo(40780), new ItemInfo(40781), new ItemInfo(40782), new ItemInfo(40783), new ItemInfo(40784), new ItemInfo(40785), new ItemInfo(40786), new ItemInfo(40787), 
            new ItemInfo(40855), new ItemInfo(40856), new ItemInfo(40857), new ItemInfo(40858), new ItemInfo(40859), new ItemInfo(40860), new ItemInfo(40861), new ItemInfo(40862), 
            new ItemInfo(40863), new ItemInfo(40864), new ItemInfo(40888), new ItemInfo(40889), new ItemInfo(40890), new ItemInfo(40891), new ItemInfo(40892), new ItemInfo(40893), 
            new ItemInfo(40894), new ItemInfo(40895), new ItemInfo(40896), new ItemInfo(40905), new ItemInfo(40906), new ItemInfo(40907), new ItemInfo(40908), new ItemInfo(40909), 
            new ItemInfo(40910), new ItemInfo(40911), new ItemInfo(40912), new ItemInfo(40913), new ItemInfo(40914), new ItemInfo(40915), new ItemInfo(40916), new ItemInfo(40917), 
            new ItemInfo(40918), new ItemInfo(40919), new ItemInfo(40920), new ItemInfo(40921), new ItemInfo(41162), new ItemInfo(41163), new ItemInfo(41164), new ItemInfo(41181), 
            new ItemInfo(41182), new ItemInfo(41183), new ItemInfo(41184), new ItemInfo(41188), new ItemInfo(41197), new ItemInfo(41204), new ItemInfo(41205), new ItemInfo(41212), 
            new ItemInfo(41213), new ItemInfo(41214), new ItemInfo(41215), new ItemInfo(41216), new ItemInfo(41219), new ItemInfo(41222), new ItemInfo(41223)*/
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCookingStaticGump()
			: this(0)
		{ }

		public AddCookingStaticGump(int page) 
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

			from.SendGump(new AddCookingStaticGump(page));
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
