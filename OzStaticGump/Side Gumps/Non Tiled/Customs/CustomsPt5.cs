using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt5Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt5", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt5_OnCommand));
		}

		[Usage("AddCustomPt5")]
		
		public static void AddCustomPt5_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt5Gump>();
			e.Mobile.SendGump(new AddCustomPt5Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(39935), new ItemInfo(39936), new ItemInfo(39937), new ItemInfo(39938), new ItemInfo(39939), new ItemInfo(39940), new ItemInfo(39941), new ItemInfo(39942), new ItemInfo(39943), 
			new ItemInfo(39944), new ItemInfo(39945), new ItemInfo(39946), new ItemInfo(39947), new ItemInfo(39948), new ItemInfo(39949), new ItemInfo(39950), new ItemInfo(39951), new ItemInfo(39952), 
			new ItemInfo(39953), new ItemInfo(39954), new ItemInfo(39955), new ItemInfo(39956), new ItemInfo(39957), new ItemInfo(39958), new ItemInfo(39959), new ItemInfo(39960), new ItemInfo(39961), 
			new ItemInfo(39962), new ItemInfo(39963), new ItemInfo(39964), new ItemInfo(39965), new ItemInfo(39966), new ItemInfo(39967), new ItemInfo(39968), new ItemInfo(39969), new ItemInfo(39970), 
			new ItemInfo(39971), new ItemInfo(39972), new ItemInfo(39973), new ItemInfo(39974), new ItemInfo(39975), new ItemInfo(39976), new ItemInfo(39977), new ItemInfo(39978), new ItemInfo(39979), 
			new ItemInfo(39980), new ItemInfo(39981), new ItemInfo(39982), new ItemInfo(39983), new ItemInfo(39984), new ItemInfo(39985), new ItemInfo(39986), new ItemInfo(39987), new ItemInfo(39988), 
			new ItemInfo(39989), new ItemInfo(39990), new ItemInfo(39991), new ItemInfo(39992), new ItemInfo(39993), new ItemInfo(39994), new ItemInfo(39995), new ItemInfo(39996), new ItemInfo(39997), 
			new ItemInfo(39998), new ItemInfo(39999), new ItemInfo(40000), new ItemInfo(40001), new ItemInfo(40002), new ItemInfo(40003), new ItemInfo(40004), new ItemInfo(40005), new ItemInfo(40006), 
			new ItemInfo(40007), new ItemInfo(40008), new ItemInfo(40009), new ItemInfo(40010), new ItemInfo(40011), new ItemInfo(40012), new ItemInfo(40013), new ItemInfo(40014), new ItemInfo(40015), 
			new ItemInfo(40016), new ItemInfo(40017), new ItemInfo(40018), new ItemInfo(40019), new ItemInfo(40020), new ItemInfo(40021), new ItemInfo(40022), new ItemInfo(40023), new ItemInfo(40024), 
			new ItemInfo(40025), new ItemInfo(40026), new ItemInfo(40027), new ItemInfo(40028), new ItemInfo(40029), new ItemInfo(40030), new ItemInfo(40031), new ItemInfo(40032), new ItemInfo(40033), 
			new ItemInfo(40034), new ItemInfo(40035), new ItemInfo(40036), new ItemInfo(40037), new ItemInfo(40038), new ItemInfo(40039), new ItemInfo(40040), new ItemInfo(40041), new ItemInfo(40042), 
			new ItemInfo(40043), new ItemInfo(40044), new ItemInfo(40045), new ItemInfo(40046), new ItemInfo(40047), new ItemInfo(40048), new ItemInfo(40049), new ItemInfo(40050), new ItemInfo(40051), 
			new ItemInfo(40052), new ItemInfo(40053), new ItemInfo(40054), new ItemInfo(40055), new ItemInfo(40056), new ItemInfo(40057), new ItemInfo(40058), new ItemInfo(40059), new ItemInfo(40060), 
			new ItemInfo(40061), new ItemInfo(40062), new ItemInfo(40063), new ItemInfo(40064), new ItemInfo(40065), new ItemInfo(40066), new ItemInfo(40067), new ItemInfo(40068), new ItemInfo(40069), 
			new ItemInfo(40070), new ItemInfo(40071), new ItemInfo(40072), new ItemInfo(40073), new ItemInfo(40074), new ItemInfo(40075), new ItemInfo(40076), new ItemInfo(40077), new ItemInfo(40078), 
			new ItemInfo(40079), new ItemInfo(40080), new ItemInfo(40081), new ItemInfo(40082), new ItemInfo(40083), new ItemInfo(40084), new ItemInfo(40085), new ItemInfo(40086), new ItemInfo(40087), 
			new ItemInfo(40088), new ItemInfo(40089), new ItemInfo(40090), new ItemInfo(40091), new ItemInfo(40092), new ItemInfo(40093), new ItemInfo(40094), new ItemInfo(40095), new ItemInfo(40096), 
			new ItemInfo(40097), new ItemInfo(40098), new ItemInfo(40099), new ItemInfo(40100), new ItemInfo(40101), new ItemInfo(40102), new ItemInfo(40103), new ItemInfo(40104), new ItemInfo(40105), 
			new ItemInfo(40106), new ItemInfo(40107), new ItemInfo(40108), new ItemInfo(40109), new ItemInfo(40110), new ItemInfo(40111), new ItemInfo(40112), new ItemInfo(40113), new ItemInfo(40114)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt5Gump()
			: this(0)
		{ }

		public AddCustomPt5Gump(int page) 
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

			from.SendGump(new AddCustomPt5Gump(page));
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
