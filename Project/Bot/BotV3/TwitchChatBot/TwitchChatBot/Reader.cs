using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TwitchChatBot
{
    /// <summary>
    /// Reads all client streamed information.
    /// </summary>
    internal static class Reader
    {
        private static StreamReader reader;
        private static TcpClient client;
        private static string lastStored;

        public static void Load(TcpClient client)
        {
            reader = new StreamReader(client.GetStream());
            Reader.client = client;
            
           
        }

        public static void Read(string text)
        {
            GUIManager.WriteToRawLabel(text);
            Message msg = MessagePrepper.Prep(text);
            PacketMaker.Create(msg, TimeFromBot.Now);
            PacketMaker.FeedLatest();
            reader.DiscardBufferedData();
        }

        public static string GetLastRead
        {
            get { return lastStored;  }
        }
        
        public static void Tick()
        {
            try
            {
                if (client.Available > 0 || reader.Peek() > 0)
                {
                    lastStored = reader.ReadLine();
                    Read(lastStored);
                }
            }
            catch(IOException e)
            {

            }

            
        }


    }
}
