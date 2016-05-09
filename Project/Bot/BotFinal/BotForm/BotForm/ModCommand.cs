using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class ModCommand : Command
    {
        private dynamic myTodo;
        private int priority;
        public ModCommand(string name, delToDo todo) : base(name, todo)
        {
            myTodo = todo;
            priority = 2;
        }

        public ModCommand(string name, string todo) : base(name, todo)
        {
            myTodo = todo;
            priority = 2;
        }

        private const string objName = "ModCommand";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }

        public void Execute(User user)
        {
            if (user.Priority >= 1)
            {
                base.Execute();
            }
        }

    }
}
