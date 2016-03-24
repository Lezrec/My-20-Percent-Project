using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public class Message
    {
        private User user;
        private string info;
        private DateTime time;
        private int atTick;

        public Message(string msg, User usr, DateTime cT)
        {
            info = msg;
            user = usr;
            time = cT;
        }


        public Message(string msg, User usr, DateTime cT, int currentTick)
        {
            info = msg;
            user = usr;
            time = cT;
            atTick = currentTick;
        }

        public string SaidMessage
        {
            get { return info; }
        }

        public User FromUser
        {
            get { return user; }
        }

        public int Length
        {
            get { return SaidMessage.Length; }
        }

        public DateTime Time
        {
            get { return time; }
        }

        public int RetrievedAtTick
        {
            get { return atTick; }
        }

        public override string ToString()
        {
            return FromUser.Name + " said: " + SaidMessage + " at " + Time.ToString() + "DT1=" + Time.Month.ToString() + "DT2=" + Time.Day.ToString() + "DT3=" + Time.Year.ToString();
        }
    }
}
