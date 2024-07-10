/**********************************************
* Script Name: InvasionSettings.cs            *
 * ReWritten by ImaNewb Aka Delphi            *
 * Original Author: RavenWolfe (for ServUO)   *
 * For use with ModernUO                      *
 * Date: June 17, 2024                        *
 * ========================================== *
 * Special thanks to Ravenwolfe, Mr, Batman   *
 * and Voxspire                               *
 **********************************************/

using System;
using System.Reflection;

namespace Server
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class EnumDescriptionAttribute : Attribute
    {
        public string Description { get; }

        public EnumDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}

namespace Server.Customs.Invasion_System
{
    public enum TownMonsterType
    {
        [EnumDescription("None")]
        None,
        [EnumDescription("Abyss")]
        Abyss,
        [EnumDescription("Arachnid")]
        Arachnid,
        [EnumDescription("Dragon Kind")]
        DragonKind,
        [EnumDescription("Elementals")]
        Elementals,
        [EnumDescription("Giants")]
        Giants,
        [EnumDescription("Humanoid")]
        Humanoid,
        [EnumDescription("Orcs and Ratmen")]
        OrcsandRatmen,
        [EnumDescription("Ore Elementals")]
        OreElementals,
        [EnumDescription("Ophidian")]
        Ophidian,
        //Coming in next Revision
        /*[EnumDescription("Sea Monsters")]
        SeaMonsters,*/
        [EnumDescription("Snakes")]
        Snakes,
        [EnumDescription("Undead")]
        Undead/*,
        [EnumDescription("Test")]
        Test*/
    }

    public enum TownChampionType
    {
        [EnumDescription("None")]
        None,
        [EnumDescription("Barracoon")]
        Barracoon,
        [EnumDescription("Harrower")]
        Harrower,
        [EnumDescription("Lord Oaks")]
        LordOaks,
        [EnumDescription("Mephitis")]
        Mephitis,
        [EnumDescription("Neira")]
        Neira,
        [EnumDescription("Rikktor")]
        Rikktor,
        [EnumDescription("Semidar")]
        Semidar,
        [EnumDescription("Serado")]
        Serado
    }

    public enum InvasionTowns
    {
        [EnumDescription("None")]
        None,
        [EnumDescription("Britain")]
        Britain,
        [EnumDescription("Buccaneer's Den")]
        BuccaneersDen,
        [EnumDescription("Cove")]
        Cove,
        [EnumDescription("Delucia")]
        Delucia,
        [EnumDescription("Jhelom")]
        Jhelom,
        [EnumDescription("Minoc")]
        Minoc,
        [EnumDescription("Moonglow")]
        Moonglow,
        [EnumDescription("Nujel")]
        Nujel,
        [EnumDescription("Ocllo")]
        Ocllo,
        [EnumDescription("Papua")]
        Papua,
        [EnumDescription("Skara Brae")]
        SkaraBrae,
        [EnumDescription("Vesper")]
        Vesper,
        [EnumDescription("Yew")]
        Yew
        /*[EnumDescription("Coastal/Islands")]
        TBD*/
    }

    public enum InvasionMap
    {
        [EnumDescription("None")]
        None,
        [EnumDescription("Felucca")]
        Felucca,
        [EnumDescription("Trammel")]
        Trammel
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi != null)
            {
                Server.EnumDescriptionAttribute[] attributes = (Server.EnumDescriptionAttribute[])fi.GetCustomAttributes(typeof(Server.EnumDescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }

            return value.ToString();
        }
    }
}
