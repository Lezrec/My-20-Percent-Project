using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    class OwnerCommand : Command
    {
        public OwnerCommand(string trigger, string todo) : base(trigger, todo)
        {
            
        }

        public new int Permission
        {
            get { return 2; }
            set { if (value != 2) { Console.WriteLine("Owner command permission level is set to 2. Do not try to change it.");
                    switch (value)
                    {
                        case 0: Console.WriteLine("The permission level you asked for was: User");
                            break;
                        case 1: Console.WriteLine("The permission level you asked for was: Mod");
                            break;
                        default: Console.WriteLine("Invalid permission level.");
                            break;
                    } } }

        }
    }
}
