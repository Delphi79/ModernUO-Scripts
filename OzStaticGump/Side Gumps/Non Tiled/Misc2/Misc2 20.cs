using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt20Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt20", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt20_OnCommand));
		}

		[Usage("AddMisc2Pt20")]
		
		public static void AddMisc2Pt20_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt20Gump>();
			e.Mobile.SendGump(new AddMisc2Pt20Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
                        new ItemInfo(22018), new ItemInfo(22019), new ItemInfo(22020), new ItemInfo(22021), new ItemInfo(22022), new ItemInfo(22023), new ItemInfo(22034), new ItemInfo(22035), new ItemInfo(22036), 
            new ItemInfo(22037), new ItemInfo(22038), new ItemInfo(22039), new ItemInfo(22040), new ItemInfo(22041), new ItemInfo(22042), new ItemInfo(22043), new ItemInfo(22044), new ItemInfo(22045), 
            new ItemInfo(22046), new ItemInfo(22047), new ItemInfo(22048), new ItemInfo(22049), new ItemInfo(22050), new ItemInfo(22051), new ItemInfo(22052), new ItemInfo(22053), new ItemInfo(22054), 
            new ItemInfo(22055), new ItemInfo(22056), new ItemInfo(22057), new ItemInfo(22058), new ItemInfo(22059), new ItemInfo(22060), new ItemInfo(22061), new ItemInfo(22071), new ItemInfo(22072), 
            new ItemInfo(22073), new ItemInfo(22074), new ItemInfo(22075), new ItemInfo(22076), new ItemInfo(22077), new ItemInfo(22078), new ItemInfo(22079), new ItemInfo(22080), new ItemInfo(22081), 
            new ItemInfo(22082), new ItemInfo(22083), new ItemInfo(22084), new ItemInfo(22085), new ItemInfo(22086), new ItemInfo(22087), new ItemInfo(22088), new ItemInfo(22089), new ItemInfo(22090), 
            new ItemInfo(22091), new ItemInfo(22092), new ItemInfo(22093), new ItemInfo(22094), new ItemInfo(22095), new ItemInfo(22096), new ItemInfo(22097), new ItemInfo(22098), new ItemInfo(22099), 
            new ItemInfo(22100), new ItemInfo(22101), new ItemInfo(22102), new ItemInfo(22103), new ItemInfo(22104), new ItemInfo(22105), new ItemInfo(22106), new ItemInfo(22107), new ItemInfo(22108), 
            new ItemInfo(22109), new ItemInfo(22110), new ItemInfo(22111), new ItemInfo(22112), new ItemInfo(22113), new ItemInfo(22114), new ItemInfo(22115), new ItemInfo(22116), new ItemInfo(22117), 
            new ItemInfo(22118), new ItemInfo(22119), new ItemInfo(22120), new ItemInfo(22121), new ItemInfo(22122), new ItemInfo(22123), new ItemInfo(22124), new ItemInfo(22125), new ItemInfo(22126), 
            new ItemInfo(22127), new ItemInfo(22128), new ItemInfo(22129), new ItemInfo(22130), new ItemInfo(22131), new ItemInfo(22132), new ItemInfo(22133), new ItemInfo(22134), new ItemInfo(22135), 
            new ItemInfo(22136), new ItemInfo(22137), new ItemInfo(22138), new ItemInfo(22139), new ItemInfo(22140), new ItemInfo(22141), new ItemInfo(22142), new ItemInfo(22143), new ItemInfo(22144), 
            new ItemInfo(22145), new ItemInfo(22146), new ItemInfo(22147), new ItemInfo(22148), new ItemInfo(22149), new ItemInfo(22150), new ItemInfo(22160), new ItemInfo(22200), new ItemInfo(22201), 
            new ItemInfo(22202), new ItemInfo(22203), new ItemInfo(22204), new ItemInfo(22205), new ItemInfo(22206), new ItemInfo(22207), new ItemInfo(22208), new ItemInfo(22209), new ItemInfo(22210), 
            new ItemInfo(22211), new ItemInfo(22212), new ItemInfo(22213), new ItemInfo(22214), new ItemInfo(22215), new ItemInfo(22216), new ItemInfo(22217), new ItemInfo(22218), new ItemInfo(22219), 
            new ItemInfo(22220), new ItemInfo(22221), new ItemInfo(22222), new ItemInfo(22223), new ItemInfo(22224), new ItemInfo(22225), new ItemInfo(22226), new ItemInfo(22227), new ItemInfo(22228), 
            new ItemInfo(22229), new ItemInfo(22230), new ItemInfo(22231), new ItemInfo(22232), new ItemInfo(22233), new ItemInfo(22234), new ItemInfo(22235), new ItemInfo(22236), new ItemInfo(22237), 
            new ItemInfo(22238), new ItemInfo(22239), new ItemInfo(22240), new ItemInfo(22241), new ItemInfo(22242), new ItemInfo(22243), new ItemInfo(22244), new ItemInfo(22245), new ItemInfo(22246), 
            new ItemInfo(22247), new ItemInfo(22248), new ItemInfo(22249), new ItemInfo(22250), new ItemInfo(22251), new ItemInfo(22252), new ItemInfo(22253), new ItemInfo(22254), new ItemInfo(22255), 
            new ItemInfo(22256), new ItemInfo(22257), new ItemInfo(22258), new ItemInfo(22259), new ItemInfo(22260), new ItemInfo(22300), new ItemInfo(22301), new ItemInfo(22302), new ItemInfo(22303), 
            new ItemInfo(22304), new ItemInfo(22305), new ItemInfo(22306), new ItemInfo(22307), new ItemInfo(22308), new ItemInfo(22309), new ItemInfo(22310), new ItemInfo(22311), new ItemInfo(22312), 
            new ItemInfo(22313), new ItemInfo(22314), new ItemInfo(22315), new ItemInfo(22316), new ItemInfo(22317), new ItemInfo(22318), new ItemInfo(22319), new ItemInfo(22320), new ItemInfo(22321), 
            new ItemInfo(22322), new ItemInfo(22323), new ItemInfo(22324), new ItemInfo(22325), new ItemInfo(22326), new ItemInfo(22327), new ItemInfo(22328), new ItemInfo(22329), new ItemInfo(22330), 
            new ItemInfo(22331), new ItemInfo(22332), new ItemInfo(22333), new ItemInfo(22334), new ItemInfo(22335), new ItemInfo(22336), new ItemInfo(22337), new ItemInfo(22338), new ItemInfo(22339), 
            new ItemInfo(22340), new ItemInfo(22341), new ItemInfo(22342), new ItemInfo(22343), new ItemInfo(22344), new ItemInfo(22345), new ItemInfo(22346), new ItemInfo(22347), new ItemInfo(22348), 
            new ItemInfo(22349), new ItemInfo(22350), new ItemInfo(22351), new ItemInfo(22352), new ItemInfo(25557), new ItemInfo(25558), new ItemInfo(25559), new ItemInfo(25560), new ItemInfo(25561), 
            new ItemInfo(25562), new ItemInfo(25563), new ItemInfo(25564), new ItemInfo(25565), new ItemInfo(25566), new ItemInfo(25567), new ItemInfo(25568), new ItemInfo(25569), new ItemInfo(25570), 
            new ItemInfo(25571), new ItemInfo(25572), new ItemInfo(25573), new ItemInfo(25574), new ItemInfo(25575), new ItemInfo(25576), new ItemInfo(25577), new ItemInfo(25578), new ItemInfo(25579), 
            new ItemInfo(25580), new ItemInfo(25581), new ItemInfo(25582), new ItemInfo(25583), new ItemInfo(25584), new ItemInfo(25585), new ItemInfo(25586), new ItemInfo(25587), new ItemInfo(25588), 
            new ItemInfo(25589), new ItemInfo(25590), new ItemInfo(25591), new ItemInfo(25592), new ItemInfo(25593), new ItemInfo(27287), new ItemInfo(27288), new ItemInfo(27289), new ItemInfo(27290), 
            new ItemInfo(27291), new ItemInfo(27292), new ItemInfo(27293), new ItemInfo(27295), new ItemInfo(27296), new ItemInfo(27297), new ItemInfo(27298), new ItemInfo(27300), new ItemInfo(27301), 
            new ItemInfo(27302), new ItemInfo(27303), new ItemInfo(27304), new ItemInfo(27306), new ItemInfo(27307), new ItemInfo(27308), new ItemInfo(27309), new ItemInfo(30000), new ItemInfo(38940), 
            new ItemInfo(38941), new ItemInfo(38942), new ItemInfo(38943), new ItemInfo(38944), new ItemInfo(38945), new ItemInfo(38946), new ItemInfo(38947), new ItemInfo(38948), new ItemInfo(38949), 
            new ItemInfo(38950), new ItemInfo(38951), new ItemInfo(38952), new ItemInfo(38953), new ItemInfo(38954), new ItemInfo(38955), new ItemInfo(38956), new ItemInfo(38957), new ItemInfo(38958), 
            new ItemInfo(38959), new ItemInfo(38960), new ItemInfo(38961), new ItemInfo(38962), new ItemInfo(38963), new ItemInfo(38964), new ItemInfo(38965), new ItemInfo(38966), new ItemInfo(38967), 
            new ItemInfo(38968), new ItemInfo(38969), new ItemInfo(38970), new ItemInfo(38971), new ItemInfo(38972), new ItemInfo(38973), new ItemInfo(38974), new ItemInfo(38975), new ItemInfo(38976), 
            new ItemInfo(38977), new ItemInfo(38980), new ItemInfo(38981), new ItemInfo(38982), new ItemInfo(38983), new ItemInfo(38984), new ItemInfo(38985), new ItemInfo(38986), new ItemInfo(38987), 
            new ItemInfo(38988), new ItemInfo(38989), new ItemInfo(38990), new ItemInfo(38991), new ItemInfo(38992), new ItemInfo(38993), new ItemInfo(38994)

            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt20Gump()
			: this(0)
		{ }

		public AddMisc2Pt20Gump(int page) 
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

			from.SendGump(new AddMisc2Pt20Gump(page));
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
