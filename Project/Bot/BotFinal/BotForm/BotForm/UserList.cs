using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class UserList : BotRelatedObject, IDataMethod
    {
        List<User> users = new List<User>();

        private const string objName = "UserList";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }

        public void Fill(User[] users)
        {
            this.users = new List<User>();
            foreach(User usr in users)
            {
                this.users.Add(usr);
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

        public void SendData()
        {
            
        }
    }
}
