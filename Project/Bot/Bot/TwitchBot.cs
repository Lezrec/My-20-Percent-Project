using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace Bot
{
    public partial class TwitchBot : Form
    {
        TcpClient tcpClient;
        StreamReader reader;
        StreamWriter writer;
        bool joined;
        int reconnectAmount;
        bool errorShown;
        int errorTicks;
        string userName;
        string channel;

        public TwitchBot(string ip, int port)
        {
            tcpClient = new TcpClient(ip, port);
            InitializeComponent();
            
            reconnectAmount = 0;
            errorShown = false;
            userName = "lezrecop";
            channel = "lezrecop";

        }

        private void Reconnect()
        {

            
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());

            var password = File.ReadAllText("password.txt");
            

            writer.WriteLine("PASS " + password + Environment.NewLine
                + "NICK " + userName + Environment.NewLine
                + "USER " + userName + " 8 * :" + userName);
            writer.Flush();
            joined = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            aLabel.Text += $"\r\nLets load it up";
            
        }

        void aLabel_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!joined)
            {
                Reconnect();
            }
            try
            {
                if (tcpClient.Available > 0 || reader.Peek() >= 0)
                {
                    var message = reader.ReadLine();
                    aLabel.Text += $"\r\n{message}";

                }



                if (!joined)
                {
                    
                    aLabel.Text += $"\r\nConnecting";
                    writer.WriteLine("JOIN #" + channel);
                    writer.Flush();
                    joined = true;
                    SendChatMessage("Hello! I am LezBot!");
                }
            }

            catch (Exception exc)
            {
                Console.WriteLine("Something happened.");
                Console.WriteLine(exc.GetType().ToString());
                Console.WriteLine("Likely causes: Blocked connection to Twitch IRC, no internet, or black magics.");
            }


            if (reconnectAmount >= 10)
                {
                    errorTicks++;
                    if (errorShown == false)
                    {
                        Console.WriteLine("Too many reconnects, exiting...");
                        errorShown = true;
                    }

                    if (errorTicks >= 5)
                    {
                        Application.Exit();
                    }
                

                if (!tcpClient.Connected && reconnectAmount < 10)
                {
                    aLabel.Text += $"\r\nAttempting reconnect...";
                    reconnectAmount++;
                    Reconnect();
                }

                

            }
        }

        public void JoinRoom(string channel)
        {
            this.channel = channel;
            writer.WriteLine("JOIN #" + channel);
            writer.Flush();
        }

        public void Disconnect()
        {
            if (joined)
            {
                tcpClient.Close();
                joined = false;
                aLabel.Text += $"Disconnected";
            }
        }

        public void SendIRCMessage(string message)
        {
            writer.WriteLine(message);
            writer.Flush();
        }

        public void SendChatMessage(string message)
        {

            SendIRCMessage(":" + userName + "!" + userName + "@" + userName 
                + ".tmi.twitch.tv PRIVMSG #" + channel + " :" + message);
        }

        public string ReadMessage()
        {
            string msg = reader.ReadLine();
            return msg;

        }
    }
}
