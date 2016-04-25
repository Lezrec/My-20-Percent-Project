using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{

    /// <summary>
    /// Gets fed InfoPackets to break up and distribute.
    /// </summary>
    internal static class PacketFeeder
    {
        private static InfoPacket lastPacket;

        /// <summary>
        /// The method for feeding the packet.
        /// </summary>
        /// <param name="packet"></param>
        public static void Feed(InfoPacket packet)
        {
            //TODO THIS
            lastPacket = packet;

        }

        public static InfoPacket LastPacket
        {
            get { return lastPacket; }
        }
    }
}
