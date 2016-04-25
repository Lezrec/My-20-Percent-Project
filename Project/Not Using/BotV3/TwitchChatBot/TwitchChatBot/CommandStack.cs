using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// Creates a stack of current commands created by the owner.
    /// </summary>
    public class CommandStack
    {
        private Command[] stack;
        private int size;

        /// <summary>
        /// Default constructor for the CommandStack, sets default array length to 10.
        /// </summary>
        public CommandStack()
        {
            stack = new Command[10];
        }

        /// <summary>
        /// Adds a command to the top of the stack.
        /// </summary>
        /// <param name="cmd"></param>
        public void Push(Command cmd)
        {

        }

        /// <summary>
        /// Removes a command from the top of the stack.
        /// </summary>
        /// <returns>The top element.</returns>
        public Command Pop()
        {
            Command ret = stack[size - 1];
            stack[size - 1] = null;
            size--;
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The command at that index.</returns>
        public Command RemoveAtIndex(int index)
        {
            
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException("The index was out of bounds.");
            }
            //TODO THIS
            throw new NotImplementedException();
        }

        public Command Peek()
        {
            return stack[size - 1];
        }
    }
}
