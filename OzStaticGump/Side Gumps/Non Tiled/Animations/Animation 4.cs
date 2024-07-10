using Server.Network;

namespace Server.Gumps
{
	public class AddAnimStPt4Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddAnimStPt4", AccessLevel.GameMaster, new CommandEventHandler(AddAnimStPt4_OnCommand));
		}

		[Usage("AddAnimStPt4")]
		public static void AddAnimStPt4_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddAnimStPt4Gump>();
			e.Mobile.SendGump(new AddAnimStPt4Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(0x351D), new ItemInfo(0x3523), new ItemInfo(0x352D), new ItemInfo(0x35EF), new ItemInfo(0x3660), new ItemInfo(0x3661), new ItemInfo(0x3662), new ItemInfo(0x366D), new ItemInfo(0x366E), 
            new ItemInfo(0x36B0), new ItemInfo(0x36BD), new ItemInfo(0x36BF), new ItemInfo(0x36CC), new ItemInfo(0x36D4), new ItemInfo(0x36DA), new ItemInfo(0x36E4), new ItemInfo(0x36E5), new ItemInfo(0x36E6), 
            new ItemInfo(0x36F4), new ItemInfo(0x36FE), new ItemInfo(0x3704), new ItemInfo(0x3705), new ItemInfo(0x3709), new ItemInfo(0x3715), new ItemInfo(0x371A), new ItemInfo(0x3723), new ItemInfo(0x3725), 
            new ItemInfo(0x3728), new ItemInfo(0x372A), new ItemInfo(0x3735), new ItemInfo(0x373A), new ItemInfo(0x3740), new ItemInfo(0x3749), new ItemInfo(0x374A), new ItemInfo(0x3753), new ItemInfo(0x3754), 
            new ItemInfo(0x375A), new ItemInfo(0x3763), new ItemInfo(0x376A), new ItemInfo(0x3772), new ItemInfo(0x3773), new ItemInfo(0x3779), new ItemInfo(0x377A), new ItemInfo(0x3789), new ItemInfo(0x3798), 
            new ItemInfo(0x37A0), new ItemInfo(0x37B9), new ItemInfo(0x37BE), new ItemInfo(0x37CA), new ItemInfo(0x37CC), new ItemInfo(0x3818), new ItemInfo(0x3914), new ItemInfo(0x3915), new ItemInfo(0x3916), 
            new ItemInfo(0x3917), new ItemInfo(0x3918), new ItemInfo(0x3920), new ItemInfo(0x3921), new ItemInfo(0x3922), new ItemInfo(0x3923), new ItemInfo(0x3924), new ItemInfo(0x3946), new ItemInfo(0x3947), 
            new ItemInfo(0x3948), new ItemInfo(0x3949), new ItemInfo(0x394A), new ItemInfo(0x3955), new ItemInfo(0x3956), new ItemInfo(0x3957), new ItemInfo(0x3958), new ItemInfo(0x3959), new ItemInfo(0x395A), 
            new ItemInfo(0x3967), new ItemInfo(0x3973), new ItemInfo(0x3979), new ItemInfo(0x398C), new ItemInfo(0x398D), new ItemInfo(0x398E), new ItemInfo(0x39EF), new ItemInfo(0x3990), new ItemInfo(0x3996), 
            new ItemInfo(0x3997), new ItemInfo(0x3998), new ItemInfo(0x3999), new ItemInfo(0x399A), new ItemInfo(0x399F), new ItemInfo(0x3A5F), new ItemInfo(0x3A7D), new ItemInfo(0x3A7E), new ItemInfo(0x3A84), 
            new ItemInfo(0x3A87), new ItemInfo(0x3A88), new ItemInfo(0x3A8D), new ItemInfo(0x3A8E), new ItemInfo(0x3E01), new ItemInfo(0x3E02), new ItemInfo(0x3E27), new ItemInfo(0x3E31), new ItemInfo(0x3F42), 
            new ItemInfo(0x3F47), new ItemInfo(0x3F51), new ItemInfo(0x3F53), new ItemInfo(0x3F55), new ItemInfo(0x3F57), new ItemInfo(0x3F59), new ItemInfo(0x3F5B), new ItemInfo(0x3F5D), new ItemInfo(0x3F5F), 
            new ItemInfo(0x3F69), new ItemInfo(0x3F6E), new ItemInfo(0x3F78), new ItemInfo(0x3F7A), new ItemInfo(0x3F7C), new ItemInfo(0x3F7E), new ItemInfo(0x3F80), new ItemInfo(0x3F82), new ItemInfo(0x3F84), 
            new ItemInfo(0x3F86), new ItemInfo(0x3F91), new ItemInfo(0x3F93), new ItemInfo(0x3F98), new ItemInfo(0x3F9D), new ItemInfo(0x3FA5), new ItemInfo(0x3FA7), new ItemInfo(0x3FA8), new ItemInfo(0x3FA9), 
            new ItemInfo(0x3FAB), new ItemInfo(0x3FAD), new ItemInfo(0x3FAF), new ItemInfo(0x3FB0), new ItemInfo(0x3FB1), new ItemInfo(0x3FB2), new ItemInfo(0x3FB3), new ItemInfo(0x3FB5), new ItemInfo(0x3FB6), 
            new ItemInfo(0x3FBE), new ItemInfo(0x3FC2), new ItemInfo(0x3FC3), new ItemInfo(0x3FC8), new ItemInfo(0x3FCA), new ItemInfo(0x3FCD), new ItemInfo(0x3FCF), new ItemInfo(0x3FD0), new ItemInfo(0x3FD1), 
            new ItemInfo(0x3FD2), new ItemInfo(0x3FD4), new ItemInfo(0x3FD5), new ItemInfo(0x3FD6), new ItemInfo(0x3FD8), new ItemInfo(0x3FDA), new ItemInfo(0x3FDC), new ItemInfo(0x3FDE), new ItemInfo(0x3FE0), 
            new ItemInfo(0x40BE), new ItemInfo(0x42CF), new ItemInfo(0x437E), new ItemInfo(0x4382), new ItemInfo(0x4386), new ItemInfo(0x438A), new ItemInfo(0x438E), new ItemInfo(0x4392), new ItemInfo(0x4396), 
            new ItemInfo(0x439A), new ItemInfo(0x439E), new ItemInfo(0x43A2), new ItemInfo(0x44C7), new ItemInfo(0x44CB), new ItemInfo(0x44D5), new ItemInfo(0x44D9), new ItemInfo(0x44DD), new ItemInfo(0x44E1), 
            new ItemInfo(0x4691), new ItemInfo(0x4695), new ItemInfo(0x46E6), new ItemInfo(0x46E9), new ItemInfo(0x46EC), new ItemInfo(0x46EF), new ItemInfo(0x46F2), new ItemInfo(0x46F5), new ItemInfo(0x483B)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddAnimStPt4Gump()
			: this(0)
		{ }

		public AddAnimStPt4Gump(int page) 
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

			from.SendGump(new AddAnimStPt4Gump(page));
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
