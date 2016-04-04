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

        public CommandsFile(string name) : base(name)
        {
            MakeSureYouCanWrite();
            string stuffInFile = File.ReadAllText(directory);
            char[] cutOff = "(SIGNED_END_12345)".ToCharArray();
            string[] stuffSplitUp = stuffInFile.Split(cutOff);
            
        }

        public void Add(Command comd)
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
            total += " (SIGNED_END_12345)";

            WriteNewLine(total);
        }

        public void TwitchChatBotToList()
        {

        }
    }
}
