using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt10Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt10", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt10_OnCommand));
		}

		[Usage("AddCustomPt10")]
		
		public static void AddCustomPt10_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt10Gump>();
			e.Mobile.SendGump(new AddCustomPt10Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(40851), new ItemInfo(40852), new ItemInfo(40853), new ItemInfo(40854), new ItemInfo(40855), new ItemInfo(40856), new ItemInfo(40857), new ItemInfo(40858), new ItemInfo(40859), 
			new ItemInfo(40860), new ItemInfo(40861), new ItemInfo(40862), new ItemInfo(40863), new ItemInfo(40864), new ItemInfo(40865), new ItemInfo(40866), new ItemInfo(40867), new ItemInfo(40868), 
			new ItemInfo(40869), new ItemInfo(40870), new ItemInfo(40871), new ItemInfo(40872), new ItemInfo(40873), new ItemInfo(40874), new ItemInfo(40875), new ItemInfo(40876), new ItemInfo(40877), 
			new ItemInfo(40878), new ItemInfo(40879), new ItemInfo(40880), new ItemInfo(40881), new ItemInfo(40882), new ItemInfo(40883), new ItemInfo(40884), new ItemInfo(40885), new ItemInfo(40886), 
			new ItemInfo(40887), new ItemInfo(40888), new ItemInfo(40889), new ItemInfo(40890), new ItemInfo(40891), new ItemInfo(40892), new ItemInfo(40893), new ItemInfo(40894), new ItemInfo(40895), 
			new ItemInfo(40896), new ItemInfo(40897), new ItemInfo(40898), new ItemInfo(40899), new ItemInfo(40900), new ItemInfo(40901), new ItemInfo(40902), new ItemInfo(40903), new ItemInfo(40904), 
			new ItemInfo(40905), new ItemInfo(40906), new ItemInfo(40907), new ItemInfo(40908), new ItemInfo(40909), new ItemInfo(40910), new ItemInfo(40911), new ItemInfo(40912), new ItemInfo(40913), 
			new ItemInfo(40914), new ItemInfo(40915), new ItemInfo(40916), new ItemInfo(40917), new ItemInfo(40918), new ItemInfo(40919), new ItemInfo(40920), new ItemInfo(40921), new ItemInfo(40922), 
			new ItemInfo(40923), new ItemInfo(40924), new ItemInfo(40925), new ItemInfo(40926), new ItemInfo(40927), new ItemInfo(40928), new ItemInfo(40929), new ItemInfo(40930), new ItemInfo(40931), 
			new ItemInfo(40932), new ItemInfo(40933), new ItemInfo(40934), new ItemInfo(40935), new ItemInfo(40936), new ItemInfo(40937), new ItemInfo(40938), new ItemInfo(40939), new ItemInfo(40940), 
			new ItemInfo(40941), new ItemInfo(40942), new ItemInfo(40943), new ItemInfo(40944), new ItemInfo(40945), new ItemInfo(40946), new ItemInfo(40947), new ItemInfo(40948), new ItemInfo(40949), 
			new ItemInfo(40950), new ItemInfo(40951), new ItemInfo(40952), new ItemInfo(40953), new ItemInfo(40954), new ItemInfo(40955), new ItemInfo(40956), new ItemInfo(40957), new ItemInfo(40959), 
			new ItemInfo(40960), new ItemInfo(40961), new ItemInfo(40962), new ItemInfo(40963), new ItemInfo(40964), new ItemInfo(40965), new ItemInfo(40966), new ItemInfo(40967), new ItemInfo(40968), 
			new ItemInfo(40969), new ItemInfo(40970), new ItemInfo(40971), new ItemInfo(40972), new ItemInfo(40973), new ItemInfo(40974), new ItemInfo(40975), new ItemInfo(40976), new ItemInfo(40977), 
			new ItemInfo(40978), new ItemInfo(40979), new ItemInfo(40980), new ItemInfo(40981), new ItemInfo(40982), new ItemInfo(40983), new ItemInfo(40984), new ItemInfo(40985), new ItemInfo(40986), 
			new ItemInfo(40987), new ItemInfo(40988), new ItemInfo(40989), new ItemInfo(40990), new ItemInfo(40991), new ItemInfo(40992), new ItemInfo(40993), new ItemInfo(40994), new ItemInfo(40995), 
			new ItemInfo(40996), new ItemInfo(40997), new ItemInfo(40998), new ItemInfo(40999), new ItemInfo(41000), new ItemInfo(41001), new ItemInfo(41002), new ItemInfo(41003), new ItemInfo(41004), 
			new ItemInfo(41005), new ItemInfo(41006), new ItemInfo(41007), new ItemInfo(41008), new ItemInfo(41009), new ItemInfo(41010), new ItemInfo(41011), new ItemInfo(41012), new ItemInfo(41013), 
			new ItemInfo(41014), new ItemInfo(41015), new ItemInfo(41016), new ItemInfo(41017), new ItemInfo(41018), new ItemInfo(41019), new ItemInfo(41020), new ItemInfo(41021), new ItemInfo(41022), 
			new ItemInfo(41023), new ItemInfo(41024), new ItemInfo(41025), new ItemInfo(41026), new ItemInfo(41027), new ItemInfo(41028), new ItemInfo(41029), new ItemInfo(41030), new ItemInfo(41031), 
			new ItemInfo(41032), new ItemInfo(41033), new ItemInfo(41034), new ItemInfo(41035), new ItemInfo(41036), new ItemInfo(41037), new ItemInfo(41038), new ItemInfo(41039), new ItemInfo(41040), 
			new ItemInfo(41041), new ItemInfo(41042), new ItemInfo(41043), new ItemInfo(41044), new ItemInfo(41045), new ItemInfo(41046), new ItemInfo(41047), new ItemInfo(41048), new ItemInfo(41049), 
			new ItemInfo(41050), new ItemInfo(41051), new ItemInfo(41052), new ItemInfo(41053), new ItemInfo(41054), new ItemInfo(41055), new ItemInfo(41056), new ItemInfo(41057), new ItemInfo(41058), 
			new ItemInfo(41059), new ItemInfo(41060), new ItemInfo(41061), new ItemInfo(41062), new ItemInfo(41063), new ItemInfo(41064), new ItemInfo(41065), new ItemInfo(41066), new ItemInfo(41067), 
			new ItemInfo(41068), new ItemInfo(41069), new ItemInfo(41070), new ItemInfo(41071), new ItemInfo(41072), new ItemInfo(41073), new ItemInfo(41074), new ItemInfo(41075), new ItemInfo(41076), 
			new ItemInfo(41077), new ItemInfo(41078), new ItemInfo(41079), new ItemInfo(41080), new ItemInfo(41081), new ItemInfo(41082), new ItemInfo(41083), new ItemInfo(41092), new ItemInfo(41093)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt10Gump()
			: this(0)
		{ }

		public AddCustomPt10Gump(int page) 
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

			from.SendGump(new AddCustomPt10Gump(page));
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
