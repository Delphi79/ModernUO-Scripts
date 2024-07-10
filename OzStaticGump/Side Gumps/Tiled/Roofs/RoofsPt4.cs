using Server.Network;

namespace Server.Gumps
{
	public class AddRoofPt4Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddRoofPt4", AccessLevel.GameMaster, new CommandEventHandler(AddRoofPt4_OnCommand));
		}

		[Usage("AddRoofPt4")]
		
		public static void AddRoofPt4_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddRoofPt4Gump>();
			e.Mobile.SendGump(new AddRoofPt4Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Roofs
            new ItemInfo(19955), new ItemInfo(19956), new ItemInfo(19957), new ItemInfo(19958), new ItemInfo(19959), new ItemInfo(19960), new ItemInfo(19961), new ItemInfo(19962), 
            new ItemInfo(19963), new ItemInfo(19964), new ItemInfo(19965), new ItemInfo(19966), new ItemInfo(19967), new ItemInfo(19968), new ItemInfo(19969), new ItemInfo(19970), 
            new ItemInfo(19971), new ItemInfo(19972), new ItemInfo(19973), new ItemInfo(19974), new ItemInfo(19975), new ItemInfo(19976), new ItemInfo(19977), new ItemInfo(19978), 
            new ItemInfo(19979), new ItemInfo(19980), new ItemInfo(19981), new ItemInfo(19982), new ItemInfo(19983), new ItemInfo(19984), new ItemInfo(19985), new ItemInfo(19986), 
            new ItemInfo(19987), new ItemInfo(19988), new ItemInfo(19989), new ItemInfo(19990), new ItemInfo(19991), new ItemInfo(19992), new ItemInfo(19993), new ItemInfo(19994), 
            new ItemInfo(19995), new ItemInfo(19996), new ItemInfo(19997), new ItemInfo(19998), new ItemInfo(19999), new ItemInfo(20000), new ItemInfo(20001), new ItemInfo(20002), 
            new ItemInfo(20003), new ItemInfo(20004), new ItemInfo(20005), new ItemInfo(20006), new ItemInfo(20007), new ItemInfo(20008), new ItemInfo(20009), new ItemInfo(20010), 
            new ItemInfo(20011), new ItemInfo(20012), new ItemInfo(20013), new ItemInfo(20014), new ItemInfo(20015), new ItemInfo(20016), new ItemInfo(20017), new ItemInfo(20018), 
            new ItemInfo(20019), new ItemInfo(20020), new ItemInfo(20021), new ItemInfo(20022), new ItemInfo(20023), new ItemInfo(20024), new ItemInfo(20025), new ItemInfo(20026), 
            new ItemInfo(20027), new ItemInfo(20028), new ItemInfo(20029), new ItemInfo(20030), new ItemInfo(20031), new ItemInfo(20032), new ItemInfo(20033), new ItemInfo(20034), 
            new ItemInfo(20035), new ItemInfo(20036), new ItemInfo(20037), new ItemInfo(20038), new ItemInfo(20039), new ItemInfo(20040), new ItemInfo(20041), new ItemInfo(20042), 
            new ItemInfo(20043), new ItemInfo(20044), new ItemInfo(20045), new ItemInfo(20046), new ItemInfo(20047), new ItemInfo(20048), new ItemInfo(20049), new ItemInfo(20050), 
            new ItemInfo(20051), new ItemInfo(20052), new ItemInfo(20053), new ItemInfo(20054), new ItemInfo(20055), new ItemInfo(20056), new ItemInfo(20057), new ItemInfo(20058), 
            new ItemInfo(20059), new ItemInfo(20060), new ItemInfo(20061), new ItemInfo(20062), new ItemInfo(20063), new ItemInfo(20064), new ItemInfo(20065), new ItemInfo(20066), 
            new ItemInfo(20067), new ItemInfo(20068), new ItemInfo(20069), new ItemInfo(20070), new ItemInfo(20071), new ItemInfo(20072), new ItemInfo(20073), new ItemInfo(20074), 
            new ItemInfo(20075), new ItemInfo(20076), new ItemInfo(20077), new ItemInfo(20078), new ItemInfo(20079), new ItemInfo(20080), new ItemInfo(20081), new ItemInfo(20082), 
            new ItemInfo(20083), new ItemInfo(20084), new ItemInfo(20085), new ItemInfo(20086), new ItemInfo(20087), new ItemInfo(20088), new ItemInfo(20089), new ItemInfo(20090), 
            new ItemInfo(20091), new ItemInfo(20092), new ItemInfo(20093), new ItemInfo(20094), new ItemInfo(20095), new ItemInfo(20096), new ItemInfo(20097), new ItemInfo(20098), 
            new ItemInfo(20099), new ItemInfo(20100), new ItemInfo(20101), new ItemInfo(20102), new ItemInfo(20103), new ItemInfo(20104), new ItemInfo(20105), new ItemInfo(20106), 
            new ItemInfo(20107), new ItemInfo(20108), new ItemInfo(20109), new ItemInfo(20110), new ItemInfo(20111), new ItemInfo(20112), new ItemInfo(20113), new ItemInfo(20114), 
            new ItemInfo(20115), new ItemInfo(20116), new ItemInfo(20117), new ItemInfo(20118), new ItemInfo(20119), new ItemInfo(20120), new ItemInfo(20121), new ItemInfo(20122), 
            new ItemInfo(20123), new ItemInfo(20124), new ItemInfo(20125), new ItemInfo(20126), new ItemInfo(20127), new ItemInfo(20128), new ItemInfo(20129), new ItemInfo(20130), 
            new ItemInfo(20131), new ItemInfo(20132), new ItemInfo(20133), new ItemInfo(20134), new ItemInfo(20135), new ItemInfo(20136), new ItemInfo(20137), new ItemInfo(20138), 
            new ItemInfo(20139), new ItemInfo(20140), new ItemInfo(20141), new ItemInfo(20142), new ItemInfo(20143), new ItemInfo(20144), new ItemInfo(20145), new ItemInfo(20146), 
            new ItemInfo(20147), new ItemInfo(20148), new ItemInfo(20149), new ItemInfo(20150), new ItemInfo(20151), new ItemInfo(20152), new ItemInfo(20153), new ItemInfo(20154), 
            new ItemInfo(20155), new ItemInfo(20156), new ItemInfo(20157), new ItemInfo(20158), new ItemInfo(20159), new ItemInfo(20160), new ItemInfo(20161), new ItemInfo(20162), 
            new ItemInfo(20163), new ItemInfo(20164), new ItemInfo(20165), new ItemInfo(20166), new ItemInfo(20167), new ItemInfo(20168), new ItemInfo(20169), new ItemInfo(20170), 
            new ItemInfo(20171), new ItemInfo(20172), new ItemInfo(20173), new ItemInfo(20174), new ItemInfo(20175), new ItemInfo(20176), new ItemInfo(20177), new ItemInfo(20178), 
            new ItemInfo(20179), new ItemInfo(20180), new ItemInfo(20181), new ItemInfo(20182), new ItemInfo(20183), new ItemInfo(20184), new ItemInfo(20185), new ItemInfo(20186), 
            new ItemInfo(20187), new ItemInfo(20188), new ItemInfo(20189), new ItemInfo(20190), new ItemInfo(20191), new ItemInfo(20192), new ItemInfo(20193), new ItemInfo(20194), 
            new ItemInfo(20195), new ItemInfo(20196), new ItemInfo(20197), new ItemInfo(20198), new ItemInfo(20199), new ItemInfo(20200), new ItemInfo(20201), new ItemInfo(20202), 
            new ItemInfo(20203), new ItemInfo(20204), new ItemInfo(20205), new ItemInfo(20206), new ItemInfo(20207), new ItemInfo(20208), new ItemInfo(20209), new ItemInfo(20210), 
            new ItemInfo(20211), new ItemInfo(20212), new ItemInfo(20213), new ItemInfo(20214), new ItemInfo(20215), new ItemInfo(20216), new ItemInfo(20217), new ItemInfo(20218), 
            new ItemInfo(20219), new ItemInfo(20220), new ItemInfo(20221), new ItemInfo(20222), new ItemInfo(20223), new ItemInfo(20224), new ItemInfo(20225), new ItemInfo(20226), 
            new ItemInfo(20227), new ItemInfo(20228), new ItemInfo(20229), new ItemInfo(20230), new ItemInfo(20231), new ItemInfo(20232), new ItemInfo(20233), new ItemInfo(20234), 
            new ItemInfo(20235), new ItemInfo(20236), new ItemInfo(20237), new ItemInfo(20238), new ItemInfo(20239), new ItemInfo(20240), new ItemInfo(20241), new ItemInfo(20242), 
            new ItemInfo(20243), new ItemInfo(20244), new ItemInfo(20245), new ItemInfo(20246), new ItemInfo(20247), new ItemInfo(20248), new ItemInfo(20249), new ItemInfo(20250), 
            new ItemInfo(20251), new ItemInfo(20252), new ItemInfo(20253), new ItemInfo(20254), new ItemInfo(20255), new ItemInfo(20256), new ItemInfo(20257), new ItemInfo(20258), 
            new ItemInfo(20259), new ItemInfo(20260), new ItemInfo(20261), new ItemInfo(20262), new ItemInfo(20263), new ItemInfo(20264), new ItemInfo(20265), new ItemInfo(20266), 
            new ItemInfo(20267), new ItemInfo(20268), new ItemInfo(20269), new ItemInfo(20270), new ItemInfo(20271), new ItemInfo(20272), new ItemInfo(20273), new ItemInfo(20274), 
            new ItemInfo(20275), new ItemInfo(20276), new ItemInfo(20277), new ItemInfo(20278), new ItemInfo(20279), new ItemInfo(20280), new ItemInfo(20281), new ItemInfo(20282), 
            new ItemInfo(20283), new ItemInfo(20284), new ItemInfo(20285), new ItemInfo(20286), new ItemInfo(20287), new ItemInfo(20289), new ItemInfo(20290), new ItemInfo(20291), 
            new ItemInfo(20292), new ItemInfo(20293), new ItemInfo(20294), new ItemInfo(20295), new ItemInfo(20298), new ItemInfo(20299), new ItemInfo(20300), new ItemInfo(20301), 
            new ItemInfo(20302), new ItemInfo(20303), new ItemInfo(20307), new ItemInfo(20308), new ItemInfo(20309), new ItemInfo(20310), new ItemInfo(20311)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddRoofPt4Gump()
			: this(0)
		{ }

		public AddRoofPt4Gump(int page) 
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

			from.SendGump(new AddRoofPt4Gump(page));
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
