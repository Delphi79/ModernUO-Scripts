/**********************************************
* Script Name: MonsterTownSpawnEntry.cs       *
 * ReWritten by ImaNewb Aka Delphi            *
 * Original Author: RavenWolfe (for ServUO)   *
 * For use with ModernUO                      *
 * Date: June 17, 2024                        *
 * ========================================== *
 * Special thanks to Ravenwolfe, Mr, Batman   *
 * and Voxspire                               *
 **********************************************/

using System;
using Server.Mobiles;

namespace Server.Customs.Invasion_System;

public class MonsterTownSpawnEntry
{
    #region MonsterSpawnEntries

    public static MonsterTownSpawnEntry[] Undead =
    {
        //Monster
        new(typeof(Zombie), 165),
        new(typeof(Skeleton), 65),
        new(typeof(SkeletalMage), 40),
        new(typeof(BoneKnight), 45),
        new(typeof(SkeletalKnight), 45),
        new(typeof(Lich), 45),
        new(typeof(Ghoul), 40),
        new(typeof(BoneMagi), 40),
        new(typeof(Wraith), 35),
        new(typeof(RottingCorpse), 35),
        new(typeof(LichLord), 55),
        new(typeof(Spectre), 30),
        new(typeof(Shade), 30),
        new(typeof(AncientLich), 50)
    };

    public static MonsterTownSpawnEntry[] Humanoid =
    {
        //Monster
        new(typeof(Brigand), 60),
        new(typeof(Executioner), 30),
        new(typeof(EvilMage), 70),
        new(typeof(EvilMageLord), 40),
        new(typeof(Ettin), 45),
        new(typeof(Ogre), 45),
        new(typeof(OgreLord), 40),
        new(typeof(ArcticOgreLord), 40),
        new(typeof(Troll), 55),
        new(typeof(Cyclops), 55),
        new(typeof(Titan), 40)
    };

    public static MonsterTownSpawnEntry[] OrcsandRatmen =
    {
        new(typeof(Orc), 80),
        new(typeof(OrcishMage), 45),
        new(typeof(OrcishLord), 55),
        new(typeof(OrcCaptain), 50),
        new(typeof(OrcBomber), 55),
        new(typeof(OrcBrute), 40),
        new(typeof(Ratman), 80),
        new(typeof(RatmanArcher), 50),
        new(typeof(RatmanMage), 45)
    };

    public static MonsterTownSpawnEntry[] Elementals =
    {
        new(typeof(EarthElemental), 95),
        new(typeof(AirElemental), 70),
        new(typeof(FireElemental), 60),
        new(typeof(WaterElemental), 60),
        new(typeof(SnowElemental), 40),
        new(typeof(IceElemental), 40),
        new(typeof(Efreet), 45),
        new(typeof(PoisonElemental), 35),
        new(typeof(BloodElemental), 35)
    };

    public static MonsterTownSpawnEntry[] OreElementals =
    {
        new(typeof(DullCopperElemental), 90),
        new(typeof(CopperElemental), 80),
        new(typeof(BronzeElemental), 50),
        new(typeof(ShadowIronElemental), 60),
        new(typeof(GoldenElemental), 55),
        new(typeof(AgapiteElemental), 45),
        new(typeof(VeriteElemental), 40),
        new(typeof(ValoriteElemental), 40)
    };

    public static MonsterTownSpawnEntry[] Ophidian =
    {
        new(typeof(OphidianWarrior), 100),
        new(typeof(OphidianMage), 70),
        new(typeof(OphidianArchmage), 30),
        new(typeof(OphidianKnight), 35),
        new(typeof(OphidianMatriarch), 35)
    };

    public static MonsterTownSpawnEntry[] Arachnid =
    {
        new(typeof(Scorpion), 75),
        new(typeof(GiantSpider), 75),
        new(typeof(TerathanDrone), 45),
        new(typeof(TerathanWarrior), 30),
        new(typeof(TerathanMatriarch), 45),
        new(typeof(TerathanAvenger), 45),
        new(typeof(DreadSpider), 40),
        new(typeof(FrostSpider), 35)
    };

    public static MonsterTownSpawnEntry[] Snakes =
    {
        new(typeof(Snake), 95),
        new(typeof(GiantSerpent), 95),
        new(typeof(LavaSnake), 50),
        new(typeof(LavaSerpent), 55),
        new(typeof(IceSnake), 50),
        new(typeof(IceSerpent), 55),
        new(typeof(SilverSerpent), 40)
    };

    public static MonsterTownSpawnEntry[] Abyss =
    {
        new(typeof(Gargoyle), 100),
        new(typeof(StoneGargoyle), 60),
        new(typeof(FireGargoyle), 60),
        new(typeof(Daemon), 60),
        new(typeof(IceFiend), 50),
        new(typeof(Balron), 30)
    };

    public static MonsterTownSpawnEntry[] DragonKind =
    {
        new(typeof(Wyvern), 100),
        new(typeof(Drake), 60),
        new(typeof(Dragon), 60),
        new(typeof(WhiteWyrm), 60),
        new(typeof(ShadowWyrm), 10),
        new(typeof(AncientWyrm), 30)
    };

    public static MonsterTownSpawnEntry[] Giants =
    {
        new(typeof(Troll), 100),
        new(typeof(Ettin), 60),
        new(typeof(Ogre), 60),
        new(typeof(OgreLord), 60),
        new(typeof(Cyclops), 10),
        new(typeof(Titan), 30)

    };

    //Coming in Next Revision
    /*public static MonsterTownSpawnEntry[] SeaMonsters =
    {
        new(typeof(SeaSerpent), 80),
        new(typeof(WaterElemental), 80),
        new(typeof(Kraken), 80),
        new(typeof(DeepSeaSerpent), 30),
        new(typeof(Leviathan), 50)

    };*/

    public static MonsterTownSpawnEntry[] Test =
    {
        new(typeof(OrcishLord), 1)
    };

    #endregion

    public Type Monster { get; set; }

    public int Amount { get; set; }

    public MonsterTownSpawnEntry(Type monster, int amount)
    {
        Monster = monster;
        Amount = amount;
    }
}
