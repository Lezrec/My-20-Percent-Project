using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public class Owner : User
    {
        public static readonly Owner owner = new Owner("");

        public Owner(string twitchName) : base(twitchName)
        {
            permissions = 2;
        }


    }
}
