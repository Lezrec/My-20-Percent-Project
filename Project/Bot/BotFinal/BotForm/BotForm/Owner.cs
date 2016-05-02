using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class Owner : User
    {
        public Owner(string name, int prio) : base(name, prio)
        {

        }

        private const string objName = "Owner";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }
    }
}
