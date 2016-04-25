using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class Channel : BotRelatedObject
    {
        private string myName;
        private User[] myUsers; //TODO do this

        public Channel(string name)
        {
            myName = name;
            
        }

        public User[] Users
        {
            get { return myUsers; }
        }

        public string Name
        {
            get { return myName; }
            set { myName = value; }
        }

        private const string objName = "Channel";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }

        
    }
}
