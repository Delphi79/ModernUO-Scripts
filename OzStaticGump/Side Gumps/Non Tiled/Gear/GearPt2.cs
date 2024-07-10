using Server.Network;

namespace Server.Gumps
{
	public class AddGearPt2Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddGearPt2", AccessLevel.GameMaster, new CommandEventHandler(AddGearPt2_OnCommand));
		}

		[Usage("AddGearPt2")]
		
		public static void AddGearPt2_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddGearPt2Gump>();
			e.Mobile.SendGump(new AddGearPt2Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(5060), new ItemInfo(5061), new ItemInfo(5062), new ItemInfo(5063), new ItemInfo(5064), new ItemInfo(5065), new ItemInfo(5066), new ItemInfo(5067), 
            new ItemInfo(5068), new ItemInfo(5069), new ItemInfo(5070), new ItemInfo(5071), new ItemInfo(5072), new ItemInfo(5073), new ItemInfo(5074), new ItemInfo(5075), 
            new ItemInfo(5076), new ItemInfo(5077), new ItemInfo(5078), new ItemInfo(5079), new ItemInfo(5080), new ItemInfo(5081), new ItemInfo(5082), new ItemInfo(5083), 
            new ItemInfo(5084), new ItemInfo(5085), new ItemInfo(5086), new ItemInfo(5087), new ItemInfo(5088), new ItemInfo(5089), new ItemInfo(5090), new ItemInfo(5091), 
            new ItemInfo(5092), new ItemInfo(5093), new ItemInfo(5094), new ItemInfo(5095), new ItemInfo(5096), new ItemInfo(5097), new ItemInfo(5098), new ItemInfo(5099), 
            new ItemInfo(5100), new ItemInfo(5101), new ItemInfo(5102), new ItemInfo(5103), new ItemInfo(5104), new ItemInfo(5105), new ItemInfo(5106), new ItemInfo(5108), 
            new ItemInfo(5109), new ItemInfo(5110), new ItemInfo(5111), new ItemInfo(5112), new ItemInfo(5113), new ItemInfo(5114), new ItemInfo(5115), new ItemInfo(5116), 
            new ItemInfo(5117), new ItemInfo(5118), new ItemInfo(5119), new ItemInfo(5120), new ItemInfo(5121), new ItemInfo(5122), new ItemInfo(5123), new ItemInfo(5124), 
            new ItemInfo(5125), new ItemInfo(5126), new ItemInfo(5127), new ItemInfo(5128), new ItemInfo(5129), new ItemInfo(5130), new ItemInfo(5131), new ItemInfo(5132), 
            new ItemInfo(5133), new ItemInfo(5134), new ItemInfo(5135), new ItemInfo(5136), new ItemInfo(5137), new ItemInfo(5138), new ItemInfo(5139), new ItemInfo(5140), 
            new ItemInfo(5141), new ItemInfo(5142), new ItemInfo(5143), new ItemInfo(5144), new ItemInfo(5145), new ItemInfo(5146), new ItemInfo(5147), new ItemInfo(5148), 
            new ItemInfo(5176), new ItemInfo(5177), new ItemInfo(5178), new ItemInfo(5179), new ItemInfo(5180), new ItemInfo(5181), new ItemInfo(5182), new ItemInfo(5183), 
            new ItemInfo(5184), new ItemInfo(5185), new ItemInfo(5186), new ItemInfo(5187), new ItemInfo(5198), new ItemInfo(5199), new ItemInfo(5200), new ItemInfo(5201), 
            new ItemInfo(5202), new ItemInfo(5203), new ItemInfo(5204), new ItemInfo(5205), new ItemInfo(5206), new ItemInfo(5207), new ItemInfo(5371), new ItemInfo(5372), 
            new ItemInfo(5373), new ItemInfo(5374), new ItemInfo(5422), new ItemInfo(5423), new ItemInfo(5424), new ItemInfo(5425), new ItemInfo(5429), new ItemInfo(5430), 
            new ItemInfo(5431), new ItemInfo(5432), new ItemInfo(5433), new ItemInfo(5434), new ItemInfo(5435), new ItemInfo(5436), new ItemInfo(5437), new ItemInfo(5438), 
            new ItemInfo(5439), new ItemInfo(5440), new ItemInfo(5441), new ItemInfo(5442), new ItemInfo(5443), new ItemInfo(5444), new ItemInfo(5445), new ItemInfo(5446), 
            new ItemInfo(5447), new ItemInfo(5448), new ItemInfo(5449), new ItemInfo(5450), new ItemInfo(5451), new ItemInfo(5452), new ItemInfo(5899), new ItemInfo(5900), 
            new ItemInfo(5901), new ItemInfo(5902), new ItemInfo(5903), new ItemInfo(5904), new ItemInfo(5905), new ItemInfo(5906), new ItemInfo(5907), new ItemInfo(5908), 
            new ItemInfo(5909), new ItemInfo(5910), new ItemInfo(5911), new ItemInfo(5912), new ItemInfo(5913), new ItemInfo(5914), new ItemInfo(5915), new ItemInfo(5916), 
            new ItemInfo(7026), new ItemInfo(7027), new ItemInfo(7028), new ItemInfo(7029), new ItemInfo(7030), new ItemInfo(7031), new ItemInfo(7032), new ItemInfo(7033), 
            new ItemInfo(7034), new ItemInfo(7035), new ItemInfo(7107), new ItemInfo(7108), new ItemInfo(7109), new ItemInfo(7110), new ItemInfo(7111), new ItemInfo(7168)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddGearPt2Gump()
			: this(0)
		{ }

		public AddGearPt2Gump(int page) 
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

			from.SendGump(new AddGearPt2Gump(page));
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
