using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace TwitchChatBot
{
    /// <summary>
    /// Edits all files inside the bot.
    /// </summary>
    public static class FileEditor
    {
        private static ThreadStart fileThreadStart;
        private static Thread fileThread;
        private static bool executing;

        /// <summary>
        /// Called at the start of the program.
        /// </summary>
        public static void Load()
        {
            fileThreadStart = new ThreadStart(Run);
            fileThread = new Thread(fileThreadStart);
            fileThread.Start();
        }

        /// <summary>
        /// Whether the FileEditor is running.
        /// </summary>
        public static bool Executing
        {
            get { return executing; }
        }

        /// <summary>
        /// The delegated method of the thread.
        /// </summary>
        public static void Run()
        {

        }

        /// <summary>
        /// The main tick method of this class.
        /// </summary>
        public static void Tick()
        {

        }

        private static void Modify(string name, string text)
        {
            executing = true;
            //stuff
            executing = false;
        }

        private static void Queue(string name)
        {

        }

        public static string GetTextFrom(string name)
        {
            try
            {
                string ret = File.ReadAllText(name);
                return ret;
            }
            catch(Exception e)
            {
                return "";
            }

        }

    }
}
