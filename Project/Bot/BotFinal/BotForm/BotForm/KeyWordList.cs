using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class KeyWordList : BotRelatedObject, IDataMethod
    {
        private const string objName = "KeyWordList";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }

        public void SendData()
        {
            
        }
    }
}
