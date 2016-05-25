using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class ChatLog : BotRelatedObject
    {
        private const string objName = "ChatLog";
        public override string MyObjectName
        {
            get
            {
                return objName;
            
            }
        }

        private FileEditor myFile;

        public ChatLog(Channel channel)
        {
            myFile = new FileEditor(channel.Name + "_logs.txt");
            myFile.WriteAllText("");
            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Modification, "Cleared chat logs on reboot."));
        }

        public void AddMessage(Message msg, User user)
        {
            myFile.WriteLine($"{user.Name} said \"{msg.Said}\" at {DateTime.UtcNow.ToString()} UTC");
            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Creation, "Added a message to the chat log."));
        }
    }
}
