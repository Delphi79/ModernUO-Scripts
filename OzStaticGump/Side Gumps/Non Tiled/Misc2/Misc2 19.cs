using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt19Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt19", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt19_OnCommand));
		}

		[Usage("AddMisc2Pt19")]
		
		public static void AddMisc2Pt19_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt19Gump>();
			e.Mobile.SendGump(new AddMisc2Pt19Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(19441), new ItemInfo(19442), new ItemInfo(19443), new ItemInfo(19444), new ItemInfo(19445), new ItemInfo(19446), new ItemInfo(19447), new ItemInfo(19448), new ItemInfo(19449), 
            new ItemInfo(19450), new ItemInfo(19451), new ItemInfo(19452), new ItemInfo(19453), new ItemInfo(19454), new ItemInfo(19455), new ItemInfo(19456), new ItemInfo(19457), new ItemInfo(19461), 
            new ItemInfo(19462), new ItemInfo(19467), new ItemInfo(19480), new ItemInfo(19481), new ItemInfo(19482), new ItemInfo(19483), new ItemInfo(19484), new ItemInfo(19485), new ItemInfo(19486), 
            new ItemInfo(19487), new ItemInfo(19488), new ItemInfo(19489), new ItemInfo(19490), new ItemInfo(19491), new ItemInfo(19597), new ItemInfo(19598), new ItemInfo(19599), new ItemInfo(19650), 
            new ItemInfo(19651), new ItemInfo(19686), new ItemInfo(19687), new ItemInfo(19688), new ItemInfo(19689), new ItemInfo(19690), new ItemInfo(19691), new ItemInfo(19692), new ItemInfo(19693), 
            new ItemInfo(19737), new ItemInfo(19738), new ItemInfo(19739), new ItemInfo(19740), new ItemInfo(19741), new ItemInfo(19742), new ItemInfo(19743), new ItemInfo(19744), new ItemInfo(19745), 
            new ItemInfo(19746), new ItemInfo(19747), new ItemInfo(19748), new ItemInfo(19749), new ItemInfo(19750), new ItemInfo(19751), new ItemInfo(19752), new ItemInfo(19753), new ItemInfo(19936), 
            new ItemInfo(19937), new ItemInfo(20326), new ItemInfo(20327), new ItemInfo(20352), new ItemInfo(20353), new ItemInfo(20354), new ItemInfo(20355), new ItemInfo(20356), new ItemInfo(20357), 
            new ItemInfo(20358), new ItemInfo(20359), new ItemInfo(20360), new ItemInfo(20361), new ItemInfo(20362), new ItemInfo(20363), new ItemInfo(20364), new ItemInfo(20365), new ItemInfo(20366), 
            new ItemInfo(20367), new ItemInfo(20368), new ItemInfo(20369), new ItemInfo(20370), new ItemInfo(20371), new ItemInfo(20372), new ItemInfo(20373), new ItemInfo(20374), new ItemInfo(20375), 
            new ItemInfo(20376), new ItemInfo(20377), new ItemInfo(20378), new ItemInfo(20379), new ItemInfo(20380), new ItemInfo(20381), new ItemInfo(20382), new ItemInfo(20383), new ItemInfo(20384), 
            new ItemInfo(20385), new ItemInfo(20386), new ItemInfo(20387), new ItemInfo(20388), new ItemInfo(20389), new ItemInfo(20390), new ItemInfo(20391), new ItemInfo(20392), new ItemInfo(20393), 
            new ItemInfo(20394), new ItemInfo(20395), new ItemInfo(20396), new ItemInfo(20397), new ItemInfo(20398), new ItemInfo(20399), new ItemInfo(20400), new ItemInfo(20401), new ItemInfo(20402), 
            new ItemInfo(20403), new ItemInfo(20404), new ItemInfo(20405), new ItemInfo(20406), new ItemInfo(20407), new ItemInfo(20408), new ItemInfo(20409), new ItemInfo(20410), new ItemInfo(20411), 
            new ItemInfo(20480), new ItemInfo(20481), new ItemInfo(20482), new ItemInfo(20483), new ItemInfo(20484), new ItemInfo(20485), new ItemInfo(20486), new ItemInfo(20487), new ItemInfo(20488), 
            new ItemInfo(20489), new ItemInfo(20490), new ItemInfo(20491), new ItemInfo(20492), new ItemInfo(20493), new ItemInfo(20494), new ItemInfo(20495), new ItemInfo(20496), new ItemInfo(20497), 
            new ItemInfo(20498), new ItemInfo(20499), new ItemInfo(20500), new ItemInfo(20501), new ItemInfo(20502), new ItemInfo(20503), new ItemInfo(20504), new ItemInfo(20505), new ItemInfo(20506), 
            new ItemInfo(20507), new ItemInfo(20508), new ItemInfo(20509), new ItemInfo(20510), new ItemInfo(20511), new ItemInfo(20512), new ItemInfo(20513), new ItemInfo(20514), new ItemInfo(20515), 
            new ItemInfo(20516), new ItemInfo(20517), new ItemInfo(20518), new ItemInfo(20519), new ItemInfo(20520), new ItemInfo(20521), new ItemInfo(20522), new ItemInfo(20523), new ItemInfo(20524), 
            new ItemInfo(20525), new ItemInfo(20526), new ItemInfo(20527), new ItemInfo(20528), new ItemInfo(20529), new ItemInfo(20530), new ItemInfo(20531), new ItemInfo(20532), new ItemInfo(20533), 
            new ItemInfo(20534), new ItemInfo(20535), new ItemInfo(20536), new ItemInfo(20537), new ItemInfo(20538), new ItemInfo(20539), new ItemInfo(20540), new ItemInfo(20541), new ItemInfo(20542), 
            new ItemInfo(20543), new ItemInfo(20544), new ItemInfo(20545), new ItemInfo(20546), new ItemInfo(20547), new ItemInfo(20548), new ItemInfo(20549), new ItemInfo(20550), new ItemInfo(20551), 
            new ItemInfo(20552), new ItemInfo(20553), new ItemInfo(20554), new ItemInfo(20555), new ItemInfo(20556), new ItemInfo(20557), new ItemInfo(20558), new ItemInfo(20559), new ItemInfo(20560), 
            new ItemInfo(20561), new ItemInfo(20562), new ItemInfo(20563), new ItemInfo(20564), new ItemInfo(20565), new ItemInfo(20566), new ItemInfo(20567), new ItemInfo(20568), new ItemInfo(20569), 
            new ItemInfo(20570), new ItemInfo(20571), new ItemInfo(20572), new ItemInfo(20573), new ItemInfo(20574), new ItemInfo(20575), new ItemInfo(20576), new ItemInfo(20577), new ItemInfo(20578), 
            new ItemInfo(20579), new ItemInfo(20580), new ItemInfo(20581), new ItemInfo(20582), new ItemInfo(20583), new ItemInfo(20584), new ItemInfo(20585), new ItemInfo(20586), new ItemInfo(20587), 
            new ItemInfo(20588), new ItemInfo(20589), new ItemInfo(20590), new ItemInfo(20591), new ItemInfo(20592), new ItemInfo(20593), new ItemInfo(20594), new ItemInfo(20595), new ItemInfo(20596), 
            new ItemInfo(20597), new ItemInfo(20598), new ItemInfo(20599), new ItemInfo(20600), new ItemInfo(20601), new ItemInfo(20602), new ItemInfo(20603), new ItemInfo(20604), new ItemInfo(20605), 
            new ItemInfo(20606), new ItemInfo(20607), new ItemInfo(20608), new ItemInfo(20609), new ItemInfo(20610), new ItemInfo(20611), new ItemInfo(20612), new ItemInfo(20613), new ItemInfo(20614), 
            new ItemInfo(20615), new ItemInfo(20616), new ItemInfo(20617), new ItemInfo(20618), new ItemInfo(20619), new ItemInfo(20620), new ItemInfo(20621), new ItemInfo(20622), new ItemInfo(20623), 
            new ItemInfo(20624), new ItemInfo(20625), new ItemInfo(20626), new ItemInfo(20627), new ItemInfo(20628), new ItemInfo(20629), new ItemInfo(20630), new ItemInfo(20631), new ItemInfo(20632), 
            new ItemInfo(20633), new ItemInfo(20634), new ItemInfo(20635), new ItemInfo(20636), new ItemInfo(20637), new ItemInfo(20638), new ItemInfo(20639), new ItemInfo(20640), new ItemInfo(20641), 
            new ItemInfo(20642), new ItemInfo(20643), new ItemInfo(20644), new ItemInfo(20645), new ItemInfo(20646), new ItemInfo(20647), new ItemInfo(20648), new ItemInfo(20649), new ItemInfo(20650), 
            new ItemInfo(20651), new ItemInfo(20652), new ItemInfo(20653), new ItemInfo(20654), new ItemInfo(20655), new ItemInfo(20656), new ItemInfo(20657), new ItemInfo(20658), new ItemInfo(20659), 
            new ItemInfo(20660), new ItemInfo(20661), new ItemInfo(20662), new ItemInfo(20663), new ItemInfo(20664), new ItemInfo(20665), new ItemInfo(20666), new ItemInfo(20667), new ItemInfo(20668), 
            new ItemInfo(20669), new ItemInfo(20670), new ItemInfo(20671), new ItemInfo(20672), new ItemInfo(20673), new ItemInfo(20674), new ItemInfo(20675), new ItemInfo(20676), new ItemInfo(20677), 
            new ItemInfo(20678), new ItemInfo(20679), new ItemInfo(20680), new ItemInfo(20681), new ItemInfo(20682), new ItemInfo(20683), new ItemInfo(20684), new ItemInfo(20685), new ItemInfo(20686), 
            new ItemInfo(20687), new ItemInfo(20688), new ItemInfo(20689), new ItemInfo(20690), new ItemInfo(20691), new ItemInfo(20692), new ItemInfo(20693), new ItemInfo(20694), new ItemInfo(20695), 
            new ItemInfo(22000), new ItemInfo(22001), new ItemInfo(22002), new ItemInfo(22003), new ItemInfo(22004), new ItemInfo(22005), new ItemInfo(22006), new ItemInfo(22007), new ItemInfo(22008), 
            new ItemInfo(22009), new ItemInfo(22010), new ItemInfo(22011), new ItemInfo(22012), new ItemInfo(22013), new ItemInfo(22014), new ItemInfo(22015), new ItemInfo(22016), new ItemInfo(22017)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt19Gump()
			: this(0)
		{ }

		public AddMisc2Pt19Gump(int page) 
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

			from.SendGump(new AddMisc2Pt19Gump(page));
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
