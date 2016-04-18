using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace TwitchChatBot
{
    /// <summary>
    /// Handles internal exceptions.
    /// </summary>
    internal static class ExceptionHandler
    {
        /// <summary>
        /// Handles connection errors to Twitch.
        /// </summary>
        /// <param name="e"></param>
        public static void CannotConnectToTwitch(Exception e)
        {
            //TODO figure out what exception is thrown
        }

        /// <summary>
        /// Handles file in use errors.
        /// </summary>
        /// <param name="e"></param>
        public static void FileInUse(IOException e)
        {

        }

        /// <summary>
        /// Handles out of bounds exception.
        /// </summary>
        /// <param name="e"></param>
        public static void OutOfBounds(Exception e)
        {

        }

        /// <summary>
        /// Handles Reader and Writer conflicts.
        /// </summary>
        /// <param name="e"></param>
        public static void StreamInfoConflict(Exception e)
        {

        }

        public static void Other(Exception e)
        {

        }
    }
}
