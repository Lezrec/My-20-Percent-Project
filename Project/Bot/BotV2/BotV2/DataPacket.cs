using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public struct DataPacket
    {
        private BackgroundPacket bPacket;
        private Message message;
        public DataPacket(BackgroundPacket pkt, Message msg)
        {
            bPacket = pkt;
            message = msg;
        }

        public BackgroundPacket BackgroundPacket
        {
            get { return bPacket; }
            set { bPacket = value; }
        }

        public Message Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
