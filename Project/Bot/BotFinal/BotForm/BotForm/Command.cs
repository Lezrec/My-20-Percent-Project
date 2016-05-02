using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class Command : BotRelatedObject, IDataMethod
    {
        private string messageToDo;
        private string messageTrigger;
        private dynamic myTodo;

        internal delegate void delToDo();

        private delToDo methodToDo;
        
        public string Trigger
        {
            get { return messageTrigger; }
            set { messageTrigger = value; }
        }

        public string ToDo
        {
            get { return messageToDo; }
            set { messageToDo = value; }
        }

        internal delToDo ToExecute //make sure to check for this too
        {
            get { return myTodo; }
            set { myTodo = value; }
        }

        private const string objName = "Command";
        public override string MyObjectName
        {
            get { return objName; }
        }

        public Command(string trigger, string todo)
        {
            messageTrigger = trigger;
            messageToDo = todo;
            myTodo = todo;
        }

        public Command(string trigger, delToDo todo)
        {
            messageTrigger = trigger;
            methodToDo = todo;
            myTodo = todo;
        }

        public void Execute()
        {
            if (myTodo is string)
            {
                TwitchChatBot.me.Client.SendChatMessage((string)myTodo);
            }
            else if (myTodo is delToDo)
            {
                myTodo = (delToDo)myTodo;
                myTodo();
            }
        }

        public void SendData()
        {
            Execute();
        }
    }
}
