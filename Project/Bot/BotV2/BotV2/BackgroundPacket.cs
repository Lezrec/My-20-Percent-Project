using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public struct BackgroundPacket
    {
        private Channel channel;
        private User user;

        public BackgroundPacket(Channel ch, User usr)
        {
            channel = ch;
            user = usr;
        }

        public Channel Channel
        {
            get { return channel; }
            set { channel = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
