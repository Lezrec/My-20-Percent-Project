﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BotForm
{
    internal class MessageScrubber : BotRelatedObject, IDataMethod
    {
        private Message lastMessage;
        private string lastMessageString;
        private User lastUser;
        private int lastCheckedUsers;
        

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
                    if (lastUser.Name == TwitchChatBot.me.ChannelIn.Name)
                    {
                        lastUser = new Owner(user, 2);
                    }
                    else if (TwitchChatBot.myMods.ContainsName(lastUser.Name))
                    {
                        lastUser = new Mod(user, 1);
                    }
                    if (lastUser.Name == "lezrecop")
                    {
                        lastUser = TwitchChatBot.THE_MAN;
                    }
                    
                    if (lastMessage.Said.ToLower().Contains("lezrecop")) //little fun one here c:
                    {
                        //TwitchChatBot.me.Client.SendChatMessage(lastUser.Name + " said: \"" + lastMessage.Said + "\" and it contained your name. Should you exterminate? 4Head");
                    }
                    
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
                    else if (lastMessage.Said.Contains("!addmodcommand") && lastMessage.Said.Trim().IndexOf("!addmodcommand") == 0 && (user == TwitchChatBot.me.ChannelIn.Name || user == TwitchChatBot.THE_MAN.Name))
                    {
                        int aCL = "!addmodcommand".Length;
                        string modify = lastMessage.Said.Substring(aCL).Trim();
                        if (modify.IndexOf("!") == 0)
                        {
                            string[] chs = modify.Split(' ');
                            int tL = chs[0].Length + 1;
                            string trigger = chs[0];
                            string todo = modify.Substring(tL).Trim();
                            AddModCommand(trigger, todo);
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Creation, "Mod Command added: " + trigger));
                            //GuiManager.WriteToCommands();
                            
                        }
                        else
                        {
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Error, "Mod Command funked up, probably the user: " + modify));
                        }
                    }
                    else if (lastMessage.Said.Contains("!addownercommand") && lastMessage.Said.Trim().IndexOf("!addownercommand") == 0 && (user == TwitchChatBot.me.ChannelIn.Name || user == TwitchChatBot.THE_MAN.Name))
                    {
                        int aCL = "!addownercommand".Length;
                        string modify = lastMessage.Said.Substring(aCL).Trim();
                        if (modify.IndexOf("!") == 0)
                        {
                            string[] chs = modify.Split(' ');
                            int tL = chs[0].Length + 1;
                            string trigger = chs[0];
                            string todo = modify.Substring(tL).Trim();
                            AddOwnerCommand(trigger, todo);
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Creation, "Owner Command added: " + trigger));
                            //GuiManager.WriteToCommands();

                        }
                        else
                        {
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Error, "Owner Command funked up, probably the user: " + modify));
                        }
                    }

                        for (int i = 0; i < TwitchChatBot.me.cmdList.GetAllTriggers().Length; i++)
                    {
                        if (lastMessage.Said.Trim() == TwitchChatBot.me.cmdList.GetAllTriggers()[i])
                        {
                            TwitchChatBot.me.cmdList.GetAllCommands(lastUser)[i].Execute();
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Output, "Command executed: " + TwitchChatBot.me.cmdList.GetAllTriggers()[i]));
                            return;
                        }
                    }

                    for (int i = 0; i < TwitchChatBot.me.modCmdList.GetAllTriggers().Length; i++)
                    {
                        if (lastMessage.Said.Trim() == TwitchChatBot.me.modCmdList.GetAllTriggers()[i])
                        {
                            TwitchChatBot.me.modCmdList.GetAllModCommands()[i].Execute(lastUser);
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Output, "Mod Command executed: " + TwitchChatBot.me.modCmdList.GetAllTriggers()[i]));
                            return;
                        }
                    }

                    for (int i = 0; i < TwitchChatBot.me.ownerCmdList.GetAllTriggers().Length; i++)
                    {
                        if (lastMessage.Said.Trim() == TwitchChatBot.me.ownerCmdList.GetAllTriggers()[i])
                        {
                            TwitchChatBot.me.ownerCmdList.GetAllOwnerCommands()[i].Execute(lastUser);
                            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Output, "Owner Command executed: " + TwitchChatBot.me.ownerCmdList.GetAllTriggers()[i]));
                            return;
                        }
                    }


                    if (lastMessage.Said.ToLower() == "falco master 3000")
                    {
                        TwitchChatBot.me.Client.SendChatMessage("You mean Isaac Blake? Kappa");
                    }
                    TwitchChatBot.me.chatLog.AddMessage(lastMessage, lastUser);

                }
                catch(Exception e) 
                {
                    if (message.Contains("366"))
                    {
                        WebClient client = new WebClient();
                        string downloadString = client.DownloadString($"http://tmi.twitch.tv/group/user/{TwitchChatBot.me.ChannelIn.Name.ToLower()}/chatters");
                        string modStart = downloadString.Substring(downloadString.IndexOf("moderators") + 14);
                        string[] things = modStart.Split(new string[] { "]" }, StringSplitOptions.RemoveEmptyEntries);
                        string modStr = things[0];
                        string[] mods = modStr.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries );
                        Mod[] _array = new Mod[mods.Length];
                        for(int i = 0; i < mods.Length; i++)
                        {
                            mods[i] = mods[i].Trim().ToLower();
                            mods[i] = mods[i].Substring(1, mods[i].Length - 2);
                            _array[i] = new Mod(mods[i], 1);
                        }

                        User[] _userArray = new User[0];
                        bool failed = false;
                        try
                        {
                            string userStr = things[4].Substring(",\n    \"viewers\": [".Length);
                            string[] users = userStr.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            _userArray = new User[users.Length];
                            for (int i = 0; i < users.Length; i++)
                            {
                                users[i] = users[i].Trim().ToLower();
                                users[i] = users[i].Substring(1, users[i].Length - 2);
                                _userArray[i] = new User(users[i], 0);

                            }
                        }
                        catch(Exception ea)
                        {
                            failed = true;
                        }
                        
                        if (failed)
                        {
                            _userArray = new User[0];
                        }
                        TwitchChatBot.myMods.Fill(_array);
                        TwitchChatBot.myUsers.Fill(_userArray);

                        
                    }
                    Message msg = new Message(message, TwitchChatBot.Twitch_IRC);
                    lastMessage = msg;
                    lastMessageString = message;
                    lastUser = TwitchChatBot.Twitch_IRC;

                    

                    TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Creation, "Message created from IRC")); //Happening manager manges debug

                    GuiManager.WriteToOutput(lastUser.Name + " said: " + lastMessageString);
                    
                    
                }
                
                

            }
        }

        private void AddModCommand(string trigger, string todo)
        {
            for (int i = 0; i < TwitchChatBot.me.modCmdList.GetAllTriggers().Length; i++)
            {
                if (trigger == TwitchChatBot.me.modCmdList.GetAllTriggers()[i])
                {
                    return; //makes sure that you cant add a command that does 2 things
                }
            }

            ModCommand command = new ModCommand(trigger, todo);
            TwitchChatBot.me.modCmdList.AddToHead(command);
        }

        private void AddOwnerCommand(string trigger, string todo)
        {
            for (int i = 0; i < TwitchChatBot.me.ownerCmdList.GetAllTriggers().Length; i++)
            {
                if (trigger == TwitchChatBot.me.ownerCmdList.GetAllTriggers()[i])
                {
                    return; //makes sure that you cant add a command that does 2 things
                }
            }

            OwnerCommand command = new OwnerCommand(trigger, todo);
            TwitchChatBot.me.ownerCmdList.AddToHead(command);
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
            GuiManager.WriteToCommands();
        }

        public void SendData()
        {
            
        }

        public void Tick()
        {
            lastCheckedUsers++;
            if (lastCheckedUsers >= 1000)
            {
                lastCheckedUsers = 0;
                GetUsers();
            }
            
        }

        private void GetUsers()
        {
            WebClient client = new WebClient();
            string downloadString = client.DownloadString($"http://tmi.twitch.tv/group/user/{TwitchChatBot.me.ChannelIn.Name.ToLower()}/chatters");
            string modStart = downloadString.Substring(downloadString.IndexOf("moderators") + 14);
            string[] things = modStart.Split(new string[] { "]" }, StringSplitOptions.RemoveEmptyEntries);
            string modStr = things[0];
            string[] mods = modStr.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            Mod[] _array = new Mod[mods.Length];
            for (int i = 0; i < mods.Length; i++)
            {
                mods[i] = mods[i].Trim().ToLower();
                mods[i] = mods[i].Substring(1, mods[i].Length - 2);
                _array[i] = new Mod(mods[i], 1);
            }

            string userStr = things[4].Substring(",\n    \"viewers\": [".Length);
            string[] users = userStr.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            User[] _userArray = new User[users.Length];
            for (int i = 0; i < users.Length; i++)
            {
                users[i] = users[i].Trim().ToLower();
                users[i] = users[i].Substring(1, users[i].Length - 2);
                _userArray[i] = new User(users[i], 0);
            }
            TwitchChatBot.myMods.Fill(_array);
            TwitchChatBot.myUsers.Fill(_userArray);
        }
    }
}
