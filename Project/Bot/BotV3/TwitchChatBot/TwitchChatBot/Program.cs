using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchChatBot
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
            Application.Run(new TwitchBot());
        }

        internal static void ShutDownAfterSeconds(int seconds)
        {
            TimeFromBot.WaitForSeconds(seconds);           
            Application.Exit();
        }
    }
}
