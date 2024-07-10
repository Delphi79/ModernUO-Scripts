using Server.Network;

namespace Server.Gumps
{
	public class AddFloorPt1Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFloorPt1", AccessLevel.GameMaster, new CommandEventHandler(AddFloorPt1_OnCommand));
		}

		[Usage("AddFloorPt1")]
		
		public static void AddFloorPt1_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFloorPt1Gump>();
			e.Mobile.SendGump(new AddFloorPt1Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(1168), new ItemInfo(1169), new ItemInfo(1170), new ItemInfo(1171), new ItemInfo(1172), new ItemInfo(1173), new ItemInfo(1174), new ItemInfo(1175), 
            new ItemInfo(1176), new ItemInfo(1177), new ItemInfo(1178), new ItemInfo(1179), new ItemInfo(1180), new ItemInfo(1181), new ItemInfo(1182), new ItemInfo(1183), 
            new ItemInfo(1184), new ItemInfo(1185), new ItemInfo(1186), new ItemInfo(1187), new ItemInfo(1188), new ItemInfo(1189), new ItemInfo(1190), new ItemInfo(1191), 
            new ItemInfo(1192), new ItemInfo(1193), new ItemInfo(1194), new ItemInfo(1195), new ItemInfo(1196), new ItemInfo(1197), new ItemInfo(1198), new ItemInfo(1199), 
            new ItemInfo(1200), new ItemInfo(1201), new ItemInfo(1202), new ItemInfo(1203), new ItemInfo(1204), new ItemInfo(1205), new ItemInfo(1206), new ItemInfo(1207), 
            new ItemInfo(1208), new ItemInfo(1209), new ItemInfo(1210), new ItemInfo(1211), new ItemInfo(1212), new ItemInfo(1213), new ItemInfo(1214), new ItemInfo(1215), 
            new ItemInfo(1216), new ItemInfo(1217), new ItemInfo(1218), new ItemInfo(1219), new ItemInfo(1220), new ItemInfo(1221), new ItemInfo(1222), new ItemInfo(1223), 
            new ItemInfo(1224), new ItemInfo(1225), new ItemInfo(1226), new ItemInfo(1227), new ItemInfo(1228), new ItemInfo(1229), new ItemInfo(1230), new ItemInfo(1231), 
            new ItemInfo(1232), new ItemInfo(1233), new ItemInfo(1234), new ItemInfo(1235), new ItemInfo(1236), new ItemInfo(1237), new ItemInfo(1238), new ItemInfo(1239), 
            new ItemInfo(1240), new ItemInfo(1241), new ItemInfo(1242), new ItemInfo(1243), new ItemInfo(1244), new ItemInfo(1245), new ItemInfo(1246), new ItemInfo(1247), 
            new ItemInfo(1248), new ItemInfo(1249), new ItemInfo(1250), new ItemInfo(1251), new ItemInfo(1252), new ItemInfo(1253), new ItemInfo(1254), new ItemInfo(1255), 
            new ItemInfo(1256), new ItemInfo(1257), new ItemInfo(1258), new ItemInfo(1259), new ItemInfo(1260), new ItemInfo(1261), new ItemInfo(1262), new ItemInfo(1263), 
            new ItemInfo(1264), new ItemInfo(1265), new ItemInfo(1266), new ItemInfo(1267), new ItemInfo(1268), new ItemInfo(1269), new ItemInfo(1270), new ItemInfo(1271), 
            new ItemInfo(1272), new ItemInfo(1273), new ItemInfo(1274), new ItemInfo(1275), new ItemInfo(1276), new ItemInfo(1277), new ItemInfo(1278), new ItemInfo(1279), 
            new ItemInfo(1280), new ItemInfo(1281), new ItemInfo(1282), new ItemInfo(1283), new ItemInfo(1284), new ItemInfo(1285), new ItemInfo(1286), new ItemInfo(1287), 
            new ItemInfo(1288), new ItemInfo(1289), new ItemInfo(1290), new ItemInfo(1291), new ItemInfo(1292), new ItemInfo(1293), new ItemInfo(1294), new ItemInfo(1295), 
            new ItemInfo(1296), new ItemInfo(1297), new ItemInfo(1298), new ItemInfo(1299), new ItemInfo(1300), new ItemInfo(1301), new ItemInfo(1302), new ItemInfo(1303), 
            new ItemInfo(1304), new ItemInfo(1305), new ItemInfo(1306), new ItemInfo(1307), new ItemInfo(1308), new ItemInfo(1309), new ItemInfo(1310), new ItemInfo(1311), 
            new ItemInfo(1312), new ItemInfo(1313), new ItemInfo(1314), new ItemInfo(1315), new ItemInfo(1316), new ItemInfo(1317), new ItemInfo(1318), new ItemInfo(1319), 
            new ItemInfo(1320), new ItemInfo(1321), new ItemInfo(1322), new ItemInfo(1323), new ItemInfo(1324), new ItemInfo(1327), new ItemInfo(1328), new ItemInfo(1329), 
            new ItemInfo(1330), new ItemInfo(1331), new ItemInfo(1332), new ItemInfo(1333), new ItemInfo(1334), new ItemInfo(1335), new ItemInfo(1336), new ItemInfo(1337)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFloorPt1Gump()
			: this(0)
		{ }

		public AddFloorPt1Gump(int page) 
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

			from.SendGump(new AddFloorPt1Gump(page));
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
