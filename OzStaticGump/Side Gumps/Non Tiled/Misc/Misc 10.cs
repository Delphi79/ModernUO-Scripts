using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt10Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt10", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt10_OnCommand));
		}

		[Usage("AddMiscPt10")]
		
		public static void AddMiscPt10_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt10Gump>();
			e.Mobile.SendGump(new AddMiscPt10Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(5163), new ItemInfo(5188), new ItemInfo(5189), new ItemInfo(5190), new ItemInfo(5191), new ItemInfo(5192), new ItemInfo(5193), new ItemInfo(5194), new ItemInfo(5195), 
            new ItemInfo(5196), new ItemInfo(5197), new ItemInfo(5208), new ItemInfo(5209), new ItemInfo(5210), new ItemInfo(5211), new ItemInfo(5212), new ItemInfo(5213), new ItemInfo(5214), 
            new ItemInfo(5215), new ItemInfo(5216), new ItemInfo(5217), new ItemInfo(5218), new ItemInfo(5219), new ItemInfo(5220), new ItemInfo(5221), new ItemInfo(5222), new ItemInfo(5223), 
            new ItemInfo(5224), new ItemInfo(5225), new ItemInfo(5226), new ItemInfo(5227), new ItemInfo(5228), new ItemInfo(5229), new ItemInfo(5230), new ItemInfo(5231), new ItemInfo(5232), 
            new ItemInfo(5233), new ItemInfo(5234), new ItemInfo(5235), new ItemInfo(5236), new ItemInfo(5237), new ItemInfo(5238), new ItemInfo(5239), new ItemInfo(5240), new ItemInfo(5241), 
            new ItemInfo(5242), new ItemInfo(5243), new ItemInfo(5244), new ItemInfo(5245), new ItemInfo(5246), new ItemInfo(5247), new ItemInfo(5248), new ItemInfo(5249), new ItemInfo(5250), 
            new ItemInfo(5251), new ItemInfo(5252), new ItemInfo(5253), new ItemInfo(5254), new ItemInfo(5255), new ItemInfo(5256), new ItemInfo(5257), new ItemInfo(5258), new ItemInfo(5259), 
            new ItemInfo(5260), new ItemInfo(5261), new ItemInfo(5262), new ItemInfo(5263), new ItemInfo(5264), new ItemInfo(5265), new ItemInfo(5266), new ItemInfo(5267), new ItemInfo(5268), 
            new ItemInfo(5269), new ItemInfo(5270), new ItemInfo(5271), new ItemInfo(5272), new ItemInfo(5273), new ItemInfo(5274), new ItemInfo(5275), new ItemInfo(5276), new ItemInfo(5277), 
            new ItemInfo(5278), new ItemInfo(5279), new ItemInfo(5280), new ItemInfo(5281), new ItemInfo(5282), new ItemInfo(5283), new ItemInfo(5284), new ItemInfo(5285), new ItemInfo(5286), 
            new ItemInfo(5287), new ItemInfo(5288), new ItemInfo(5289), new ItemInfo(5290), new ItemInfo(5291), new ItemInfo(5292), new ItemInfo(5293), new ItemInfo(5294), new ItemInfo(5295), 
            new ItemInfo(5296), new ItemInfo(5297), new ItemInfo(5298), new ItemInfo(5299), new ItemInfo(5300), new ItemInfo(5301), new ItemInfo(5302), new ItemInfo(5303), new ItemInfo(5304), 
            new ItemInfo(5305), new ItemInfo(5306), new ItemInfo(5307), new ItemInfo(5308), new ItemInfo(5309), new ItemInfo(5310), new ItemInfo(5311), new ItemInfo(5312), new ItemInfo(5313), 
            new ItemInfo(5314), new ItemInfo(5315), new ItemInfo(5316), new ItemInfo(5317), new ItemInfo(5318), new ItemInfo(5319), new ItemInfo(5320), new ItemInfo(5321), new ItemInfo(5322), 
            new ItemInfo(5323), new ItemInfo(5324), new ItemInfo(5325), new ItemInfo(5326), new ItemInfo(5327), new ItemInfo(5328), new ItemInfo(5329), new ItemInfo(5330), new ItemInfo(5331), 
            new ItemInfo(5332), new ItemInfo(5333), new ItemInfo(5334), new ItemInfo(5335), new ItemInfo(5336), new ItemInfo(5337), new ItemInfo(5338), new ItemInfo(5339), new ItemInfo(5340), 
            new ItemInfo(5341), new ItemInfo(5342), new ItemInfo(5343), new ItemInfo(5344), new ItemInfo(5345), new ItemInfo(5346), new ItemInfo(5347), new ItemInfo(5348), new ItemInfo(5349), 
            new ItemInfo(5350), new ItemInfo(5351), new ItemInfo(5352), new ItemInfo(5353), new ItemInfo(5354), new ItemInfo(5355), new ItemInfo(5356), new ItemInfo(5357), new ItemInfo(5358), 
            new ItemInfo(5359), new ItemInfo(5360), new ItemInfo(5361), new ItemInfo(5362), new ItemInfo(5363), new ItemInfo(5364), new ItemInfo(5365), new ItemInfo(5366), new ItemInfo(5367), 
            new ItemInfo(5368), new ItemInfo(5369), new ItemInfo(5370), new ItemInfo(5375), new ItemInfo(5376), new ItemInfo(5377), new ItemInfo(5378), new ItemInfo(5379), new ItemInfo(5380), 
            new ItemInfo(5381), new ItemInfo(5382), new ItemInfo(5383), new ItemInfo(5384), new ItemInfo(5385), new ItemInfo(5386), new ItemInfo(5387), new ItemInfo(5388), new ItemInfo(5389), 
            new ItemInfo(5390), new ItemInfo(5391), new ItemInfo(5392), new ItemInfo(5393), new ItemInfo(5394), new ItemInfo(5395), new ItemInfo(5396), new ItemInfo(5397), new ItemInfo(5398), 
            new ItemInfo(5399), new ItemInfo(5400), new ItemInfo(5401), new ItemInfo(5402), new ItemInfo(5403), new ItemInfo(5404), new ItemInfo(5405), new ItemInfo(5406), new ItemInfo(5407), 
            new ItemInfo(5408), new ItemInfo(5409), new ItemInfo(5410), new ItemInfo(5411), new ItemInfo(5412), new ItemInfo(5413), new ItemInfo(5414), new ItemInfo(5415), new ItemInfo(5416), 
            new ItemInfo(5417), new ItemInfo(5418), new ItemInfo(5419), new ItemInfo(5420), new ItemInfo(5421), new ItemInfo(5453), new ItemInfo(5454), new ItemInfo(5455), new ItemInfo(5456)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt10Gump()
			: this(0)
		{ }

		public AddMiscPt10Gump(int page) 
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

			from.SendGump(new AddMiscPt10Gump(page));
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
