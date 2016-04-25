using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class Message : BotRelatedObject, IDataMethod //TODO : this
    {
        private string stuff;
        private User myUser;

        public Message(string message, User user)
        {
            stuff = message;
            myUser = user;
        }

        public string Said
        {
            get { return stuff; }
            set { stuff = value; }
        }

        private const string objName = "Message";
        public override string MyObjectName
        {
            get
            {

                return objName;
            }
        }

        public void SendData()
        {
           
        }
    }
}
