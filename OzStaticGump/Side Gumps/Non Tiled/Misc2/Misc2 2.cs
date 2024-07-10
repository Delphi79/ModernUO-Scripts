using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt2Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt2", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt2_OnCommand));
		}

		[Usage("AddMisc2Pt2")]
		
		public static void AddMisc2Pt2_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt2Gump>();
			e.Mobile.SendGump(new AddMisc2Pt2Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(8241), new ItemInfo(8242), new ItemInfo(8243), new ItemInfo(8244), new ItemInfo(8245), new ItemInfo(8246), new ItemInfo(8247), new ItemInfo(8248), new ItemInfo(8249), 
            new ItemInfo(8250), new ItemInfo(8251), new ItemInfo(8252), new ItemInfo(8253), new ItemInfo(8254), new ItemInfo(8255), new ItemInfo(8256), new ItemInfo(8257), new ItemInfo(8258), 
            new ItemInfo(8259), new ItemInfo(8260), new ItemInfo(8261), new ItemInfo(8262), new ItemInfo(8263), new ItemInfo(8264), new ItemInfo(8265), new ItemInfo(8266), new ItemInfo(8267), 
            new ItemInfo(8268), new ItemInfo(8269), new ItemInfo(8270), new ItemInfo(8271), new ItemInfo(8272), new ItemInfo(8273), new ItemInfo(8274), new ItemInfo(8275), new ItemInfo(8276), 
            new ItemInfo(8277), new ItemInfo(8278), new ItemInfo(8279), new ItemInfo(8280), new ItemInfo(8281), new ItemInfo(8282), new ItemInfo(8283), new ItemInfo(8284), new ItemInfo(8285), 
            new ItemInfo(8286), new ItemInfo(8287), new ItemInfo(8288), new ItemInfo(8289), new ItemInfo(8290), new ItemInfo(8291), new ItemInfo(8292), new ItemInfo(8293), new ItemInfo(8294), 
            new ItemInfo(8295), new ItemInfo(8296), new ItemInfo(8297), new ItemInfo(8298), new ItemInfo(8299), new ItemInfo(8300), new ItemInfo(8301), new ItemInfo(8302), new ItemInfo(8303), 
            new ItemInfo(8304), new ItemInfo(8305), new ItemInfo(8306), new ItemInfo(8307), new ItemInfo(8308), new ItemInfo(8309), new ItemInfo(8310), new ItemInfo(8311), new ItemInfo(8312), 
            new ItemInfo(8313), new ItemInfo(8314), new ItemInfo(8315), new ItemInfo(8316), new ItemInfo(8317), new ItemInfo(8318), new ItemInfo(8319), new ItemInfo(8320), new ItemInfo(8321), 
            new ItemInfo(8322), new ItemInfo(8323), new ItemInfo(8324), new ItemInfo(8325), new ItemInfo(8326), new ItemInfo(8327), new ItemInfo(8328), new ItemInfo(8329), new ItemInfo(8330), 
            new ItemInfo(8331), new ItemInfo(8332), new ItemInfo(8333), new ItemInfo(8334), new ItemInfo(8335), new ItemInfo(8336), new ItemInfo(8337), new ItemInfo(8338), new ItemInfo(8339), 
            new ItemInfo(8340), new ItemInfo(8341), new ItemInfo(8342), new ItemInfo(8343), new ItemInfo(8344), new ItemInfo(8345), new ItemInfo(8346), new ItemInfo(8347), new ItemInfo(8348), 
            new ItemInfo(8349), new ItemInfo(8350), new ItemInfo(8351), new ItemInfo(8352), new ItemInfo(8353), new ItemInfo(8354), new ItemInfo(8355), new ItemInfo(8356), new ItemInfo(8357), 
            new ItemInfo(8358), new ItemInfo(8359), new ItemInfo(8360), new ItemInfo(8361), new ItemInfo(8362), new ItemInfo(8363), new ItemInfo(8364), new ItemInfo(8365), new ItemInfo(8366), 
            new ItemInfo(8367), new ItemInfo(8368), new ItemInfo(8369), new ItemInfo(8370), new ItemInfo(8371), new ItemInfo(8372), new ItemInfo(8373), new ItemInfo(8374), new ItemInfo(8375), 
            new ItemInfo(8376), new ItemInfo(8377), new ItemInfo(8378), new ItemInfo(8379), new ItemInfo(8380), new ItemInfo(8381), new ItemInfo(8382), new ItemInfo(8383), new ItemInfo(8384), 
            new ItemInfo(8385), new ItemInfo(8386), new ItemInfo(8387), new ItemInfo(8388), new ItemInfo(8389), new ItemInfo(8390), new ItemInfo(8391), new ItemInfo(8392), new ItemInfo(8393), 
            new ItemInfo(8394), new ItemInfo(8395), new ItemInfo(8396), new ItemInfo(8397), new ItemInfo(8398), new ItemInfo(8399), new ItemInfo(8400), new ItemInfo(8401), new ItemInfo(8402), 
            new ItemInfo(8403), new ItemInfo(8404), new ItemInfo(8405), new ItemInfo(8406), new ItemInfo(8407), new ItemInfo(8408), new ItemInfo(8409), new ItemInfo(8410), new ItemInfo(8411), 
            new ItemInfo(8412), new ItemInfo(8413), new ItemInfo(8414), new ItemInfo(8415), new ItemInfo(8416), new ItemInfo(8417), new ItemInfo(8418), new ItemInfo(8419), new ItemInfo(8420), 
            new ItemInfo(8421), new ItemInfo(8422), new ItemInfo(8423), new ItemInfo(8424), new ItemInfo(8425), new ItemInfo(8426), new ItemInfo(8427), new ItemInfo(8428), new ItemInfo(8429), 
            new ItemInfo(8430), new ItemInfo(8431), new ItemInfo(8432), new ItemInfo(8433), new ItemInfo(8434), new ItemInfo(8435), new ItemInfo(8436), new ItemInfo(8437), new ItemInfo(8438), 
            new ItemInfo(8439), new ItemInfo(8440), new ItemInfo(8441), new ItemInfo(8442), new ItemInfo(8443), new ItemInfo(8444), new ItemInfo(8445), new ItemInfo(8446), new ItemInfo(8447), 
            new ItemInfo(8448), new ItemInfo(8449), new ItemInfo(8450), new ItemInfo(8451), new ItemInfo(8452), new ItemInfo(8453), new ItemInfo(8454), new ItemInfo(8455), new ItemInfo(8456), 
            new ItemInfo(8457), new ItemInfo(8458), new ItemInfo(8459), new ItemInfo(8460), new ItemInfo(8461), new ItemInfo(8462), new ItemInfo(8463), new ItemInfo(8464), new ItemInfo(8465)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt2Gump()
			: this(0)
		{ }

		public AddMisc2Pt2Gump(int page) 
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

			from.SendGump(new AddMisc2Pt2Gump(page));
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
