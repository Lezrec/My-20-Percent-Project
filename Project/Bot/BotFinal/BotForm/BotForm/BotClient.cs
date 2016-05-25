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
    internal class BotClient : BotRelatedObject
    {
        private TcpClient myClient;
        private bool ctorFail = false;
        private StreamReader myReader;
        private StreamWriter myWriter;
        private string lastMessage;

        private const string objName = "BotClient";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }

        public BotClient()
        {
            try
            {
                lastMessage = "";
                myClient = new TcpClient("irc.twitch.tv", 6667);
                myReader = new StreamReader(myClient.GetStream());
                myWriter = new StreamWriter(myClient.GetStream());
            }
            catch(Exception e)
            {
                ctorFail = true;
            }
            
            
            
        }

        public void WriteToClientStream(string text)
        {
            myWriter.WriteLine(text);
            myWriter.Flush();
        }

        public void Load()
        {
            if (!ctorFail)
            {
                string password = File.ReadAllText("password.txt"); //only exception of direct file I/O
                myWriter.WriteLine("PASS " + password + Environment.NewLine
                        + "NICK lezrecbot" + Environment.NewLine
                        + "USER lezrecbot" + " 8 * :lezrecbot");
                myWriter.Flush();
            }
            
            
            
        }

        public void Connect(string ip, int port)
        {
            myClient = new TcpClient(ip, port);
        }

        public void Whisper(string msg, User other)
        {
            WriteToClientStream("CAP REQ :twitch.tv/commands");
            WriteToClientStream("PRIVMSG #jtv :.w " + other.Name + " " + msg);
            
        }

        public void JoinChannel(Channel channel)
        {
            WriteToClientStream("JOIN #" + channel.Name);
            TwitchChatBot.me.ChannelIn = channel;
            TwitchChatBot.me.cmdsFromFile = new FileEditor(TwitchChatBot.me.ChannelIn.Name + "_cmds.txt");
            TwitchChatBot.me.modCmdsFromFile = new FileEditor(TwitchChatBot.me.ChannelIn.Name + "_mod_cmds.txt");
            TwitchChatBot.me.ownerCmdsFromFile = new FileEditor(TwitchChatBot.me.ChannelIn.Name + "_owner_cmds.txt");
            ModList.modFile = new FileEditor(TwitchChatBot.me.ChannelIn.Name + "_mods.txt");
            TwitchChatBot.me.cmdList = new CommandList();
            TwitchChatBot.me.modCmdList = new ModCommandList();
            TwitchChatBot.me.ownerCmdList = new OwnerCommandList();
            TwitchChatBot.me.chatLog = new ChatLog(channel);
            //SendChatMessage("Hola " + channel.Name + "! Soy LezrecBot! LezrecOp me hizo, y lo amo para eso <3.");
            //Whisper("psst, your bot is living Kappa", TwitchChatBot.THE_MAN);
            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Modification, $"Changed channel to {channel.Name}"));
        }

        

        public void SendChatMessage(string text)
        {
            WriteToClientStream(":lezrecbot!lezrecbot@.tmi.twitch.tv PRIVMSG #" + TwitchChatBot.me.ChannelIn.Name + " :" + text); //todo test
        }

        private void CheckForMessage()
        {
            try
            {
                if (myReader.Peek() > 0 || myClient.Available > 0)
                {
                    lastMessage = myReader.ReadLine();
                }
            }
            catch(Exception e)
            {

            }
            
        }

        internal bool CanConnect()
        {
            try
            {
                if (myReader.Peek() > 0 || myClient.Available > 0)
                {

                }
            }
            catch(Exception e)
            {
                return false;
            }
            return true && !ctorFail;
        }

        public string GetLastStreamMessage()
        {
            CheckForMessage();
            return lastMessage;
        }
    }
}
