using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BotV2
{
    class MessageWithUserList
    {
        private string desigName = TwitchChatBot.ChannelIn.Name.ToLower();
        private List<Message> messages = new List<Message>();

        public MessageWithUserList()
        {
            
            try
            {
                string something = File.ReadAllText(desigName + "_Ulogs");
            }
            catch(FileNotFoundException exc)
            {
                int j = 0;
                File.Create(desigName + "_Ulogs");
                int i = 0;
                File.WriteAllText(desigName + "_Ulogs", Environment.NewLine);
            }
            catch(IOException exc)
            {
                desigName = TwitchChatBot.ChannelIn.Name.ToLower();
                int j = 0;
                File.Create(desigName + "_Ulogs");
                int i = 0;
                File.WriteAllText(desigName + "_Ulogs", Environment.NewLine);
                //TwitchChatBot.LogError(exc.ToString());
            }

            String allTextInFile = File.ReadAllText(desigName + "_Ulogs");
            String[] linesOfText = allTextInFile.Split(Environment.NewLine.ToCharArray());
            
            foreach (String msg in linesOfText)
            {
                if (msg.Contains("LOG_MESSAGE_FROMUSER"))
                {
                    string user = msg.Substring(0, msg.IndexOf("said") - 1);
                    User usr = new User(user);
                    string month = msg.Substring(msg.IndexOf("DT1=") + 4, msg.IndexOf("DT2=") - msg.IndexOf("DT1="));
                    string day = msg.Substring(msg.IndexOf("DT2=") + 4, msg.IndexOf("DT3=") - msg.IndexOf("DT2="));
                    string year = msg.Substring(msg.IndexOf("DT3=") + 4, msg.Trim().Length - msg.IndexOf("DT3="));
                    int monthNum = int.Parse(month);
                    int dayNum = int.Parse(day);
                    int yearNum = int.Parse(year);
                    DateTime dt = new DateTime(yearNum, monthNum, dayNum);
                    string cutOff = msg.Substring(msg.IndexOf(":") + 2, msg.Trim().Length - msg.IndexOf("at" + dt.ToString()));
                    Message mesg = new Message(cutOff, usr, dt);
                    messages.Add(mesg);
                }

                    
            }

        }


        public void Add(Message msg)
        {
            try
            {
                messages.Add(msg);
            }
            catch (NullReferenceException exc)
            {
                desigName = TwitchChatBot.ChannelIn.Name;
            }
            
        }

        public Message Get(int index)
        {
            return messages.ToArray()[index];
        }

        public bool Contains(Message msg)
        {
            return messages.Contains(msg);
        }

        public Message[] ToArray()
        {
            return messages.ToArray();
        }

        public string AllText()
        {
            Message[] msgs = ToArray();
            string ret = "";
            foreach(Message msg in msgs)
            {
                ret += msg.ToString() + Environment.NewLine;
            }
            return ret;
        }

        public string[] ToArrayString()
        {
            string[] _array = new string[ToArray().Length];
            Message[] _msgArray = ToArray();
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = _msgArray[i].ToString();
            }
            return _array;
        }

        
        public void RipToTxt()
        {
            
            try
            {
                
                File.ReadAllText(desigName + "_Ulogs");
            }
            catch(FileNotFoundException exc)
            {
                File.Create(desigName + "_Ulogs");
                File.WriteAllText(desigName + "_Ulogs", Environment.NewLine);
            }
            finally
            {
                string allTextInFile = File.ReadAllText(desigName + "_Ulogs");
                File.WriteAllText(desigName + "_Ulogs", allTextInFile + AllText());
            }
        }
    }
}
