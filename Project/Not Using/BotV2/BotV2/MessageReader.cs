using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public static class MessageReader
    {
        public static void Read(Message msg)
        {
            User user = msg.FromUser;


            if (msg.SaidMessage.Contains("!addcommand") && msg.SaidMessage.IndexOf("!addcommand") == 0 && user.Permission >= 1)
            {
                
                string useStr = msg.SaidMessage.Trim();
                useStr = useStr.Substring(useStr.IndexOf("nd") + 3);
                
                string[] splitUp = useStr.Split(' ');
                string trigger = splitUp[0];
                int triggerLength = trigger.Length;
                string todo = useStr.Substring(triggerLength);
                
                if (!TwitchChatBot.list.AddCommandAlreadyMatches(trigger.Trim()))
                {
                    TwitchChatBot.list.AddCommand(trigger, todo, user);
                }
                
                return;

                
            }

            if (TwitchChatBot.list.MatchesCommandFromCommandList(msg))
            {
                TwitchChatBot.list.FindCommandFromMessage(msg).Execute();
            }
        }
    }
}
