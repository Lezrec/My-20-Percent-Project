using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// Holds important information not appropriate in other classes.
    /// </summary>
    internal static class ImportantData
    {
        private static User owner;


        public static User Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public static void UpdateOwner(User newOwner)
        {
            Owner = newOwner;
        }
    }
}
