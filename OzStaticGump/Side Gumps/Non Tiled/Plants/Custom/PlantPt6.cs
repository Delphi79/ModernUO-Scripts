using Server.Network;

namespace Server.Gumps
{
	public class AddPlantPt6Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddPlantPt6", AccessLevel.GameMaster, new CommandEventHandler(AddPlantPt6_OnCommand));
		}

		[Usage("AddPlantPt6")]
		public static void AddPlantPt6_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddPlantPt6Gump>();
			e.Mobile.SendGump(new AddPlantPt6Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(41939), new ItemInfo(41940), new ItemInfo(41941), new ItemInfo(41942), new ItemInfo(41943), new ItemInfo(41944), new ItemInfo(41945), new ItemInfo(41946), 
            new ItemInfo(41947), new ItemInfo(41948), new ItemInfo(41949), new ItemInfo(41950), new ItemInfo(41951), new ItemInfo(41952), new ItemInfo(41953), new ItemInfo(41954), 
            new ItemInfo(41955), new ItemInfo(41956), new ItemInfo(41957), new ItemInfo(41958), new ItemInfo(41959), new ItemInfo(41960), new ItemInfo(41961), new ItemInfo(41962), 
            new ItemInfo(41963), new ItemInfo(41964), new ItemInfo(41965), new ItemInfo(41966), new ItemInfo(41967), new ItemInfo(41968), new ItemInfo(41969), new ItemInfo(41970), 
            new ItemInfo(41971), new ItemInfo(41972), new ItemInfo(41973), new ItemInfo(41974), new ItemInfo(41975), new ItemInfo(41976), new ItemInfo(41977), new ItemInfo(41978), 
            new ItemInfo(41979), new ItemInfo(41980), new ItemInfo(41981), new ItemInfo(41982), new ItemInfo(41983), new ItemInfo(41984), new ItemInfo(41985), new ItemInfo(41986), 
            new ItemInfo(41987), new ItemInfo(41988), new ItemInfo(41989), new ItemInfo(41990), new ItemInfo(41991), new ItemInfo(41992), new ItemInfo(41993), new ItemInfo(41994), 
            new ItemInfo(41995), new ItemInfo(41996), new ItemInfo(41997), new ItemInfo(41998), new ItemInfo(41999), new ItemInfo(42000), new ItemInfo(42001), new ItemInfo(42002), 
            new ItemInfo(42003), new ItemInfo(42004), new ItemInfo(42005), new ItemInfo(42006), new ItemInfo(42007), new ItemInfo(42008), new ItemInfo(42009), new ItemInfo(42010), 
            new ItemInfo(42011), new ItemInfo(42012), new ItemInfo(42013), new ItemInfo(42014), new ItemInfo(42015), new ItemInfo(42016), new ItemInfo(42017), new ItemInfo(42018), 
            new ItemInfo(42019), new ItemInfo(42020), new ItemInfo(42021), new ItemInfo(42022), new ItemInfo(42023), new ItemInfo(42024), new ItemInfo(42025), new ItemInfo(42026), 
            new ItemInfo(42027), new ItemInfo(42028), new ItemInfo(42029), new ItemInfo(42030), new ItemInfo(42031), new ItemInfo(42032), new ItemInfo(42033), new ItemInfo(42034), 
            new ItemInfo(42035), new ItemInfo(42036), new ItemInfo(42037), new ItemInfo(42038), new ItemInfo(42039), new ItemInfo(42040), new ItemInfo(42041), new ItemInfo(42042), 
            new ItemInfo(42043), new ItemInfo(42044), new ItemInfo(42045), new ItemInfo(42046), new ItemInfo(42047), new ItemInfo(42048), new ItemInfo(42049), new ItemInfo(42050), 
            new ItemInfo(42051), new ItemInfo(42052), new ItemInfo(42053), new ItemInfo(42054), new ItemInfo(42055), new ItemInfo(42056), new ItemInfo(42057), new ItemInfo(42058), 
            new ItemInfo(42059), new ItemInfo(42060), new ItemInfo(42061), new ItemInfo(42062), new ItemInfo(42063), new ItemInfo(42064), new ItemInfo(42065), new ItemInfo(42066), 
            new ItemInfo(42067), new ItemInfo(42068), new ItemInfo(42069), new ItemInfo(42070), new ItemInfo(42071), new ItemInfo(42072), new ItemInfo(42073), new ItemInfo(42074), 
            new ItemInfo(42075), new ItemInfo(42076), new ItemInfo(42077), new ItemInfo(42078), new ItemInfo(42079), new ItemInfo(42080), new ItemInfo(42081), new ItemInfo(42082), 
            new ItemInfo(42083), new ItemInfo(42084), new ItemInfo(42085), new ItemInfo(42086), new ItemInfo(42087), new ItemInfo(42088), new ItemInfo(42089), new ItemInfo(42090), 
            new ItemInfo(42091), new ItemInfo(42092), new ItemInfo(42093), new ItemInfo(42094), new ItemInfo(42095), new ItemInfo(42096), new ItemInfo(42097), new ItemInfo(42098), 
            new ItemInfo(42099), new ItemInfo(42100), new ItemInfo(42101), new ItemInfo(42102), new ItemInfo(42103), new ItemInfo(42104), new ItemInfo(42105), new ItemInfo(42106), 
            new ItemInfo(42107), new ItemInfo(42108), new ItemInfo(42109), new ItemInfo(42110), new ItemInfo(42111), new ItemInfo(42112), new ItemInfo(42113), new ItemInfo(42114)
			
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddPlantPt6Gump()
			: this(0)
		{ }

		public AddPlantPt6Gump(int page) 
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

			from.SendGump(new AddPlantPt6Gump(page));
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
