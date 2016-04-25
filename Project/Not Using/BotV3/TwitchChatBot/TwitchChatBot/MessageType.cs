using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// Only to differentiate different types of messages for use later.
    /// </summary>
    public enum MessageType
    {
        IRCMessage,
        UserMessage,
        DeveloperMessage,

    }
}
