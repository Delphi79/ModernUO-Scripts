using Server.Network;

namespace Server.Gumps
{
	public class AddWallPt3Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddWallPt3", AccessLevel.GameMaster, new CommandEventHandler(AddWallPt3_OnCommand));
		}

		[Usage("AddWallPt3")]
		
		public static void AddWallPt3_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddWallPt3Gump>();
			e.Mobile.SendGump(new AddWallPt3Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(9343), new ItemInfo(9344), new ItemInfo(9345), new ItemInfo(9346), new ItemInfo(9347), new ItemInfo(9348), new ItemInfo(9349), new ItemInfo(9350), new ItemInfo(9351), 
            new ItemInfo(9352), new ItemInfo(9353), new ItemInfo(9354), new ItemInfo(9355), new ItemInfo(9356), new ItemInfo(9357), new ItemInfo(9358), new ItemInfo(9359), new ItemInfo(9360), 
            new ItemInfo(9361), new ItemInfo(9362), new ItemInfo(9363), new ItemInfo(9364), new ItemInfo(9365), new ItemInfo(9366), new ItemInfo(9367), new ItemInfo(9368), new ItemInfo(9369), 
            new ItemInfo(9370), new ItemInfo(9371), new ItemInfo(9372), new ItemInfo(9373), new ItemInfo(9374), new ItemInfo(9375), new ItemInfo(9376), new ItemInfo(9377), new ItemInfo(9378), 
            new ItemInfo(9379), new ItemInfo(9380), new ItemInfo(9381), new ItemInfo(9382), new ItemInfo(9383), new ItemInfo(9384), new ItemInfo(9385), new ItemInfo(9386), new ItemInfo(9387), 
            new ItemInfo(9388), new ItemInfo(9460), new ItemInfo(9461), new ItemInfo(9462), new ItemInfo(9463), new ItemInfo(9464), new ItemInfo(9465), new ItemInfo(9466), new ItemInfo(9467), 
            new ItemInfo(9468), new ItemInfo(9469), new ItemInfo(9470), new ItemInfo(9471), new ItemInfo(9472), new ItemInfo(9473), new ItemInfo(9474), new ItemInfo(9475), new ItemInfo(9476), 
            new ItemInfo(9477), new ItemInfo(9478), new ItemInfo(9479), new ItemInfo(9480), new ItemInfo(9481), new ItemInfo(9482), new ItemInfo(9483), new ItemInfo(9484), new ItemInfo(9485), 
            new ItemInfo(9486), new ItemInfo(9487), new ItemInfo(9488), new ItemInfo(9489), new ItemInfo(9490), new ItemInfo(9491), new ItemInfo(9492), new ItemInfo(9493), new ItemInfo(9494), 
            new ItemInfo(9495), new ItemInfo(9496), new ItemInfo(9497), new ItemInfo(9498), new ItemInfo(9499), new ItemInfo(9500), new ItemInfo(9501), new ItemInfo(9502), new ItemInfo(9503), 
            new ItemInfo(9504), new ItemInfo(9505), new ItemInfo(9506), new ItemInfo(9507), new ItemInfo(9508), new ItemInfo(9509), new ItemInfo(9510), new ItemInfo(9511), new ItemInfo(9512), 
            new ItemInfo(9513), new ItemInfo(9514), new ItemInfo(9515), new ItemInfo(9516), new ItemInfo(9517), new ItemInfo(9518), new ItemInfo(9519), new ItemInfo(9520), new ItemInfo(9521), 
            new ItemInfo(9522), new ItemInfo(9523), new ItemInfo(9524), new ItemInfo(9525), new ItemInfo(9526), new ItemInfo(9527), new ItemInfo(9528), new ItemInfo(9529), new ItemInfo(9530), 
            new ItemInfo(9531), new ItemInfo(9532), new ItemInfo(9533), new ItemInfo(9534), new ItemInfo(9535), new ItemInfo(9536), new ItemInfo(9537), new ItemInfo(9538), new ItemInfo(9539), 
            new ItemInfo(9540), new ItemInfo(9541), new ItemInfo(9543), new ItemInfo(9544), new ItemInfo(9545), new ItemInfo(9546), new ItemInfo(9547), new ItemInfo(9548), new ItemInfo(9549), 
            new ItemInfo(9550), new ItemInfo(9551), new ItemInfo(9552), new ItemInfo(9553), new ItemInfo(9554), new ItemInfo(9555), new ItemInfo(9936), new ItemInfo(9937), new ItemInfo(9938), 
            new ItemInfo(9939), new ItemInfo(9940), new ItemInfo(9941), new ItemInfo(9942), new ItemInfo(9943), new ItemInfo(9944), new ItemInfo(9945), new ItemInfo(10006), new ItemInfo(10007), 
            new ItemInfo(10008), new ItemInfo(10009), new ItemInfo(10010), new ItemInfo(10011), new ItemInfo(10012), new ItemInfo(10013), new ItemInfo(10014), new ItemInfo(10015), new ItemInfo(10067), 
            new ItemInfo(10068), new ItemInfo(10069), new ItemInfo(10070), new ItemInfo(10071), new ItemInfo(10072), new ItemInfo(10073), new ItemInfo(10074), new ItemInfo(10075), new ItemInfo(10076), 
            new ItemInfo(10077), new ItemInfo(10078), new ItemInfo(10079), new ItemInfo(10080), new ItemInfo(10081), new ItemInfo(10082), new ItemInfo(10335), new ItemInfo(10336), new ItemInfo(10337), 
            new ItemInfo(10338), new ItemInfo(10339), new ItemInfo(10340), new ItemInfo(10341), new ItemInfo(10342), new ItemInfo(10343), new ItemInfo(10344), new ItemInfo(10345), new ItemInfo(10346), 
            new ItemInfo(10347), new ItemInfo(10348), new ItemInfo(10349), new ItemInfo(10376), new ItemInfo(10377), new ItemInfo(10378), new ItemInfo(10379), new ItemInfo(10380), new ItemInfo(10381), 
            new ItemInfo(10382), new ItemInfo(10383), new ItemInfo(10384), new ItemInfo(10385), new ItemInfo(10386), new ItemInfo(10387), new ItemInfo(10388), new ItemInfo(10389), new ItemInfo(10390), 
            new ItemInfo(10391), new ItemInfo(10392), new ItemInfo(10393), new ItemInfo(10394), new ItemInfo(10395), new ItemInfo(10396), new ItemInfo(10397), new ItemInfo(10398), new ItemInfo(10399), 
            new ItemInfo(10400), new ItemInfo(10401), new ItemInfo(10402), new ItemInfo(10403), new ItemInfo(10552), new ItemInfo(10553), new ItemInfo(10554), new ItemInfo(10555), new ItemInfo(10556), 
            new ItemInfo(10557), new ItemInfo(10558), new ItemInfo(10559), new ItemInfo(10560), new ItemInfo(10561), new ItemInfo(10562), new ItemInfo(10563), new ItemInfo(10564), new ItemInfo(10565), 
            new ItemInfo(10566), new ItemInfo(10567), new ItemInfo(10568), new ItemInfo(10569), new ItemInfo(10570), new ItemInfo(10571), new ItemInfo(10572), new ItemInfo(10573), new ItemInfo(10574), 
            new ItemInfo(10575), new ItemInfo(10576), new ItemInfo(10577), new ItemInfo(10578), new ItemInfo(10579), new ItemInfo(10580), new ItemInfo(10581), new ItemInfo(10582), new ItemInfo(10583), 
            new ItemInfo(10584), new ItemInfo(10585), new ItemInfo(10586), new ItemInfo(10587), new ItemInfo(10640), new ItemInfo(10641), new ItemInfo(10642), new ItemInfo(10643), new ItemInfo(10644), 
            new ItemInfo(10645), new ItemInfo(10646), new ItemInfo(10647), new ItemInfo(10648), new ItemInfo(10649), new ItemInfo(10650), new ItemInfo(10651), new ItemInfo(10652), new ItemInfo(10653), 
            new ItemInfo(10654), new ItemInfo(10655), new ItemInfo(10656), new ItemInfo(10657), new ItemInfo(10658), new ItemInfo(10659), new ItemInfo(10660), new ItemInfo(10661), new ItemInfo(10662), 
            new ItemInfo(10663), new ItemInfo(10664), new ItemInfo(10665), new ItemInfo(10666), new ItemInfo(10667), new ItemInfo(10668), new ItemInfo(10669), new ItemInfo(10670), new ItemInfo(10671), 
            new ItemInfo(10672), new ItemInfo(10673), new ItemInfo(10674), new ItemInfo(10675), new ItemInfo(10676), new ItemInfo(10677), new ItemInfo(10678), new ItemInfo(10679), new ItemInfo(10680), 
            new ItemInfo(10681), new ItemInfo(10682), new ItemInfo(10683), new ItemInfo(10684), new ItemInfo(10685), new ItemInfo(10686), new ItemInfo(10687), new ItemInfo(10726), new ItemInfo(10727), 
            new ItemInfo(10728), new ItemInfo(10729), new ItemInfo(10730), new ItemInfo(10731), new ItemInfo(10732), new ItemInfo(10733), new ItemInfo(10734), new ItemInfo(10735), new ItemInfo(10736), 
            new ItemInfo(10737), new ItemInfo(10738), new ItemInfo(10739), new ItemInfo(10740), new ItemInfo(10741), new ItemInfo(10742), new ItemInfo(10743), new ItemInfo(10744), new ItemInfo(10745), 
            new ItemInfo(10746), new ItemInfo(10747), new ItemInfo(10748), new ItemInfo(10800), new ItemInfo(10801), new ItemInfo(10802), new ItemInfo(10803), new ItemInfo(10804), new ItemInfo(10805), 
            new ItemInfo(10806), new ItemInfo(10807), new ItemInfo(10808), new ItemInfo(10809), new ItemInfo(10810), new ItemInfo(10811), new ItemInfo(11182), new ItemInfo(11183), new ItemInfo(11184), 
            new ItemInfo(11185), new ItemInfo(11186), new ItemInfo(11187), new ItemInfo(11188), new ItemInfo(11193), new ItemInfo(11194), new ItemInfo(11195), new ItemInfo(11196), new ItemInfo(11197), 
            new ItemInfo(11198), new ItemInfo(11199), new ItemInfo(11200), new ItemInfo(11201), new ItemInfo(11202), new ItemInfo(11207), new ItemInfo(11208), new ItemInfo(11209), new ItemInfo(11210), 
            new ItemInfo(11211), new ItemInfo(11212), new ItemInfo(11213), new ItemInfo(11214), new ItemInfo(11503), new ItemInfo(11504), new ItemInfo(11505), new ItemInfo(11506), new ItemInfo(11507), 
            new ItemInfo(11508), new ItemInfo(11509), new ItemInfo(11510), new ItemInfo(11511), new ItemInfo(11512), new ItemInfo(11544), new ItemInfo(11545), new ItemInfo(11546), new ItemInfo(11547), 
            new ItemInfo(11548), new ItemInfo(11549), new ItemInfo(11580), new ItemInfo(11581), new ItemInfo(11582), new ItemInfo(11583), new ItemInfo(11584), new ItemInfo(11585), new ItemInfo(11586), 
            new ItemInfo(11587), new ItemInfo(11588), new ItemInfo(11589), new ItemInfo(11715), new ItemInfo(11716), new ItemInfo(11717), new ItemInfo(11718), new ItemInfo(11719), new ItemInfo(11720), 
            new ItemInfo(11721), new ItemInfo(11722), new ItemInfo(11727), new ItemInfo(11728), new ItemInfo(11729), new ItemInfo(11767), new ItemInfo(11768), new ItemInfo(11769), new ItemInfo(11770), 
            new ItemInfo(11771), new ItemInfo(11772), new ItemInfo(11773), new ItemInfo(11774), new ItemInfo(11775), new ItemInfo(11776), new ItemInfo(12555), new ItemInfo(12556), new ItemInfo(12557), 
            new ItemInfo(12558), new ItemInfo(12559), new ItemInfo(12560), new ItemInfo(12561), new ItemInfo(12562), new ItemInfo(12563), new ItemInfo(12564), new ItemInfo(12565), new ItemInfo(12566), 
            new ItemInfo(12567), new ItemInfo(12568), new ItemInfo(12569), new ItemInfo(13783), new ItemInfo(13784), new ItemInfo(13785), new ItemInfo(13786), new ItemInfo(13787), new ItemInfo(13788), 
            new ItemInfo(13789), new ItemInfo(13790), new ItemInfo(13791), new ItemInfo(13792), new ItemInfo(13793), new ItemInfo(13794), new ItemInfo(13795), new ItemInfo(13796), new ItemInfo(13797), 
            new ItemInfo(13798), new ItemInfo(13843), new ItemInfo(13844), new ItemInfo(13845), new ItemInfo(13846), new ItemInfo(13847), new ItemInfo(13848), new ItemInfo(13849), new ItemInfo(13936), 
            new ItemInfo(13937), new ItemInfo(13938), new ItemInfo(13939), new ItemInfo(13940), new ItemInfo(13941), new ItemInfo(13942), new ItemInfo(13943)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddWallPt3Gump()
			: this(0)
		{ }

		public AddWallPt3Gump(int page) 
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

			from.SendGump(new AddWallPt3Gump(page));
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
