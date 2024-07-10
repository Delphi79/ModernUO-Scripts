using Server.Network;

namespace Server.Gumps
{
	public class AddAnimStPt3Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddAnimStPt3", AccessLevel.GameMaster, new CommandEventHandler(AddAnimStPt3_OnCommand));
		}

		[Usage("AddAnimStPt3")]
		public static void AddAnimStPt3_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddAnimStPt3Gump>();
			e.Mobile.SendGump(new AddAnimStPt3Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(0x1FD4), new ItemInfo(0x1FEB), new ItemInfo(0x204B), new ItemInfo(0x22C6), new ItemInfo(0x2332), new ItemInfo(0x2336), new ItemInfo(0x2352), new ItemInfo(0x2358), new ItemInfo(0x235C), 
            new ItemInfo(0x2360), new ItemInfo(0x2364), new ItemInfo(0x2366), new ItemInfo(0x236E), new ItemInfo(0x2371), new ItemInfo(0x29FD), new ItemInfo(0x2A94), new ItemInfo(0x2AA3), new ItemInfo(0x2AA5), 
            new ItemInfo(0x2AA7), new ItemInfo(0x2AA9), new ItemInfo(0x2AAA), new ItemInfo(0x2AAB), new ItemInfo(0x2AB6), new ItemInfo(0x2AB7), new ItemInfo(0x2ABB), new ItemInfo(0x2ABC), new ItemInfo(0x2ABD), 
            new ItemInfo(0x2ABE), new ItemInfo(0x2AC0), new ItemInfo(0x2AC3), new ItemInfo(0x2AC6), new ItemInfo(0x2AC9), new ItemInfo(0x2ACA), new ItemInfo(0x2ACB), new ItemInfo(0x2ACC), new ItemInfo(0x2ACD), 
            new ItemInfo(0x2ACE), new ItemInfo(0x2ACF), new ItemInfo(0x2AD0), new ItemInfo(0x2AD1), new ItemInfo(0x2AD2), new ItemInfo(0x2AD3), new ItemInfo(0x2AD4), new ItemInfo(0x2AD5), new ItemInfo(0x2AD6), 
            new ItemInfo(0x2AD7), new ItemInfo(0x2AD8), new ItemInfo(0x2AD9), new ItemInfo(0x2ADB), new ItemInfo(0x2ADD), new ItemInfo(0x2ADE), new ItemInfo(0x2ADF), new ItemInfo(0x2AE1), new ItemInfo(0x2AE4), 
            new ItemInfo(0x2AE5), new ItemInfo(0x2AE6), new ItemInfo(0x2AE8), new ItemInfo(0x2AE9), new ItemInfo(0x2AEA), new ItemInfo(0x2AED), new ItemInfo(0x2AEE), new ItemInfo(0x2AEF), new ItemInfo(0x2AF3), 
            new ItemInfo(0x2AF5), new ItemInfo(0x2AFA), new ItemInfo(0x2AFB), new ItemInfo(0x2AFE), new ItemInfo(0x2B01), new ItemInfo(0x2B02), new ItemInfo(0x2B06), new ItemInfo(0x2B07), new ItemInfo(0x2B0A), 
            new ItemInfo(0x2B0D), new ItemInfo(0x2B0E), new ItemInfo(0x2E3C), new ItemInfo(0x2E3E), new ItemInfo(0x320D), new ItemInfo(0x3213), new ItemInfo(0x321A), new ItemInfo(0x3220), new ItemInfo(0x3226), 
            new ItemInfo(0x322C), new ItemInfo(0x3236), new ItemInfo(0x3241), new ItemInfo(0x32F4), new ItemInfo(0x3421), new ItemInfo(0x3422), new ItemInfo(0x3423), new ItemInfo(0x3424), new ItemInfo(0x3426), 
            new ItemInfo(0x3427), new ItemInfo(0x3428), new ItemInfo(0x3429), new ItemInfo(0x342C), new ItemInfo(0x342D), new ItemInfo(0x342E), new ItemInfo(0x342F), new ItemInfo(0x3430), new ItemInfo(0x3431), 
            new ItemInfo(0x3432), new ItemInfo(0x3433), new ItemInfo(0x3434), new ItemInfo(0x3435), new ItemInfo(0x343B), new ItemInfo(0x3447), new ItemInfo(0x344E), new ItemInfo(0x3459), new ItemInfo(0x3462), 
            new ItemInfo(0x3468), new ItemInfo(0x346E), new ItemInfo(0x346F), new ItemInfo(0x3470), new ItemInfo(0x3471), new ItemInfo(0x3472), new ItemInfo(0x3473), new ItemInfo(0x3474), new ItemInfo(0x3475), 
            new ItemInfo(0x3476), new ItemInfo(0x3477), new ItemInfo(0x3478), new ItemInfo(0x3479), new ItemInfo(0x347A), new ItemInfo(0x347B), new ItemInfo(0x347C), new ItemInfo(0x347D), new ItemInfo(0x347E), 
            new ItemInfo(0x347F), new ItemInfo(0x3480), new ItemInfo(0x3481), new ItemInfo(0x3482), new ItemInfo(0x3483), new ItemInfo(0x3484), new ItemInfo(0x3485), new ItemInfo(0x3486), new ItemInfo(0x3487), 
            new ItemInfo(0x3488), new ItemInfo(0x3489), new ItemInfo(0x348A), new ItemInfo(0x348B), new ItemInfo(0x348C), new ItemInfo(0x348D), new ItemInfo(0x348E), new ItemInfo(0x348F), new ItemInfo(0x3490), 
            new ItemInfo(0x3492), new ItemInfo(0x3494), new ItemInfo(0x349A), new ItemInfo(0x349D), new ItemInfo(0x34A0), new ItemInfo(0x34A6), new ItemInfo(0x34A8), new ItemInfo(0x34AC), new ItemInfo(0x34AD), 
            new ItemInfo(0x34AE), new ItemInfo(0x34AF), new ItemInfo(0x34B0), new ItemInfo(0x34B1), new ItemInfo(0x34B2), new ItemInfo(0x34B3), new ItemInfo(0x34B4), new ItemInfo(0x34B5), new ItemInfo(0x34B6), 
            new ItemInfo(0x34B8), new ItemInfo(0x34B9), new ItemInfo(0x34BA), new ItemInfo(0x34BD), new ItemInfo(0x34BE), new ItemInfo(0x34C2), new ItemInfo(0x34C3), new ItemInfo(0x34C7), new ItemInfo(0x34D1), 
            new ItemInfo(0x34ED), new ItemInfo(0x34F3), new ItemInfo(0x34F9), new ItemInfo(0x34FF), new ItemInfo(0x3505), new ItemInfo(0x350B), new ItemInfo(0x350C), new ItemInfo(0x3511), new ItemInfo(0x3517)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddAnimStPt3Gump()
			: this(0)
		{ }

		public AddAnimStPt3Gump(int page) 
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

			from.SendGump(new AddAnimStPt3Gump(page));
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
