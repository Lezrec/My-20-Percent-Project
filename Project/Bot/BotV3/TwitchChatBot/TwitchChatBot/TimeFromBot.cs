using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchChatBot
{
    /// <summary>
    /// Internal bot timing.
    /// </summary>
    internal class TimeFromBot
    {
        private static Timer timer;

        private static int tickMilliCount;
        private static int seconds;
        private static int millis, totalMillis;


        private static int ticks;
        private int myTicks;
        private int myMillis;
        private int mySeconds;

        private static bool ticksBlocked;
        private static int secondsWhileCalled, millisWhenCalled;

        /// <summary>
        /// The default constructor for bot timing.
        /// </summary>
        public TimeFromBot()
        {
            myMillis = millis;
            mySeconds = seconds;
            myTicks = ticks;
        }

        public static bool TicksAreBlocked
        {
            get { return ticksBlocked; }
            set { ticksBlocked = value; }
        }

        /// <summary>
        /// Executed at program start. I recommend you do not touch this!
        /// </summary>
        /// <param name="timer1"></param>
        public static void Load(Timer timer1)
        {
            tickMilliCount = timer1.Interval;
            timer = timer1;
            timer.Tick += new EventHandler(Tick);
            timer.Start();
        }

        public static void Tick(object sender, EventArgs e)
        {
            
            millis += tickMilliCount;
            totalMillis += tickMilliCount;
            
            if (millis > 1000)
            {
                millis -= 1000;
                seconds++;
            }
            ticks++;
            //Put all tick methods here.
            
           if (false) //False = debug on True = debug off
            {
                Reader.Tick(); //TODO
                CommandManager.Tick(); //TODO
                FileEditor.Tick(); //TODO
                GUIManager.Tick(); //TODO
                Connector.Tick(); //TODO
            }

        }

        public static void WaitForMillis(int millis)
        {
            millisWhenCalled = DateTime.Now.Millisecond;
            secondsWhileCalled = DateTime.Now.Second;
            int totalMillis = secondsWhileCalled * 1000 + millisWhenCalled;
            while(totalMillis + millis > DateTime.Now.Millisecond + DateTime.Now.Second*1000)
            {

            }
            
        }


        public static void BlockAllTicks()
        {
            TicksAreBlocked = true;
        }

        public static void UnblockAllTicks()
        {
            TicksAreBlocked = false;
        }

        public static void WaitForSeconds(int seconds)
        {
            WaitForMillis(1000 * seconds);
            
        }

        public static int TickMilliCount
        {
            get { return tickMilliCount; }
        }

        public static int Ticks
        {
            get { return ticks; }
        }

        public static int CurrentSeconds
        {
            get { return seconds; }
        }

        public static int CurrentMillis
        {
            get { return millis; }
        }

        public int CreatedOnTick
        {
            get { return myTicks; }
        }

        public int Seconds
        {
            get { return mySeconds; }
        }

        public int Millis
        {
            get { return myMillis; }
        }


         public static TimeFromBot Now
        {
            get { return new TimeFromBot(); }
        }
    }
}
