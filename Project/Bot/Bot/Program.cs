﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bot
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
            TwitchBot bot = new TwitchBot("irc.twitch.tv", 6667, new string[] { "!NA", "!EU", "!cantbanthesemoves", "!time", }, "hardlydifficult");
            
            Application.Run(bot);
            
        }
    }
}
