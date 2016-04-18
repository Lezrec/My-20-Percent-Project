using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// A total doubly linked list of all the commands.
    /// </summary>
    public class CLL
    {
        private DualPointer head;
        private DualPointer tail;
        private int size;


        /// <summary>
        /// Returns the size of the linked list.
        /// </summary>
        public int Size
        {
            get { return size; }
        }


        /// <summary>
        /// Adds a command to the tail of the linked list.
        /// </summary>
        /// <param name="cmd"></param>
        public void Add(Command cmd)
        {
            switch(size)
            {
                case 0:
                    head = new DualPointer(null, null, cmd);
                    tail = new DualPointer(null, null, cmd);
                    break;
                case 1:
                    tail.GetPreviousPointer = head;
                    tail.MyCommand = cmd;
                    head.GetNextPointer = tail;
                    break;
                default:
                    tail.GetPreviousPointer = tail;
                    tail.MyCommand = cmd;
                    break;
            }
            size++;
        }

        /// <summary>
        /// Removes a command of a certain trigger, returns null and removes nothing if not found.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns> The removed command. </returns>
        public Command Remove(Command cmd)
        {
            Command ret = null;
            DualPointer use = head;
            for(int i = 0; i < size; i++)
            {
                if (use.MyCommand.Trigger == cmd.Trigger)
                {
                    ret = use.MyCommand;
                    break;
                }
                else
                {
                    use = head.GetNextPointer;
                }
            }
            return ret;
        }

        /// <summary>
        /// Removes a command at a certain index. Throws an 
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The removed command.</returns>
        public Command RemoveAtIndex(int index)
        {
            Command ret = null;
            DualPointer use = head;
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException("The index was out of bounds.");
            }
            else
            {
                use = head;
                ret = use.Me.MyCommand;
                for (int i = 0; i < index; i++)
                {
                    use = head.GetNextPointer;
                    ret = use.Me.MyCommand;
                }
            }
            return ret;
        }

        /// <summary>
        /// Essentially the '!commands' trigger.
        /// </summary>
        /// <returns>All the commands listed.</returns>
        public override string ToString()
        {
            //TODO THIS
            string ret = "";
            return ret;
        }


        /// <summary>
        /// Class for the purpose of linking the list.
        /// </summary>
        public class DualPointer
        {
            private DualPointer before;
            private DualPointer after;
            private Command myComd;

            /// <summary>
            /// Constructor for the DualPointer.
            /// </summary>
            /// <param name="bef"></param>
            /// <param name="af"></param>
            /// <param name="comd"></param>
            public DualPointer(DualPointer bef, DualPointer af, Command comd)
            {
                before = bef;
                after = af;
                myComd = comd;
            }


            /// <summary>
            /// Returns this DualPointer.
            /// </summary>
            public DualPointer Me
            {
                get { return this; }
            }

            /// <summary>
            /// Returns the previous DualPointer or null if there is none.
            /// </summary>
            public DualPointer GetPreviousPointer
            {
                get { return before; }
                set { before = value; }
            }

            /// <summary>
            /// Returns the command in this DualPointer.
            /// </summary>
            public Command MyCommand
            {
                get { return myComd; }
                set { myComd = value; }
            }

            /// <summary>
            /// Returns the next DualPointer or null if there is none.
            /// </summary>
            public DualPointer GetNextPointer
            {
                get { return after; }
                set { after = value; }
            }
        }
    }
}
