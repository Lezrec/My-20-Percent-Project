using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BotV2
{
    public class CommandsFile : BotFile
    {
        Command[] commands;
        int size;

        public CommandsFile(string name) : base(name)
        {
            size = 0;
            MakeSureYouCanWrite();
            commands = new Command[100];
            string stuffInFile = File.ReadAllText(directory);
            char[] cutOff = "(SIGNED_END_12345)".ToCharArray();
            string[] stuffSplitUp = stuffInFile.Split(cutOff);
            
            foreach(string stuff in stuffSplitUp)
            {
                try
                {
                    string use = stuff;
                    string permission = use.Substring(0, use.IndexOf(":"));
                    use = use.Substring(use.IndexOf(":") + 1);
                    string trigger = use.Substring(0, use.IndexOf(",.,"));
                    use = use.Substring(0, use.IndexOf(",.,") + 1);
                    string todo = use.Substring(0, use.IndexOf("(SIGNED_END_12345)"));

                    if (permission == "owner")
                    {
                        commands[size] = new OwnerCommand(trigger, todo);
                    }
                    else if (permission == "mod")
                    {
                        commands[size] = new ModCommand(trigger, todo);
                    }
                    else
                    {
                        commands[size] = new Command(trigger, todo);
                    }
                    size++;
                }
                catch(ArgumentOutOfRangeException e)
                {
                    TwitchChatBot.UseBot.AddToLabel("Something caught in COMMANDSFILE, exiting.");
                    break;
                }
                
            }
            TwitchChatBotToList();
        }

        public void Add(Command comd)
        {
            if (!TriggerMatch(comd.Trigger))
            {
                string designation = "";
                if (comd is OwnerCommand)
                {
                    designation = "owner";
                }
                else if (comd is ModCommand)
                {
                    designation = "mod";
                }
                else
                {
                    designation = "normal";
                }
                string total = designation + ":";
                total += comd.Trigger + ",.,";
                total += comd.CommandLine;
                total += "(SIGNED_END_12345)";

                WriteNewLine(total);
            }
            
        }

        public bool TriggerMatch(string trigger)
        {
            foreach(Command comd in commands)
            {
                if (comd.Trigger.ToLower() == trigger.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public Command GetAsCommand(int index)
        {
            return commands[index];
        }

        public void TwitchChatBotToList()
        {
            foreach(Command comd in commands)
            {
                if (comd != null)
                {
                    TwitchChatBot.list.AddCommand(comd, new Owner("Developer"));
                }
                else
                {
                    
                    TwitchChatBot.UseBot.AddToLabel("Command was null in commandsfile. ¯\\_(ツ)_/¯");
                    break;
                    
                }
                
            }
            
        }
    }
}
