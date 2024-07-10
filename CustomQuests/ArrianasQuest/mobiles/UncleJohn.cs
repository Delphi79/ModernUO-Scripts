/****************************************
 * Original Author Unknown              *
 * Updated for MUO by Admin Delphi      *
 * For use with ModernUO                *
 * Date: June 8, 2024                   *
 ****************************************/

using Server.Items;
using Server.ContextMenus;
using Server.Gumps;
using System.Collections.Generic;


namespace Server.Mobiles
{
    [CorpseName( "UncleJohn corpse" )]
    public class UncleJohn : Mobile
    {
        public virtual bool IsInvulnerable{ get{ return true; } }
        [Constructible]
        public UncleJohn()
        {
            Name = "Uncle John";
            Title = "the farming fool";
            Body = 0x190;
            Hue = Race.Human.RandomSkinHue();
            HairItemID = 0x203C; // LongHair
            HairHue = 1337;

            Boots b = new Boots();
            b.Hue = 1;
            AddItem( b );

            LongPants lp = new LongPants();
            lp.Hue = 292;
            AddItem( lp );

            FancyShirt fs = new FancyShirt();
            fs.Hue = 1153;
            AddItem( fs );

            Pitchfork pf = new Pitchfork();
            AddItem( pf );



        }

        public UncleJohn( Serial serial ) : base( serial )
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries( from, list );
            list.Add( new UncleJohnEntry( from, this ) );
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 );
        }

        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }

        public class UncleJohnEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public UncleJohnEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {


                if( !( m_Mobile is PlayerMobile ) )
                    return;

                PlayerMobile mobile = (PlayerMobile) m_Mobile;

                {
                    if ( ! mobile.HasGump<UncleJohnGump>() )
                    {
                        mobile.SendGump( new UncleJohnGump( mobile ));
                        //

                    }
                }
            }
        }

        public override bool OnDragDrop( Mobile from, Item dropped )
        {
            Mobile m = from;
            PlayerMobile mobile = m as PlayerMobile;

            if ( mobile != null)
            {
                if( dropped is Greencarrot )
                {
                    if(dropped.Amount!=1)
                    {
                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "thanks for helping with that pesky rabbit!", mobile.NetState );
                        return false;
                    }

                    dropped.Delete();

                    mobile.AddToBackpack( new ArrianasDiamond() );
                    mobile.AddToBackpack( new UncleJohnsBook() );
                    mobile.SendMessage( "Thanks for getting my carrot!" );


                    return true;
                }
                else if ( dropped is Greencarrot )
                {
                    this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
                    return false;
                }
                else
                {
                    this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Why on earth would I want to have that?", mobile.NetState );
                }
            }
            return false;
        }
    }
}
