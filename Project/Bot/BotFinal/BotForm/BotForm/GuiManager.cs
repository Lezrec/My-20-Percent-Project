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
    }
}
