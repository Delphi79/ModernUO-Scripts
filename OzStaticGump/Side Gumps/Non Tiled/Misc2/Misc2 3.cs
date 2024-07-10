using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt3Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt3", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt3_OnCommand));
		}

		[Usage("AddMisc2Pt3")]
		
		public static void AddMisc2Pt3_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt3Gump>();
			e.Mobile.SendGump(new AddMisc2Pt3Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(8466), new ItemInfo(8467), new ItemInfo(8468), new ItemInfo(8469), new ItemInfo(8470), new ItemInfo(8471), new ItemInfo(8472), new ItemInfo(8473), new ItemInfo(8474), 
            new ItemInfo(8475), new ItemInfo(8476), new ItemInfo(8477), new ItemInfo(8478), new ItemInfo(8479), new ItemInfo(8480), new ItemInfo(8481), new ItemInfo(8482), new ItemInfo(8483), 
            new ItemInfo(8484), new ItemInfo(8485), new ItemInfo(8486), new ItemInfo(8487), new ItemInfo(8488), new ItemInfo(8489), new ItemInfo(8490), new ItemInfo(8491), new ItemInfo(8492), 
            new ItemInfo(8493), new ItemInfo(8494), new ItemInfo(8495), new ItemInfo(8496), new ItemInfo(8497), new ItemInfo(8498), new ItemInfo(8499), new ItemInfo(8500), new ItemInfo(8501), 
            new ItemInfo(8502), new ItemInfo(8503), new ItemInfo(8504), new ItemInfo(8505), new ItemInfo(8506), new ItemInfo(8507), new ItemInfo(8508), new ItemInfo(8509), new ItemInfo(8510), 
            new ItemInfo(8511), new ItemInfo(8512), new ItemInfo(8513), new ItemInfo(8514), new ItemInfo(8515), new ItemInfo(8516), new ItemInfo(8517), new ItemInfo(8518), new ItemInfo(8519), 
            new ItemInfo(8520), new ItemInfo(8521), new ItemInfo(8522), new ItemInfo(8523), new ItemInfo(8524), new ItemInfo(8525), new ItemInfo(8526), new ItemInfo(8527), new ItemInfo(8528), 
            new ItemInfo(8529), new ItemInfo(8530), new ItemInfo(8531), new ItemInfo(8532), new ItemInfo(8533), new ItemInfo(8534), new ItemInfo(8535), new ItemInfo(8536), new ItemInfo(8537), 
            new ItemInfo(8538), new ItemInfo(8539), new ItemInfo(8540), new ItemInfo(8541), new ItemInfo(8542), new ItemInfo(8543), new ItemInfo(8544), new ItemInfo(8545), new ItemInfo(8546), 
            new ItemInfo(8547), new ItemInfo(8548), new ItemInfo(8549), new ItemInfo(8550), new ItemInfo(8551), new ItemInfo(8552), new ItemInfo(8553), new ItemInfo(8554), new ItemInfo(8555), 
            new ItemInfo(8556), new ItemInfo(8557), new ItemInfo(8558), new ItemInfo(8559), new ItemInfo(8560), new ItemInfo(8561), new ItemInfo(8562), new ItemInfo(8563), new ItemInfo(8564), 
            new ItemInfo(8565), new ItemInfo(8566), new ItemInfo(8567), new ItemInfo(8568), new ItemInfo(8569), new ItemInfo(8570), new ItemInfo(8571), new ItemInfo(8572), new ItemInfo(8573), 
            new ItemInfo(8574), new ItemInfo(8575), new ItemInfo(8576), new ItemInfo(8577), new ItemInfo(8578), new ItemInfo(8579), new ItemInfo(8580), new ItemInfo(8581), new ItemInfo(8582), 
            new ItemInfo(8583), new ItemInfo(8681), new ItemInfo(8682), new ItemInfo(8683), new ItemInfo(8684), new ItemInfo(8685), new ItemInfo(8686), new ItemInfo(8687), new ItemInfo(8688), 
            new ItemInfo(8689), new ItemInfo(8690), new ItemInfo(8691), new ItemInfo(8692), new ItemInfo(8693), new ItemInfo(8694), new ItemInfo(8695), new ItemInfo(8696), new ItemInfo(8697), 
            new ItemInfo(8698), new ItemInfo(8699), new ItemInfo(8700), new ItemInfo(8701), new ItemInfo(8702), new ItemInfo(8703), new ItemInfo(8704), new ItemInfo(8705), new ItemInfo(8706), 
            new ItemInfo(8707), new ItemInfo(8708), new ItemInfo(8709), new ItemInfo(8710), new ItemInfo(8711), new ItemInfo(8712), new ItemInfo(8713), new ItemInfo(8714), new ItemInfo(8715), 
            new ItemInfo(8716), new ItemInfo(8717), new ItemInfo(8718), new ItemInfo(8719), new ItemInfo(8720), new ItemInfo(8721), new ItemInfo(8722), new ItemInfo(8723), new ItemInfo(8724), 
            new ItemInfo(8725), new ItemInfo(8726), new ItemInfo(8727), new ItemInfo(8728), new ItemInfo(8729), new ItemInfo(8730), new ItemInfo(8731), new ItemInfo(8732), new ItemInfo(8733), 
            new ItemInfo(8734), new ItemInfo(8735), new ItemInfo(8736), new ItemInfo(8737), new ItemInfo(8738), new ItemInfo(8739), new ItemInfo(8740), new ItemInfo(8741), new ItemInfo(8742), 
            new ItemInfo(8743), new ItemInfo(8744), new ItemInfo(8745), new ItemInfo(8746), new ItemInfo(8747), new ItemInfo(8748), new ItemInfo(8749), new ItemInfo(8750), new ItemInfo(8751), 
            new ItemInfo(8752), new ItemInfo(8753), new ItemInfo(8754), new ItemInfo(8755), new ItemInfo(8756), new ItemInfo(8757), new ItemInfo(8758), new ItemInfo(8759), new ItemInfo(8760), 
            new ItemInfo(8761), new ItemInfo(8762), new ItemInfo(8763), new ItemInfo(8764), new ItemInfo(8765), new ItemInfo(8766), new ItemInfo(8767), new ItemInfo(8768), new ItemInfo(8769), 
            new ItemInfo(8770), new ItemInfo(8771), new ItemInfo(8772), new ItemInfo(8773), new ItemInfo(8774), new ItemInfo(8775), new ItemInfo(8776), new ItemInfo(8777), new ItemInfo(8778), 
            new ItemInfo(8779), new ItemInfo(8780), new ItemInfo(8781), new ItemInfo(8782), new ItemInfo(8783), new ItemInfo(8784), new ItemInfo(8785), new ItemInfo(8786), new ItemInfo(8787)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt3Gump()
			: this(0)
		{ }

		public AddMisc2Pt3Gump(int page) 
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

			from.SendGump(new AddMisc2Pt3Gump(page));
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
