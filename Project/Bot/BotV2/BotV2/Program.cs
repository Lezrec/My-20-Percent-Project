using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotV2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TwitchChatBot.UseBot = new TwitchChatBot("irc.twitch.tv", 6667);
            Application.Run(TwitchChatBot.UseBot);
        }
    }
}
