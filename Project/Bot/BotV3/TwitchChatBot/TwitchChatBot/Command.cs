using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchChatBot
{
    /// <summary>
    /// Class used for packaging a command for execution.
    /// </summary>
    public class Command
    {
        private string trigger;
        private string todo;
        private int prio;


        /// <summary>
        /// The part that will execute the command if the message matches.
        /// </summary>
        public string Trigger
        {
            get { return trigger; }
            set { trigger = value; }
        }

        /// <summary>
        /// What will be said if executed.
        /// </summary>
        public string ToDo
        {
            get { return todo; }
            set { todo = value; }
        }

        /// <summary>
        /// The priority of the command.
        /// 0 for anyone to say.
        /// 1 for mods to say.
        /// 2 for owner only to say.
        /// </summary>
        public int Priority
        {
            get { return prio; }
            set { prio = value; }
        }



        /// <summary>
        /// Constructor where priority is defined 0-2.
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="todo"></param>
        /// <param name="prio"></param>
        public Command(string trigger, string todo, int prio)
        {
            if (prio > 2)
            {
                prio = 2;
            }
            else if (prio < 0)
            {
                prio = 0;
            }

            this.trigger = trigger;
            this.todo = todo;
        }

        /// <summary>
        /// Constructor where priority defaults to 0 (Lowest level of priority).
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="todo"></param>
        public Command(string trigger, string todo)
        {
            this.trigger = trigger;
            this.todo = todo;
            prio = 0;
        }
    }
}
