using Server.Network;

namespace Server.Gumps
{
	public class AddWallPt1Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddWallPt1", AccessLevel.GameMaster, new CommandEventHandler(AddWallPt1_OnCommand));
		}

		[Usage("AddWallPt1")]
		
		public static void AddWallPt1_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddWallPt1Gump>();
			e.Mobile.SendGump(new AddWallPt1Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(6), new ItemInfo(7), new ItemInfo(8), new ItemInfo(9), new ItemInfo(10), new ItemInfo(11), new ItemInfo(12), new ItemInfo(13), new ItemInfo(14), new ItemInfo(15), 
            new ItemInfo(16), new ItemInfo(17), new ItemInfo(18), new ItemInfo(19), new ItemInfo(20), new ItemInfo(21), new ItemInfo(22), new ItemInfo(23), new ItemInfo(24), new ItemInfo(25), 
            new ItemInfo(26), new ItemInfo(27), new ItemInfo(28), new ItemInfo(29), new ItemInfo(30), new ItemInfo(31), new ItemInfo(32), new ItemInfo(33), new ItemInfo(34), new ItemInfo(35), 
            new ItemInfo(36), new ItemInfo(37), new ItemInfo(38), new ItemInfo(39), new ItemInfo(45), new ItemInfo(46), new ItemInfo(47), new ItemInfo(48), new ItemInfo(49), new ItemInfo(50), 
            new ItemInfo(51), new ItemInfo(52), new ItemInfo(53), new ItemInfo(54), new ItemInfo(55), new ItemInfo(56), new ItemInfo(57), new ItemInfo(58), new ItemInfo(59), new ItemInfo(60), 
            new ItemInfo(61), new ItemInfo(62), new ItemInfo(63), new ItemInfo(64), new ItemInfo(65), new ItemInfo(66), new ItemInfo(67), new ItemInfo(68), new ItemInfo(74), new ItemInfo(75), 
            new ItemInfo(76), new ItemInfo(77), new ItemInfo(78), new ItemInfo(79), new ItemInfo(80), new ItemInfo(81), new ItemInfo(82), new ItemInfo(83), new ItemInfo(84), new ItemInfo(85), 
            new ItemInfo(86), new ItemInfo(87), new ItemInfo(88), new ItemInfo(89), new ItemInfo(90), new ItemInfo(91), new ItemInfo(92), new ItemInfo(93), new ItemInfo(94), new ItemInfo(95), 
            new ItemInfo(96), new ItemInfo(97), new ItemInfo(98), new ItemInfo(99), new ItemInfo(100), new ItemInfo(101), new ItemInfo(102), new ItemInfo(103), new ItemInfo(104), new ItemInfo(105), 
            new ItemInfo(106), new ItemInfo(107), new ItemInfo(108), new ItemInfo(128), new ItemInfo(129), new ItemInfo(130), new ItemInfo(131), new ItemInfo(132), new ItemInfo(133), new ItemInfo(140), 
            new ItemInfo(141), new ItemInfo(142), new ItemInfo(143), new ItemInfo(144), new ItemInfo(145), new ItemInfo(146), new ItemInfo(147), new ItemInfo(148), new ItemInfo(149), new ItemInfo(150), 
            new ItemInfo(151), new ItemInfo(152), new ItemInfo(153), new ItemInfo(154), new ItemInfo(155), new ItemInfo(156), new ItemInfo(157), new ItemInfo(158), new ItemInfo(159), new ItemInfo(160), 
            new ItemInfo(161), new ItemInfo(162), new ItemInfo(163), new ItemInfo(164), new ItemInfo(165), new ItemInfo(166), new ItemInfo(167), new ItemInfo(168), new ItemInfo(169), new ItemInfo(170), 
            new ItemInfo(171), new ItemInfo(172), new ItemInfo(173), new ItemInfo(174), new ItemInfo(175), new ItemInfo(176), new ItemInfo(177), new ItemInfo(178), new ItemInfo(179), new ItemInfo(180), 
            new ItemInfo(181), new ItemInfo(182), new ItemInfo(183), new ItemInfo(184), new ItemInfo(185), new ItemInfo(186), new ItemInfo(187), new ItemInfo(188), new ItemInfo(189), new ItemInfo(190), 
            new ItemInfo(191), new ItemInfo(192), new ItemInfo(193), new ItemInfo(194), new ItemInfo(197), new ItemInfo(199), new ItemInfo(200), new ItemInfo(201), new ItemInfo(202), new ItemInfo(203), 
            new ItemInfo(204), new ItemInfo(248), new ItemInfo(249), new ItemInfo(250), new ItemInfo(251), new ItemInfo(252), new ItemInfo(253), new ItemInfo(254), new ItemInfo(255), new ItemInfo(256), 
            new ItemInfo(257), new ItemInfo(258), new ItemInfo(259), new ItemInfo(260), new ItemInfo(261), new ItemInfo(262), new ItemInfo(263), new ItemInfo(264), new ItemInfo(265), new ItemInfo(266), 
            new ItemInfo(267), new ItemInfo(268), new ItemInfo(269), new ItemInfo(270), new ItemInfo(271), new ItemInfo(272), new ItemInfo(273), new ItemInfo(283), new ItemInfo(284), new ItemInfo(285), 
            new ItemInfo(286), new ItemInfo(287), new ItemInfo(288), new ItemInfo(289), new ItemInfo(290), new ItemInfo(291), new ItemInfo(292), new ItemInfo(293), new ItemInfo(294), new ItemInfo(295), 
            new ItemInfo(296), new ItemInfo(297), new ItemInfo(298), new ItemInfo(299), new ItemInfo(300), new ItemInfo(301), new ItemInfo(302), new ItemInfo(303), new ItemInfo(304), new ItemInfo(305), 
            new ItemInfo(306), new ItemInfo(307), new ItemInfo(308), new ItemInfo(309), new ItemInfo(310), new ItemInfo(311), new ItemInfo(312), new ItemInfo(313), new ItemInfo(314), new ItemInfo(315),
            new ItemInfo(332), new ItemInfo(333), new ItemInfo(334), new ItemInfo(335), new ItemInfo(336), new ItemInfo(337), new ItemInfo(338), new ItemInfo(339), new ItemInfo(340), new ItemInfo(341), 
            new ItemInfo(342), new ItemInfo(343), new ItemInfo(344), new ItemInfo(345), new ItemInfo(346), new ItemInfo(347), new ItemInfo(348), new ItemInfo(349), new ItemInfo(350), new ItemInfo(351), 
            new ItemInfo(352), new ItemInfo(353), new ItemInfo(354), new ItemInfo(355), new ItemInfo(356), new ItemInfo(357), new ItemInfo(358), new ItemInfo(359), new ItemInfo(360), new ItemInfo(361), 
            new ItemInfo(362), new ItemInfo(363), new ItemInfo(369), new ItemInfo(370), new ItemInfo(371), new ItemInfo(372), new ItemInfo(373), new ItemInfo(374), new ItemInfo(375), new ItemInfo(376), 
            new ItemInfo(377), new ItemInfo(378), new ItemInfo(379), new ItemInfo(380), new ItemInfo(381), new ItemInfo(382), new ItemInfo(383), new ItemInfo(384), new ItemInfo(385), new ItemInfo(386), 
            new ItemInfo(387), new ItemInfo(388), new ItemInfo(389), new ItemInfo(390), new ItemInfo(391), new ItemInfo(392), new ItemInfo(393), new ItemInfo(394), new ItemInfo(395), new ItemInfo(396), 
            new ItemInfo(397), new ItemInfo(398), new ItemInfo(399), new ItemInfo(400), new ItemInfo(401), new ItemInfo(402), new ItemInfo(403), new ItemInfo(404), new ItemInfo(405), new ItemInfo(406), 
            new ItemInfo(407), new ItemInfo(408), new ItemInfo(409), new ItemInfo(410), new ItemInfo(411), new ItemInfo(412), new ItemInfo(413), new ItemInfo(414), new ItemInfo(415), new ItemInfo(416), 
            new ItemInfo(417), new ItemInfo(418), new ItemInfo(419), new ItemInfo(420), new ItemInfo(421), new ItemInfo(422), new ItemInfo(423), new ItemInfo(424), new ItemInfo(425), new ItemInfo(426), 
            new ItemInfo(427), new ItemInfo(428), new ItemInfo(429), new ItemInfo(430), new ItemInfo(431), new ItemInfo(432), new ItemInfo(433), new ItemInfo(434), new ItemInfo(435), new ItemInfo(436), 
            new ItemInfo(437), new ItemInfo(438), new ItemInfo(439), new ItemInfo(440), new ItemInfo(441), new ItemInfo(442), new ItemInfo(443), new ItemInfo(444), new ItemInfo(445), new ItemInfo(446), 
            new ItemInfo(447), new ItemInfo(448), new ItemInfo(449), new ItemInfo(450), new ItemInfo(451), new ItemInfo(452), new ItemInfo(453), new ItemInfo(454), new ItemInfo(455), new ItemInfo(456), 
            new ItemInfo(457), new ItemInfo(458), new ItemInfo(459), new ItemInfo(460), new ItemInfo(461), new ItemInfo(462), new ItemInfo(463), new ItemInfo(464), new ItemInfo(465), new ItemInfo(466), 
            new ItemInfo(467), new ItemInfo(468), new ItemInfo(480), new ItemInfo(481), new ItemInfo(482), new ItemInfo(483), new ItemInfo(484), new ItemInfo(485), new ItemInfo(486), new ItemInfo(487), 
            new ItemInfo(488), new ItemInfo(489), new ItemInfo(490), new ItemInfo(491), new ItemInfo(492), new ItemInfo(493), new ItemInfo(494), new ItemInfo(495), new ItemInfo(496), new ItemInfo(497), 
            new ItemInfo(498), new ItemInfo(499), new ItemInfo(500), new ItemInfo(501), new ItemInfo(502), new ItemInfo(503), new ItemInfo(504), new ItemInfo(505), new ItemInfo(511), new ItemInfo(512), 
            new ItemInfo(513), new ItemInfo(514), new ItemInfo(515), new ItemInfo(516), new ItemInfo(517), new ItemInfo(518), new ItemInfo(519), new ItemInfo(520), new ItemInfo(521), new ItemInfo(522), 
            new ItemInfo(523), new ItemInfo(524), new ItemInfo(527), new ItemInfo(528), new ItemInfo(529), new ItemInfo(530), new ItemInfo(531), new ItemInfo(532), new ItemInfo(533), new ItemInfo(534), 
            new ItemInfo(535), new ItemInfo(536), new ItemInfo(537), new ItemInfo(538), new ItemInfo(541), new ItemInfo(542), new ItemInfo(543), new ItemInfo(544), new ItemInfo(545), new ItemInfo(546), 
            new ItemInfo(547), new ItemInfo(550), new ItemInfo(551), new ItemInfo(552), new ItemInfo(553), new ItemInfo(554), new ItemInfo(555), new ItemInfo(556), new ItemInfo(557), new ItemInfo(558), 
            new ItemInfo(559), new ItemInfo(560), new ItemInfo(561), new ItemInfo(562), new ItemInfo(563), new ItemInfo(564), new ItemInfo(565), new ItemInfo(566), new ItemInfo(567), new ItemInfo(568), 
            new ItemInfo(569), new ItemInfo(577), new ItemInfo(578), new ItemInfo(579), new ItemInfo(580), new ItemInfo(588), new ItemInfo(589), new ItemInfo(590), new ItemInfo(591), new ItemInfo(592)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddWallPt1Gump()
			: this(0)
		{ }

		public AddWallPt1Gump(int page) 
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

				CommandSystem.Handle(from, string.Format("{0}Tile Static {1}", CommandSystem.Prefix, m_Types[button].m_BaseID));
			}
			else if (button >= 10000)
			{
				button -= 10000;

				page = button;
			}

			from.SendGump(new AddWallPt1Gump(page));
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
