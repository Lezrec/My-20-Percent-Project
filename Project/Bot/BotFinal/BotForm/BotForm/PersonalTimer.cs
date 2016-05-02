using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalTwitch.Timing;
using System.Windows.Forms;

namespace BotForm
{
    public class PersonalTimer : BotRelatedObject
    {

        private const string objName = "Timer";
        public override string MyObjectName
        {
            get
            {

                return objName;
            }
        }

        private static PersonalTimer me;
        private delegate void myDel();
        private const int tick = 200;

        public PersonalTimer()
        {
            if (me == null)
            {
                TickDelegation.TickMethod = new TickDelegation.TickDelegateMethod(Tick);
                me = this;
            } 
        }

        public static PersonalTimer Me
        {
            get { return me; }
            set { me = value; }
        }

        public void Start()
        {
            PublicTiming.Start(tick);
        }

        public void Abort()
        {
            GuiManager.WriteToOutput("Aborted timer. Check Debug for why.");
            TwitchChatBot.me.myHandler.Handle(TwitchChatBot.me.Client, new Happening(Happening.State.Error, "Cannot connect to Twitch IRC."));
            PublicTiming.Abort();
            
        }
        
        public void WaitForMillis(int millis)
        {
            int milatstart = PublicTiming.ElapsedMillis;
            while (PublicTiming.ElapsedMillis - milatstart < millis)
            {

            }
        }

        public void Tick()
        {
            if (!TwitchChatBot.started)
            {
                TwitchChatBot.me.Reload();
            }


            //TODO
            myDel del = () => { };
                try
                {
                    TwitchChatBot.me.Invoke(del);
                }
                catch(InvalidOperationException e)
                {
                if (TwitchChatBot.me.Client.CanConnect()) TwitchChatBot.me.Client.SendChatMessage("Goodbye! HeyGuys");
                    Application.Exit();
                    Environment.Exit(0);
                }
                //PUT CHECKS HERE:

                string message = TwitchChatBot.me.Client.GetLastStreamMessage();
                if (message == null)
                {

                }
                else
                {
                    TwitchChatBot.me.Scrubber.Scrub(message);
                    try
                    {
                        if (TwitchChatBot.ActiveForm == null && TwitchChatBot.started) throw new Exception(); // if the form is not found, fucking stop the program
                    }
                    catch
                    {
                        //Environment.Exit(0);
                    }
                }
            
            
            



        }

    }
}
