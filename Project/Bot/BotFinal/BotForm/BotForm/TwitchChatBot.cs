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
        internal FileEditor cmdsFromFile;
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
                FileEditor testEditor = new FileEditor("test.txt");
                testEditor.WriteLine("kay");
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
                if (Client.CanConnect())
                {
                    timer.Start();
                    Client.JoinChannel(ChannelIn);
                    cmdList = new CommandList();
                    cmdList.UpdateGUI();
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
            cmdText.Update();
        }

        public void WriteToCMDWhatItDo(string text)
        {
            
            string prev = whatItDoText.Text;
            prev += text + Environment.NewLine;
            whatItDoText.Text = prev;
            whatItDoText.Update();
        }

        public void WipeCommands()
        {
            whatItDoText.Text = "";
            cmdText.Text = "";
        }
    }
}
