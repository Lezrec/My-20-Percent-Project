using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public class User
    {
        protected string name;

        //normal = 0, mod = 1, owner = 2
        protected int permissions;

        public User(string twitchName)
        {
            name = twitchName;
            permissions = 0;
        }


        public User(string twitchName, int permissionLevel)
        {
            name = twitchName;

            if (permissionLevel < 0) permissionLevel = 0;
            if (permissionLevel > 2) permissionLevel = 2;
            permissions = permissionLevel;
        }

        public int Permission
        {
            get { return permissions; }
            set {if (value < 0) value = 0;
                if (value > 2) value = 0;
                permissions = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string newName)
        {
            name = newName;
        }
    }
}
