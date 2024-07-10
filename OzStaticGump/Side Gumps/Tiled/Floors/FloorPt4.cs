using Server.Network;

namespace Server.Gumps
{
	public class AddFloorPt4Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFloorPt4", AccessLevel.GameMaster, new CommandEventHandler(AddFloorPt4_OnCommand));
		}

		[Usage("AddFloorPt4")]
		
		public static void AddFloorPt4_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFloorPt4Gump>();
			e.Mobile.SendGump(new AddFloorPt4Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(16535), new ItemInfo(16536), new ItemInfo(16537), new ItemInfo(16538), new ItemInfo(16547), new ItemInfo(16548), new ItemInfo(16549), new ItemInfo(16550), 
            new ItemInfo(16551), new ItemInfo(16552), new ItemInfo(16553), new ItemInfo(16554), new ItemInfo(16555), new ItemInfo(16556), new ItemInfo(16557), new ItemInfo(16558), 
            new ItemInfo(16559), new ItemInfo(16560), new ItemInfo(16561), new ItemInfo(16562), new ItemInfo(16563), new ItemInfo(16564), new ItemInfo(16565), new ItemInfo(16566), 
            new ItemInfo(16567), new ItemInfo(16568), new ItemInfo(16569), new ItemInfo(16570), new ItemInfo(16571), new ItemInfo(16577), new ItemInfo(16578), new ItemInfo(16579), 
            new ItemInfo(16580), new ItemInfo(16581), new ItemInfo(16582), new ItemInfo(16583), new ItemInfo(16584), new ItemInfo(16585), new ItemInfo(16586), new ItemInfo(16587), 
            new ItemInfo(16588), new ItemInfo(16589), new ItemInfo(16590), new ItemInfo(16591), new ItemInfo(16592), new ItemInfo(16593), new ItemInfo(16594), new ItemInfo(16595), 
            new ItemInfo(16596), new ItemInfo(16597), new ItemInfo(16598), new ItemInfo(16599), new ItemInfo(16600), new ItemInfo(16601), new ItemInfo(16774), new ItemInfo(16775), 
            new ItemInfo(16776), new ItemInfo(16777), new ItemInfo(16778), new ItemInfo(16779), new ItemInfo(16780), new ItemInfo(16781), new ItemInfo(16782), new ItemInfo(16815), 
            new ItemInfo(16816), new ItemInfo(16817), new ItemInfo(16818), new ItemInfo(16821), new ItemInfo(16822), new ItemInfo(16823), new ItemInfo(16824), new ItemInfo(16825), 
            new ItemInfo(16826), new ItemInfo(16827), new ItemInfo(16828), new ItemInfo(16842), new ItemInfo(16843), new ItemInfo(16844), new ItemInfo(16855), new ItemInfo(16860), 
            new ItemInfo(16861), new ItemInfo(16862), new ItemInfo(16863), new ItemInfo(16864), new ItemInfo(16865), new ItemInfo(16866), new ItemInfo(16867), new ItemInfo(16868), 
            new ItemInfo(16872), new ItemInfo(16873), new ItemInfo(16874), new ItemInfo(16875), new ItemInfo(16876), new ItemInfo(16877), new ItemInfo(16878), new ItemInfo(16879), 
            new ItemInfo(16880), new ItemInfo(16881), new ItemInfo(16882), new ItemInfo(16883), new ItemInfo(16884), new ItemInfo(16885), new ItemInfo(16886), new ItemInfo(16887), 
            new ItemInfo(16888), new ItemInfo(16889), new ItemInfo(16890), new ItemInfo(16891), new ItemInfo(17192), new ItemInfo(17193), new ItemInfo(17194), new ItemInfo(17195), 
            new ItemInfo(17196), new ItemInfo(17197), new ItemInfo(17198), new ItemInfo(17199), new ItemInfo(17200), new ItemInfo(17201), new ItemInfo(17202), new ItemInfo(17203), 
            new ItemInfo(17204), new ItemInfo(17205), new ItemInfo(17206), new ItemInfo(17207), new ItemInfo(17208), new ItemInfo(17209), new ItemInfo(17210), new ItemInfo(17211), 
            new ItemInfo(17376), new ItemInfo(17377), new ItemInfo(17378), new ItemInfo(17379), new ItemInfo(17380), new ItemInfo(17381), new ItemInfo(17382), new ItemInfo(17383), 
            new ItemInfo(17384), new ItemInfo(17385), new ItemInfo(17386), new ItemInfo(17387), new ItemInfo(17388), new ItemInfo(17389), new ItemInfo(17390), new ItemInfo(17391), 
            new ItemInfo(17392), new ItemInfo(17393), new ItemInfo(17394), new ItemInfo(17395), new ItemInfo(17396), new ItemInfo(17397), new ItemInfo(17398), new ItemInfo(17399), 
            new ItemInfo(17400), new ItemInfo(17401), new ItemInfo(17402), new ItemInfo(17403), new ItemInfo(17404), new ItemInfo(17405), new ItemInfo(17406), new ItemInfo(17407), 
            new ItemInfo(17408), new ItemInfo(17409), new ItemInfo(17410), new ItemInfo(17411), new ItemInfo(17412), new ItemInfo(17413), new ItemInfo(17414), new ItemInfo(17415), 
            new ItemInfo(17416), new ItemInfo(17417), new ItemInfo(17418), new ItemInfo(17419), new ItemInfo(17420), new ItemInfo(17421), new ItemInfo(17422), new ItemInfo(17423)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFloorPt4Gump()
			: this(0)
		{ }

		public AddFloorPt4Gump(int page) 
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

			from.SendGump(new AddFloorPt4Gump(page));
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
