using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class Mod : User
    {
        public Mod(string name, int prio) : base(name, prio)
        {

        }

        private const string objName = "Mod";
        public override string MyObjectName
        {
            get { return objName; }
        }
    }
}
