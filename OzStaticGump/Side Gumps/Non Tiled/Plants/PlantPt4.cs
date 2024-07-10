using Server.Network;

namespace Server.Gumps
{
	public class AddPlantPt4Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddPlantPt4", AccessLevel.GameMaster, new CommandEventHandler(AddPlantPt4_OnCommand));
		}

		[Usage("AddPlantPt4")]
		public static void AddPlantPt4_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddPlantPt4Gump>();
			e.Mobile.SendGump(new AddPlantPt4Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(14821), new ItemInfo(14822), new ItemInfo(14823), new ItemInfo(14824), new ItemInfo(14825), new ItemInfo(14826), new ItemInfo(14827), new ItemInfo(14828), 
            new ItemInfo(14829), new ItemInfo(14830), new ItemInfo(14831), new ItemInfo(14832), new ItemInfo(14833), new ItemInfo(14834), new ItemInfo(14835), new ItemInfo(14836), 
            new ItemInfo(14837), new ItemInfo(14838), new ItemInfo(14839), new ItemInfo(14840), new ItemInfo(14841), new ItemInfo(14842), new ItemInfo(14843), new ItemInfo(14844), 
            new ItemInfo(14845), new ItemInfo(14846), new ItemInfo(14847), new ItemInfo(14848), new ItemInfo(14849), new ItemInfo(14850), new ItemInfo(14851), new ItemInfo(14852), 
            new ItemInfo(14853), new ItemInfo(14854), new ItemInfo(14857), new ItemInfo(14858), new ItemInfo(14859), new ItemInfo(14860), new ItemInfo(14861), new ItemInfo(14862), 
            new ItemInfo(14863), new ItemInfo(14864), new ItemInfo(14865), new ItemInfo(14866), new ItemInfo(14867), new ItemInfo(14868), new ItemInfo(14869), new ItemInfo(14870), 
            new ItemInfo(14871), new ItemInfo(14872), new ItemInfo(14873), new ItemInfo(14874), new ItemInfo(14875), new ItemInfo(14876), new ItemInfo(14877), new ItemInfo(14878), 
            new ItemInfo(14879), new ItemInfo(14880), new ItemInfo(14881), new ItemInfo(14882), new ItemInfo(14883), new ItemInfo(14884), new ItemInfo(14885), new ItemInfo(14886), 
            new ItemInfo(14887), new ItemInfo(14888), new ItemInfo(14889), new ItemInfo(14890), new ItemInfo(14891), new ItemInfo(14892), new ItemInfo(14893), new ItemInfo(14894), 
            new ItemInfo(14895), new ItemInfo(14896), new ItemInfo(14897), new ItemInfo(14898), new ItemInfo(14899), new ItemInfo(14900), new ItemInfo(14901), new ItemInfo(14902), 
            new ItemInfo(14903), new ItemInfo(14904), new ItemInfo(14905), new ItemInfo(14906), new ItemInfo(14907), new ItemInfo(14908), new ItemInfo(14909), new ItemInfo(14910), 
            new ItemInfo(14911), new ItemInfo(14912), new ItemInfo(14913), new ItemInfo(14914), new ItemInfo(14915), new ItemInfo(14916), new ItemInfo(14917), new ItemInfo(14918), 
            new ItemInfo(14919), new ItemInfo(14920), new ItemInfo(14921), new ItemInfo(14922), new ItemInfo(14923), new ItemInfo(14924), new ItemInfo(14925), new ItemInfo(14926), 
            new ItemInfo(14927), new ItemInfo(14928), new ItemInfo(14929), new ItemInfo(14930), new ItemInfo(14931), new ItemInfo(14932), new ItemInfo(15004), new ItemInfo(15005), 
            new ItemInfo(15006), new ItemInfo(15007), new ItemInfo(15008), new ItemInfo(15009), new ItemInfo(15010), new ItemInfo(15011), new ItemInfo(15012), new ItemInfo(15013), 
            new ItemInfo(15014), new ItemInfo(15015), new ItemInfo(15016), new ItemInfo(15017), new ItemInfo(15018), new ItemInfo(15019), new ItemInfo(15020), new ItemInfo(15021), 
            new ItemInfo(15022), new ItemInfo(15023), new ItemInfo(15024), new ItemInfo(15025), new ItemInfo(15026), new ItemInfo(15027), new ItemInfo(15028), new ItemInfo(15029), 
            new ItemInfo(15030), new ItemInfo(15031), new ItemInfo(15032), new ItemInfo(15033), new ItemInfo(15034), new ItemInfo(15035), new ItemInfo(15036), new ItemInfo(15037), 
            new ItemInfo(15038), new ItemInfo(15039), new ItemInfo(15040), new ItemInfo(15041), new ItemInfo(15042), new ItemInfo(15043), new ItemInfo(15044), new ItemInfo(15045), 
            new ItemInfo(15046), new ItemInfo(15047), new ItemInfo(15048), new ItemInfo(15049), new ItemInfo(15050), new ItemInfo(15051), new ItemInfo(15052), new ItemInfo(15053), 
            new ItemInfo(15054), new ItemInfo(15055), new ItemInfo(15056), new ItemInfo(15057), new ItemInfo(15058), new ItemInfo(15059), new ItemInfo(15060), new ItemInfo(15061), 
            new ItemInfo(15062), new ItemInfo(15063), new ItemInfo(15064), new ItemInfo(15065), new ItemInfo(15066), new ItemInfo(15067), new ItemInfo(15068), new ItemInfo(15069), 
            new ItemInfo(15070), new ItemInfo(15071), new ItemInfo(15072), new ItemInfo(15073), new ItemInfo(15074), new ItemInfo(15075), new ItemInfo(15076), new ItemInfo(15077), 
            new ItemInfo(15078), new ItemInfo(15079), new ItemInfo(15080), new ItemInfo(15081), new ItemInfo(15082), new ItemInfo(15083), new ItemInfo(15084), new ItemInfo(15085), 
            new ItemInfo(15086), new ItemInfo(15087)
			
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddPlantPt4Gump()
			: this(0)
		{ }

		public AddPlantPt4Gump(int page) 
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

			from.SendGump(new AddPlantPt4Gump(page));
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
