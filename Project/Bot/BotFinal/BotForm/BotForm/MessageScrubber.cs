using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class MessageScrubber : BotRelatedObject, IDataMethod
    {
        private Message lastMessage;
        private string lastMessageString;
        private User lastUser;

        private const string objName = "MessageScrubber";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }

        public void Scrub(string message)
        {
            if (message != lastMessageString)
            {
                try
                {
                    string user = message.Substring(1, message.IndexOf("!") - 1);
                    if (user.Contains("lezrecbot") && message.Contains("tmi.twitch.tv"))
                    {
                        throw new Exception();
                    }
                        string saidMessage = message.Substring(message.IndexOf("#" + TwitchChatBot.me.ChannelIn.Name));
                    saidMessage = saidMessage.Substring(message.IndexOf(":") + 1).Trim();
                    saidMessage = saidMessage.Substring(saidMessage.IndexOf(":") + 1);
                    Message msg = new Message(saidMessage, lastUser);

                    lastMessage = msg;
                    lastMessageString = message;
                    lastUser = new User(user, 0); // For now just set default prio to 0, but soon i gotta figure out how to get all the users. 

                    TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Creation, "Message created from user?")); //Happening manager manages debug

                    GuiManager.WriteToOutput(lastUser.Name + " said: " + lastMessage.Said);
                }
                catch(Exception e) //if this isnt a real fucking message from a real fucking user, it's over here
                {
                    Message msg = new Message(message, TwitchChatBot.Twitch_IRC);
                    lastMessage = msg;
                    lastMessageString = message;
                    lastUser = TwitchChatBot.Twitch_IRC;

                    //if (lastMessageString.Contains("376") && !TwitchChatBot.connected)
                    //{
                    //    TwitchChatBot.me.Client.JoinChannel(TwitchChatBot.me.ChannelIn);
                    //    TwitchChatBot.connected = true;
                    //}

                    TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Creation, "Message created from IRC?")); //Happening manager manges debug

                    GuiManager.WriteToOutput(lastUser.Name + " said: " + lastMessageString);
                    
                    
                }
                
                

            }
        }

        public void SendData()
        {
            
        }
    }
}
