using Server.Network;

namespace Server.Gumps
{
	public class AddWallPt4Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddWallPt4", AccessLevel.GameMaster, new CommandEventHandler(AddWallPt4_OnCommand));
		}

		[Usage("AddWallPt4")]
		
		public static void AddWallPt4_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddWallPt4Gump>();
			e.Mobile.SendGump(new AddWallPt4Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(16660), new ItemInfo(16661), new ItemInfo(16662), new ItemInfo(16663), new ItemInfo(16664), new ItemInfo(16665), new ItemInfo(16666),
            new ItemInfo(16675), new ItemInfo(16676), new ItemInfo(16677), new ItemInfo(16718), new ItemInfo(16719), new ItemInfo(16720), new ItemInfo(16721), 
            new ItemInfo(16722), new ItemInfo(16723), new ItemInfo(16724), new ItemInfo(16725), new ItemInfo(16730), new ItemInfo(16731), new ItemInfo(16732), 
            new ItemInfo(16733), new ItemInfo(16734), new ItemInfo(16735), new ItemInfo(16736), new ItemInfo(16737), new ItemInfo(16738), new ItemInfo(16739),
            new ItemInfo(16742), new ItemInfo(16743), new ItemInfo(16744), new ItemInfo(16745), new ItemInfo(16746), new ItemInfo(16747), new ItemInfo(16756), new ItemInfo(16757), 
            new ItemInfo(16758), new ItemInfo(16759), new ItemInfo(16760), new ItemInfo(16761), new ItemInfo(16762), new ItemInfo(16763), new ItemInfo(16764), 
            new ItemInfo(16765), new ItemInfo(16766), new ItemInfo(16767), new ItemInfo(16768), new ItemInfo(16769), new ItemInfo(16770), new ItemInfo(16771), 
            new ItemInfo(16772), new ItemInfo(16773), new ItemInfo(16784), new ItemInfo(16785), new ItemInfo(16786), new ItemInfo(16787), new ItemInfo(16788), 
            new ItemInfo(16789), new ItemInfo(16790), new ItemInfo(16791), new ItemInfo(16792), new ItemInfo(16793), new ItemInfo(16794), new ItemInfo(16795), 
            new ItemInfo(16796), new ItemInfo(16797), new ItemInfo(16798), new ItemInfo(16799), new ItemInfo(16805), new ItemInfo(16806), new ItemInfo(16807), 
            new ItemInfo(16808), new ItemInfo(16809), new ItemInfo(16810), new ItemInfo(16811), new ItemInfo(16812), new ItemInfo(17172), new ItemInfo(17173), 
            new ItemInfo(17174), new ItemInfo(17175), new ItemInfo(17176), new ItemInfo(17177), new ItemInfo(17178), new ItemInfo(17179), new ItemInfo(17180), 
            new ItemInfo(17181), new ItemInfo(17182), new ItemInfo(17183), new ItemInfo(17184), new ItemInfo(17185), new ItemInfo(17186), new ItemInfo(17187), 
            new ItemInfo(17188), new ItemInfo(17189), new ItemInfo(17190), new ItemInfo(17191), new ItemInfo(17224), new ItemInfo(17225), new ItemInfo(17226), 
            new ItemInfo(17227), new ItemInfo(17228), new ItemInfo(17229), new ItemInfo(17230), new ItemInfo(17231), new ItemInfo(17232), new ItemInfo(17233), 
            new ItemInfo(17234), new ItemInfo(17235), new ItemInfo(17344), new ItemInfo(17345), new ItemInfo(17346), new ItemInfo(17347), new ItemInfo(17348), 
            new ItemInfo(17349), new ItemInfo(17350), new ItemInfo(17351), new ItemInfo(17352), new ItemInfo(17353), new ItemInfo(17354), new ItemInfo(17355), 
            new ItemInfo(17356), new ItemInfo(17357), new ItemInfo(17358), new ItemInfo(17359), new ItemInfo(17360), new ItemInfo(17361), new ItemInfo(17362), 
            new ItemInfo(17363), new ItemInfo(17364), new ItemInfo(17365), new ItemInfo(17366), new ItemInfo(17367), new ItemInfo(17368), new ItemInfo(17369), 
            new ItemInfo(17370), new ItemInfo(17371), new ItemInfo(17372), new ItemInfo(17373), new ItemInfo(17374), new ItemInfo(17375), new ItemInfo(17657), 
            new ItemInfo(17658), new ItemInfo(17659), new ItemInfo(17660), new ItemInfo(17661), new ItemInfo(17662), new ItemInfo(17663), new ItemInfo(17664), 
            new ItemInfo(17665), new ItemInfo(17666), new ItemInfo(17667), new ItemInfo(17668), new ItemInfo(17669), new ItemInfo(17670), new ItemInfo(17671), 
            new ItemInfo(17672), new ItemInfo(17673), new ItemInfo(17674), new ItemInfo(17675), new ItemInfo(17676), new ItemInfo(17679), new ItemInfo(17680), 
            new ItemInfo(17681), new ItemInfo(17682), new ItemInfo(17688), new ItemInfo(17689), new ItemInfo(17690), new ItemInfo(17691), new ItemInfo(17692), 
            new ItemInfo(17693), new ItemInfo(17694), new ItemInfo(17695), new ItemInfo(17696), new ItemInfo(17697), new ItemInfo(17698), new ItemInfo(17699), 
            new ItemInfo(17700), new ItemInfo(17701), new ItemInfo(17702), new ItemInfo(17703), new ItemInfo(17704), new ItemInfo(17705), new ItemInfo(17706), 
            new ItemInfo(17707), new ItemInfo(17708), new ItemInfo(17709), new ItemInfo(17710), new ItemInfo(17711), new ItemInfo(17712), new ItemInfo(17713), 
            new ItemInfo(17714), new ItemInfo(17715), new ItemInfo(17716), new ItemInfo(17717), new ItemInfo(17718), new ItemInfo(17719), new ItemInfo(17720), 
            new ItemInfo(17721), new ItemInfo(17722), new ItemInfo(17723), new ItemInfo(17724), new ItemInfo(17725), new ItemInfo(17726), new ItemInfo(17727), 
            new ItemInfo(17728), new ItemInfo(17729), new ItemInfo(17730), new ItemInfo(17731), new ItemInfo(17732), new ItemInfo(17733), new ItemInfo(17734), 
            new ItemInfo(17735), new ItemInfo(17736), new ItemInfo(17737), new ItemInfo(17738), new ItemInfo(17739), new ItemInfo(17740), new ItemInfo(17741), 
            new ItemInfo(17742), new ItemInfo(17743), new ItemInfo(17744), new ItemInfo(17745), new ItemInfo(17746), new ItemInfo(17747), new ItemInfo(17748), 
            new ItemInfo(17749), new ItemInfo(17750), new ItemInfo(17751), new ItemInfo(17752), new ItemInfo(17753), new ItemInfo(17754), new ItemInfo(17755), 
            new ItemInfo(17756), new ItemInfo(17757), new ItemInfo(17758), new ItemInfo(17759), new ItemInfo(17760), new ItemInfo(17761), new ItemInfo(17762), 
            new ItemInfo(17763), new ItemInfo(17764), new ItemInfo(17765), new ItemInfo(17766), new ItemInfo(17767), new ItemInfo(17768), new ItemInfo(17769), 
            new ItemInfo(17770), new ItemInfo(17771), new ItemInfo(17772), new ItemInfo(17773), new ItemInfo(17794), new ItemInfo(17795), new ItemInfo(17796), 
            new ItemInfo(17797), new ItemInfo(17798), new ItemInfo(17799), new ItemInfo(17800), new ItemInfo(17801), new ItemInfo(17802), new ItemInfo(17803), 
            new ItemInfo(17804), new ItemInfo(17805), new ItemInfo(17806), new ItemInfo(17807), new ItemInfo(17808), new ItemInfo(17809), new ItemInfo(17810), 
            new ItemInfo(17811), new ItemInfo(17812), new ItemInfo(17813), new ItemInfo(17814), new ItemInfo(17815), new ItemInfo(17816), new ItemInfo(17817), 
            new ItemInfo(17818), new ItemInfo(17819), new ItemInfo(17820), new ItemInfo(17821), new ItemInfo(17822), new ItemInfo(17823), new ItemInfo(17824), 
            new ItemInfo(17825), new ItemInfo(17826), new ItemInfo(17827), new ItemInfo(17832), new ItemInfo(17833), new ItemInfo(17834), new ItemInfo(17835), 
            new ItemInfo(17836), new ItemInfo(17837), new ItemInfo(17838), new ItemInfo(17839), new ItemInfo(17840), new ItemInfo(17842), new ItemInfo(18109), 
            new ItemInfo(18110), new ItemInfo(18111), new ItemInfo(18112), new ItemInfo(18113), new ItemInfo(18114), new ItemInfo(18115), new ItemInfo(18116), 
            new ItemInfo(18117), new ItemInfo(18118), new ItemInfo(18119), new ItemInfo(18120), new ItemInfo(18121), new ItemInfo(18122), new ItemInfo(18123), 
            new ItemInfo(18128), new ItemInfo(18129), new ItemInfo(18130), new ItemInfo(18131), new ItemInfo(18132), new ItemInfo(18133), new ItemInfo(18134), 
            new ItemInfo(18135), new ItemInfo(18136), new ItemInfo(18138), new ItemInfo(18139), new ItemInfo(18140), new ItemInfo(18301), new ItemInfo(18302), 
            new ItemInfo(18303), new ItemInfo(18304), new ItemInfo(18305), new ItemInfo(18306), new ItemInfo(18307), new ItemInfo(18308), new ItemInfo(18309), 
            new ItemInfo(18310), new ItemInfo(18311), new ItemInfo(18312), new ItemInfo(18313), new ItemInfo(18314), new ItemInfo(18315), new ItemInfo(18316), 
            new ItemInfo(18317), new ItemInfo(18318), new ItemInfo(18319), new ItemInfo(19189), new ItemInfo(19190), new ItemInfo(19191), new ItemInfo(19192), 
            new ItemInfo(19193), new ItemInfo(19194), new ItemInfo(19195), new ItemInfo(19196), new ItemInfo(19197), new ItemInfo(19200), new ItemInfo(19206), 
            new ItemInfo(19207), new ItemInfo(19208), new ItemInfo(19209), new ItemInfo(19210), new ItemInfo(19211), new ItemInfo(19212), new ItemInfo(19213), 
            new ItemInfo(19214), new ItemInfo(19215), new ItemInfo(19216), new ItemInfo(19217), new ItemInfo(19218), new ItemInfo(19219), new ItemInfo(19220), 
            new ItemInfo(19221), new ItemInfo(19222), new ItemInfo(19223), new ItemInfo(19224), new ItemInfo(19225), new ItemInfo(19226), new ItemInfo(19227), 
            new ItemInfo(19243), new ItemInfo(19244), new ItemInfo(19245), new ItemInfo(19246), new ItemInfo(19247), new ItemInfo(19253), new ItemInfo(19254), 
            new ItemInfo(19255), new ItemInfo(19256), new ItemInfo(19257), new ItemInfo(19258), new ItemInfo(19259), new ItemInfo(19260), new ItemInfo(19266), 
            new ItemInfo(19267)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddWallPt4Gump()
			: this(0)
		{ }

		public AddWallPt4Gump(int page) 
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

			from.SendGump(new AddWallPt4Gump(page));
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
