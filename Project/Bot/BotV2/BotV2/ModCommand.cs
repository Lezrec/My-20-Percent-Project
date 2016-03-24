using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public class ModCommand : Command
    {
        public ModCommand(string trigger, string todo) : base(trigger, todo)
        {

        }

        public new int Permission
        {
            get { return 1; }
            set
            {
                if (value != 1)
                {
                    Console.WriteLine("Owner command permission level is set to 2. Do not try to change it.");
                    switch (value)
                    {
                        case 0:
                            Console.WriteLine("The permission level you asked for was: User");
                            break;
                        case 2:
                            Console.WriteLine("The permission level you asked for was: Owner");
                            break;
                        default:
                            Console.WriteLine("Invalid permission level.");
                            break;
                    }
                }
            }

        }
    }
}
