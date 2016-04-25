using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public interface ILogger
    {
        void Log(Message msg);
        void Log(string msg);
        string PrintLogContinuous();
        Message[] PrintLogMessages();
        string[] PrintLogStrings();
        
        
    }
}
