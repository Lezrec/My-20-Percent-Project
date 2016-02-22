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
        int ticks;
        int getTick;
        int minutes;
        int seconds;
        int hours;
        float getMultiplier;
        string owner;
        string[] commands;
        string[] mods;
        int msgCt;
        int getSec;
        int totalSec;
        bool cmdsOn;
        bool cmdsDisp;
        bool swearPermit;
        string[] modCmds;
        string[] ownerCmds;
        string[] totalMods;
        bool reminder = false;
        bool haveModPowers = false;



        public TwitchBot(string ip, int port, string[] cmds, string owner)
        {
            totalMods = new string[100];
            ownerCmds = new string[] { "!dismiss", "!addmods + user + ;", "!removemods + user + ;" , "!swearson (if bot is modded)", "!swearsoff", "!modcommands", "!ownercommands", "!modbot", "!unmodbot" };
            modCmds = new string[] { "!swearson (if bot is modded", "!swearsoff", "!modcommands" };
            swearPermit = true;
            cmdsOn = false;
            cmdsDisp = false;
            tcpClient = new TcpClient(ip, port);
            InitializeComponent();

            reconnectAmount = 0;
            errorShown = false;
            userName = "lezrecbot";

            this.owner = owner;
            this.channel = this.owner;
            aLabel.Text += $"\r\nOwner = " + channel;
            ticks = 0;
            getTick = 0;
            minutes = 0;
            commands = cmds;
            msgCt = 0;
            try {
                mods = File.ReadAllText("mods_" + channel + ".txt").ToLower().Split(' ');

            }
            catch (Exception exc)
            {
                File.Create("mods_" + channel + ".txt");
                mods = new string[100];
                mods[0] = "";

            }
            for (int i = 0; i < mods.Length; i++)
            {
                totalMods[i] = mods[i];
            }
            mods = new string[100];
            mods = totalMods;

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
            getMultiplier = ((float)1 / ((float)timer1.Interval / (float)1000));


        }

        void aLabel_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (totalSec % 119 == 0 && totalSec > 0 && reminder)
            {

                reminder = false;
            }

            if (totalSec % 120 == 0 && totalSec > 0 && !reminder)
            {
                SendChatMessage("I am an experimental bot! If you wish to kick me out of this chat, say \"!dismiss\"");
                reminder = true;
            }

            if (totalSec == 30 && !cmdsOn)
            {
                SendChatMessage("Commands are now enabled!");
                cmdsOn = true;

            }

            if (totalSec == 35 && !cmdsDisp)
            {
                ListCommands();
                cmdsDisp = true;
            }

            if (ticks % getMultiplier == 0 && ticks > 0)
            {
                seconds++;
                totalSec++;
            }

            if (seconds % 60 == 0 && seconds > 0)
            {
                minutes++;
                seconds = 0;
            }

            if (minutes % 60 == 0 && minutes > 0)
            {
                hours++;
                minutes = 0;
            }

            if (!joined)
            {
                Reconnect();
            }
            try
            {
                if (tcpClient.Available > 0 || reader.Peek() >= 0)
                {

                    string message = reader.ReadLine();
                    aLabel.Text += $"\r\n{message}";
                    string user = message.Substring(message.IndexOf("@") + 1, message.IndexOf("!") - 1).Trim();
                    if (message.Length > 250 && haveModPowers)
                    {
                        ModTimeout(user, 30);
                        SendChatMessage("No spammerino please!");
                    }




                    CheckCMD(message, user);



                }



                if (!joined)
                {
                    owner = channel;
                    aLabel.Text += $"\r\nConnecting";

                    writer.WriteLine("JOIN #" + channel);
                    writer.Flush();

                    joined = true;
                    SendChatMessage("Hello! I am LezrecBot! If I have been summoned and you wish to dismiss me (channel owner), say !dismiss and I will dissapear!");
                }
            }

            catch (Exception exc)
            {
                Console.WriteLine("Something happened.");
                Console.WriteLine(exc.GetType().ToString());
                Console.WriteLine("Likely causes: Blocked connection to Twitch IRC, no internet, or black magics.");
                Console.WriteLine(exc.ToString());
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
            ticks++;
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

                SendChatMessage("Goodbye! HeyGuys");
                tcpClient.Close();
                joined = false;
                aLabel.Text += $"Disconnected";
                Application.Exit();
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

        public void Timeout(string user)
        {
            if (getTick != ticks)
            {
                SendChatMessage("/timeout " + user);
                try
                {


                    if (tcpClient.Available > 0 || reader.Peek() >= 0)
                    {
                        var message = reader.ReadLine();
                        if (message.Contains("421"))
                        {
                            aLabel.Text += $"\r\nUsername doesn't exist";
                        }
                        else
                        {
                            SendChatMessage(user + " has been timed out. Don't be bad! :/");
                        }
                        aLabel.Text += $"\r\n{message}";
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.GetType().ToString());
                    Console.WriteLine("Something happened during the ban command");

                }
            }
            getTick = ticks;
        }

        private void CheckCMD(string cmd, string user)
        {

            if ((totalSec - getSec >= 10 || IsMod(user) || user.Equals(owner)))
            {
                if (cmd.Contains("!addmods") && user.Equals(owner) && cmd.Contains(";") && cmd.IndexOf("!addmods") < cmd.IndexOf(";"))
                {
                    SendChatMessage("in addmods");

                    int index = cmd.IndexOf("!addmods") + 9;
                    int endCMD = cmd.IndexOf(";");
                    string allMods = "";
                    string newMod = cmd.ToLower().Substring(index, endCMD - index) + " ";
                    bool alreadyAdded = false;
                    int modCt = 0;
                    for (int i = 0; i < mods.Length; i++)
                    {
                        if (mods[i].Trim().ToLower().Equals(newMod.Trim()))
                        {
                            SendChatMessage("Already added this mod.");
                            alreadyAdded = true;
                        }
                        if (mods[i] == null)
                        {
                            modCt = i;
                            break;
                        }
                        allMods += mods[i] + " ";
                    }

                    if (!alreadyAdded)
                    {
                        allMods += newMod;
                        File.WriteAllText("mods_" + channel + ".txt", allMods);
                        mods[modCt] = newMod;
                        SendChatMessage("Added " + cmd.Substring(index, endCMD - index));
                    }




                }

                if (cmd.Contains("!dismiss") && user.Equals(owner))
                {
                    Disconnect();
                }

                if (cmd.Contains("!modcommands") && (IsMod(user) || user.Equals(owner)))
                {
                    SendChatMessage(ListModCommands());

                }

                if (cmd.Contains("!ownercommands") && (user.Equals(owner)))
                {
                    SendChatMessage(ListOwnerCommands());

                }

                if (cmd.Contains("!swearson") && (IsMod(user) || user.Equals(owner)))
                {
                    swearPermit = true;

                    SendChatMessage("Sailor mode enabled!");
                }

                if (cmd.Contains("!swearsoff") && (IsMod(user) || user.Equals(owner)))
                {
                    swearPermit = false;
                    SendChatMessage("Watch your tongues!");

                }

                if (cmd.Contains("***") && swearPermit == false)
                {
                    aLabel.Text += $"\r\nbad word detected";

                    ModTimeout(user, 60);
                    SendChatMessage("Bad " + user + "!");
                    msgCt++;
                }

                if (cmd.Contains("!time") && msgCt < 5)
                {

                    if (hours < 1)
                    {
                        SendChatMessage("I have been live for: " + minutes + " minutes and " + seconds + " seconds.");
                    }
                    else if (hours == 1)
                    {
                        SendChatMessage("I have been live for : " + hours + " hour, " + minutes + " minutes, and " + seconds + " seconds.");
                    }
                    else
                    {
                        SendChatMessage("I have been live for: " + hours + " hours, " + minutes + " minutes, and " + seconds + " seconds.");
                    }
                    msgCt++;
                }

                if (cmd.Contains("!cantbanthesemoves") && msgCt < 5)
                {

                    if (cmd.Contains("x1") || cmd.Contains("x2") || cmd.Contains("x3") || cmd.Contains("x4") || cmd.Contains("x5") || cmd.Contains("x6") || cmd.Contains("x7") || cmd.Contains("x8") || cmd.Contains("x9"))
                    {
                        int index = cmd.IndexOf("x");

                        bool caughtexc = false;

                        string ma = cmd.Substring(index + 1, 1);
                        aLabel.Text += $"\r\n{ma}";

                        int ct = 0;
                        try
                        {
                            ct = int.Parse(ma);
                        }
                        catch (Exception exce)
                        {
                            caughtexc = true;
                            SendChatMessage("Not a valid amount.");
                        }
                        if (!caughtexc)
                        {
                            ct = int.Parse(ma);
                        }
                        string retMsg = "";
                        for (int i = 0; i < ct; i++)
                        {
                            retMsg += "SourPls ";
                        }
                        SendChatMessage(retMsg);
                        getSec = totalSec;
                    }
                    else
                    {
                        SendChatMessage("SourPls");
                        msgCt++;
                        getSec = totalSec;
                    }

                }

                if (cmd.Contains("!NA") && msgCt < 5)
                {
                    SendChatMessage("OpieOP MY BELLY IS BIG OpieOP MY BRAIN HAS DELAY OpieOP YOU GUESSED RIGHT OpieOP IM FROM NA OpieOP");
                    msgCt++;
                    getSec = totalSec;
                }

                if (cmd.Contains("!commands") && msgCt < 5)
                {
                    ListCommands();
                }

                if (cmd.Contains("!EU") && msgCt < 5)
                {
                    SendChatMessage("4Head MY TEETH ARE BROWN 4Head I SMELL LIKE POO 4Head YOU GUESSED RIGHT 4Head IM FROM EU 4Head");
                    msgCt++;
                    getSec = totalSec;
                }

                if (cmd.Contains("!modbot") && user.Equals(owner))
                {
                    haveModPowers = true;
                    SendChatMessage("I now think I can moderate! Please make sure to mod me if this is the case.");
                }

                if (cmd.Contains("!unmodbot") && user.Equals(owner))
                {
                    haveModPowers = false;
                    SendChatMessage("I now think I cannot moderate! Please make sure to unmod me if this is the case.");
                }

                if (cmd.Contains("!removemods") && user.Equals(owner) && cmd.Contains(";") && cmd.IndexOf("!removemods") < cmd.IndexOf(";"))
                {
                    SendChatMessage("in removemods");

                    int index = cmd.IndexOf("!removemods") + 11;
                    int endCMD = cmd.IndexOf(";");

                    string newMod = cmd.ToLower().Substring(index, endCMD - index);
                    

                    RemoveMod(newMod);
                    




                }

                if (cmd.Contains("!mods") && user.Equals(owner))
                {
                    ListMods();

                }

                if (cmd.ToLower().Contains("is " + owner) && msgCt < 5)
                {
                    SendChatMessage("Yes " + user + " Kappa");
                    msgCt++;
                    getSec = totalSec;
                }
            }
            msgCt = 0;

        }

        private bool IsMod(string user)
        {
            bool isMod = false;
            mods = File.ReadAllText("mods_" + owner + ".txt").ToLower().Split(' ');
            foreach (string moderator in mods)
            {
                if (user.Trim().ToLower().Equals(moderator.ToLower().Trim()))
                {
                    isMod = true;
                }
            }
            return isMod;
        }

        private void ModTimeout(string user, int time)
        {
            if (haveModPowers)
            {
                if (getTick != ticks && time <= 300)
                {
                    SendChatMessage("/timeout " + user + " " + time);
                    try
                    {


                        if (tcpClient.Available > 0 || reader.Peek() >= 0)
                        {
                            var message = reader.ReadLine();
                            if (message.Contains("421"))
                            {
                                aLabel.Text += $"\r\nUsername doesn't exist";
                            }
                            else
                            {
                                SendChatMessage(user + " has been timed out. Don't be bad! :/");
                            }
                            aLabel.Text += $"\r\n{message}";
                        }
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.GetType().ToString());
                        Console.WriteLine("Something happened during the ban command");

                    }
                }
            }
            getTick = ticks;
        }

        public void ListCommands()
        {
            string cmds = "Commands: ";
            foreach (string cmd in commands)
            {
                cmds += cmd + " ";
            }
            SendChatMessage(cmds);
        }

        public string ListOwnerCommands()
        {
            string cmds = "Owner Commands: ";
            foreach (string cmd in ownerCmds)
            {
                cmds += cmd + " ";
            }
            return cmds;
        }

        public string ListModCommands()
        {
            string cmds = "Mod Commands: ";
            foreach (string cmd in modCmds)
            {
                cmds += cmd + " ";
            }
            return cmds;
        }

        public void ListMods()
        {
            string retMods = "Mods: ";
            foreach (string mod in mods)
            {
                retMods += mod + " ";
            }
            SendChatMessage(retMods);
        }


        public void UpdateMods()
        {
            string allMods = "";
            foreach(string mod in mods)
            {
                allMods += mod + " ";
            }
            File.WriteAllText("mods_" + owner + ".txt", allMods);
        }

        public void RemoveMod(string user)
        {
            bool removed = false;
            for (int i = 0; i < mods.Length; i++)
            {
                string mod = mods[i];
                if (mods == null)
                {
                    break;
                }
                if (user.Trim().ToLower().Equals(mod.Trim().ToLower()))
                {
                    mods[i] = null;
                    removed = true;

                    for(int j = i + 1; j < mods.Length; j++)
                    {
                        if (mods[j] == null)
                        {
                            break;
                        }
                        mods[j - 1] = mods[j];
                        
                    }
                }
            }
            if (removed)
            {
                SendChatMessage("Removed " + user);
            }
            else
            {
                SendChatMessage("Invalid user: " + user);
            }
            UpdateMods();
        }

        
    }
}
