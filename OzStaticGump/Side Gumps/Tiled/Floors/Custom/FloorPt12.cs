using Server.Network;

namespace Server.Gumps
{
	public class AddFloorPt12Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFloorPt12", AccessLevel.GameMaster, new CommandEventHandler(AddFloorPt12_OnCommand));
		}

		[Usage("AddFloorPt12")]
		
		public static void AddFloorPt12_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFloorPt12Gump>();
			e.Mobile.SendGump(new AddFloorPt12Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(40051), new ItemInfo(40052), new ItemInfo(40053), new ItemInfo(40054), new ItemInfo(40055), new ItemInfo(40056), new ItemInfo(40057), new ItemInfo(40058), 
            new ItemInfo(40059), new ItemInfo(40060), new ItemInfo(40061), new ItemInfo(40062), new ItemInfo(40063), new ItemInfo(40064), new ItemInfo(40065), new ItemInfo(40066), 
            new ItemInfo(40067), new ItemInfo(40068), new ItemInfo(40069), new ItemInfo(40070), new ItemInfo(40071), new ItemInfo(40072), new ItemInfo(40073), new ItemInfo(40074), 
            new ItemInfo(40075), new ItemInfo(40076), new ItemInfo(40077), new ItemInfo(40078), new ItemInfo(40079), new ItemInfo(40080), new ItemInfo(40081), new ItemInfo(40082), 
            new ItemInfo(40083), new ItemInfo(40084), new ItemInfo(40085), new ItemInfo(40086), new ItemInfo(40087), new ItemInfo(40088), new ItemInfo(40089), new ItemInfo(40090), 
            new ItemInfo(40091), new ItemInfo(40092), new ItemInfo(40093), new ItemInfo(40094), new ItemInfo(40095), new ItemInfo(40096), new ItemInfo(40097), new ItemInfo(40098), 
            new ItemInfo(40099), new ItemInfo(40100), new ItemInfo(40101), new ItemInfo(40102), new ItemInfo(40103), new ItemInfo(40104), new ItemInfo(40105), new ItemInfo(40106), 
            new ItemInfo(40107), new ItemInfo(40108), new ItemInfo(40109), new ItemInfo(40110), new ItemInfo(40111), new ItemInfo(40112), new ItemInfo(40113), new ItemInfo(40114), 
            new ItemInfo(40115), new ItemInfo(40116), new ItemInfo(40117), new ItemInfo(40118), new ItemInfo(40119), new ItemInfo(40120), new ItemInfo(40121), new ItemInfo(40122), 
            new ItemInfo(40123), new ItemInfo(40124), new ItemInfo(40125), new ItemInfo(40126), new ItemInfo(40127), new ItemInfo(40128), new ItemInfo(40129), new ItemInfo(40130), 
            new ItemInfo(40131), new ItemInfo(40132), new ItemInfo(40133), new ItemInfo(40134), new ItemInfo(40135), new ItemInfo(40136), new ItemInfo(40137), new ItemInfo(40138), 
            new ItemInfo(40139), new ItemInfo(40140), new ItemInfo(40141), new ItemInfo(40142), new ItemInfo(40143), new ItemInfo(40144), new ItemInfo(40145), new ItemInfo(40146), 
            new ItemInfo(40147), new ItemInfo(40148), new ItemInfo(40149), new ItemInfo(40150), new ItemInfo(40151), new ItemInfo(40152), new ItemInfo(40153), new ItemInfo(40154), 
            new ItemInfo(40155), new ItemInfo(40156), new ItemInfo(40157), new ItemInfo(40158), new ItemInfo(40159), new ItemInfo(40160), new ItemInfo(40161), new ItemInfo(40162), 
            new ItemInfo(40163), new ItemInfo(40164), new ItemInfo(40165), new ItemInfo(40166), new ItemInfo(40167), new ItemInfo(40168), new ItemInfo(40169), new ItemInfo(40170), 
            new ItemInfo(40171), new ItemInfo(40172), new ItemInfo(40173), new ItemInfo(40174), new ItemInfo(40175), new ItemInfo(40176), new ItemInfo(40177), new ItemInfo(40178), 
            new ItemInfo(40179), new ItemInfo(40180), new ItemInfo(40181), new ItemInfo(40182), new ItemInfo(40183), new ItemInfo(40184), new ItemInfo(40185), new ItemInfo(42338), 
            new ItemInfo(42339), new ItemInfo(42340), new ItemInfo(42341), new ItemInfo(43002), new ItemInfo(43003), new ItemInfo(43004), new ItemInfo(43005), new ItemInfo(43006), 
            new ItemInfo(43007), new ItemInfo(43008), new ItemInfo(43009), new ItemInfo(43010), new ItemInfo(43011), new ItemInfo(43012), new ItemInfo(43013), new ItemInfo(43014), 
            new ItemInfo(43015), new ItemInfo(43016), new ItemInfo(43017), new ItemInfo(43019), new ItemInfo(43020), new ItemInfo(43021), new ItemInfo(43022), new ItemInfo(43023), 
            new ItemInfo(43024), new ItemInfo(43025), new ItemInfo(43026), new ItemInfo(43027), new ItemInfo(43028), new ItemInfo(43029), new ItemInfo(43030), new ItemInfo(43031), 
            new ItemInfo(43032), new ItemInfo(43033), new ItemInfo(43034), new ItemInfo(43036), new ItemInfo(43037), new ItemInfo(43038), new ItemInfo(43039), new ItemInfo(43040)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFloorPt12Gump()
			: this(0)
		{ }

		public AddFloorPt12Gump(int page) 
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

			from.SendGump(new AddFloorPt12Gump(page));
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
