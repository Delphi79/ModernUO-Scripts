#region AuthorHeader
/****************************************
 * Original Author Xanthos              *
 * Modified for MUO by Delphi           *
 * For use with ModernUO                *
 * Date: June 13, 2024                  *
 ****************************************/
#endregion AuthorHeader
using System;
using System.Reflection;
using System.Security;
using Server;

namespace Xanthos.Utilities
{
    public class Misc
    {
        /// <summary>
        /// The hues used for gumps in the systems
        /// </summary>
        public static int kLabelHue = 0x480;
        public static int kGreenHue = 0x40;
        public static int kRedHue = 0x20;

        public static bool IsArtifact(Item item)
        {
            if (item == null)
                return false;

            Type t = item.GetType();
            PropertyInfo prop = null;

            try { prop = t.GetProperty("ArtifactRarity"); }
            catch { }

            if (prop == null)
                return false;

            var value = prop.GetValue(item, null);
            if (value == null || (int)value <= 0)
                return false;

            return true;
        }


        public static bool IsPlayerConstructed(Item item)
        {
            if (item == null)
                return false;

            Type t = item.GetType();
            PropertyInfo prop = null;

            try { prop = t.GetProperty("PlayerConstructed"); }
            catch { }

            if (prop == null)
                return false;

            var value = prop.GetValue(item, null);
            if (value == null || !(bool)value)
                return false;

            return true;
        }


        //
        // Puts spaces before type name inner-caps
        //
        public static string GetFriendlyClassName( string typeName )
        {
            for ( int index = 1; index < typeName.Length; index++ )
            {
                if ( char.IsUpper( typeName, index ) )
                {
                    typeName.Insert( index++, " " );
                }
            }

            return typeName;
        }

        public static object InvokeParameterlessMethod( object target, string method )
        {
            object result = null;

            try
            {
                Type objectType = target.GetType();
                MethodInfo methodInfo = objectType.GetMethod( method );

                if (methodInfo != null)
                {
                    result = methodInfo.Invoke(target, null);
                }
            }
            catch ( SecurityException exc )
            {
                Console.WriteLine( "SecurityException: " + exc.Message );
            }
            return result;
        }

        public static void SendCommandDetails( Mobile player, string command )
        {
            SendCommandDescription( player, command );
            SendCommandUsage( player, command );
        }

        public static void SendCommandUsage( Mobile player, string command )
        {
            string message;
            CommandEntry entry = CommandSystem.Entries[ command ];

            if ( null != entry )
            {
                MethodInfo mi = entry.Handler.Method;

                object[] attrs = mi.GetCustomAttributes( typeof( UsageAttribute ), false );

                UsageAttribute usage = attrs.Length > 0 ? attrs[ 0 ] as UsageAttribute : null;

                message = "Format: " + ( null == usage ? " - no usage" : usage.Usage );
            }
            else
                message = command + " - unknown command";

            player.SendMessage( kRedHue, message );
        }

        public static void SendCommandDescription( Mobile player, string command )
        {
            string message;
            CommandEntry entry = CommandSystem.Entries[ command ];

            if ( null != entry )
            {
                MethodInfo mi = entry.Handler.Method;

                object[] attrs = mi.GetCustomAttributes( typeof( DescriptionAttribute ), false );

                DescriptionAttribute desc = attrs.Length > 0 ? attrs[ 0 ] as DescriptionAttribute : null;

                message = command + ": " + ( null == desc ? " - no description" : desc.Description );
            }
            else
                message = command + " - unknown command";

            player.SendMessage( kRedHue, message );
        }
    }
}
