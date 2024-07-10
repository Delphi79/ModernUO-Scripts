using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt20Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt20", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt20_OnCommand));
		}

		[Usage("AddCustomPt20")]
		
		public static void AddCustomPt20_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt20Gump>();
			e.Mobile.SendGump(new AddCustomPt20Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
           	new ItemInfo(43189), new ItemInfo(43190), new ItemInfo(43191), new ItemInfo(43192), new ItemInfo(43193), new ItemInfo(43194), new ItemInfo(43195), new ItemInfo(43196), new ItemInfo(43197), 
			new ItemInfo(43198), new ItemInfo(43199), new ItemInfo(43200), new ItemInfo(43201), new ItemInfo(43202), new ItemInfo(43203), new ItemInfo(43204), new ItemInfo(43205), new ItemInfo(43206), 
			new ItemInfo(43207), new ItemInfo(43208), new ItemInfo(43209), new ItemInfo(43210), new ItemInfo(43211), new ItemInfo(43212), new ItemInfo(43213), new ItemInfo(43214), new ItemInfo(43215), 
			new ItemInfo(43216), new ItemInfo(43217), new ItemInfo(43218), new ItemInfo(43219), new ItemInfo(43220), new ItemInfo(43221), new ItemInfo(43222), new ItemInfo(43223), new ItemInfo(43224), 
			new ItemInfo(43225), new ItemInfo(43226), new ItemInfo(43227), new ItemInfo(43228), new ItemInfo(43229), new ItemInfo(43230), new ItemInfo(43231), new ItemInfo(43232), new ItemInfo(43233), 
			new ItemInfo(43234), new ItemInfo(43235), new ItemInfo(43236), new ItemInfo(43237), new ItemInfo(43238), new ItemInfo(43239), new ItemInfo(43240), new ItemInfo(43241), new ItemInfo(43242), 
			new ItemInfo(43243), new ItemInfo(43244), new ItemInfo(43245), new ItemInfo(43246), new ItemInfo(43247), new ItemInfo(43248), new ItemInfo(43249), new ItemInfo(43250), new ItemInfo(43251), 
			new ItemInfo(43252), new ItemInfo(43253), new ItemInfo(43254), new ItemInfo(43255), new ItemInfo(43256), new ItemInfo(43257), new ItemInfo(43258), new ItemInfo(43259), new ItemInfo(43260), 
			new ItemInfo(43261), new ItemInfo(43262), new ItemInfo(43263), new ItemInfo(43264), new ItemInfo(43265), new ItemInfo(43267), new ItemInfo(43268), new ItemInfo(43269), new ItemInfo(43270), 
			new ItemInfo(43271), new ItemInfo(43272), new ItemInfo(43273), new ItemInfo(43274), new ItemInfo(43275), new ItemInfo(43276), new ItemInfo(43277), new ItemInfo(43278), new ItemInfo(43279), 
			new ItemInfo(43280), new ItemInfo(43281), new ItemInfo(43282), new ItemInfo(43283), new ItemInfo(43284), new ItemInfo(43285), new ItemInfo(43286), new ItemInfo(43287), new ItemInfo(43288), 
			new ItemInfo(43289), new ItemInfo(43290), new ItemInfo(43291), new ItemInfo(43292), new ItemInfo(43293), new ItemInfo(43294), new ItemInfo(43295), new ItemInfo(43296), new ItemInfo(43297), 
			new ItemInfo(43298), new ItemInfo(43300), new ItemInfo(43301), new ItemInfo(43302), new ItemInfo(43303), new ItemInfo(43304), new ItemInfo(43305), new ItemInfo(43306), new ItemInfo(43307), 
			new ItemInfo(43308), new ItemInfo(43309), new ItemInfo(43310), new ItemInfo(43311), new ItemInfo(43312), new ItemInfo(43313), new ItemInfo(43314), new ItemInfo(43315), new ItemInfo(43316), 
			new ItemInfo(43317), new ItemInfo(43318), new ItemInfo(43319), new ItemInfo(43320), new ItemInfo(43321), new ItemInfo(43322), new ItemInfo(43323), new ItemInfo(43324), new ItemInfo(43325), 
			new ItemInfo(43326), new ItemInfo(43327), new ItemInfo(43328), new ItemInfo(43329), new ItemInfo(43330), new ItemInfo(43331), new ItemInfo(43332), new ItemInfo(43333), new ItemInfo(43334), 
			new ItemInfo(43335), new ItemInfo(43336), new ItemInfo(43337), new ItemInfo(43338), new ItemInfo(43339), new ItemInfo(43340), new ItemInfo(43341), new ItemInfo(43342), new ItemInfo(43343), 
			new ItemInfo(43344), new ItemInfo(43345), new ItemInfo(43346), new ItemInfo(43347), new ItemInfo(43348), new ItemInfo(43349), new ItemInfo(43350), new ItemInfo(43351), new ItemInfo(43352), 
			new ItemInfo(43353), new ItemInfo(43354), new ItemInfo(43355), new ItemInfo(43356), new ItemInfo(43357), new ItemInfo(43358), new ItemInfo(43359), new ItemInfo(43360), new ItemInfo(43361), 
			new ItemInfo(43362), new ItemInfo(43363), new ItemInfo(43364), new ItemInfo(43365), new ItemInfo(43366), new ItemInfo(43367)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt20Gump()
			: this(0)
		{ }

		public AddCustomPt20Gump(int page) 
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

			from.SendGump(new AddCustomPt20Gump(page));
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
