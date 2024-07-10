using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt17Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt17", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt17_OnCommand));
		}

		[Usage("AddMiscPt17")]
		
		public static void AddMiscPt17_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt17Gump>();
			e.Mobile.SendGump(new AddMiscPt17Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(6977), new ItemInfo(6978), new ItemInfo(6979), new ItemInfo(6980), new ItemInfo(6981), new ItemInfo(6982), new ItemInfo(6983), new ItemInfo(6984), new ItemInfo(6985), 
            new ItemInfo(6986), new ItemInfo(6987), new ItemInfo(6988), new ItemInfo(6989), new ItemInfo(6990), new ItemInfo(6991), new ItemInfo(6992), new ItemInfo(6993), new ItemInfo(6994), 
            new ItemInfo(6995), new ItemInfo(6996), new ItemInfo(6997), new ItemInfo(6998), new ItemInfo(6999), new ItemInfo(7000), new ItemInfo(7001), new ItemInfo(7002), new ItemInfo(7003), 
            new ItemInfo(7004), new ItemInfo(7005), new ItemInfo(7006), new ItemInfo(7007), new ItemInfo(7008), new ItemInfo(7009), new ItemInfo(7010), new ItemInfo(7011), new ItemInfo(7012), 
            new ItemInfo(7013), new ItemInfo(7014), new ItemInfo(7015), new ItemInfo(7016), new ItemInfo(7017), new ItemInfo(7018), new ItemInfo(7019), new ItemInfo(7020), new ItemInfo(7021), 
            new ItemInfo(7022), new ItemInfo(7023), new ItemInfo(7024), new ItemInfo(7025), new ItemInfo(7036), new ItemInfo(7037), new ItemInfo(7039), new ItemInfo(7040), new ItemInfo(7041), 
            new ItemInfo(7042), new ItemInfo(7043), new ItemInfo(7044), new ItemInfo(7045), new ItemInfo(7046), new ItemInfo(7047), new ItemInfo(7048), new ItemInfo(7049), new ItemInfo(7050), 
            new ItemInfo(7051), new ItemInfo(7052), new ItemInfo(7053), new ItemInfo(7054), new ItemInfo(7055), new ItemInfo(7056), new ItemInfo(7057), new ItemInfo(7058), new ItemInfo(7059), 
            new ItemInfo(7060), new ItemInfo(7061), new ItemInfo(7062), new ItemInfo(7063), new ItemInfo(7064), new ItemInfo(7065), new ItemInfo(7066), new ItemInfo(7067), new ItemInfo(7068), 
            new ItemInfo(7069), new ItemInfo(7070), new ItemInfo(7071), new ItemInfo(7072), new ItemInfo(7073), new ItemInfo(7074), new ItemInfo(7075), new ItemInfo(7076), new ItemInfo(7077), 
            new ItemInfo(7078), new ItemInfo(7079), new ItemInfo(7080), new ItemInfo(7081), new ItemInfo(7082), new ItemInfo(7083), new ItemInfo(7084), new ItemInfo(7085), new ItemInfo(7086), 
            new ItemInfo(7087), new ItemInfo(7088), new ItemInfo(7089), new ItemInfo(7090), new ItemInfo(7091), new ItemInfo(7092), new ItemInfo(7093), new ItemInfo(7094), new ItemInfo(7095), 
            new ItemInfo(7096), new ItemInfo(7097), new ItemInfo(7098), new ItemInfo(7099), new ItemInfo(7100), new ItemInfo(7101), new ItemInfo(7102), new ItemInfo(7103), new ItemInfo(7104), 
            new ItemInfo(7105), new ItemInfo(7106), new ItemInfo(7112), new ItemInfo(7113), new ItemInfo(7114), new ItemInfo(7115), new ItemInfo(7116), new ItemInfo(7117), new ItemInfo(7118), 
            new ItemInfo(7119), new ItemInfo(7120), new ItemInfo(7121), new ItemInfo(7122), new ItemInfo(7123), new ItemInfo(7124), new ItemInfo(7125), new ItemInfo(7126), new ItemInfo(7127), 
            new ItemInfo(7128), new ItemInfo(7129), new ItemInfo(7130), new ItemInfo(7131), new ItemInfo(7132), new ItemInfo(7133), new ItemInfo(7134), new ItemInfo(7135), new ItemInfo(7136), 
            new ItemInfo(7137), new ItemInfo(7138), new ItemInfo(7139), new ItemInfo(7140), new ItemInfo(7141), new ItemInfo(7142), new ItemInfo(7143), new ItemInfo(7144), new ItemInfo(7145), 
            new ItemInfo(7146), new ItemInfo(7147), new ItemInfo(7148), new ItemInfo(7149), new ItemInfo(7150), new ItemInfo(7151), new ItemInfo(7152), new ItemInfo(7153), new ItemInfo(7154), 
            new ItemInfo(7155), new ItemInfo(7156), new ItemInfo(7157), new ItemInfo(7158), new ItemInfo(7159), new ItemInfo(7160), new ItemInfo(7161), new ItemInfo(7162), new ItemInfo(7163), 
            new ItemInfo(7164), new ItemInfo(7165), new ItemInfo(7166), new ItemInfo(7167), new ItemInfo(7182), new ItemInfo(7183), new ItemInfo(7184), new ItemInfo(7185), new ItemInfo(7186), 
            new ItemInfo(7187), new ItemInfo(7188), new ItemInfo(7189), new ItemInfo(7190), new ItemInfo(7191), new ItemInfo(7192), new ItemInfo(7193), new ItemInfo(7194), new ItemInfo(7195), 
            new ItemInfo(7196), new ItemInfo(7197), new ItemInfo(7198), new ItemInfo(7199), new ItemInfo(7200), new ItemInfo(7201), new ItemInfo(7202), new ItemInfo(7203), new ItemInfo(7204), 
            new ItemInfo(7205), new ItemInfo(7206), new ItemInfo(7207), new ItemInfo(7208), new ItemInfo(7209), new ItemInfo(7210), new ItemInfo(7211), new ItemInfo(7212), new ItemInfo(7213), 
            new ItemInfo(7214), new ItemInfo(7215), new ItemInfo(7216), new ItemInfo(7217), new ItemInfo(7218), new ItemInfo(7219), new ItemInfo(7220), new ItemInfo(7221), new ItemInfo(7222), 
            new ItemInfo(7223), new ItemInfo(7224), new ItemInfo(7225), new ItemInfo(7226), new ItemInfo(7227), new ItemInfo(7228), new ItemInfo(7229), new ItemInfo(7230), new ItemInfo(7231)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt17Gump()
			: this(0)
		{ }

		public AddMiscPt17Gump(int page) 
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

			from.SendGump(new AddMiscPt17Gump(page));
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
