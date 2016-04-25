using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public class Channel
    {
        private string name;

        public Channel(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public void Switch(string newChannel)
        {
            name = newChannel;
        }

        public void Switch(Channel newChannel)
        {
            name = newChannel.Name;
        }

        public void ConnectTo()
        {
            TwitchChatBot.UseBot.SendIRCMessage("JOIN #" + Name);
            TwitchChatBot.UseBot.Connected = true;
            
            
        }
    }
}
