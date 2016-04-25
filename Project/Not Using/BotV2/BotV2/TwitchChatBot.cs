using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace BotV2
{
    /// <summary>
    ///  A simple Twitch chat bot. Able to switch channels and stuff.
    /// 
    /// </summary>
    public partial class TwitchChatBot : Form
    {

        private class BotNotFoundException : Exception
        {
            private string additionalText;

            public BotNotFoundException(string s)
            {
                additionalText = s;
            }

            public override string ToString()
            {
                return "BotNotFoundException: The bot was not initialiazed, and therefore the program couldn't run. Additional notes: " + additionalText;
            }
        }


        public static TwitchChatBot UseBot;
        public static CommandList list;

        public static CommandsFile cmdFile;
        public static ModsFile modFile;

        public static Channel ChannelIn;
        public static string ViewerList;
        public static int InputCount;

        public static int seconds;
        public static int minutes;
        public static int hours;
        public static double ticksTilSecond;
        public static int errorTicks;

        public Owner ChannelOwner
        {
            get { return new Owner(ChannelIn.Name); }
        }

        public Owner Developer
        {
            get { return new Owner("lezrecop"); }
        }

        public MessageLogger logger;


        private bool initialized; //, justSentMessage;
        private bool connected = false;
        private int currentTicks, lastTimeTicked;
        public static int lastSinceRippedToTxt;

        public int Ticks
        {
            get { return currentTicks; }
        }

        public bool Connected
        {
            get { return connected; }
            set { connected = value; }
        }
        

        public bool Initialized
        {
            get { return initialized; }
        }

        public TcpClient client;
        private StreamWriter writer;
        private StreamReader reader;

        public TwitchChatBot(string ip, int port)
        {
            InitializeComponent();
            try
            {
                Channel channelBase = new Channel("lezrecbot");
                TwitchChatBot.ChannelIn = channelBase;
                TwitchChatBot.ChannelIn.Switch(new Channel("lezrecbot"));
                client = new TcpClient(ip, port);
                writer = new StreamWriter(client.GetStream());
                reader = new StreamReader(client.GetStream());
                

                string password = File.ReadAllText("password.txt");


                writer.WriteLine("PASS " + password + Environment.NewLine
                    + "NICK lezrecbot" + Environment.NewLine
                    + "USER lezrecbot" + " 8 * :lezrecbot");
                writer.Flush();

                logger = new MessageLogger(true);
                list = new CommandList();
                initialized = true;
            }
            catch (Exception exc)
            {
                label1.Text += $"\r\r{exc.ToString()}";
                label1.Text += $"\r\nConstructor Error!";
                initialized = false;
            }
            finally
            {
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
                
            {
                
                initialized = true;
                cmdFile = new CommandsFile(ChannelIn.Name.ToLower() + "_commands");
                modFile = new ModsFile(ChannelIn.Name.ToLower() + "_mods");


            }
            catch(Exception exc)
            {
                label1.Text += $"\r\n{exc.ToString()}";
                label1.Text += $"\r\nForm Load Error!";
                initialized = false;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            ticksTilSecond = (double)1000 / (double)timer1.Interval;
            if ((double) Ticks % ticksTilSecond == 0)
            {
                seconds++;
            }
            if (seconds % 60 == 0)
            {
                seconds = 0;
                minutes++;
            }
            if (minutes % 60 == 0)
            {
                minutes = 0;
                hours++;
            }

            if (TwitchChatBot.UseBot == null)
            {
                throw new BotNotFoundException("Obviously you messed up Noah.");
            }


            try
            {
                if (lastTimeTicked == currentTicks)
                {
                    
                }
                else //if (InputCount < 15)
                {
                    lastTimeTicked = currentTicks;

                    if (client.Available > 0 || reader.Peek() > 0)
                    {
                        string message = reader.ReadLine();
                        if (Connected)
                        {
                            if (message.Contains("!") && message.Contains("@"))
                            {
                                string user = message.Substring(1, message.IndexOf("!") - 1);
                                if (!user.ToLower().Equals("lezrecbot"))
                                {
                                    User messageUser = new User(user);
                                    if (messageUser.Name.Equals(ChannelOwner.Name))
                                    {
                                        messageUser = ChannelOwner;
                                    }
                                    else if (messageUser.Name.Equals(Developer.Name))
                                    {
                                        messageUser = Developer;
                                    }
                                    string saidMessage = message.Substring(message.IndexOf("#" + ChannelIn.Name));
                                    saidMessage = saidMessage.Substring(message.IndexOf(":") + 1).Trim();
                                    saidMessage = saidMessage.Substring(saidMessage.IndexOf(":") + 1);
                                    Message msg = new Message(saidMessage, messageUser, DateTime.Now);
                                    InputCount++;
                                    Log(msg);
                                    MessageReader.Read(msg);
                                    logger.Log(msg);
                                    //logger.Log(saidMessage);
                                    lastSinceRippedToTxt++;

                                    //if (message.ToLower().Contains("lezrecbot i think you're stupid"))
                                    //{
                                     //   LezrecBotSendChatMessage(user + ". I think the same about you!");
                                   // }

                                    
                                }

                            }


                        }

                        if (!message.Contains("USERSTATE"))
                        {
                            label1.Text += $"\r\n{message}";
                        }
                        
                    }

                }
                    
                
                if (!Connected && currentTicks >= 5)
                {
                    SendIRCMessage("CAP REQ :twitch.tv/commands");
                }


                if (!Connected && currentTicks >= 10)
                {
                    Reconnect(ChannelIn);
                    //LezrecBotSendChatMessage("Hello! I am LezrecBot!");
                    LezrecBotSendChatMessage("MrDestructoid beep boo- I mean I'm a normal viewer Kappa");
                }

                if (currentTicks == 20)
                {
                    Whisper("lezrecop", "ok so dis work");
                }

            }
            catch(BotNotFoundException exc)
            {
                label1.Text += $"\r\n{exc.ToString()}";
                TwitchChatBot.UseBot = new TwitchChatBot("irc.twitch.tv", 6667);
            }

            catch(Exception exc)
            {
                if (errorTicks > 200)
                {
                    Application.Exit();
                }
                label1.Text += $"\r\nERROR ERROR BEEP BOOP";
                label1.Text += $"\r\n{exc.StackTrace}";
                textBox1.Text = $"!!!!!!!!!!!!!!!!!!!!!!";
                errorTicks++;

            }
            
            currentTicks++;

        }

        public void Reconnect(Channel channel)
        {
            if (initialized)
            {
                InputCount++;
                TwitchChatBot.ChannelIn = channel;
                ChannelIn.ConnectTo();
                
            }
            else
            {
                label1.Text += $"\r\nSomething happened. Now I can't connect! :(";
            }
        }

        public void SendIRCMessage(string message)
        {
            InputCount++;
            writer.WriteLine(message);
            writer.Flush();
        }

        public void AddToLabel(string message)
        {
            label1.Text += $"\r\n{message}";
        }

        public void Timeout(User user)
        {
            Command.Timeout(user).Execute();
        }

        public void LezrecBotSendChatMessage(string message)
        {
            if (ChannelIn != null)
            {
                string channelName = ChannelIn.Name;
                channelName = ChannelIn.Name;
                SendIRCMessage(":lezrecbot!lezrecbot@.tmi.twitch.tv PRIVMSG #" + channelName + " :" + message);
                //justSentMessage = true;
            }
            else
            {
                Console.WriteLine("You can't send a message if you're not in a channel.");
            }
            
        }

        public static void Log(Message message)
        {
            UseBot.label1.Text += $"\r\n{message.ToString()} LOG_MESSAGE_FROMUSER";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChannelIn = new Channel(textBox1.Text);
            MessageWithUserList.desigName = ChannelIn.Name;
            Reconnect(ChannelIn);
            LezrecBotSendChatMessage("Kappa This is a LezrecBoi attack you are now going to lose followers! Kappa");
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.github.com/Lezrec/My-20-Percent-Project");
            Process.Start(sInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals(""))
            {
                LezrecBotSendChatMessage(textBox2.Text);
                textBox2.Text = "";
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UseBot.logger.RipToTxt();
            TwitchChatBot.UseBot.LezrecBotSendChatMessage("Goodbye! HeyGuys");
            TwitchChatBot.UseBot.client.Close();
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           if (textBox2.Text.Contains("/end"))
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.IndexOf("/end"));
                button2_Click(sender, e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("/end"))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.IndexOf("/end"));
                button1_Click(sender, e);
            }
        }


        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            TwitchChatBot.ActiveForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            vScrollBar1.Enabled = false;
            vScrollBar1.Visible = false;
            TwitchChatBot.ActiveForm.AutoScroll = true;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        public static void LogError(string error)
        {
            UseBot.label1.Text += $"\r\n{error}";
        }

        public void Whisper(string user, string mesage)
        {
            
            //TODO THIS
            SendIRCMessage("CAP REQ :twitch.tv/commands");
            SendIRCMessage("PRIVMSG #jtv :.w " + user + " " + mesage);
            
        }

    }
}
