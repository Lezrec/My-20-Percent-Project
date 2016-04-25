using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    public abstract class BotRelatedObject //For the sole purpose of limitng the type of objects happeninghandler uses
    {
        public abstract string MyObjectName
        {
            get;
        }
    }
}
