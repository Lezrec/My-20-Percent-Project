using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    internal static class PacketMaker
    {
        private static InfoPacket lastPacket;

        public static void Create(Message message, TimeFromBot time)
        {
            lastPacket = new InfoPacket(message, time);
        }

        public static void FeedLatest()
        {
            try
            {
                PacketFeeder.Feed(lastPacket);
            }
            catch(Exception e)
            {
                GUIManager.WriteToRawLabel("No packet to feed!");
            }
            
        }
    }
}
