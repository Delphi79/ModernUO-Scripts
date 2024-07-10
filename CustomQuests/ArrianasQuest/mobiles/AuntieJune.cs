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
    [CorpseName( "AuntieJune corpse" )]
    public class AuntieJune : Mobile
    {
        public virtual bool IsInvulnerable{ get{ return true; } }
        [Constructible]
        public AuntieJune()
        {
            Name = "Auntie June";
            Title = "the biofarmer";
            Body = 0x191;
            Hue = Race.Human.RandomSkinHue();
            HairItemID = 0x203C; // LongHair
            HairHue = 91;

            Robe r = new Robe();
            r.Hue = 1156;
            AddItem( r );

        }

        public AuntieJune( Serial serial ) : base( serial )
        {
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries( from, list );
            list.Add( new AuntieJuneEntry( from, this ) );
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

        public class AuntieJuneEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public AuntieJuneEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
                    if ( ! mobile.HasGump<AuntieJuneGump>() )
                    {
                        mobile.SendGump( new AuntieJuneGump( mobile ));
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
                if( dropped is Blueapple )
                {
                    if(dropped.Amount!=1)
                    {
                        this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "ahhh my apple!", mobile.NetState );
                        return false;
                    }

                    dropped.Delete();

                    mobile.AddToBackpack( new ArrianasClips() );
                    mobile.SendMessage( "The Piece is now yours, now join them and bring it back to arriana!" );


                    return true;
                }
                else if ( dropped is Blueapple )
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
