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
    [CorpseName( "Grandpa Tam's corpse" )]
    public class GrandpaTam : Mobile
    {
        public virtual bool IsInvulnerable{ get{ return true; } }
        [Constructible]
        public GrandpaTam()
        {
            Name = "Grandpa Tam";
            Title = "the old coot";
            Body = 0x190;
            Hue = Race.Human.RandomSkinHue();
            HairItemID = 0x203C; // LongHair
            HairHue = 1150;

            Boots b = new Boots();
            b.Hue = 1;
            AddItem( b );

            LongPants lp = new LongPants();
            lp.Hue = 292;
            AddItem( lp );

            FancyShirt fs = new FancyShirt();
            fs.Hue = 1153;
            AddItem( fs );


        }

        public GrandpaTam( Serial serial ) : base( serial )
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries( from, list );
            list.Add( new GrandpaTamEntry( from, this ) );
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

        public class GrandpaTamEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public GrandpaTamEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
                    if ( ! mobile.HasGump<GrandpaTamGump>() )
                    {
                        mobile.SendGump( new GrandpaTamGump( mobile ));
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
                if( dropped is Goldenegg )
                {
                    if(dropped.Amount!=1)
                    {
                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "my egg!", mobile.NetState );
                        return false;
                    }

                    dropped.Delete();

                    mobile.AddToBackpack( new ArrianasHoops() );
                    mobile.AddToBackpack( new GrandpaTamsJournal() );
                    mobile.SendMessage( "Good luck to you!" );



                    return true;
                }
                else if ( dropped is Goldenegg )
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
