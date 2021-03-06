﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalTwitch.Storage;

namespace BotForm
{
    internal class CommandList : BotRelatedObject, IDataMethod 
    {
        private LinkedList<Command> commands = new LinkedList<Command>();
        private bool comingFromFile;
        private bool addedStuff;
        
        public CommandList()
        {
            WriteFromFileToList();
            
        }

        internal void AddToHead(Command comd)
        {
            if (!Contains(comd))
            {
                commands.AddFirst(comd);
                if (!comingFromFile)
                {
                    WriteToFile(); 
                }
                

            }
            comingFromFile = false;
            
            
        }

        internal Command GetHead()
        {
            return commands.First.Value;
        }

        internal Command GetTail()
        {
            return commands.Last.Value;
        }

        internal Command[] GetAllCommands(User user)
        {
            bool cmdHere = false;
            bool uptimeHere = false;
            foreach(Command comd in commands.ToArray<Command>())
            {
                if (comd.Trigger == "!command") cmdHere = true;
                if (comd.Trigger == "!uptime") uptimeHere = true;
            }
            if (!addedStuff)
            {
                Command.delToDo uptimeDel = () =>
                {
                    string x = "Uptime: ";
                    x += TwitchChatBot.me.timer.Hours + " hours, " + TwitchChatBot.me.timer.Minutes + " minutes, " + TwitchChatBot.me.timer.Seconds + " seconds.";
                    TwitchChatBot.me.Client.SendChatMessage(x);
                };
                Command uptime = new Command("!uptime", uptimeDel);
                commands.AddFirst(uptime);

                Command.delToDo creditsDel = () =>
               {
                   string x = "This bot was made by LezrecOP, shout out to my master <3";
                   TwitchChatBot.me.Client.SendChatMessage(x);
               };
                Command credits = new Command("!credits", creditsDel);
                commands.AddFirst(credits);

                string schreiber = "My favorite teacher Kappa";
                Command schrieb = new Command("!schreiber", schreiber);
                commands.AddFirst(schrieb);


                Command.delToDo commandsDel = () =>
                {
                    string x = "Commands: ";
                    foreach (Command cmd in commands.ToArray<Command>())
                    {
                        x += cmd.Trigger + ", ";
                    }
                    x = x.Substring(0, x.Length - 2);
                    x += ".";
                    TwitchChatBot.me.Client.Whisper(x, user);
                };
                Command cmds = new Command("!commands", commandsDel);
                commands.AddFirst(cmds);
                addedStuff = true;
            }
            

            Command[] comds = commands.ToArray<Command>();
            
            
            return commands.ToArray<Command>();
        }

        internal bool Contains(Command comd)
        {
            Command[] all = GetAllCommands(TwitchChatBot.THE_MAN);
            foreach(Command c in all)
            {
                if (c.Trigger == comd.Trigger)
                {
                    return true;
                }
                
            }
            return false;
        }

        internal void WriteToFile()
        {
            //todo make this work with the dels
            Command[] todos = GetAllCommands(TwitchChatBot.THE_MAN);
            string write = "";
            for(int i = 0; i < todos.Length; i++)
            {
                //Θ = beginning, ☻ = end
                if (todos[i].Trigger == "!commands" || todos[i].Trigger == "!uptime") continue;
                write += "Θ" + todos[i].Trigger + "," + todos[i].ToDo  + "NEW_LINE";
            }
            TwitchChatBot.me.cmdsFromFile.WriteAllText(write);
            
        }

        internal Command[] GetAllCommandsFromFile()
        {
            string all = TwitchChatBot.me.cmdsFromFile.ReadAllText();
            if (all == "") return null;
            string[] splitUp = all.Split(new string[] { "NEW_LINE" }, StringSplitOptions.None);
            Command[] ret = new Command[splitUp.Length];
            for(int i = 0; i < ret.Length; i++)
            {
                string modify = splitUp[i];
                if (modify == "") return ret;
                modify = modify.Substring(1);
                int whereTrigger = modify.IndexOf(",");
                string trigger = modify.Substring(0, whereTrigger);
                modify = modify.Substring(whereTrigger + 1);
                string todo = modify;
                ret[i] = new Command(trigger, todo);
                
            }

            

            return ret;
            
            
        }

        internal void WriteFromFileToList()
        {
            try
            {
                Command[] todos = GetAllCommandsFromFile();
                if (todos == null) return;
                foreach (Command comd in todos)
                {
                    if (comd == null) return;
                    comingFromFile = true;
                    AddToHead(comd);
                }
            }
            catch(Exception e)
            {
                //TwitchChatBot.me.Client.SendChatMessage("!");
            }

            
        }

        public void UpdateGUI()
        {
            GuiManager.WriteToCommands();
        }

        internal string[] GetAllTriggers()
        {
            Command[] use = GetAllCommands(TwitchChatBot.THE_MAN);
            string[] ret = new string[use.Length];
            for(int i = 0; i < GetAllCommands(TwitchChatBot.THE_MAN).Length; i++)
            {
                ret[i] = use[i].Trigger;
            }
            return ret;
        }

        internal Command RemoveHead()
        {
            Command cmd = GetHead();
            commands.RemoveFirst();
            return cmd;
        }

        internal Command RemoveTail()
        {
            Command cmd = GetTail();
            commands.RemoveLast();
            return cmd;
        }

        internal Command RemoveCommand(Command command)
        {
            commands.Remove(command);
            WriteToFile();
            return command;
        }

        internal Command RemoveCommandUsingOnlyTrigger(string trigger)
        {
            string[] todos = GetAllTriggers();
            for(int i = 0; i < todos.Length; i++)
            {
                if (trigger == todos[i])
                {
                    return RemoveAtIndex(i);
                }
            }
            return null;
        }

        internal Command RemoveAtIndex(int index)
        {
            LinkedList<Command>.Enumerator enumerator = commands.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < index; i++)
            {
                enumerator.MoveNext();
            }
            return RemoveCommand(enumerator.Current);
            
        }

        internal Command GetAtIndex(int index)
        {
            LinkedList<Command>.Enumerator enumerator = commands.GetEnumerator();
            for(int i = 0; i < index; i++)
            {
                enumerator.MoveNext();
            }
            return enumerator.Current;
        }

        internal void AddToTail(Command comd)
        {
            commands.AddLast(comd);
        }


        private const string objName = "CommandList";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }

        public void SendData()
        {

        }
    }
}
