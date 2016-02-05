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
using System;

namespace TwitchBot
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        StreamReader reader;
        StreamWriter writer;

        public Form1()
        {
            InitializeComponent();
            Reconnect();

        }

        private void Reconnect()
        {
            tcpClient = new TcpClient("irc.twitch.tv", 6667);
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());

            var username = "LezrecOP";

            var password = File.ReadAllText("password.txt");
            writer.WriteLine("PASS " + password + Environment.NewLine
                + "NOAH " + username + Environment.NewLine
                + "USER + username + "  + " 8 * :" + username);
            writer.Flush();
            writer.WriteLine("JOIN LezrecOP");
            writer.Flush();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (!tcpClient.Connected)
            {
                Reconnect();
            }

            if (tcpClient.Available > 0 || reader.Peek() >= 0)
            {
                var message = reader.ReadLine();
                Label aLabel = new Label();
                aLabel.Text += $"\r\n{message}";
            }
        }
    }
}
