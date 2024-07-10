using Server.Network;

namespace Server.Gumps
{
	public class AddRockGump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddRock", AccessLevel.GameMaster, new CommandEventHandler(AddRock_OnCommand));
		}

		[Usage("AddRock")]
		[Description("Displays a menu from which you can interactively add Walls.")]
		public static void AddRock_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddRockGump>();
			e.Mobile.SendGump(new AddRockGump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(2272), new ItemInfo(2273), new ItemInfo(2274), new ItemInfo(2275), new ItemInfo(2276), new ItemInfo(2277), new ItemInfo(2278), new ItemInfo(2279), new ItemInfo(2280), 
			new ItemInfo(2281), new ItemInfo(2282), new ItemInfo(4943), new ItemInfo(4944), new ItemInfo(4945), new ItemInfo(4946), new ItemInfo(4947), new ItemInfo(4948), new ItemInfo(4949), 
			new ItemInfo(4950), new ItemInfo(4951), new ItemInfo(4952), new ItemInfo(4953), new ItemInfo(4954), new ItemInfo(4955), new ItemInfo(4956), new ItemInfo(4957), new ItemInfo(4958), 
			new ItemInfo(4959), new ItemInfo(4960), new ItemInfo(4961), new ItemInfo(4962), new ItemInfo(4963), new ItemInfo(4964), new ItemInfo(4965), new ItemInfo(4966), new ItemInfo(4967), 
			new ItemInfo(4968), new ItemInfo(4969), new ItemInfo(4970), new ItemInfo(4971), new ItemInfo(4972), new ItemInfo(4973), new ItemInfo(6001), new ItemInfo(6002), new ItemInfo(6003), 
			new ItemInfo(6004), new ItemInfo(6005), new ItemInfo(6006), new ItemInfo(6007), new ItemInfo(6008), new ItemInfo(6009), new ItemInfo(6010), new ItemInfo(6011), new ItemInfo(6012),
			new ItemInfo(13345), new ItemInfo(13346), new ItemInfo(13347), new ItemInfo(13348), new ItemInfo(13350), new ItemInfo(13351), new ItemInfo(13352), new ItemInfo(13353), 
			new ItemInfo(13356), new ItemInfo(13357), new ItemInfo(13358), new ItemInfo(13359), new ItemInfo(13360), new ItemInfo(13446), 
			new ItemInfo(13447), new ItemInfo(13448), new ItemInfo(13449), new ItemInfo(13450), new ItemInfo(13451), new ItemInfo(13452), new ItemInfo(13453), new ItemInfo(13454), new ItemInfo(13455),
			new ItemInfo(13484), new ItemInfo(13485), new ItemInfo(13486), new ItemInfo(13487), new ItemInfo(13488), new ItemInfo(13489), new ItemInfo(13490), new ItemInfo(13491), new ItemInfo(13492), 
			new ItemInfo(22024), new ItemInfo(22025), new ItemInfo(22026), new ItemInfo(22027), new ItemInfo(22028), new ItemInfo(22029), new ItemInfo(22030), new ItemInfo(22031), new ItemInfo(22032), 
			new ItemInfo(22033), new ItemInfo(22062), new ItemInfo(22063), new ItemInfo(22064), new ItemInfo(22065), new ItemInfo(22066), new ItemInfo(22067), new ItemInfo(22068), new ItemInfo(22069), 
			new ItemInfo(22070)/*, new ItemInfo(1788), new ItemInfo(1793), new ItemInfo(1794), new ItemInfo(1795), new ItemInfo(1796), new ItemInfo(1797), new ItemInfo(1798), new ItemInfo(1799), 
			new ItemInfo(1800), new ItemInfo(2001), new ItemInfo(2002), new ItemInfo(42238), new ItemInfo(42239), new ItemInfo(42240), new ItemInfo(42241), new ItemInfo(42242), new ItemInfo(42243), 
			new ItemInfo(42244), new ItemInfo(42245), new ItemInfo(42246), new ItemInfo(42247), new ItemInfo(42251), new ItemInfo(42252), new ItemInfo(42253), new ItemInfo(42254), new ItemInfo(42255), 
			new ItemInfo(42256), new ItemInfo(42257), new ItemInfo(42258), new ItemInfo(42259), new ItemInfo(42260), new ItemInfo(42261), new ItemInfo(42278), new ItemInfo(42279), new ItemInfo(42280), 
			new ItemInfo(42281), new ItemInfo(42301), new ItemInfo(42302), new ItemInfo(42303), new ItemInfo(42304), new ItemInfo(42305), new ItemInfo(42306), new ItemInfo(42307), new ItemInfo(42308), 
			new ItemInfo(42309), new ItemInfo(42310), new ItemInfo(42311), new ItemInfo(42312), new ItemInfo(42313), new ItemInfo(42314), new ItemInfo(42315), new ItemInfo(42316), new ItemInfo(42317), 
			new ItemInfo(42318), new ItemInfo(42319), new ItemInfo(42320), new ItemInfo(42321), new ItemInfo(42322), new ItemInfo(42323), new ItemInfo(42324), new ItemInfo(42325), 
			
			*/
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddRockGump()
			: this(0)
		{ }

		public AddRockGump(int page) 
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

			from.SendGump(new AddRockGump(page));
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
