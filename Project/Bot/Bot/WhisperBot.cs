using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
{
    class WhisperBot
    {
        TwitchBot bot;
        public WhisperBot(string i)
        {
            bot = new TwitchBot("199.9.253.59:80", 80 , null);
            Application.Run(bot);
        }

        private void Whisper(string msg, string user)
        {
            bot.SendIRCMessage(".CAP REQ:twitch.tv/commands");
            bot.SendIRCMessage(":" + user + "!" + user + "@" + user + ".tmi.twitch.tv .WHISPER lezrecbot: " + msg);
        }

        void timer2_tick(object sender, EventArgs e)
        {
            
        }
    }
}
