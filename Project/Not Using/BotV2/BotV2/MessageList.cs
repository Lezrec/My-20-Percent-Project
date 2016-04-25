using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BotV2
{
    class MessageList
    {
        private List<String> messages = new List<String>();
        private string desigName;

        public MessageList()
        {
            
            desigName = TwitchChatBot.ChannelIn.Name.ToLower();
            try
            {
                string something =  File.ReadAllText(desigName + "_logs");
            }
            catch(FileNotFoundException exc)
            {
                int j = 0;
                File.Create(desigName + "_logs");
                int i = 0;
                File.WriteAllText(desigName + "_logs", Environment.NewLine);
            }
            catch(IOException exc)
            {
                desigName = TwitchChatBot.ChannelIn.Name.ToLower();
                int j = 0;
                File.Create(desigName + "_logs");
                int i = 0;
                File.WriteAllText(desigName + "_logs", Environment.NewLine);
                //TwitchChatBot.LogError(exc.ToString());
            }
            
            String allTextInFile = File.ReadAllText(desigName + "_logs");
            String[] linesOfText = allTextInFile.Split(Environment.NewLine.ToCharArray());
            foreach (String msg in linesOfText)
            {
                messages.Add(msg);
            }
            
            

        }
            
            
            

        public void Add(String msg)
        {
            try
            {
                messages.Add(msg);
            }
            catch(NullReferenceException exc)
            {
                desigName = TwitchChatBot.ChannelIn.Name;
            }
            
        }

        public String Get(int index)
        {
            return messages.ToArray()[index];
        }

        public bool Contains(String msg)
        {
            return messages.Contains(msg);
        }

        public String[] ToArray()
        {
            return messages.ToArray();
        }

        public string AllText()
        {
            String[] msgs = ToArray();
            string ret = "";
            foreach (String msg in msgs)
            {
                ret += msg + Environment.NewLine;
            }
            return ret;
        }

        public void RipToTxt()
        {
            
            try
            {

                File.ReadAllText(desigName + "_logs");
            }
            catch (FileNotFoundException exc)
            {
                File.Create(desigName + "_logs");
                File.WriteAllText(desigName + "_logs", Environment.NewLine);
            }
            
                string allTextInFile = File.ReadAllText(desigName + "_logs");
                File.WriteAllText(desigName + "_logs", allTextInFile + AllText());
            
        }
    }
}
