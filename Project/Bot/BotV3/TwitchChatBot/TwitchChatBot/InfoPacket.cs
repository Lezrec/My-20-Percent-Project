using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    internal struct InfoPacket
    {
        private Message msg;
        private TimeFromBot time;

        public InfoPacket(Message mesg, TimeFromBot tm)
        {
            msg = mesg;
            time = tm;
        }

        public Message PacketMessage
        {
            get { return msg; }
            set { msg = value;}
        }

        public TimeFromBot Time
        {
            get { return time; }
            set { time = value; }
        }

    
    }
}
