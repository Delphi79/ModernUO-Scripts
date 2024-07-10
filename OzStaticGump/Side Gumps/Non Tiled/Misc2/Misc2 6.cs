using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt6Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt6", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt6_OnCommand));
		}

		[Usage("AddMisc2Pt6")]
		
		public static void AddMisc2Pt6_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt6Gump>();
			e.Mobile.SendGump(new AddMisc2Pt6Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(9250), new ItemInfo(9251), new ItemInfo(9252), new ItemInfo(9299), new ItemInfo(9300), new ItemInfo(9301), new ItemInfo(9302), new ItemInfo(9303), new ItemInfo(9304), 
            new ItemInfo(9305), new ItemInfo(9306), new ItemInfo(9307), new ItemInfo(9308), new ItemInfo(9309), new ItemInfo(9310), new ItemInfo(9311), new ItemInfo(9312), new ItemInfo(9313), 
            new ItemInfo(9314), new ItemInfo(9315), new ItemInfo(9316), new ItemInfo(9317), new ItemInfo(9318), new ItemInfo(9319), new ItemInfo(9320), new ItemInfo(9321), new ItemInfo(9322), 
            new ItemInfo(9323), new ItemInfo(9389), new ItemInfo(9390), new ItemInfo(9391), new ItemInfo(9392), new ItemInfo(9393), new ItemInfo(9394), new ItemInfo(9395), new ItemInfo(9396), 
            new ItemInfo(9397), new ItemInfo(9398), new ItemInfo(9399), new ItemInfo(9400), new ItemInfo(9401), new ItemInfo(9402), new ItemInfo(9403), new ItemInfo(9404), new ItemInfo(9405), 
            new ItemInfo(9406), new ItemInfo(9407), new ItemInfo(9408), new ItemInfo(9409), new ItemInfo(9410), new ItemInfo(9411), new ItemInfo(9412), new ItemInfo(9413), new ItemInfo(9414), 
            new ItemInfo(9415), new ItemInfo(9416), new ItemInfo(9417), new ItemInfo(9418), new ItemInfo(9419), new ItemInfo(9420), new ItemInfo(9421), new ItemInfo(9422), new ItemInfo(9423), 
            new ItemInfo(9424), new ItemInfo(9425), new ItemInfo(9426), new ItemInfo(9427), new ItemInfo(9428), new ItemInfo(9429), new ItemInfo(9430), new ItemInfo(9431), new ItemInfo(9432), 
            new ItemInfo(9433), new ItemInfo(9434), new ItemInfo(9435), new ItemInfo(9436), new ItemInfo(9437), new ItemInfo(9438), new ItemInfo(9439), new ItemInfo(9440), new ItemInfo(9441), 
            new ItemInfo(9442), new ItemInfo(9443), new ItemInfo(9444), new ItemInfo(9445), new ItemInfo(9446), new ItemInfo(9447), new ItemInfo(9450), new ItemInfo(9451), new ItemInfo(9452), 
            new ItemInfo(9453), new ItemInfo(9454), new ItemInfo(9455), new ItemInfo(9456), new ItemInfo(9457), new ItemInfo(9458), new ItemInfo(9459), new ItemInfo(9600), new ItemInfo(9601), 
            new ItemInfo(9602), new ItemInfo(9603), new ItemInfo(9604), new ItemInfo(9605), new ItemInfo(9606), new ItemInfo(9607), new ItemInfo(9608), new ItemInfo(9609), new ItemInfo(9610), 
            new ItemInfo(9611), new ItemInfo(9612), new ItemInfo(9613), new ItemInfo(9614), new ItemInfo(9615), new ItemInfo(9616), new ItemInfo(9617), new ItemInfo(9618), new ItemInfo(9619), 
            new ItemInfo(9620), new ItemInfo(9621), new ItemInfo(9622), new ItemInfo(9623), new ItemInfo(9624), new ItemInfo(9625), new ItemInfo(9626), new ItemInfo(9627), new ItemInfo(9628), 
            new ItemInfo(9629), new ItemInfo(9630), new ItemInfo(9631), new ItemInfo(9632), new ItemInfo(9633), new ItemInfo(9634), new ItemInfo(9635), new ItemInfo(9636), new ItemInfo(9637), 
            new ItemInfo(9638), new ItemInfo(9639), new ItemInfo(9640), new ItemInfo(9641), new ItemInfo(9642), new ItemInfo(9643), new ItemInfo(9644), new ItemInfo(9645), new ItemInfo(9646), 
            new ItemInfo(9647), new ItemInfo(9648), new ItemInfo(9649), new ItemInfo(9650), new ItemInfo(9651), new ItemInfo(9652), new ItemInfo(9653), new ItemInfo(9654), new ItemInfo(9655), 
            new ItemInfo(9656), new ItemInfo(9657), new ItemInfo(9658), new ItemInfo(9659), new ItemInfo(9660), new ItemInfo(9661), new ItemInfo(9662), new ItemInfo(9663), new ItemInfo(9664), 
            new ItemInfo(9665), new ItemInfo(9666), new ItemInfo(9667), new ItemInfo(9668), new ItemInfo(9669), new ItemInfo(9670), new ItemInfo(9671), new ItemInfo(9672), new ItemInfo(9673), 
            new ItemInfo(9674), new ItemInfo(9675), new ItemInfo(9676), new ItemInfo(9677), new ItemInfo(9678), new ItemInfo(9679), new ItemInfo(9680), new ItemInfo(9681), new ItemInfo(9682), 
            new ItemInfo(9683), new ItemInfo(9684), new ItemInfo(9685), new ItemInfo(9686), new ItemInfo(9687), new ItemInfo(9688), new ItemInfo(9689), new ItemInfo(9690), new ItemInfo(9691), 
            new ItemInfo(9692), new ItemInfo(9693), new ItemInfo(9694), new ItemInfo(9695), new ItemInfo(9696), new ItemInfo(9697), new ItemInfo(9698), new ItemInfo(9699), new ItemInfo(9716), 
            new ItemInfo(9717), new ItemInfo(9718), new ItemInfo(9719), new ItemInfo(9720), new ItemInfo(9721), new ItemInfo(9722), new ItemInfo(9723), new ItemInfo(9724), new ItemInfo(9725), 
            new ItemInfo(9726), new ItemInfo(9727), new ItemInfo(9728), new ItemInfo(9729), new ItemInfo(9730), new ItemInfo(9731), new ItemInfo(9732), new ItemInfo(9733), new ItemInfo(9734), 
            new ItemInfo(9735), new ItemInfo(9736), new ItemInfo(9737), new ItemInfo(9738), new ItemInfo(9739), new ItemInfo(9740), new ItemInfo(9741), new ItemInfo(9742), new ItemInfo(9743)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt6Gump()
			: this(0)
		{ }

		public AddMisc2Pt6Gump(int page) 
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

			from.SendGump(new AddMisc2Pt6Gump(page));
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
