using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class HappeningHandler : BotRelatedObject
    {


        private const string objName = "HappeningHandler";
        public override string MyObjectName
        {
            get
            {

                return objName;
            }
        }


        public HappeningHandler()
        {
            
        }

        public void Handle(BotRelatedObject sender, Happening e)
        {
            string stateVal = "";
            
            switch (e.HappeningState)
            {
                case Happening.State.Creation:
                    stateVal = "Something was created";
                    break;
                case Happening.State.Deletion:
                    stateVal = "Something was deleted";
                    break;
                case Happening.State.Error:
                    stateVal = "You dun fucked up";
                    break;
                case Happening.State.Input:
                    stateVal = "Something was used as input, must be important.";
                    break;
                case Happening.State.Modification:
                    stateVal = "Something was changed, must be important";
                    break;
                case Happening.State.Output:
                    stateVal = "Something was output, must be important";
                    break;
            }
            GuiManager.WriteToDebug("Action derived from " + sender.MyObjectName + ". Additional information: " + stateVal + "... Developer's note: " + e.Details); //TODO this
        }
    }
}
