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
    /// Connects to the Twitch IRC servers.
    /// </summary>
    internal static class Connector
    {
        private static TcpClient client;
        

        public static TcpClient Client
        {
            get { return client; }
            set { client = value; }
        }

        /// <summary>
        /// Called at the start of the program.
        /// </summary>
        public static void Load()
        {
            client = new TcpClient("irc.twitch.tv", 6667);
            Reader.Load(client);
            Writer.Load(client);
            Connector.StartUp(false);
            
        }

        public static void StartUp(bool debugOff)
        {
            if (debugOff)
            {
                string password = FileEditor.GetTextFrom("password.txt");
                if (password == "" || !password.Contains("oath:"))
                {
                    ShutDown();
                }
                Writer.Write("PASS " + password + Environment.NewLine
                    + "NICK lezrecbot" + Environment.NewLine
                    + "USER lezrecbot" + " 8 * :lezrecbot");
            }
                
        }


        public static void Tick()
        {
            
        }


        public static void ShutDown()
        {
            Program.ShutDownAfterSeconds(5);
        }
        
        /// <summary>
        /// Connects to an IP and a port.
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public static void Connect(string ip, int port)
        {
            client = new TcpClient("irc.twitch.tv", 6667);
        }

        public static void JoinRoom(User channelOwner)
        {
            Writer.Write("#JOIN " + channelOwner.Name);
        }

    }
}
