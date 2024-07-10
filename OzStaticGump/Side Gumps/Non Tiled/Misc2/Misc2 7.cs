using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt7Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt7", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt7_OnCommand));
		}

		[Usage("AddMisc2Pt7")]
		
		public static void AddMisc2Pt7_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt7Gump>();
			e.Mobile.SendGump(new AddMisc2Pt7Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(9744), new ItemInfo(9745), new ItemInfo(9746), new ItemInfo(9747), new ItemInfo(9748), new ItemInfo(9749), new ItemInfo(9750), new ItemInfo(9751), new ItemInfo(9752), 
            new ItemInfo(9753), new ItemInfo(9754), new ItemInfo(9755), new ItemInfo(9756), new ItemInfo(9757), new ItemInfo(9758), new ItemInfo(9759), new ItemInfo(9760), new ItemInfo(9761), 
            new ItemInfo(9762), new ItemInfo(9763), new ItemInfo(9764), new ItemInfo(9765), new ItemInfo(9766), new ItemInfo(9767), new ItemInfo(9768), new ItemInfo(9769), new ItemInfo(9770), 
            new ItemInfo(9771), new ItemInfo(9772), new ItemInfo(9773), new ItemInfo(9774), new ItemInfo(9775), new ItemInfo(9776), new ItemInfo(9777), new ItemInfo(9778), new ItemInfo(9779), 
            new ItemInfo(9780), new ItemInfo(9781), new ItemInfo(9782), new ItemInfo(9783), new ItemInfo(9784), new ItemInfo(9785), new ItemInfo(9786), new ItemInfo(9787), new ItemInfo(9788), 
            new ItemInfo(9789), new ItemInfo(9790), new ItemInfo(9791), new ItemInfo(9792), new ItemInfo(9911), new ItemInfo(9912), new ItemInfo(9913), new ItemInfo(9972), new ItemInfo(9973), 
            new ItemInfo(9974), new ItemInfo(9975),new ItemInfo(9997), new ItemInfo(9998), new ItemInfo(9999), new ItemInfo(10000), new ItemInfo(10001), new ItemInfo(10002), new ItemInfo(10003), 
            new ItemInfo(10004), new ItemInfo(10005), new ItemInfo(10016), new ItemInfo(10017), new ItemInfo(10066), new ItemInfo(10083), new ItemInfo(10084), new ItemInfo(10085), new ItemInfo(10086), 
            new ItemInfo(10087), new ItemInfo(10088), new ItemInfo(10089), new ItemInfo(10090), new ItemInfo(10091), new ItemInfo(10092), new ItemInfo(10093), new ItemInfo(10094), new ItemInfo(10095), 
            new ItemInfo(10096), new ItemInfo(10097), new ItemInfo(10098), new ItemInfo(10099), new ItemInfo(10267), new ItemInfo(10268), new ItemInfo(10269), new ItemInfo(10270), new ItemInfo(10271), 
            new ItemInfo(10272), new ItemInfo(10273), new ItemInfo(10274), new ItemInfo(10275), new ItemInfo(10276), new ItemInfo(10277), new ItemInfo(10278), new ItemInfo(10279), new ItemInfo(10280), 
            new ItemInfo(10281), new ItemInfo(10282), new ItemInfo(10283), new ItemInfo(10284), new ItemInfo(10285), new ItemInfo(10286), new ItemInfo(10287), new ItemInfo(10288), new ItemInfo(10289), 
            new ItemInfo(10290), new ItemInfo(10291), new ItemInfo(10292), new ItemInfo(10293), new ItemInfo(10294), new ItemInfo(10295), new ItemInfo(10296), new ItemInfo(10297), new ItemInfo(10298), 
            new ItemInfo(10299), new ItemInfo(10300), new ItemInfo(10301), new ItemInfo(10306), new ItemInfo(10307), new ItemInfo(10308), new ItemInfo(10309), new ItemInfo(10310), new ItemInfo(10311), 
            new ItemInfo(10312), new ItemInfo(10313), new ItemInfo(10314), new ItemInfo(10321), new ItemInfo(10322), new ItemInfo(10323), new ItemInfo(10324), new ItemInfo(10325), new ItemInfo(10326), 
            new ItemInfo(10374), new ItemInfo(10375), new ItemInfo(10460), new ItemInfo(10461), new ItemInfo(10462), new ItemInfo(10463), new ItemInfo(10464), new ItemInfo(10465), new ItemInfo(10466), 
            new ItemInfo(10467), new ItemInfo(10524), new ItemInfo(10525), new ItemInfo(10526), new ItemInfo(10527), new ItemInfo(10550), new ItemInfo(10551), new ItemInfo(10588), new ItemInfo(10589), 
            new ItemInfo(10590), new ItemInfo(10591), new ItemInfo(10749), new ItemInfo(10750), new ItemInfo(10751), new ItemInfo(10752), new ItemInfo(10753), new ItemInfo(10754), new ItemInfo(10755), 
            new ItemInfo(10756), new ItemInfo(10757), new ItemInfo(10758), new ItemInfo(10759), new ItemInfo(10760), new ItemInfo(10761), new ItemInfo(10762), new ItemInfo(10763), new ItemInfo(10764), 
            new ItemInfo(10765), new ItemInfo(10766), new ItemInfo(10767), new ItemInfo(10768), new ItemInfo(10769), new ItemInfo(10770), new ItemInfo(10771), new ItemInfo(10772), new ItemInfo(10773), 
            new ItemInfo(10774), new ItemInfo(10775), new ItemInfo(10776), new ItemInfo(10777), new ItemInfo(10778), new ItemInfo(10779), new ItemInfo(10780), new ItemInfo(10794), new ItemInfo(10795), 
            new ItemInfo(10796), new ItemInfo(10797), new ItemInfo(10798), new ItemInfo(10799), new ItemInfo(10821), new ItemInfo(10822), new ItemInfo(10823), new ItemInfo(10824), new ItemInfo(10825), 
            new ItemInfo(10826), new ItemInfo(10827), new ItemInfo(10828), new ItemInfo(10829), new ItemInfo(10830), new ItemInfo(10831), new ItemInfo(10832), new ItemInfo(10833), new ItemInfo(10834), 
            new ItemInfo(10835), new ItemInfo(10836), new ItemInfo(10837), new ItemInfo(10838), new ItemInfo(10839), new ItemInfo(10840), new ItemInfo(10841), new ItemInfo(10842), new ItemInfo(10843), 
            new ItemInfo(10844), new ItemInfo(10845), new ItemInfo(10846), new ItemInfo(10847), new ItemInfo(10848), new ItemInfo(10849), new ItemInfo(10850), new ItemInfo(10851), new ItemInfo(10852), 
            new ItemInfo(10853), new ItemInfo(10854), new ItemInfo(10855), new ItemInfo(10856), new ItemInfo(10857), new ItemInfo(10858), new ItemInfo(10859), new ItemInfo(10860), new ItemInfo(10861), 
            new ItemInfo(10862), new ItemInfo(10863), new ItemInfo(10864), new ItemInfo(10865), new ItemInfo(10866), new ItemInfo(10867), new ItemInfo(10868), new ItemInfo(10869), new ItemInfo(10870), 
            new ItemInfo(10871), new ItemInfo(10872), new ItemInfo(10873), new ItemInfo(10874), new ItemInfo(10875), new ItemInfo(10876), new ItemInfo(10877), new ItemInfo(10878), new ItemInfo(10879), 
            new ItemInfo(10880), new ItemInfo(10881), new ItemInfo(10882), new ItemInfo(10883), new ItemInfo(10884), new ItemInfo(10885), new ItemInfo(10886), new ItemInfo(10887), new ItemInfo(10888), 
            new ItemInfo(10889), new ItemInfo(10890), new ItemInfo(10891), new ItemInfo(10892), new ItemInfo(10893), new ItemInfo(10894), new ItemInfo(10895), new ItemInfo(10896), new ItemInfo(10897)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt7Gump()
			: this(0)
		{ }

		public AddMisc2Pt7Gump(int page) 
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

			from.SendGump(new AddMisc2Pt7Gump(page));
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
