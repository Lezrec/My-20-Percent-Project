using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace BotForm
{
    internal class BotClient
    {
        private TcpClient myClient;
        private StreamReader myReader;
        private StreamWriter myWriter;
        private string lastMessage;

        public BotClient()
        {
            lastMessage = "";
            myClient = new TcpClient("irc.twitch.tv", 6667);
            myReader = new StreamReader(myClient.GetStream());
            myWriter = new StreamWriter(myClient.GetStream());
            
            
        }

        public void WriteToClientStream(string text)
        {
            myWriter.WriteLine(text);
            myWriter.Flush();
        }

        public void Load()
        {
            string password = File.ReadAllText("password.txt"); //only exception of direct file I/O
            myWriter.WriteLine("PASS " + password + Environment.NewLine
                    + "NICK lezrecbot" + Environment.NewLine
                    + "USER lezrecbot" + " 8 * :lezrecbot");
            myWriter.Flush();
            
            
        }

        public void Connect(string ip, int port)
        {
            myClient = new TcpClient(ip, port);
        }

        public void JoinChannel(Channel channel)
        {
            WriteToClientStream("JOIN #" + channel.Name);
            TwitchChatBot.me.ChannelIn = channel;
        }

        

        public void SendChatMessage(string text)
        {
            WriteToClientStream(text); //todo this
        }

        private void CheckForMessage()
        {
            if (myReader.Peek() > 0 || myClient.Available > 0)
            {
                lastMessage = myReader.ReadLine();
            }
        }

        public string GetLastStreamMessage()
        {
            CheckForMessage();
            return lastMessage;
        }
    }
}
