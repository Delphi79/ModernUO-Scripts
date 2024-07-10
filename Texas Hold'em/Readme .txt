/*****************************
 * Name: Texas Hold'em Poker *
 * Modified by: ImaNewb      *
 * For use with ModernUO     *
 * Date: 07/10/2024          *
 *****************************/

=========================================
= ModernUO edits for Texas Holdem Poker =
=========================================

If you have a custom PlayerMobile (PM) or would rather make the edits yourself, here are the instructions to add Texas Holdem Poker functionalities to your ModernUO playermobile script:

1)
=======================
= Add Using Statement =
=======================

Add the following using statement at the top of your PlayerMobile.cs file:

// Texas Holdem
using Server.Poker;
// End Texas Holdem

2)
==================================
= Declare the PokerGame Variable =
==================================

After the line private QuestArrow m_QuestArrow;, insert the following code to declare the PokerGame variable and its property:

// Texas Holdem
private PokerGame m_PokerGame;

public PokerGame PokerGame
{
    get { return m_PokerGame; }
    set { m_PokerGame = value; }
}
// End Texas Holdem

3)
========================
= Modify OnMove Method =
========================

After the line protected override bool OnMove(Direction d), insert the following code to handle the poker game logic:

// Texas Holdem
if (m_PokerGame != null)
{
    if (!HasGump<PokerLeaveGump>())
    {
        SendGump(new PokerLeaveGump(this, m_PokerGame));

        return false;
    }
}
// End Texas Holdem


============
= Commands =
============

"[Add PokerDealer" - Adds the Poker Dealer NPC to the world
"[Add JackpotBoard" - Adds the Poker Jackpot board to the world
"[AddPokerSeat <X Y Z>" - Adds seating coordinates for the poker table
"[PokerKick" - Kicks poker player from the current pokergame

======================
= Setup Instructions =
======================

1) Place the Texas Holdem Scripts into your Custom scripts folder, make sure your playermobile.cs has the outlined edits above.

2) Start Compile and start your ModernUO server

3) When ingame use the command [add pokerdealer

4) use [props on the poker dealer and set the buyin amounts, blind amounts, max players and exit location and map.

5) add a table and some stools or chairs so your players have a place to sit and play. This should be near your Poker Dealer

6) Stand on top of the dealer and specify the poker seats for your players by using the command [AddPokerSeat X Y Z. You must specify the XYZ coordinates of the chait so that when players buy in they are automatically seated. When all the chairs are added use [props on the dealer again and change "Active" from false to true

7) Add the Jackpot board by using the command [add JackpotBoard and place it in the area where poker players will be

8) doubleclick the poker dealer and start playing

