using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    //TODO THIS CLASS

    /// <summary>
    /// The base class used for messages. DEVNOTE: F***ing figure out if you're going to use this just for user messages or IRC and Developer messages.
    /// </summary>
    public class Message
    {
        private string information;
        private MessageType msgType;


        /// <summary>
        /// The default constructor for Message.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="type"></param>
        public Message(string info, MessageType type)
        {
            information = info;
            msgType = type;

        }

        public string Said
        {
            get { return information; }
            set
            {
                information = value;
            }
        }

        public MessageType MyType
        {
            get
            {
                return msgType;
            }
            set
            {
                msgType = value;
            }
        }
    }
}
