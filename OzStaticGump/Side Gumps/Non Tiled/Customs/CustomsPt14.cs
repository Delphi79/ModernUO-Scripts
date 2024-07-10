using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt14Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt14", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt14_OnCommand));
		}

		[Usage("AddCustomPt14")]
		
		public static void AddCustomPt14_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt14Gump>();
			e.Mobile.SendGump(new AddCustomPt14Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(41827), new ItemInfo(41828), new ItemInfo(41829), new ItemInfo(41830), new ItemInfo(41831), new ItemInfo(41832), new ItemInfo(41833), new ItemInfo(41834), new ItemInfo(41835), 
			new ItemInfo(41836), new ItemInfo(41837), new ItemInfo(41838), new ItemInfo(41839), new ItemInfo(41840), new ItemInfo(41841), new ItemInfo(41842), new ItemInfo(41843), new ItemInfo(41844), 
			new ItemInfo(41845), new ItemInfo(41846), new ItemInfo(41847), new ItemInfo(41848), new ItemInfo(41849), new ItemInfo(41850), new ItemInfo(41851), new ItemInfo(41852), new ItemInfo(41853), 
			new ItemInfo(41854), new ItemInfo(41855), new ItemInfo(41856), new ItemInfo(41857), new ItemInfo(41858), new ItemInfo(41859), new ItemInfo(41860), new ItemInfo(41861), new ItemInfo(41862), 
			new ItemInfo(41863), new ItemInfo(41864), new ItemInfo(41865), new ItemInfo(41866), new ItemInfo(41867), new ItemInfo(41868), new ItemInfo(41869), new ItemInfo(41870), new ItemInfo(41871), 
			new ItemInfo(41872), new ItemInfo(41873), new ItemInfo(41874), new ItemInfo(41875), new ItemInfo(41876), new ItemInfo(41877), new ItemInfo(41878), new ItemInfo(41879), new ItemInfo(41880), 
			new ItemInfo(41881), new ItemInfo(41882), new ItemInfo(41883), new ItemInfo(41884), new ItemInfo(41885), new ItemInfo(41886), new ItemInfo(41887), new ItemInfo(41888), new ItemInfo(41889), 
			new ItemInfo(41890), new ItemInfo(41891), new ItemInfo(41892), new ItemInfo(41893), new ItemInfo(41894), new ItemInfo(41895), new ItemInfo(41896), new ItemInfo(41897), new ItemInfo(41898), 
			new ItemInfo(41899), new ItemInfo(41900), new ItemInfo(41901), new ItemInfo(41902), new ItemInfo(41903), new ItemInfo(41904), new ItemInfo(41905), new ItemInfo(41906), new ItemInfo(41907), 
			new ItemInfo(41908), new ItemInfo(41909), new ItemInfo(41910), new ItemInfo(41911), new ItemInfo(41912), new ItemInfo(41913), new ItemInfo(41914), new ItemInfo(41915), new ItemInfo(41916), 
			new ItemInfo(41917), new ItemInfo(41918), new ItemInfo(41919), new ItemInfo(41920), new ItemInfo(41921), new ItemInfo(41922), new ItemInfo(41923), new ItemInfo(41924), new ItemInfo(41925), 
			new ItemInfo(41926), new ItemInfo(41927), new ItemInfo(41928), new ItemInfo(41929), new ItemInfo(41930), new ItemInfo(41931), new ItemInfo(41932), new ItemInfo(41933), new ItemInfo(41934), 
			new ItemInfo(41935), new ItemInfo(41936), new ItemInfo(41937), new ItemInfo(41938), new ItemInfo(41939), new ItemInfo(41940), new ItemInfo(41941), new ItemInfo(41942), new ItemInfo(41943), 
			new ItemInfo(41944), new ItemInfo(41945), new ItemInfo(41946), new ItemInfo(41947), new ItemInfo(41948), new ItemInfo(41949), new ItemInfo(41950), new ItemInfo(41951), new ItemInfo(41952), 
			new ItemInfo(41953), new ItemInfo(41954), new ItemInfo(41955), new ItemInfo(41956), new ItemInfo(41957), new ItemInfo(41958), new ItemInfo(41959), new ItemInfo(41960), new ItemInfo(41961), 
			new ItemInfo(41962), new ItemInfo(41963), new ItemInfo(41964), new ItemInfo(41965), new ItemInfo(41966), new ItemInfo(41967), new ItemInfo(41968), new ItemInfo(41969), new ItemInfo(41970), 
			new ItemInfo(41971), new ItemInfo(41972), new ItemInfo(41973), new ItemInfo(41974), new ItemInfo(41975), new ItemInfo(41976), new ItemInfo(41977), new ItemInfo(41978), new ItemInfo(41979), 
			new ItemInfo(41980), new ItemInfo(41981), new ItemInfo(41982), new ItemInfo(41983), new ItemInfo(41984), new ItemInfo(41985), new ItemInfo(41986), new ItemInfo(41987), new ItemInfo(41988), 
			new ItemInfo(41989), new ItemInfo(41990), new ItemInfo(41991), new ItemInfo(41992), new ItemInfo(41993), new ItemInfo(41994), new ItemInfo(41995), new ItemInfo(41996), new ItemInfo(41997), 
			new ItemInfo(41998), new ItemInfo(41999), new ItemInfo(42000), new ItemInfo(42001), new ItemInfo(42002), new ItemInfo(42003), new ItemInfo(42004), new ItemInfo(42005), new ItemInfo(42006), 
			new ItemInfo(42007), new ItemInfo(42008), new ItemInfo(42009), new ItemInfo(42010), new ItemInfo(42011), new ItemInfo(42012), new ItemInfo(42013), new ItemInfo(42014), new ItemInfo(42015), 
			new ItemInfo(42016), new ItemInfo(42017), new ItemInfo(42018), new ItemInfo(42019), new ItemInfo(42020), new ItemInfo(42021), new ItemInfo(42022), new ItemInfo(42023), new ItemInfo(42024), 
			new ItemInfo(42025), new ItemInfo(42026), new ItemInfo(42027), new ItemInfo(42028), new ItemInfo(42029), new ItemInfo(42030), new ItemInfo(42031), new ItemInfo(42032), new ItemInfo(42033), 
			new ItemInfo(42034), new ItemInfo(42035), new ItemInfo(42036), new ItemInfo(42037), new ItemInfo(42038), new ItemInfo(42039), new ItemInfo(42040), new ItemInfo(42041), new ItemInfo(42042), 
			new ItemInfo(42043), new ItemInfo(42044), new ItemInfo(42045), new ItemInfo(42046), new ItemInfo(42047), new ItemInfo(42048), new ItemInfo(42049), new ItemInfo(42050), new ItemInfo(42051)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt14Gump()
			: this(0)
		{ }

		public AddCustomPt14Gump(int page) 
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

			from.SendGump(new AddCustomPt14Gump(page));
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
