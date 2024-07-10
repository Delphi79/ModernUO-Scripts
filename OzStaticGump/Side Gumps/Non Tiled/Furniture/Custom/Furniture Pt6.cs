using Server.Network;

namespace Server.Gumps
{
	public class AddFurnPt6Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFurnPt6", AccessLevel.GameMaster, new CommandEventHandler(AddFurnPt6_OnCommand));
		}

		[Usage("AddFurnPt6")]
		public static void AddFurnPt6_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFurnPt6Gump>();
			e.Mobile.SendGump(new AddFurnPt6Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(40630), new ItemInfo(40631), new ItemInfo(40632), new ItemInfo(40633), new ItemInfo(40634), new ItemInfo(40635), new ItemInfo(40636), 
            new ItemInfo(40637), new ItemInfo(40638), new ItemInfo(40639), new ItemInfo(40640), new ItemInfo(40641), new ItemInfo(40642), new ItemInfo(40643), 
            new ItemInfo(40688), new ItemInfo(40689), new ItemInfo(40690), new ItemInfo(40691), new ItemInfo(40692), new ItemInfo(40693), new ItemInfo(40743), 
            new ItemInfo(40744), new ItemInfo(40853), new ItemInfo(40854), new ItemInfo(40871), new ItemInfo(40872), new ItemInfo(40873), new ItemInfo(40874), 
            new ItemInfo(40875), new ItemInfo(40897), new ItemInfo(40898), new ItemInfo(40899), new ItemInfo(40900), new ItemInfo(40947), new ItemInfo(40948), 
            new ItemInfo(40968), new ItemInfo(40969), new ItemInfo(40970), new ItemInfo(40971), new ItemInfo(40972), new ItemInfo(40973), new ItemInfo(40974), 
            new ItemInfo(40975), new ItemInfo(40976), new ItemInfo(40977), new ItemInfo(40978), new ItemInfo(40979), new ItemInfo(40980), new ItemInfo(40981), 
            new ItemInfo(40982), new ItemInfo(40983), new ItemInfo(40984), new ItemInfo(40985), new ItemInfo(40986), new ItemInfo(40987), new ItemInfo(41031), 
            new ItemInfo(41032), new ItemInfo(41033), new ItemInfo(41034), new ItemInfo(41035), new ItemInfo(41036), new ItemInfo(41037), new ItemInfo(41038), 
            new ItemInfo(41039), new ItemInfo(41040), new ItemInfo(41041), new ItemInfo(41042), new ItemInfo(41043), new ItemInfo(41044), new ItemInfo(41045), 
            new ItemInfo(41046), new ItemInfo(41047), new ItemInfo(41048), new ItemInfo(41049), new ItemInfo(41050), new ItemInfo(41051), new ItemInfo(41052), 
            new ItemInfo(41053), new ItemInfo(41054), new ItemInfo(41055), new ItemInfo(41056), new ItemInfo(41057), new ItemInfo(41058), new ItemInfo(41059), 
            new ItemInfo(41060), new ItemInfo(41061), new ItemInfo(41062), new ItemInfo(41063), new ItemInfo(41064), new ItemInfo(41065), new ItemInfo(41066), 
            new ItemInfo(41067), new ItemInfo(41068), new ItemInfo(41226), new ItemInfo(41227), new ItemInfo(41228), new ItemInfo(41229), new ItemInfo(41230), 
            new ItemInfo(41231), new ItemInfo(41232), new ItemInfo(41233), new ItemInfo(41273), new ItemInfo(41274), new ItemInfo(41275), new ItemInfo(41276), 
            new ItemInfo(41277), new ItemInfo(41278), new ItemInfo(41279), new ItemInfo(41280), new ItemInfo(41281), new ItemInfo(41282), new ItemInfo(41283), 
            new ItemInfo(41284), new ItemInfo(41285), new ItemInfo(41286), new ItemInfo(41287), new ItemInfo(41288), new ItemInfo(41289), new ItemInfo(41290), 
            new ItemInfo(42194), new ItemInfo(42195), new ItemInfo(42196), new ItemInfo(42197), new ItemInfo(42198), new ItemInfo(42199), new ItemInfo(42200), 
            new ItemInfo(42201), new ItemInfo(42202), new ItemInfo(42203), new ItemInfo(42204), new ItemInfo(42205), new ItemInfo(42206), new ItemInfo(42207), 
            new ItemInfo(42382), new ItemInfo(42383), new ItemInfo(42384), new ItemInfo(42385), new ItemInfo(42398), new ItemInfo(42399), new ItemInfo(42400), 
            new ItemInfo(42401), new ItemInfo(42402), new ItemInfo(42403), new ItemInfo(42404), new ItemInfo(42405), new ItemInfo(42406), new ItemInfo(42407), 
            new ItemInfo(42408), new ItemInfo(42409), new ItemInfo(42410), new ItemInfo(42411), new ItemInfo(42412), new ItemInfo(42413), new ItemInfo(42414), 
            new ItemInfo(42415), new ItemInfo(42416), new ItemInfo(42417), new ItemInfo(42418), new ItemInfo(42419), new ItemInfo(42420), new ItemInfo(42421), 
            new ItemInfo(42422), new ItemInfo(42423), new ItemInfo(42424), new ItemInfo(42425), new ItemInfo(42426), new ItemInfo(42427), new ItemInfo(42428), 
            new ItemInfo(42429), new ItemInfo(42430), new ItemInfo(42431), new ItemInfo(42432), new ItemInfo(42433), new ItemInfo(42434), new ItemInfo(42435), 
            new ItemInfo(42436), new ItemInfo(42437), new ItemInfo(42438), new ItemInfo(42439), new ItemInfo(42440), new ItemInfo(42441), new ItemInfo(42442), 
            new ItemInfo(42443), new ItemInfo(42444), new ItemInfo(42445), new ItemInfo(42446), new ItemInfo(42447)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFurnPt6Gump()
			: this(0)
		{ }

		public AddFurnPt6Gump(int page) 
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

			from.SendGump(new AddFurnPt6Gump(page));
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
