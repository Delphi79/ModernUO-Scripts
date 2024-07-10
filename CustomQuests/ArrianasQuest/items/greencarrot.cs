/****************************************
 * Original Author Unknown              *
 * Updated for MUO by Admin Delphi      *
 * For use with ModernUO                *
 * Date: June 8, 2024                   *
 ****************************************/

namespace Server.Items
{
    public class Greencarrot : Item
    {
        [Constructible]
        public Greencarrot() : this( 1 )
        {
        }

        [Constructible]
        public Greencarrot( int amount ) : base( 0xC78 )
        {
            Name = "green carrot";
            Hue = 462;
            Weight = 0.1;

        }

        public Greencarrot( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
