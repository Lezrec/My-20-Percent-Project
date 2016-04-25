using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// Takes raw information from the streams and outputs a message.
    /// </summary>
    internal static class MessagePrepper
    {
        private static string lastText;
        private static Message lastMessage;

        public static Message LastMessage
        {
            get { return lastMessage; }
        }

        public static string LastText
        {
            get { return lastText; }
        }

        public static Message Prep(string message)
        {
            Message ret = null;
            try
            {
                
                string saidMessage = message.Substring(message.IndexOf("#" + ImportantData.Owner));
                saidMessage = saidMessage.Substring(message.IndexOf(":") + 1).Trim();
                saidMessage = saidMessage.Substring(saidMessage.IndexOf(":") + 1);
                ret = new Message(saidMessage, MessageType.UserMessage); //For now this defaults to usermessage.
            }
            catch
            {
                Writer.Write("durrr");
            }
            
            return ret;
        }

    }
}
