using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt11Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt11", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt11_OnCommand));
		}

		[Usage("AddMiscPt11")]
		
		public static void AddMiscPt11_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt11Gump>();
			e.Mobile.SendGump(new AddMiscPt11Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(5457), new ItemInfo(5458), new ItemInfo(5459), new ItemInfo(5460), new ItemInfo(5461), new ItemInfo(5462), new ItemInfo(5463), new ItemInfo(5464), new ItemInfo(5465), 
            new ItemInfo(5466), new ItemInfo(5467), new ItemInfo(5468), new ItemInfo(5469), new ItemInfo(5470), new ItemInfo(5471), new ItemInfo(5472), new ItemInfo(5473), new ItemInfo(5474), 
            new ItemInfo(5475), new ItemInfo(5476), new ItemInfo(5477), new ItemInfo(5478), new ItemInfo(5479), new ItemInfo(5480), new ItemInfo(5481), new ItemInfo(5482), new ItemInfo(5483), 
            new ItemInfo(5484), new ItemInfo(5485), new ItemInfo(5486), new ItemInfo(5487), new ItemInfo(5488), new ItemInfo(5489), new ItemInfo(5490), new ItemInfo(5491), new ItemInfo(5492), 
            new ItemInfo(5493), new ItemInfo(5494), new ItemInfo(5495), new ItemInfo(5496), new ItemInfo(5497), new ItemInfo(5498), new ItemInfo(5499), new ItemInfo(5500), new ItemInfo(5501), 
            new ItemInfo(5502), new ItemInfo(5503), new ItemInfo(5504), new ItemInfo(5505), new ItemInfo(5506), new ItemInfo(5507), new ItemInfo(5508), new ItemInfo(5509), new ItemInfo(5510), 
            new ItemInfo(5511), new ItemInfo(5512), new ItemInfo(5513), new ItemInfo(5514), new ItemInfo(5515), new ItemInfo(5516), new ItemInfo(5517), new ItemInfo(5518), new ItemInfo(5519), 
            new ItemInfo(5520), new ItemInfo(5521), new ItemInfo(5522), new ItemInfo(5523), new ItemInfo(5524), new ItemInfo(5525), new ItemInfo(5526), new ItemInfo(5527), new ItemInfo(5528), 
            new ItemInfo(5529), new ItemInfo(5530), new ItemInfo(5531), new ItemInfo(5532), new ItemInfo(5533), new ItemInfo(5534), new ItemInfo(5535), new ItemInfo(5536), new ItemInfo(5537), 
            new ItemInfo(5538), new ItemInfo(5539), new ItemInfo(5540), new ItemInfo(5541), new ItemInfo(5542), new ItemInfo(5543), new ItemInfo(5544), new ItemInfo(5545), new ItemInfo(5546), 
            new ItemInfo(5547), new ItemInfo(5548), new ItemInfo(5549), new ItemInfo(5550), new ItemInfo(5551), new ItemInfo(5552), new ItemInfo(5553), new ItemInfo(5554), new ItemInfo(5555), 
            new ItemInfo(5556), new ItemInfo(5557), new ItemInfo(5558), new ItemInfo(5559), new ItemInfo(5560), new ItemInfo(5561), new ItemInfo(5562), new ItemInfo(5563), new ItemInfo(5564), 
            new ItemInfo(5565), new ItemInfo(5566), new ItemInfo(5567), new ItemInfo(5568), new ItemInfo(5569), new ItemInfo(5570), new ItemInfo(5571), new ItemInfo(5572), new ItemInfo(5573), 
            new ItemInfo(5574), new ItemInfo(5575), new ItemInfo(5576), new ItemInfo(5577), new ItemInfo(5578), new ItemInfo(5579), new ItemInfo(5580), new ItemInfo(5581), new ItemInfo(5582), 
            new ItemInfo(5583), new ItemInfo(5584), new ItemInfo(5585), new ItemInfo(5586), new ItemInfo(5587), new ItemInfo(5588), new ItemInfo(5589), new ItemInfo(5590), new ItemInfo(5591), 
            new ItemInfo(5592), new ItemInfo(5593), new ItemInfo(5594), new ItemInfo(5595), new ItemInfo(5596), new ItemInfo(5597), new ItemInfo(5598), new ItemInfo(5599), new ItemInfo(5600), 
            new ItemInfo(5601), new ItemInfo(5602), new ItemInfo(5603), new ItemInfo(5604), new ItemInfo(5605), new ItemInfo(5606), new ItemInfo(5607), new ItemInfo(5608), new ItemInfo(5609), 
            new ItemInfo(5610), new ItemInfo(5611), new ItemInfo(5612), new ItemInfo(5613), new ItemInfo(5614), new ItemInfo(5615), new ItemInfo(5616), new ItemInfo(5617), new ItemInfo(5618), 
            new ItemInfo(5619), new ItemInfo(5620), new ItemInfo(5621), new ItemInfo(5622), new ItemInfo(5623), new ItemInfo(5624), new ItemInfo(5625), new ItemInfo(5626), new ItemInfo(5627), 
            new ItemInfo(5645), new ItemInfo(5646), new ItemInfo(5647), new ItemInfo(5648), new ItemInfo(5649), new ItemInfo(5650), new ItemInfo(5651), new ItemInfo(5652), new ItemInfo(5653), 
            new ItemInfo(5654), new ItemInfo(5655), new ItemInfo(5656), new ItemInfo(5657), new ItemInfo(5658), new ItemInfo(5659), new ItemInfo(5660), new ItemInfo(5661), new ItemInfo(5662), 
            new ItemInfo(5663), new ItemInfo(5664), new ItemInfo(5665), new ItemInfo(5666), new ItemInfo(5667), new ItemInfo(5668), new ItemInfo(5669), new ItemInfo(5670), new ItemInfo(5671), 
            new ItemInfo(5672), new ItemInfo(5673), new ItemInfo(5674), new ItemInfo(5675), new ItemInfo(5676), new ItemInfo(5677), new ItemInfo(5678), new ItemInfo(5679), new ItemInfo(5680), 
            new ItemInfo(5681), new ItemInfo(5682), new ItemInfo(5683), new ItemInfo(5684), new ItemInfo(5685), new ItemInfo(5686), new ItemInfo(5687), new ItemInfo(5688), new ItemInfo(5689), 
            new ItemInfo(5690), new ItemInfo(5691), new ItemInfo(5692), new ItemInfo(5693), new ItemInfo(5694), new ItemInfo(5695), new ItemInfo(5696), new ItemInfo(5697), new ItemInfo(5698)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt11Gump()
			: this(0)
		{ }

		public AddMiscPt11Gump(int page) 
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

			from.SendGump(new AddMiscPt11Gump(page));
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
