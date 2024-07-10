using Server.Network;

namespace Server.Gumps
{
	public class AddFloorPt2Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFloorPt2", AccessLevel.GameMaster, new CommandEventHandler(AddFloorPt2_OnCommand));
		}

		[Usage("AddFloorPt2")]
		
		public static void AddFloorPt2_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFloorPt2Gump>();
			e.Mobile.SendGump(new AddFloorPt2Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(1338), new ItemInfo(1364), new ItemInfo(1365), new ItemInfo(1366), new ItemInfo(1367), new ItemInfo(1368), new ItemInfo(1369), new ItemInfo(1370), 
            new ItemInfo(1371), new ItemInfo(1372), new ItemInfo(1373), new ItemInfo(1374), new ItemInfo(1375), new ItemInfo(1376), new ItemInfo(1377), new ItemInfo(1378), 
            new ItemInfo(1379), new ItemInfo(1380), new ItemInfo(1381), new ItemInfo(1382), new ItemInfo(1383), new ItemInfo(1384), new ItemInfo(1385), new ItemInfo(1387), 
            new ItemInfo(1388), new ItemInfo(1389), new ItemInfo(1390), new ItemInfo(1391), new ItemInfo(1392), new ItemInfo(1393), new ItemInfo(1394), new ItemInfo(1395), 
            new ItemInfo(1396), new ItemInfo(1397), new ItemInfo(1398), new ItemInfo(1399), new ItemInfo(1400), new ItemInfo(1401), new ItemInfo(1402), new ItemInfo(1403), 
            new ItemInfo(1404), new ItemInfo(1405), new ItemInfo(1406), new ItemInfo(1407), new ItemInfo(1408), new ItemInfo(1409), new ItemInfo(1410), new ItemInfo(1411), 
            new ItemInfo(1412), new ItemInfo(1413), new ItemInfo(1579), new ItemInfo(1580), new ItemInfo(1581), new ItemInfo(1582), new ItemInfo(1583), new ItemInfo(1584), 
            new ItemInfo(1585), new ItemInfo(1586), new ItemInfo(1591), new ItemInfo(1592), new ItemInfo(1593), new ItemInfo(1594), new ItemInfo(1595), new ItemInfo(1596), 
            new ItemInfo(1597), new ItemInfo(1598), new ItemInfo(1993), new ItemInfo(1994), new ItemInfo(1995), new ItemInfo(1996), new ItemInfo(1997), new ItemInfo(1998), 
			new ItemInfo(1999), new ItemInfo(2000), new ItemInfo(9253), new ItemInfo(9254), new ItemInfo(9255), new ItemInfo(9256), new ItemInfo(9257), new ItemInfo(9258), 
            new ItemInfo(9259), new ItemInfo(9260), new ItemInfo(9261), new ItemInfo(9262), new ItemInfo(9263), new ItemInfo(9264), new ItemInfo(9265), new ItemInfo(9266), 
            new ItemInfo(9267), new ItemInfo(9268), new ItemInfo(9269), new ItemInfo(9270), new ItemInfo(9271), new ItemInfo(9272), new ItemInfo(9273), new ItemInfo(9274), 
            new ItemInfo(9275), new ItemInfo(9276), new ItemInfo(9277), new ItemInfo(9278), new ItemInfo(9279), new ItemInfo(9280), new ItemInfo(9281), new ItemInfo(9282), 
            new ItemInfo(9283), new ItemInfo(9284), new ItemInfo(9285), new ItemInfo(9286), new ItemInfo(9287), new ItemInfo(9288), new ItemInfo(9289), new ItemInfo(9290), 
            new ItemInfo(9291), new ItemInfo(9292), new ItemInfo(9293), new ItemInfo(9294), new ItemInfo(9295), new ItemInfo(9296), new ItemInfo(9297), new ItemInfo(9298), 
            new ItemInfo(10018), new ItemInfo(10019), new ItemInfo(10020), new ItemInfo(10021), new ItemInfo(10022), new ItemInfo(10023), new ItemInfo(10024), new ItemInfo(10025), 
            new ItemInfo(10026), new ItemInfo(10027), new ItemInfo(10028), new ItemInfo(10029), new ItemInfo(10030), new ItemInfo(10031), new ItemInfo(10032), new ItemInfo(10033), 
            new ItemInfo(10034), new ItemInfo(10035), new ItemInfo(10036), new ItemInfo(10037), new ItemInfo(10038), new ItemInfo(10039), new ItemInfo(10040), new ItemInfo(10041), 
            new ItemInfo(10042), new ItemInfo(10043), new ItemInfo(10044), new ItemInfo(10045), new ItemInfo(10046), new ItemInfo(10047), new ItemInfo(10048), new ItemInfo(10049), 
            new ItemInfo(10050), new ItemInfo(10051), new ItemInfo(10052), new ItemInfo(10053), new ItemInfo(10054), new ItemInfo(10055), new ItemInfo(10056), new ItemInfo(10057), 
            new ItemInfo(10058), new ItemInfo(10059), new ItemInfo(10060), new ItemInfo(10061), new ItemInfo(10062), new ItemInfo(10063), new ItemInfo(10064), new ItemInfo(10065), 
            new ItemInfo(10350), new ItemInfo(10351), new ItemInfo(10352), new ItemInfo(10353), new ItemInfo(10354), new ItemInfo(10355), new ItemInfo(10356), new ItemInfo(10357), 
            new ItemInfo(10358), new ItemInfo(10359), new ItemInfo(10360), new ItemInfo(10361), new ItemInfo(10362), new ItemInfo(10363), new ItemInfo(10364), new ItemInfo(10365), 
            new ItemInfo(10366), new ItemInfo(10367), new ItemInfo(10368), new ItemInfo(10369), new ItemInfo(10370), new ItemInfo(10371), new ItemInfo(10372), new ItemInfo(10373)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFloorPt2Gump()
			: this(0)
		{ }

		public AddFloorPt2Gump(int page) 
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

			from.SendGump(new AddFloorPt2Gump(page));
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
