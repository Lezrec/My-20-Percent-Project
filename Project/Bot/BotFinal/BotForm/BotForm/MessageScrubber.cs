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
                    // TODO TEST THIS BELOW
                    if (lastMessage.Said.Contains("!addcommand") && lastMessage.Said.Trim().IndexOf("!addcommand") == 0 && (user == TwitchChatBot.me.ChannelIn.Name || user == TwitchChatBot.THE_MAN.Name))
                    {
                        int aCL = "!addcommand".Length;
                        string modify = lastMessage.Said.Substring(aCL).Trim() ;
                        if (modify.IndexOf("!") == 0)
                        {
                            string[] chs = modify.Split(' ');
                            int tL = chs[0].Length + 1;
                            string trigger = chs[0];
                            string todo = modify.Substring(tL).Trim() ;
                            AddCommand(trigger, todo);
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Creation, "Command added: " + trigger));
                            GuiManager.WriteToCommands();
                            //  TwitchChatBot.me.cmdList.UpdateGUI();
                        }
                        else
                        {
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Error, "Command funked up, probably the user: " + modify));
                        }
                       

                    }
                    else if (lastMessage.Said.Contains("!removecommand") && lastMessage.Said.Trim().IndexOf("!removecommand") == 0 && (user == TwitchChatBot.me.ChannelIn.Name || user == TwitchChatBot.THE_MAN.Name))
                    {
                        int rCL = "!removecommand".Length;
                        string modify = lastMessage.Said.Substring(rCL).Trim();
                        if (modify.IndexOf("!") == 0)
                        {
                            string[] chs = modify.Split(' ');
                            string trigger = chs[0];
                            TwitchChatBot.me.cmdList.RemoveCommandUsingOnlyTrigger(trigger);
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Deletion, "Command removed: " + trigger));
                            GuiManager.WriteToCommands();
                            // TwitchChatBot.me.cmdList.UpdateGUI();
                        }
                        else
                        {
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Error, "Remove funked up, probably the user: " + modify));
                        }
                    }

                    for (int i = 0; i < TwitchChatBot.me.cmdList.GetAllTriggers().Length; i++)
                    {
                        if (lastMessage.Said.Trim() == TwitchChatBot.me.cmdList.GetAllTriggers()[i])
                        {
                            TwitchChatBot.me.cmdList.GetAllCommands()[i].Execute();
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Output, "Command executed: " + TwitchChatBot.me.cmdList.GetAllTriggers()[i]));
                            return;
                        }
                    }

                    




                }
                catch(Exception e) //if this isnt a real fucking message from a real fucking user, it's over here
                {
                    if (message.Contains("366"))
                    {
                        TwitchChatBot.myUsers.Fill(message);
                        User[] allUsers = TwitchChatBot.myUsers.ToArray();
                        int x = allUsers.Length;
                    }
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

        private void AddCommand(string trigger, string todo)
        {
            for (int i = 0; i < TwitchChatBot.me.cmdList.GetAllTriggers().Length; i++)
            {
                if (trigger == TwitchChatBot.me.cmdList.GetAllTriggers()[i])
                {
                    return; //makes sure that you cant add a command that does 2 things
                }
            }
            
            Command command = new Command(trigger, todo);
            TwitchChatBot.me.cmdList.AddToHead(command);
        }

        public void SendData()
        {
            
        }
    }
}
