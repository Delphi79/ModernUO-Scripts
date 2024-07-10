/****************************************
 * Original Author Unknown              *
 * Updated for MUO by Admin Delphi      *
 * For use with ModernUO                *
 * Date: June 8, 2024                   *
 ****************************************/

using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName( "a savage bunny corpse" )]
    public class SavageBunny : BaseCreature
    {
        [Constructible]
        public SavageBunny() : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1)
        {
            Name = "a savage bunny";
            Body = 205;
            Hue = 1166;

            SetStr( 15 );
            SetDex( 2000 );
            SetInt( 1000 );

            SetHits( 200 );
            SetStam( 500 );
            SetMana( 0 );

            SetDamage( 1 );

            SetDamageType( ResistanceType.Physical, 100 );

            SetSkill( SkillName.MagicResist, 200.0 );
            SetSkill( SkillName.Tactics, 5.0 );
            SetSkill( SkillName.Wrestling, 5.0 );

            Fame = 1000;
            Karma = 0;

            VirtualArmor = 4;

            switch ( Utility.Random( 5 ))
            {
                case 0: PackItem( new Greencarrot() ); break;
            }




            DelayBeginTunnel();
        }



        public class BunnyHole : Item
        {
            public BunnyHole() : base( 0x913 )
            {
                Movable = false;
                Hue = 1;
                Name = "a mysterious rabbit hole";

                Timer.DelayCall(TimeSpan.FromSeconds(40.0), () => Delete());

            }

            public BunnyHole( Serial serial ) : base( serial )
            {
            }

            public override void Serialize( IGenericWriter writer )
            {
                base.Serialize(writer);

                writer.Write( (int) 0 );
            }

            public override void Deserialize( IGenericReader reader )
            {
                base.Deserialize( reader );

                int version = reader.ReadInt();

                Delete();
            }
        }

        public virtual void DelayBeginTunnel()
        {
            Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), () => BeginTunnel());


        }

        public virtual void BeginTunnel()
        {
            if ( Deleted )
                return;

            new BunnyHole().MoveToWorld( Location, Map );

            Frozen = true;
            Say( "* The bunny begins to dig a tunnel back to its underground lair *" );
            PlaySound( 0x247 );

            Timer.DelayCall(TimeSpan.FromSeconds(5), () => Delete());
        }

        public override int Meat{ get{ return 1; } }
        public override int Hides{ get{ return 1; } }
        public override bool BardImmune{ get{ return true; } }

        public SavageBunny( Serial serial ) : base( serial )
        {
        }

        public override int GetAttackSound()
        {
            return 0xC9;
        }

        public override int GetHurtSound()
        {
            return 0xCA;
        }

        public override int GetDeathSound()
        {
            return 0xCB;
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize(writer);

            writer.Write( (int) 0 );
        }

        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            DelayBeginTunnel();
        }
    }
}