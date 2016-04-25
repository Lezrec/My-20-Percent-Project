using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public class Date
    {
        string representedInString;

        public Date(DateTime dt)
        {
            representedInString = dt.ToString().Substring(0, dt.ToString().IndexOf("201") + 4);
        }

        public Date(string date)
        {
            representedInString = date;
        }

        public override string ToString()
        {
            return representedInString;
        }

        public string RepresentedInString
        {
            get { return representedInString; }
            set {
                    if (value.Length > 9 && value.Length < 11)
                    {
                    representedInString = value;
                    }
                    
                }
        }
    }
}
