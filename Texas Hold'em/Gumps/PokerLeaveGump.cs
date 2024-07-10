/*****************************
 * Name: Texas Hold'em Poker *
 * Modified by: ImaNewb      *
 * For use with ModernUO     *
 * Date: 07/10/2024          *
 *****************************/

using Server.Gumps;
using Server.Network;

namespace Server.Poker
{
    public class PokerLeaveGump : Gump
    {
        private PokerGame m_Game;

        public PokerLeaveGump( Mobile from, PokerGame game )
            : base( 50, 50 )
        {
            m_Game = game;

            this.Closable = true;
            this.Disposable = true;
            this.Draggable = true;
            this.Resizable = false;
            this.AddPage( 0 );
            this.AddImageTiled( 18, 15, 350, 180, 9274 );
            this.AddAlphaRegion( 23, 20, 340, 170 );
            this.AddLabel( 133, 25, 1149, @"Leave Poker Table" );
            this.AddImageTiled( 42, 47, 301, 3, 96 );
            this.AddLabel( 60, 62, 154, @"You are about to leave a game of Poker." );
            this.AddImage( 33, 38, 95 );
            this.AddImage( 342, 38, 97 );
            this.AddLabel( 48, 80, 154, @"Are you sure you want to cash-out and leave the" );
            this.AddLabel( 48, 98, 154, @"table? You will auto fold, and any current bets" );
            this.AddLabel( 48, 116, 154, @"will be lost. Winnings will be deposited in your bank." );
            this.AddButton( 163, 155, 247, 248, (int)Handlers.btnOkay, GumpButtonType.Reply, 0 );
        }

        public enum Handlers
        {
            None,
            btnOkay
        }

        public override void OnResponse( NetState state, in RelayInfo info )
        {
            Mobile from = state.Mobile;

            if ( from == null )
                return;

            PokerPlayer player = m_Game.GetPlayer( from );

            if ( player != null )
            {
                if ( info.ButtonID == 1 )
                {
                    if ( m_Game.State == PokerGameState.Inactive )
                    {
                        if ( m_Game.Players.Contains( player ) )
                            m_Game.RemovePlayer( player );
                        return;
                    }


                    if ( player.RequestLeave )
                        from.SendMessage( 0x22, "You have already submitted a request to leave." );
                    else
                    {
                        from.SendMessage( 0x22, "You have submitted a request to leave the table." );
                        player.RequestLeave = true;
                    }
                }
            }
        }
    }
}
