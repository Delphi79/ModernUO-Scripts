using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt5Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt5", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt5_OnCommand));
		}

		[Usage("AddMisc2Pt5")]
		
		public static void AddMisc2Pt5_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt5Gump>();
			e.Mobile.SendGump(new AddMisc2Pt5Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(9025), new ItemInfo(9026), new ItemInfo(9027), new ItemInfo(9028), new ItemInfo(9029), new ItemInfo(9030), new ItemInfo(9031), new ItemInfo(9032), new ItemInfo(9033), 
            new ItemInfo(9034), new ItemInfo(9035), new ItemInfo(9036), new ItemInfo(9037), new ItemInfo(9038), new ItemInfo(9039), new ItemInfo(9040), new ItemInfo(9041), new ItemInfo(9042), 
            new ItemInfo(9043), new ItemInfo(9044), new ItemInfo(9045), new ItemInfo(9046), new ItemInfo(9047), new ItemInfo(9048), new ItemInfo(9049), new ItemInfo(9050), new ItemInfo(9051), 
            new ItemInfo(9052), new ItemInfo(9053), new ItemInfo(9054), new ItemInfo(9055), new ItemInfo(9056), new ItemInfo(9057), new ItemInfo(9058), new ItemInfo(9059), new ItemInfo(9060), 
            new ItemInfo(9061), new ItemInfo(9062), new ItemInfo(9063), new ItemInfo(9064), new ItemInfo(9065), new ItemInfo(9066), new ItemInfo(9067), new ItemInfo(9068), new ItemInfo(9069), 
            new ItemInfo(9070), new ItemInfo(9071), new ItemInfo(9072), new ItemInfo(9073), new ItemInfo(9074), new ItemInfo(9075), new ItemInfo(9076), new ItemInfo(9077), new ItemInfo(9078), 
            new ItemInfo(9079), new ItemInfo(9080), new ItemInfo(9081), new ItemInfo(9082), new ItemInfo(9083), new ItemInfo(9084), new ItemInfo(9085), new ItemInfo(9086), new ItemInfo(9087), 
            new ItemInfo(9088), new ItemInfo(9089), new ItemInfo(9090), new ItemInfo(9091), new ItemInfo(9092), new ItemInfo(9093), new ItemInfo(9094), new ItemInfo(9095), new ItemInfo(9096), 
            new ItemInfo(9097), new ItemInfo(9098), new ItemInfo(9099), new ItemInfo(9100), new ItemInfo(9101), new ItemInfo(9102), new ItemInfo(9103), new ItemInfo(9104), new ItemInfo(9105), 
            new ItemInfo(9106), new ItemInfo(9107), new ItemInfo(9108), new ItemInfo(9109), new ItemInfo(9110), new ItemInfo(9111), new ItemInfo(9112), new ItemInfo(9113), new ItemInfo(9114), 
            new ItemInfo(9115), new ItemInfo(9116), new ItemInfo(9117), new ItemInfo(9118), new ItemInfo(9119), new ItemInfo(9120), new ItemInfo(9121), new ItemInfo(9122), new ItemInfo(9123), 
            new ItemInfo(9124), new ItemInfo(9125), new ItemInfo(9126), new ItemInfo(9127), new ItemInfo(9128), new ItemInfo(9129), new ItemInfo(9130), new ItemInfo(9131), new ItemInfo(9132), 
            new ItemInfo(9133), new ItemInfo(9134), new ItemInfo(9135), new ItemInfo(9136), new ItemInfo(9137), new ItemInfo(9138), new ItemInfo(9139), new ItemInfo(9140), new ItemInfo(9141), 
            new ItemInfo(9142), new ItemInfo(9143), new ItemInfo(9144), new ItemInfo(9145), new ItemInfo(9146), new ItemInfo(9147), new ItemInfo(9148), new ItemInfo(9149), new ItemInfo(9150), 
            new ItemInfo(9151), new ItemInfo(9152), new ItemInfo(9153), new ItemInfo(9154), new ItemInfo(9155), new ItemInfo(9156), new ItemInfo(9157), new ItemInfo(9158), new ItemInfo(9159), 
            new ItemInfo(9160), new ItemInfo(9161), new ItemInfo(9162), new ItemInfo(9163), new ItemInfo(9164), new ItemInfo(9165), new ItemInfo(9166), new ItemInfo(9167), new ItemInfo(9168), 
            new ItemInfo(9169), new ItemInfo(9170), new ItemInfo(9171), new ItemInfo(9172), new ItemInfo(9173), new ItemInfo(9174), new ItemInfo(9175), new ItemInfo(9176), new ItemInfo(9177), 
            new ItemInfo(9178), new ItemInfo(9179), new ItemInfo(9180), new ItemInfo(9181), new ItemInfo(9182), new ItemInfo(9183), new ItemInfo(9184), new ItemInfo(9185), new ItemInfo(9186), 
            new ItemInfo(9187), new ItemInfo(9188), new ItemInfo(9189), new ItemInfo(9190), new ItemInfo(9191), new ItemInfo(9192), new ItemInfo(9193), new ItemInfo(9194), new ItemInfo(9195), 
            new ItemInfo(9196), new ItemInfo(9197), new ItemInfo(9198), new ItemInfo(9199), new ItemInfo(9200), new ItemInfo(9201), new ItemInfo(9202), new ItemInfo(9203), new ItemInfo(9204), 
            new ItemInfo(9205), new ItemInfo(9206), new ItemInfo(9207), new ItemInfo(9208), new ItemInfo(9209), new ItemInfo(9210), new ItemInfo(9211), new ItemInfo(9212), new ItemInfo(9213), 
            new ItemInfo(9214), new ItemInfo(9215), new ItemInfo(9216), new ItemInfo(9217), new ItemInfo(9218), new ItemInfo(9219), new ItemInfo(9220), new ItemInfo(9221), new ItemInfo(9222), 
            new ItemInfo(9223), new ItemInfo(9224), new ItemInfo(9225), new ItemInfo(9226), new ItemInfo(9227), new ItemInfo(9228), new ItemInfo(9229), new ItemInfo(9230), new ItemInfo(9231), 
            new ItemInfo(9232), new ItemInfo(9233), new ItemInfo(9234), new ItemInfo(9235), new ItemInfo(9236), new ItemInfo(9237), new ItemInfo(9238), new ItemInfo(9239), new ItemInfo(9240), 
            new ItemInfo(9241), new ItemInfo(9242), new ItemInfo(9243), new ItemInfo(9244), new ItemInfo(9245), new ItemInfo(9246), new ItemInfo(9247), new ItemInfo(9248), new ItemInfo(9249)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt5Gump()
			: this(0)
		{ }

		public AddMisc2Pt5Gump(int page) 
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

			from.SendGump(new AddMisc2Pt5Gump(page));
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
