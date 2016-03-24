using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    class Mod : User
    {
        public Mod(string twitchName) : base(twitchName)
        {
            permissions = 1;
        }
    }
}
