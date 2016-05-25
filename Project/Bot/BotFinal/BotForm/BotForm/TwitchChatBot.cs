using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalTwitch.Timing;
using System.IO;

namespace BotForm
{

    public partial class TwitchChatBot : Form //cant extend botrelatedobject but if this is truly good it shouldnt need to have any important methods inside here
    {
        internal CommandList cmdList;
        internal ModCommandList modCmdList;
        internal OwnerCommandList ownerCmdList;
        internal FileEditor cmdsFromFile;
        internal FileEditor modCmdsFromFile;
        internal FileEditor ownerCmdsFromFile;
        internal PersonalTimer timer;
        internal static bool started = false;
        internal HappeningHandler myHandler;
        internal BotClient Client;
        internal MessageScrubber Scrubber;
        internal Channel ChannelIn;
        internal static Developer THE_MAN;
        internal static Developer Twitch_IRC;
        internal static bool connected = false;
        internal FileEditor myEditor;
        internal static UserList myUsers = new UserList();
        internal static ModList myMods = new ModList();
        internal ChatLog chatLog;

        private object loadObj;
        private EventArgs loadEventArgs;
        
        internal static TwitchChatBot me;

        private delegate string MyWriting();

        public TwitchChatBot()
        {
            InitializeComponent();
            
            me = this;
            
            ChannelIn = new Channel("lezrecop"); //start in my channel because why not :)
            Client = new BotClient();
            Scrubber = new MessageScrubber();
        }

        internal void AddHappening(BotRelatedObject sender, Happening e)
        {
            myHandler.Handle(sender, e);
        }

        internal void WriteToOutput(string text)
        {
            OutputText.Text += $"\r\n{text}";  
        }

        internal void WriteToDebug(string text)
        {
            DebugTextBox.Text += $"\r\n{text}";
        }

        internal void Reload()
        {
            Form1_Load(loadObj, loadEventArgs);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadObj = sender;
            loadEventArgs = e;
            if (!started)
            {
                
                
                Size = new Size((int)1280 / (int)2, (int)720 / (int)2);
                MinimumSize = Size;
                MaximumSize = Size;
                timer = new PersonalTimer();
                
                started = true;
                myHandler = new HappeningHandler();
                THE_MAN = new Developer("lezrecop", 3);
                Twitch_IRC = new Developer("Twitch", 3);
                Client.Load();
                
                cmdsFromFile = new FileEditor(ChannelIn.Name + "_cmds.txt");
                modCmdsFromFile = new FileEditor(ChannelIn.Name + "_mod_cmds.txt");
                ownerCmdsFromFile = new FileEditor(ChannelIn.Name + "_owner_cmds.txt");
                if (Client.CanConnect())
                {
                    timer.Start();
                    Client.JoinChannel(ChannelIn);
                    label3.Text = $"Current Channel: {ChannelIn.Name}";
                    cmdList = new CommandList();
                    modCmdList = new ModCommandList();
                    ownerCmdList = new OwnerCommandList();
                    cmdList.UpdateGUI();
                    chatLog = new ChatLog(ChannelIn);
                }
                else
                {
                    timer.Abort();
                    
                }

                
                
                
                
            //To frikken do the mass comment do Ctrl + K + C
            //BeginTesting
            //Happening hap1 = new Happening();
            //Happening hap2 = new Happening();
            //Happening hap3 = new Happening();
            //Happening hap4 = new Happening();
            //Happening hap5 = new Happening();
            //Happening[] haps = new Happening[] { hap1, hap2, hap3, hap4, hap5 };
            //HappeningList list = new HappeningList();
            //foreach(Happening hap in haps)
            //{
            //    list.Add(hap);
            //}
            //EndTesting
            }

        }

        private void OutputLabel_Click(object sender, EventArgs e)
        {

        }

        

        public void WriteToCMDTrig(string text)
        {
            string prev = cmdText.Text;
            prev += text + Environment.NewLine ;
            cmdText.Text = prev;
            //cmdText.Update();
        }

        public void WriteToCMDWhatItDo(string text)
        {
            
            string prev = whatItDoText.Text;
            prev += text + Environment.NewLine;
            whatItDoText.Text = prev;
           // whatItDoText.Update();
        }

        public void WipeCommands()
        {
            whatItDoText.Text = " ";
            cmdText.Text = " ";
        }

        private void comdB_Click(object sender, EventArgs e)
        {
            if (trigBox.Text == "")
            {
                return;
            }
            if (trigBox.Text.Substring(0,1) != "!")
            {
                trigBox.Text = "!" + trigBox.Text;
            }
            string trigger = trigBox.Text;
            string todo = doBox.Text;
            for (int i = 0; i < me.cmdList.GetAllTriggers().Length; i++)
            {
                if (trigger == me.cmdList.GetAllTriggers()[i])
                {
                    return; //makes sure that you cant add a command that does 2 things
                }
            }

            Command command = new Command(trigger, todo);
            me.cmdList.AddToHead(command);
            GuiManager.WriteToCommands();
            trigBox.Text = "";
            doBox.Text = "";
        }

        private void modCmdB_Click(object sender, EventArgs e)
        {
            if (trigBox.Text == "")
            {
                return;
            }
            if (trigBox.Text.Substring(0, 1) != "!")
            {
                trigBox.Text = "!" + trigBox.Text;
            }
            string trigger = trigBox.Text;
            string todo = doBox.Text;
            for (int i = 0; i < TwitchChatBot.me.modCmdList.GetAllTriggers().Length; i++)
            {
                if (trigger == TwitchChatBot.me.modCmdList.GetAllTriggers()[i])
                {
                    return; //makes sure that you cant add a command that does 2 things
                }
            }

            ModCommand command = new ModCommand(trigger, todo);
            TwitchChatBot.me.modCmdList.AddToHead(command);
            trigBox.Text = "";
            doBox.Text = "";
        }

        private void ownerCmdB_Click(object sender, EventArgs e)
        {
            if (trigBox.Text == "")
            {
                return;
            }
            if (trigBox.Text.Substring(0, 1) != "!")
            {
                trigBox.Text = "!" + trigBox.Text;
            }
            string trigger = trigBox.Text;
            string todo = doBox.Text;
            for (int i = 0; i < TwitchChatBot.me.ownerCmdList.GetAllTriggers().Length; i++)
            {
                if (trigger == TwitchChatBot.me.ownerCmdList.GetAllTriggers()[i])
                {
                    return; //makes sure that you cant add a command that does 2 things
                }
            }

            OwnerCommand command = new OwnerCommand(trigger, todo);
            TwitchChatBot.me.ownerCmdList.AddToHead(command);
            trigBox.Text = "";
            doBox.Text = "";
        }

        private void banB_Click(object sender, EventArgs e)
        {
            me.Client.SendChatMessage($"/ban {banBox.Text.ToLower()}");
            banBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secs = 0;
            try
            {
                secs = int.Parse(secondsBox.Text);
            }
            catch(Exception ea)
            {
                secs = 600;
            }
            me.Client.SendChatMessage($"/timeout {timeoutBox.Text.ToLower()} {secs}");
        }

        private void chB_Click(object sender, EventArgs e)
        {
            if (chBox.Text.Trim() != "")
            {
                string chan = chBox.Text;
                me.Client.JoinChannel(new Channel(chan.ToLower()));
                label3.Text = $"Current Channel: {chan}";
                chBox.Text = "";
                cmdList.UpdateGUI();
            }
            
        }
    }
}
