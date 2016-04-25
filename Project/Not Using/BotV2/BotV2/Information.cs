using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    
    public static class Information
    {
        private static string channel;
        private static Channel channelObj;

        public static Channel TwitchChannel
        {
            get { return channelObj; }
            set { channelObj = value; }
            
        }
    }
}
