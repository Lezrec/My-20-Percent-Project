using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// Contains all users in a channel.
    /// </summary>
    public class UserList
    {
        private List<User> users;

        /// <summary>
        /// Default constructor for UserList.
        /// </summary>
        public UserList()
        {
            users = new List<User>();
        }
    }
}
