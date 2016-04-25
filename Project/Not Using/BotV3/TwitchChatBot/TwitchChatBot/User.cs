using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// Class for packaging a Twitch user.
    /// </summary>
    public class User
    {
        //private float troubleCapacity;

        private string name;
        private string nick;
        private int priority;


        /// <summary>
        /// Constructor where the nickname and main name are different.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nickname"></param>
        /// <param name="prio"></param>
        public User(string name, string nickname, int prio)
        {
            nick = nickname;
            this.name = name;
            priority = prio;
            if (priority < 0) priority = 0;
            if (priority > 2) priority = 2;
        }

        /// <summary>
        /// Constructor where the nickname and main name are the same.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="prio"></param>
        public User(string name, int prio)
        {
            nick = this.name = name;
            priority = prio;
            if (priority < 0) priority = 0;
            if (priority > 2) priority = 2;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Nickname
        {
            get { return nick; }
            set { nick = value; }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public static void SetChannelOwner(string name)
        {
            ImportantData.Owner = new User(name, 2);
        }
    }
}
