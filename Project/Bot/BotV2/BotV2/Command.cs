using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace BotV2
{
    public class Command
    {
        public static List<Command> Defaults = new List<Command>();
        BaseCommands _BaseCommand;

        protected string commandTrigger;
        protected string commandDo;
        protected int permissionLevel;

        public Command(string trigger, string todo)
        {
            commandTrigger = trigger;
            commandDo = todo;
            permissionLevel = 0;
        }

        public Command(string trigger, string todo, int level)
        {
            commandTrigger = trigger;
            commandDo = todo;
            if (level < 0) level = 0;
            if (level > 2) level = 2;
            permissionLevel = level;
        }

        public Command(string trigger, string todo, int level, BaseCommands BC)
        {
            commandTrigger = trigger;
            commandDo = todo;
            if (level < 0) level = 0;
            if (level > 2) level = 2;
            permissionLevel = level;
            _BaseCommand = BC;
        }

        public string Name
        {
            get { return Trigger; }
        }

        public int Permission
        {
            get { return permissionLevel; }
            set { permissionLevel = value; }
        }

        public string Trigger
        {
            get { return commandTrigger; }
            
            set {
                if (_BaseCommand == null)
                {
                    commandTrigger = value;
                }
                else
                {
                    Console.WriteLine("You cannot change a base command's values.");
                }

               
            }
        }

        public string CommandLine
        {
            get { return commandDo; }
            set
            {
                if (_BaseCommand == null)
                {
                    commandDo = value;
                }
                else
                {
                    Console.WriteLine("You cannot change a base command's values.");
                }
            }
        }

        public bool UserPrio()
        {
            return permissionLevel == 0;
        }

        public bool ModPrio()
        {
            return permissionLevel == 1;
        }

        public bool OwnerPrio()
        {
            return permissionLevel == 2;
        }

        public void Execute()
        {
            if (this.Trigger.Equals("!exit"))
            {
                if (TwitchChatBot.lastSinceRippedToTxt > 0)
                {
                    TwitchChatBot.UseBot.logger.RipToTxt();
                    TwitchChatBot.lastSinceRippedToTxt = 0;
                }

                TwitchChatBot.UseBot.LezrecBotSendChatMessage("Goodbye! HeyGuys");
                TwitchChatBot.UseBot.client.Close();
                Application.Exit();
            }
            TwitchChatBot.UseBot.LezrecBotSendChatMessage(CommandLine);    
        }

        public static Command[] GetAllDefault()
        {
            Defaults.Add(Kappa);
            Defaults.Add(Credits);
            Defaults.Add(IsLezrec);
            Defaults.Add(Exit);
            
            //Defaults.Add(ListCommands());
            
            
            return Defaults.ToArray();
        }


        public static Command Timeout(User user)
        {
            return new Command("!timeout", "/timeout 120 " + user.Name); 
        }

        public static Command Credits
        {
            get { return new Command("!credits", "LezrecBot is created by LezrecOP."); }
        }
        
        public static Command Kappa
        {
            get { return new Command("!whatsakappa", "Kappa"); }
        }

        public static Command IsLezrec
        {
            get { return new Command("!islezrec", "Yes Kappa"); }
        }

        public static Command Exit
        {
            get { return new Command("!exit", ""); }
        }

        public static Command ListCommands()
        {
            return new Command("!list", TwitchChatBot.list.ToString());
        }
            

        public static void AddDefault(Command cmd)
        {
            Defaults.Add(cmd);
        }




    }
}
