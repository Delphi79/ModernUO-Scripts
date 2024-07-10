using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt1Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt1", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt1_OnCommand));
		}

		[Usage("AddMisc2Pt1")]
		
		public static void AddMisc2Pt1_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt1Gump>();
			e.Mobile.SendGump(new AddMisc2Pt1Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(8008), new ItemInfo(8009), new ItemInfo(8010), new ItemInfo(8011), new ItemInfo(8012), new ItemInfo(8013), new ItemInfo(8014), new ItemInfo(8015), new ItemInfo(8016), 
            new ItemInfo(8017), new ItemInfo(8018), new ItemInfo(8019), new ItemInfo(8020), new ItemInfo(8021), new ItemInfo(8022), new ItemInfo(8023), new ItemInfo(8024), new ItemInfo(8025), 
            new ItemInfo(8026), new ItemInfo(8027), new ItemInfo(8028), new ItemInfo(8029), new ItemInfo(8030), new ItemInfo(8031), new ItemInfo(8032), new ItemInfo(8033), new ItemInfo(8034), 
            new ItemInfo(8035), new ItemInfo(8036), new ItemInfo(8037), new ItemInfo(8038), new ItemInfo(8039), new ItemInfo(8040), new ItemInfo(8041), new ItemInfo(8042), new ItemInfo(8043), 
            new ItemInfo(8044), new ItemInfo(8045), new ItemInfo(8046), new ItemInfo(8047), new ItemInfo(8048), new ItemInfo(8049), new ItemInfo(8050), new ItemInfo(8051), new ItemInfo(8052), 
            new ItemInfo(8053), new ItemInfo(8054), new ItemInfo(8055), new ItemInfo(8056), new ItemInfo(8057), new ItemInfo(8058), new ItemInfo(8061), new ItemInfo(8062), new ItemInfo(8063), 
            new ItemInfo(8064), new ItemInfo(8065), new ItemInfo(8066), new ItemInfo(8067), new ItemInfo(8068), new ItemInfo(8069), new ItemInfo(8070), new ItemInfo(8071), new ItemInfo(8072), 
            new ItemInfo(8073), new ItemInfo(8074), new ItemInfo(8075), new ItemInfo(8076), new ItemInfo(8077), new ItemInfo(8078), new ItemInfo(8079), new ItemInfo(8080), new ItemInfo(8081), 
            new ItemInfo(8082), new ItemInfo(8083), new ItemInfo(8084), new ItemInfo(8085), new ItemInfo(8086), new ItemInfo(8087), new ItemInfo(8088), new ItemInfo(8089), new ItemInfo(8090), 
            new ItemInfo(8091), new ItemInfo(8092), new ItemInfo(8093), new ItemInfo(8094), new ItemInfo(8099), new ItemInfo(8100), new ItemInfo(8101), new ItemInfo(8102), new ItemInfo(8103), 
            new ItemInfo(8104), new ItemInfo(8105), new ItemInfo(8106), new ItemInfo(8107), new ItemInfo(8108), new ItemInfo(8109), new ItemInfo(8110), new ItemInfo(8111), new ItemInfo(8112), 
            new ItemInfo(8113), new ItemInfo(8114), new ItemInfo(8115), new ItemInfo(8116), new ItemInfo(8117), new ItemInfo(8118), new ItemInfo(8119), new ItemInfo(8120), new ItemInfo(8121), 
            new ItemInfo(8122), new ItemInfo(8123), new ItemInfo(8124), new ItemInfo(8125), new ItemInfo(8126), new ItemInfo(8127), new ItemInfo(8128), new ItemInfo(8129), new ItemInfo(8130), 
            new ItemInfo(8131), new ItemInfo(8132), new ItemInfo(8133), new ItemInfo(8134), new ItemInfo(8135), new ItemInfo(8136), new ItemInfo(8137), new ItemInfo(8138), new ItemInfo(8139), 
            new ItemInfo(8140), new ItemInfo(8141), new ItemInfo(8142), new ItemInfo(8143), new ItemInfo(8144), new ItemInfo(8145), new ItemInfo(8146), new ItemInfo(8147), new ItemInfo(8148), 
            new ItemInfo(8149), new ItemInfo(8150), new ItemInfo(8151), new ItemInfo(8152), new ItemInfo(8153), new ItemInfo(8154), new ItemInfo(8155), new ItemInfo(8156), new ItemInfo(8157), 
            new ItemInfo(8158), new ItemInfo(8159), new ItemInfo(8160), new ItemInfo(8161), new ItemInfo(8162), new ItemInfo(8163), new ItemInfo(8164), new ItemInfo(8165), new ItemInfo(8166), 
            new ItemInfo(8167), new ItemInfo(8168), new ItemInfo(8169), new ItemInfo(8170), new ItemInfo(8171), new ItemInfo(8172), new ItemInfo(8173), new ItemInfo(8174), new ItemInfo(8175), 
            new ItemInfo(8176), new ItemInfo(8177), new ItemInfo(8178), new ItemInfo(8179), new ItemInfo(8180), new ItemInfo(8181), new ItemInfo(8182), new ItemInfo(8183), new ItemInfo(8184), 
            new ItemInfo(8185), new ItemInfo(8186), new ItemInfo(8187), new ItemInfo(8188), new ItemInfo(8191), new ItemInfo(8192), new ItemInfo(8193), new ItemInfo(8194), new ItemInfo(8195), 
            new ItemInfo(8196), new ItemInfo(8197), new ItemInfo(8198), new ItemInfo(8199), new ItemInfo(8200), new ItemInfo(8201), new ItemInfo(8202), new ItemInfo(8203), new ItemInfo(8204), 
            new ItemInfo(8205), new ItemInfo(8206), new ItemInfo(8207), new ItemInfo(8208), new ItemInfo(8209), new ItemInfo(8210), new ItemInfo(8211), new ItemInfo(8212), new ItemInfo(8213), 
            new ItemInfo(8214), new ItemInfo(8215), new ItemInfo(8216), new ItemInfo(8217), new ItemInfo(8218), new ItemInfo(8219), new ItemInfo(8220), new ItemInfo(8221), new ItemInfo(8222), 
            new ItemInfo(8223), new ItemInfo(8224), new ItemInfo(8225), new ItemInfo(8226), new ItemInfo(8227), new ItemInfo(8228), new ItemInfo(8229), new ItemInfo(8230), new ItemInfo(8231), 
            new ItemInfo(8232), new ItemInfo(8233), new ItemInfo(8234), new ItemInfo(8235), new ItemInfo(8236), new ItemInfo(8237), new ItemInfo(8238), new ItemInfo(8239), new ItemInfo(8240)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt1Gump()
			: this(0)
		{ }

		public AddMisc2Pt1Gump(int page) 
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

			from.SendGump(new AddMisc2Pt1Gump(page));
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
