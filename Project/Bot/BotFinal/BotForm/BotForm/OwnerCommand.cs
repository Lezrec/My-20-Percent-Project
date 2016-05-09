using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class OwnerCommand : Command
    {
        private dynamic myTodo;
        private int priority;
        public OwnerCommand(string name, delToDo todo) : base(name, todo)
        {
            myTodo = todo;
            priority = 2;
        }

        public OwnerCommand(string name, string todo) : base(name, todo)
        {
            myTodo = todo;
            priority = 2;
        }

        private const string objName = "OwnerCommand";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }

        public void Execute(User user)
        {
            if (user.Priority >= 2)
            {
                base.Execute();
            }
        }

       
    }
}
