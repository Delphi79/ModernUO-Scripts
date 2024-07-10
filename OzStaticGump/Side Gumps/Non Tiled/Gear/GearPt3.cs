using Server.Network;

namespace Server.Gumps
{
	public class AddGearPt3Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddGearPt3", AccessLevel.GameMaster, new CommandEventHandler(AddGearPt3_OnCommand));
		}

		[Usage("AddGearPt3")]
		
		public static void AddGearPt3_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddGearPt3Gump>();
			e.Mobile.SendGump(new AddGearPt3Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(7169), new ItemInfo(7170), new ItemInfo(7171), new ItemInfo(7172), new ItemInfo(7173), new ItemInfo(7174), new ItemInfo(7175), new ItemInfo(7176), 
            new ItemInfo(7177), new ItemInfo(7178), new ItemInfo(7179), new ItemInfo(7180), new ItemInfo(7181), new ItemInfo(7933), new ItemInfo(7934), new ItemInfo(7935), 
            new ItemInfo(7936), new ItemInfo(7937), new ItemInfo(7938), new ItemInfo(7939), new ItemInfo(7940), new ItemInfo(7941), new ItemInfo(7942), new ItemInfo(7943), 
            new ItemInfo(7944), new ItemInfo(7945), new ItemInfo(7946), new ItemInfo(7947), new ItemInfo(7948), new ItemInfo(8059), new ItemInfo(8060), new ItemInfo(8095), 
            new ItemInfo(8096), new ItemInfo(8097), new ItemInfo(8098), new ItemInfo(8189), new ItemInfo(8190), new ItemInfo(8965), new ItemInfo(8966), new ItemInfo(8967), 
            new ItemInfo(8968), new ItemInfo(8969), new ItemInfo(8970), new ItemInfo(8971), new ItemInfo(8972), new ItemInfo(8973), new ItemInfo(8974), new ItemInfo(8975), 
            new ItemInfo(8976), new ItemInfo(9556), new ItemInfo(9557), new ItemInfo(9558), new ItemInfo(9559), new ItemInfo(9560), new ItemInfo(9561), new ItemInfo(9562), 
            new ItemInfo(9563), new ItemInfo(9564), new ItemInfo(9565), new ItemInfo(9566), new ItemInfo(9567), new ItemInfo(9568), new ItemInfo(9569), new ItemInfo(9570), 
            new ItemInfo(9571), new ItemInfo(9572), new ItemInfo(9573), new ItemInfo(9574), new ItemInfo(9575), new ItemInfo(9576), new ItemInfo(9577), new ItemInfo(9578), 
            new ItemInfo(9579), new ItemInfo(9580), new ItemInfo(9581), new ItemInfo(9582), new ItemInfo(9583), new ItemInfo(9584), new ItemInfo(9585), new ItemInfo(9586), 
            new ItemInfo(9587), new ItemInfo(9588), new ItemInfo(9589), new ItemInfo(9590), new ItemInfo(9591), new ItemInfo(9592), new ItemInfo(9593), new ItemInfo(9594), 
            new ItemInfo(9595), new ItemInfo(9596), new ItemInfo(9597), new ItemInfo(9598), new ItemInfo(9599), new ItemInfo(9700), new ItemInfo(9701), new ItemInfo(9702), 
            new ItemInfo(9703), new ItemInfo(9704), new ItemInfo(9705), new ItemInfo(9706), new ItemInfo(9707), new ItemInfo(9708), new ItemInfo(9709), new ItemInfo(9710), 
            new ItemInfo(9711), new ItemInfo(9712), new ItemInfo(9713), new ItemInfo(9714), new ItemInfo(9715), new ItemInfo(9793), new ItemInfo(9794), new ItemInfo(9795), 
            new ItemInfo(9796), new ItemInfo(9797), new ItemInfo(9798), new ItemInfo(9799), new ItemInfo(9800), new ItemInfo(9801), new ItemInfo(9802), new ItemInfo(9803), 
            new ItemInfo(9804), new ItemInfo(9805), new ItemInfo(9806), new ItemInfo(9807), new ItemInfo(9808), new ItemInfo(9809), new ItemInfo(9810), new ItemInfo(9811), 
            new ItemInfo(9812), new ItemInfo(9813), new ItemInfo(9814), new ItemInfo(9815), new ItemInfo(9816), new ItemInfo(9817), new ItemInfo(9818), new ItemInfo(9819), 
            new ItemInfo(9820), new ItemInfo(9821), new ItemInfo(9822), new ItemInfo(9823), new ItemInfo(9824), new ItemInfo(9825), new ItemInfo(9826), new ItemInfo(9827), 
            new ItemInfo(9828), new ItemInfo(9829), new ItemInfo(9830), new ItemInfo(9831), new ItemInfo(9832), new ItemInfo(9835), new ItemInfo(9836), new ItemInfo(9837), 
            new ItemInfo(9838), new ItemInfo(9841), new ItemInfo(9842), new ItemInfo(9843), new ItemInfo(9844), new ItemInfo(9847), new ItemInfo(9848), new ItemInfo(9849), 
            new ItemInfo(9850), new ItemInfo(9851), new ItemInfo(9852), new ItemInfo(9853), new ItemInfo(9854), new ItemInfo(9855), new ItemInfo(9856), new ItemInfo(9857), 
            new ItemInfo(9858), new ItemInfo(9859), new ItemInfo(9860), new ItemInfo(9861), new ItemInfo(9862), new ItemInfo(9863), new ItemInfo(9865), new ItemInfo(9866)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddGearPt3Gump()
			: this(0)
		{ }

		public AddGearPt3Gump(int page) 
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

			from.SendGump(new AddGearPt3Gump(page));
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
