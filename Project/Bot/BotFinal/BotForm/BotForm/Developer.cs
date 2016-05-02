using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class Developer : User
    {
        public Developer(string name, int prio) : base(name, prio)
        {

        }

        private const string objName = "Developer";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }
    }
}
