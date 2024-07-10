using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt1Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt1", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt1_OnCommand));
		}

		[Usage("AddCustomPt1")]
		
		public static void AddCustomPt1_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt1Gump>();
			e.Mobile.SendGump(new AddCustomPt1Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(39214), new ItemInfo(39215), new ItemInfo(39216), new ItemInfo(39217), new ItemInfo(39218), new ItemInfo(39219), new ItemInfo(39220), new ItemInfo(39221), new ItemInfo(39222), 
			new ItemInfo(39223), new ItemInfo(39224), new ItemInfo(39225), new ItemInfo(39226), new ItemInfo(39227), new ItemInfo(39228), new ItemInfo(39229), new ItemInfo(39230), new ItemInfo(39231), 
			new ItemInfo(39232), new ItemInfo(39233), new ItemInfo(39234), new ItemInfo(39235), new ItemInfo(39236), new ItemInfo(39237), new ItemInfo(39238), new ItemInfo(39239), new ItemInfo(39240), 
			new ItemInfo(39241), new ItemInfo(39242), new ItemInfo(39243), new ItemInfo(39244), new ItemInfo(39245), new ItemInfo(39246), new ItemInfo(39247), new ItemInfo(39248), new ItemInfo(39249), 
			new ItemInfo(39250), new ItemInfo(39251), new ItemInfo(39252), new ItemInfo(39253), new ItemInfo(39254), new ItemInfo(39255), new ItemInfo(39256), new ItemInfo(39257), new ItemInfo(39258), 
			new ItemInfo(39259), new ItemInfo(39260), new ItemInfo(39261), new ItemInfo(39262), new ItemInfo(39263), new ItemInfo(39264), new ItemInfo(39265), new ItemInfo(39266), new ItemInfo(39267), 
			new ItemInfo(39268), new ItemInfo(39269), new ItemInfo(39270), new ItemInfo(39271), new ItemInfo(39272), new ItemInfo(39273), new ItemInfo(39274), new ItemInfo(39275), new ItemInfo(39276), 
			new ItemInfo(39277), new ItemInfo(39278), new ItemInfo(39279), new ItemInfo(39280), new ItemInfo(39281), new ItemInfo(39282), new ItemInfo(39283), new ItemInfo(39284), new ItemInfo(39285), 
			new ItemInfo(39286), new ItemInfo(39287), new ItemInfo(39288), new ItemInfo(39289), new ItemInfo(39290), new ItemInfo(39291), new ItemInfo(39292), new ItemInfo(39293), new ItemInfo(39294), 
			new ItemInfo(39295), new ItemInfo(39296), new ItemInfo(39297), new ItemInfo(39298), new ItemInfo(39299), new ItemInfo(39300), new ItemInfo(39301), new ItemInfo(39302), new ItemInfo(39303), 
			new ItemInfo(39304), new ItemInfo(39305), new ItemInfo(39306), new ItemInfo(39307), new ItemInfo(39308), new ItemInfo(39309), new ItemInfo(39310), new ItemInfo(39311), new ItemInfo(39312), 
			new ItemInfo(39313), new ItemInfo(39314), new ItemInfo(39315), new ItemInfo(39316), new ItemInfo(39317), new ItemInfo(39318), new ItemInfo(39319), new ItemInfo(39320), new ItemInfo(39321), 
			new ItemInfo(39322), new ItemInfo(39323), new ItemInfo(39324), new ItemInfo(39325), new ItemInfo(39326), new ItemInfo(39327), new ItemInfo(39328), new ItemInfo(39329), new ItemInfo(39330), 
			new ItemInfo(39331), new ItemInfo(39332), new ItemInfo(39333), new ItemInfo(39334), new ItemInfo(39335), new ItemInfo(39336), new ItemInfo(39337), new ItemInfo(39338), new ItemInfo(39339), 
			new ItemInfo(39340), new ItemInfo(39341), new ItemInfo(39342), new ItemInfo(39343), new ItemInfo(39344), new ItemInfo(39345), new ItemInfo(39346), new ItemInfo(39347), new ItemInfo(39348), 
			new ItemInfo(39349), new ItemInfo(39350), new ItemInfo(39351), new ItemInfo(39352), new ItemInfo(39353), new ItemInfo(39354), new ItemInfo(39355), new ItemInfo(39356), new ItemInfo(39357), 
			new ItemInfo(39358), new ItemInfo(39359), new ItemInfo(39360), new ItemInfo(39361), new ItemInfo(39362), new ItemInfo(39363), new ItemInfo(39364), new ItemInfo(39365), new ItemInfo(39366), 
			new ItemInfo(39367), new ItemInfo(39368), new ItemInfo(39369), new ItemInfo(39370), new ItemInfo(39371), new ItemInfo(39372), new ItemInfo(39373), new ItemInfo(39374), new ItemInfo(39375), 
			new ItemInfo(39376), new ItemInfo(39377), new ItemInfo(39378), new ItemInfo(39379), new ItemInfo(39380), new ItemInfo(39381), new ItemInfo(39382), new ItemInfo(39383), new ItemInfo(39384), 
			new ItemInfo(39385), new ItemInfo(39386), new ItemInfo(39387), new ItemInfo(39388), new ItemInfo(39389), new ItemInfo(39390), new ItemInfo(39391), new ItemInfo(39392), new ItemInfo(39393)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt1Gump()
			: this(0)
		{ }

		public AddCustomPt1Gump(int page) 
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

			from.SendGump(new AddCustomPt1Gump(page));
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
