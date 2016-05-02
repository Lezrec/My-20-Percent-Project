using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class UserList
    {
        List<User> users = new List<User>();

        public void Fill(string raw)
        {
            users = new List<User>();
            int length = $"lezrecbot.tmi.twitch.tv 366 lezrecbot ".Length;
            string modify = raw.Substring(length);
            string[] todos = modify.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < todos.Length; i++)
            {
                string use = todos[i];
                if (use == " ") continue;

                if (use.Contains(":")) use = use.Substring(0, use.Length - " :End of /NAMES list".Length);
                Add(use.Trim());
                //more testing needs to be done
            } 
        }

        public User[] ToArray()
        {
            return users.ToArray();
        }

        public void Add(string user)
        {
            users.Add(new User(user, 0));
            //todo specify if mod or not
        }

        public bool InList(User user)
        {
            return users.Contains(user);
        }
    }
}
