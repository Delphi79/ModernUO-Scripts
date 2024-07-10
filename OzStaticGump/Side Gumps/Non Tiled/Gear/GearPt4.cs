using Server.Network;

namespace Server.Gumps
{
	public class AddGearPt4Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddGearPt4", AccessLevel.GameMaster, new CommandEventHandler(AddGearPt4_OnCommand));
		}

		[Usage("AddGearPt4")]
		
		public static void AddGearPt4_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddGearPt4Gump>();
			e.Mobile.SendGump(new AddGearPt4Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(9867), new ItemInfo(9868), new ItemInfo(9869), new ItemInfo(9870), new ItemInfo(9871), new ItemInfo(9872), new ItemInfo(9873), new ItemInfo(9874), 
            new ItemInfo(9885), new ItemInfo(9886), new ItemInfo(9889), new ItemInfo(9890), new ItemInfo(9891), new ItemInfo(9892), new ItemInfo(9900), new ItemInfo(9901), 
            new ItemInfo(9902), new ItemInfo(9903), new ItemInfo(9904), new ItemInfo(9905), new ItemInfo(9906), new ItemInfo(9907), new ItemInfo(9908), new ItemInfo(9909), 
            new ItemInfo(9910), new ItemInfo(9914), new ItemInfo(9915), new ItemInfo(9916), new ItemInfo(9917), new ItemInfo(9918), new ItemInfo(9919), new ItemInfo(9920), 
            new ItemInfo(9921), new ItemInfo(9922), new ItemInfo(9923), new ItemInfo(9924), new ItemInfo(9925), new ItemInfo(9926), new ItemInfo(9927), new ItemInfo(9928), 
            new ItemInfo(9929), new ItemInfo(9930), new ItemInfo(9931), new ItemInfo(9932), new ItemInfo(9933), new ItemInfo(9934), new ItemInfo(9935), new ItemInfo(10100), 
            new ItemInfo(10101), new ItemInfo(10102), new ItemInfo(10103), new ItemInfo(10104), new ItemInfo(10105), new ItemInfo(10106), new ItemInfo(10107), new ItemInfo(10108), 
            new ItemInfo(10109), new ItemInfo(10110), new ItemInfo(10111), new ItemInfo(10112), new ItemInfo(10113), new ItemInfo(10114), new ItemInfo(10115), new ItemInfo(10116), 
            new ItemInfo(10117), new ItemInfo(10118), new ItemInfo(10119), new ItemInfo(10120), new ItemInfo(10121), new ItemInfo(10122), new ItemInfo(10123), new ItemInfo(10125), 
            new ItemInfo(10126), new ItemInfo(10127), new ItemInfo(10128), new ItemInfo(10129), new ItemInfo(10130), new ItemInfo(10131), new ItemInfo(10132), new ItemInfo(10134), 
            new ItemInfo(10135), new ItemInfo(10136), new ItemInfo(10137), new ItemInfo(10138), new ItemInfo(10139), new ItemInfo(10140), new ItemInfo(10141), new ItemInfo(10144), 
            new ItemInfo(10145), new ItemInfo(10146), new ItemInfo(10147), new ItemInfo(10148), new ItemInfo(10149), new ItemInfo(10150), new ItemInfo(10151), new ItemInfo(10152), 
            new ItemInfo(10153), new ItemInfo(10154), new ItemInfo(10155), new ItemInfo(10156), new ItemInfo(10157), new ItemInfo(10158), new ItemInfo(10159), new ItemInfo(10175), 
            new ItemInfo(10176), new ItemInfo(10177), new ItemInfo(10178), new ItemInfo(10179), new ItemInfo(10180), new ItemInfo(10181), new ItemInfo(10182), new ItemInfo(10183), 
            new ItemInfo(10184), new ItemInfo(10185), new ItemInfo(10186), new ItemInfo(10187), new ItemInfo(10188), new ItemInfo(10189), new ItemInfo(10190), new ItemInfo(10191), 
            new ItemInfo(10192), new ItemInfo(10193), new ItemInfo(10194), new ItemInfo(10195), new ItemInfo(10196), new ItemInfo(10197), new ItemInfo(10198), new ItemInfo(10200), 
            new ItemInfo(10201), new ItemInfo(10202), new ItemInfo(10203), new ItemInfo(10204), new ItemInfo(10205), new ItemInfo(10206), new ItemInfo(10207), new ItemInfo(10209), 
            new ItemInfo(10210), new ItemInfo(10211), new ItemInfo(10212), new ItemInfo(10213), new ItemInfo(10214), new ItemInfo(10215), new ItemInfo(10216), new ItemInfo(10219), 
            new ItemInfo(10220), new ItemInfo(10221), new ItemInfo(10222), new ItemInfo(10223), new ItemInfo(10224), new ItemInfo(10225), new ItemInfo(10226), new ItemInfo(10227), 
            new ItemInfo(10228), new ItemInfo(10229), new ItemInfo(10230), new ItemInfo(10231), new ItemInfo(10232), new ItemInfo(10233), new ItemInfo(10234), new ItemInfo(10244), 
            new ItemInfo(10245), new ItemInfo(10246), new ItemInfo(10247), new ItemInfo(10248), new ItemInfo(10249), new ItemInfo(11009), new ItemInfo(11010), new ItemInfo(11011), 
            new ItemInfo(11012), new ItemInfo(11013), new ItemInfo(11014), new ItemInfo(11015), new ItemInfo(11016), new ItemInfo(11017), new ItemInfo(11018), new ItemInfo(11019)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddGearPt4Gump()
			: this(0)
		{ }

		public AddGearPt4Gump(int page) 
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

			from.SendGump(new AddGearPt4Gump(page));
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
