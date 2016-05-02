using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal static class GuiManager
    {
        
        private delegate void MyWriteTo(string text);
        private delegate void MyInvoke();

        public static void WriteToOutput(string text)
        {
            MyWriteTo del = txt => TwitchChatBot.me.WriteToOutput(txt);
            MyInvoke voker = () => del(text);
            
            TwitchChatBot.me.Invoke(voker);
        }

        public static void WriteToDebug(string text)
        {
            MyWriteTo del = txt => TwitchChatBot.me.WriteToDebug(txt);
            MyInvoke voker = () => del(text);

            TwitchChatBot.me.Invoke(voker);
        }

        public static void WriteToCommands()
        {
            Command[] comds = TwitchChatBot.me.cmdList.GetAllCommands();
            TwitchChatBot.me.WipeCommands();
            string cmds = "Commands:";
            string whatItDos = "What it does:";
            TwitchChatBot.me.WriteToCMDTrig(cmds);
            TwitchChatBot.me.WriteToCMDWhatItDo(whatItDos);
            foreach(Command command in comds)
            {
                //cmds += command.Trigger;
              //  whatItDos += (string)command.ToDo;
                TwitchChatBot.me.WriteToCMDWhatItDo(command.ToDo);
                TwitchChatBot.me.WriteToCMDTrig(command.Trigger);
            }
            
        }

    }
}
