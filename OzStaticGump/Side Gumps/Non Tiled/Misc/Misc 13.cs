using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt13Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt13", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt13_OnCommand));
		}

		[Usage("AddMiscPt13")]
		
		public static void AddMiscPt13_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt13Gump>();
			e.Mobile.SendGump(new AddMiscPt13Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(5959), new ItemInfo(5960), new ItemInfo(5961), new ItemInfo(5962), new ItemInfo(5963), new ItemInfo(5964), new ItemInfo(5965), new ItemInfo(5966), new ItemInfo(5967), 
            new ItemInfo(5968), new ItemInfo(5969), new ItemInfo(5970), new ItemInfo(5971), new ItemInfo(5972), new ItemInfo(5973), new ItemInfo(5974), new ItemInfo(5975), new ItemInfo(5976), 
            new ItemInfo(5977), new ItemInfo(5978), new ItemInfo(5979), new ItemInfo(5980), new ItemInfo(5981), new ItemInfo(5982), new ItemInfo(5983), new ItemInfo(5984), new ItemInfo(5985), 
            new ItemInfo(5986), new ItemInfo(5987), new ItemInfo(5988), new ItemInfo(5989), new ItemInfo(5990), new ItemInfo(5991), new ItemInfo(5992), new ItemInfo(5993), new ItemInfo(5994), 
            new ItemInfo(5995), new ItemInfo(5996), new ItemInfo(5997), new ItemInfo(5998), new ItemInfo(5999), new ItemInfo(6000), new ItemInfo(6026), new ItemInfo(6027), new ItemInfo(6028), 
            new ItemInfo(6029), new ItemInfo(6030), new ItemInfo(6031), new ItemInfo(6032), new ItemInfo(6033), new ItemInfo(6034), new ItemInfo(6035), new ItemInfo(6036), new ItemInfo(6037), 
            new ItemInfo(6067), new ItemInfo(6068), new ItemInfo(6069), new ItemInfo(6070), new ItemInfo(6071), new ItemInfo(6072), new ItemInfo(6073), new ItemInfo(6074), new ItemInfo(6075), 
            new ItemInfo(6076), new ItemInfo(6093), new ItemInfo(6094), new ItemInfo(6095), new ItemInfo(6096), new ItemInfo(6097), new ItemInfo(6098), new ItemInfo(6099), new ItemInfo(6100), 
            new ItemInfo(6101), new ItemInfo(6102), new ItemInfo(6103), new ItemInfo(6104), new ItemInfo(6105), new ItemInfo(6106), new ItemInfo(6107), new ItemInfo(6108), new ItemInfo(6109), 
            new ItemInfo(6110), new ItemInfo(6111), new ItemInfo(6112), new ItemInfo(6113), new ItemInfo(6114), new ItemInfo(6115), new ItemInfo(6116), new ItemInfo(6117), new ItemInfo(6118), 
            new ItemInfo(6119), new ItemInfo(6120), new ItemInfo(6121), new ItemInfo(6122), new ItemInfo(6123), new ItemInfo(6124), new ItemInfo(6125), new ItemInfo(6126), new ItemInfo(6127), 
            new ItemInfo(6128), new ItemInfo(6129), new ItemInfo(6130), new ItemInfo(6131), new ItemInfo(6132), new ItemInfo(6133), new ItemInfo(6134), new ItemInfo(6135), new ItemInfo(6136), 
            new ItemInfo(6137), new ItemInfo(6138), new ItemInfo(6139), new ItemInfo(6140), new ItemInfo(6141), new ItemInfo(6142), new ItemInfo(6143), new ItemInfo(6144), new ItemInfo(6145), 
            new ItemInfo(6146), new ItemInfo(6147), new ItemInfo(6148), new ItemInfo(6149), new ItemInfo(6150), new ItemInfo(6151), new ItemInfo(6152), new ItemInfo(6153), new ItemInfo(6154), 
            new ItemInfo(6155), new ItemInfo(6156), new ItemInfo(6157), new ItemInfo(6158), new ItemInfo(6159), new ItemInfo(6160), new ItemInfo(6161), new ItemInfo(6162), new ItemInfo(6163), 
            new ItemInfo(6164), new ItemInfo(6165), new ItemInfo(6166), new ItemInfo(6167), new ItemInfo(6168), new ItemInfo(6169), new ItemInfo(6170), new ItemInfo(6171), new ItemInfo(6172), 
            new ItemInfo(6173), new ItemInfo(6174), new ItemInfo(6175), new ItemInfo(6176), new ItemInfo(6177), new ItemInfo(6178), new ItemInfo(6179), new ItemInfo(6180), new ItemInfo(6181), 
            new ItemInfo(6182), new ItemInfo(6183), new ItemInfo(6184), new ItemInfo(6185), new ItemInfo(6186), new ItemInfo(6187), new ItemInfo(6188), new ItemInfo(6189), new ItemInfo(6190), 
            new ItemInfo(6191), new ItemInfo(6192), new ItemInfo(6193), new ItemInfo(6194), new ItemInfo(6195), new ItemInfo(6196), new ItemInfo(6197), new ItemInfo(6198), new ItemInfo(6199), 
            new ItemInfo(6200), new ItemInfo(6201), new ItemInfo(6202), new ItemInfo(6203), new ItemInfo(6204), new ItemInfo(6205), new ItemInfo(6206), new ItemInfo(6207), new ItemInfo(6208), 
            new ItemInfo(6209), new ItemInfo(6210), new ItemInfo(6211), new ItemInfo(6212), new ItemInfo(6213), new ItemInfo(6214), new ItemInfo(6215), new ItemInfo(6216), new ItemInfo(6217), 
            new ItemInfo(6218), new ItemInfo(6219), new ItemInfo(6220), new ItemInfo(6221), new ItemInfo(6222), new ItemInfo(6223), new ItemInfo(6224), new ItemInfo(6225), new ItemInfo(6226), 
            new ItemInfo(6235), new ItemInfo(6236), new ItemInfo(6237), new ItemInfo(6238), new ItemInfo(6239), new ItemInfo(6240), new ItemInfo(6241), new ItemInfo(6242), new ItemInfo(6243), 
            new ItemInfo(6244), new ItemInfo(6245), new ItemInfo(6246), new ItemInfo(6247), new ItemInfo(6248), new ItemInfo(6249), new ItemInfo(6250), new ItemInfo(6251), new ItemInfo(6252), 
            new ItemInfo(6253), new ItemInfo(6254), new ItemInfo(6255), new ItemInfo(6256), new ItemInfo(6257), new ItemInfo(6258), new ItemInfo(6259), new ItemInfo(6260), new ItemInfo(6261)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt13Gump()
			: this(0)
		{ }

		public AddMiscPt13Gump(int page) 
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

			from.SendGump(new AddMiscPt13Gump(page));
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
