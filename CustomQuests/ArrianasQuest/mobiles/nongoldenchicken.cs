/****************************************
 * Original Author Unknown              *
 * Updated for MUO by Admin Delphi      *
 * For use with ModernUO                *
 * Date: June 8, 2024                   *
 ****************************************/

using Server.Items;
namespace Server.Mobiles
{
    [CorpseName( "a chicken corpse" )]
    public class NonGoldenChicken : BaseCreature
    {
        [Constructible]
        public NonGoldenChicken() : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1)
        {
            Name = "a chicken";
            Body = 0xD0;
            BaseSoundID = 0x6E;

            SetStr( 5 );
            SetDex( 15 );
            SetInt( 5 );

            SetHits( 3 );
            SetMana( 0 );

            SetDamage( 1 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetResistance( ResistanceType.Physical, 1, 5 );

            SetSkill( SkillName.MagicResist, 4.0 );
            SetSkill( SkillName.Tactics, 5.0 );
            SetSkill( SkillName.Wrestling, 5.0 );

            Fame = 150;
            Karma = 0;

            VirtualArmor = 2;

            Tamable = false;

        }

        public override void OnDoubleClick( Mobile from )

        {
            Eggs eg = new Eggs();

            eg.MoveToWorld( this.Location, this.Map );
        }

        public override int Meat{ get{ return 1; } }
        public override MeatType MeatType{ get{ return MeatType.Bird; } }
        public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }

        public override int Feathers{ get{ return 25; } }

        public NonGoldenChicken(Serial serial) : base(serial)
        {
        }

        public override void Serialize(IGenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0);
        }

        public override void Deserialize(IGenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
