/****************************************
 * Original Author Unknown              *
 * Updated for MUO by Admin Delphi      *
 * For use with ModernUO                *
 * Date: June 8, 2024                   *
 ****************************************/

namespace Server.Items
{
    public class ArrianasEarrings : SilverEarrings
    {

        public override int ArtifactRarity{ get{ return 15; } }

        [Constructible]
        public ArrianasEarrings()
        {
            Name = "Arriana's Earrings";
            Hue = 1154;


            Attributes.NightSight = 1;
            Attributes.Luck = 100;
            Attributes.BonusStr = 2;
            Attributes.RegenHits = 1;
            Attributes.RegenStam = 2;
            Resistances.Energy = 5;
            Resistances.Fire = 5;
            Resistances.Cold = 5;
            Resistances.Poison = 5;
            Resistances.Physical = 5;

        }

        public ArrianasEarrings( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 );
        }

        public override void Deserialize(IGenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
