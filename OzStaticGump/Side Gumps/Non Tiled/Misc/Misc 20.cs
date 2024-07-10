using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt20Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt20", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt20_OnCommand));
		}

		[Usage("AddMiscPt20")]
		
		public static void AddMiscPt20_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt20Gump>();
			e.Mobile.SendGump(new AddMiscPt20Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(7719), new ItemInfo(7720), new ItemInfo(7721), new ItemInfo(7722), new ItemInfo(7723), new ItemInfo(7724), new ItemInfo(7725), new ItemInfo(7726), new ItemInfo(7727), 
            new ItemInfo(7728), new ItemInfo(7729), new ItemInfo(7730), new ItemInfo(7731), new ItemInfo(7732), new ItemInfo(7733), new ItemInfo(7734), new ItemInfo(7735), new ItemInfo(7736), 
            new ItemInfo(7737), new ItemInfo(7738), new ItemInfo(7739), new ItemInfo(7740), new ItemInfo(7741), new ItemInfo(7742), new ItemInfo(7743), new ItemInfo(7744), new ItemInfo(7745), 
            new ItemInfo(7746), new ItemInfo(7747), new ItemInfo(7748), new ItemInfo(7749), new ItemInfo(7750), new ItemInfo(7751), new ItemInfo(7752), new ItemInfo(7753), new ItemInfo(7754), 
            new ItemInfo(7755), new ItemInfo(7756), new ItemInfo(7757), new ItemInfo(7758), new ItemInfo(7759), new ItemInfo(7760), new ItemInfo(7761), new ItemInfo(7762), new ItemInfo(7763), 
            new ItemInfo(7764), new ItemInfo(7765), new ItemInfo(7766), new ItemInfo(7767), new ItemInfo(7768), new ItemInfo(7769), new ItemInfo(7770), new ItemInfo(7771), new ItemInfo(7772), 
            new ItemInfo(7773), new ItemInfo(7774), new ItemInfo(7775), new ItemInfo(7776), new ItemInfo(7777), new ItemInfo(7778), new ItemInfo(7779), new ItemInfo(7780), new ItemInfo(7781), 
            new ItemInfo(7782), new ItemInfo(7783), new ItemInfo(7784), new ItemInfo(7785), new ItemInfo(7786), new ItemInfo(7787), new ItemInfo(7788), new ItemInfo(7789), new ItemInfo(7834), 
            new ItemInfo(7835), new ItemInfo(7836), new ItemInfo(7837), new ItemInfo(7838), new ItemInfo(7839), new ItemInfo(7840), new ItemInfo(7841), new ItemInfo(7842), new ItemInfo(7843), 
            new ItemInfo(7844), new ItemInfo(7845), new ItemInfo(7846), new ItemInfo(7847), new ItemInfo(7848), new ItemInfo(7849), new ItemInfo(7850), new ItemInfo(7851), new ItemInfo(7852), 
            new ItemInfo(7853), new ItemInfo(7854), new ItemInfo(7855), new ItemInfo(7856), new ItemInfo(7857), new ItemInfo(7858), new ItemInfo(7859), new ItemInfo(7860), new ItemInfo(7861), 
            new ItemInfo(7862), new ItemInfo(7863), new ItemInfo(7864), new ItemInfo(7865), new ItemInfo(7866), new ItemInfo(7867), new ItemInfo(7868), new ItemInfo(7869), new ItemInfo(7870), 
            new ItemInfo(7871), new ItemInfo(7872), new ItemInfo(7873), new ItemInfo(7874), new ItemInfo(7875), new ItemInfo(7876), new ItemInfo(7877), new ItemInfo(7878), new ItemInfo(7879), 
            new ItemInfo(7880), new ItemInfo(7881), new ItemInfo(7882), new ItemInfo(7883), new ItemInfo(7884), new ItemInfo(7885), new ItemInfo(7886), new ItemInfo(7887), new ItemInfo(7888), 
            new ItemInfo(7889), new ItemInfo(7890), new ItemInfo(7891), new ItemInfo(7892), new ItemInfo(7893), new ItemInfo(7894), new ItemInfo(7895), new ItemInfo(7896), new ItemInfo(7897), 
            new ItemInfo(7898), new ItemInfo(7899), new ItemInfo(7900), new ItemInfo(7901), new ItemInfo(7902), new ItemInfo(7903), new ItemInfo(7904), new ItemInfo(7905), new ItemInfo(7906), 
            new ItemInfo(7907), new ItemInfo(7908), new ItemInfo(7909), new ItemInfo(7910), new ItemInfo(7911), new ItemInfo(7912), new ItemInfo(7913), new ItemInfo(7914), new ItemInfo(7915), 
            new ItemInfo(7916), new ItemInfo(7917), new ItemInfo(7918), new ItemInfo(7919), new ItemInfo(7920), new ItemInfo(7921), new ItemInfo(7922), new ItemInfo(7923), new ItemInfo(7924), 
            new ItemInfo(7925), new ItemInfo(7926), new ItemInfo(7927), new ItemInfo(7928), new ItemInfo(7929), new ItemInfo(7930), new ItemInfo(7931), new ItemInfo(7932), new ItemInfo(7949), 
            new ItemInfo(7950), new ItemInfo(7951), new ItemInfo(7952), new ItemInfo(7953), new ItemInfo(7954), new ItemInfo(7955), new ItemInfo(7956), new ItemInfo(7957), new ItemInfo(7958), 
            new ItemInfo(7959), new ItemInfo(7960), new ItemInfo(7961), new ItemInfo(7962), new ItemInfo(7963), new ItemInfo(7964), new ItemInfo(7965), new ItemInfo(7966), new ItemInfo(7967), 
            new ItemInfo(7968), new ItemInfo(7969), new ItemInfo(7970), new ItemInfo(7971), new ItemInfo(7976), new ItemInfo(7977), new ItemInfo(7978), new ItemInfo(7979), new ItemInfo(7980), 
            new ItemInfo(7981), new ItemInfo(7982), new ItemInfo(7983), new ItemInfo(7984), new ItemInfo(7985), new ItemInfo(7986), new ItemInfo(7987), new ItemInfo(7988), new ItemInfo(7989), 
            new ItemInfo(7990), new ItemInfo(7991), new ItemInfo(7992), new ItemInfo(7993), new ItemInfo(7994), new ItemInfo(7995), new ItemInfo(7996), new ItemInfo(7997), new ItemInfo(7998), 
            new ItemInfo(7999), new ItemInfo(8000), new ItemInfo(8001), new ItemInfo(8002), new ItemInfo(8003), new ItemInfo(8004), new ItemInfo(8005), new ItemInfo(8006), new ItemInfo(8007)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt20Gump()
			: this(0)
		{ }

		public AddMiscPt20Gump(int page) 
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

			from.SendGump(new AddMiscPt20Gump(page));
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
