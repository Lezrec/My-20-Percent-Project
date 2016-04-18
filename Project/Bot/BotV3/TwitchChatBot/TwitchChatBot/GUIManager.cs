using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchChatBot
{
    /// <summary>
    /// Manages the GUI.
    /// </summary>
    public static class GUIManager
    {
        private static TwitchBot bot;
        private static Label label;
        private static int lastTick;
        private static int currentTick;


        internal static TwitchBot Bot
        {
            get { return bot; }
            set { bot = value; }
        }

        /// <summary>
        /// Called at the start of the program.
        /// </summary>
        public static void Load()
        {
            label = bot.MyLabel;
        }

        /// <summary>
        /// Writes to the label (Should use this one).
        /// </summary>
        /// <param name="text"></param>
        public static void WriteToRawLabel(string text)
        {
            bot.WriteToRawLabel($"\r\n{text}");
        }


        /// <summary>
        /// The main tick method of this class.
        /// </summary>
        public static void Tick()
        {
            
            
        }


    }
}
