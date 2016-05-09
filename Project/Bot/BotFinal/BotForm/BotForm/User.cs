using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    public class User : BotRelatedObject , IDataMethod //TODO: this
    {
        protected string myName;
        protected int priority;

        public User(string name, int prio)
        {
            myName = name;
            if (prio > 3) prio = 3;
            if (prio < 0) prio = 0;
            priority = prio;
            TwitchChatBot.me.AddHappening(this, new Happening(Happening.State.Creation, "User created"));
        }

        public string Name
        {
            get { return myName; }
            set { myName = value; }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }


        private const string objName = "User";
        public override string MyObjectName
        {
            get
            {

                return objName;
            }
        }

        public void SendData()
        {
            throw new NotImplementedException();
        }
    }
}
