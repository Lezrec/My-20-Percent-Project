using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public class MessageLogger : ILogger
    {
        bool enabled;
        
        private MessageList msgList = new MessageList();
        private MessageWithUserList msgUserList = new MessageWithUserList();

        public MessageLogger()
        {
            enabled = true;
            
            //msgList.RipToTxt();
            msgUserList.RipToTxt();
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }

        public MessageLogger(bool b)
        {
            enabled = b;
        }

        public void Log(string msg)
        {
            if (enabled)
            {
                msgList.Add(msg);
            }

           
            
        }

        public void Log(Message msg)
        {
            if (enabled)
            {
                msgUserList.Add(msg);
                msgList.Add(msg.SaidMessage);
            }
            
        }

        public string PrintLogContinuous()
        {
            if (enabled)
            {
                return msgList.AllText();
            }
            else
            {
                return "";
            }

            
        }

        public Message[] PrintLogMessages()
        {
            if (enabled)
            {
                return msgUserList.ToArray();
            }
            else
            {
                return new Message[] { new Message("", new User(""), DateTime.Now) };
            }
            
        }

        public string[] PrintLogStrings()
        {
            if (enabled)
            {
                return msgUserList.ToArrayString();
            }
            else
            {
                return new string[] { "" };
            }
            
        }

        public void RipToTxt()
        {
            if (enabled)
            {
                msgUserList.RipToTxt();
                //msgList.RipToTxt();
            }
            
        }
    }
}
