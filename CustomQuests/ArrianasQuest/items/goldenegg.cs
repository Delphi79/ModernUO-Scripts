/****************************************
 * Original Author Unknown              *
 * Updated for MUO by Admin Delphi      *
 * For use with ModernUO                *
 * Date: June 8, 2024                   *
 ****************************************/

namespace Server.Items
{
    public class Goldenegg : Item
    {
        [Constructible]
        public Goldenegg() : this( 1 )
        {
        }

        [Constructible]
        public Goldenegg( int amount ) : base( 0x9B5 )
        {
            Name = "Golden egg";
            Hue = 1701;
            Weight = 0.1;
            Amount = amount;
        }

        public Goldenegg( Serial serial ) : base( serial )
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
