using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class Happening //everytime something important goes on, use a happening because it makes debugging and life easier
    {
        internal enum State
        {
            Error,
            Output,
            Input,
            Creation,
            Deletion,
            Modification,
        }

        private State myState;
        private string myDetails;

        public Happening(State state, string details)
        {
            myState = state;
            myDetails = details;
        }

        public State HappeningState
        {
            get { return myState; }
        }

        public string Details
        {
            get { return myDetails; }
        }
    }
}
