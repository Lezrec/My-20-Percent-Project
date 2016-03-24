using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotV2
{
    public class CommandList
    {
        private class CommandNotFoundException : Exception
        {
            public CommandNotFoundException(string str)
            {

            }
        }






        //FIX DEFAULT COMMANDS
        public static Command[] DefaultCommands;
        List<Command> commands = new List<Command>();
        private string _toString;
        Command[] _array;

        public static Command[] Defaults
        {
            get { return DefaultCommands; }
        }

        public CommandList()
        {
            
            DefaultCommands = Command.GetAllDefault();
            _array = Defaults;
            foreach (Command comd in _array)
            {
                commands.Add(comd);
            }
            _toString = ToString();
            commands.Add(new Command("!list", _toString + " Also there's !list that has to be formatted differently because of a weird recursion loop!"));
            

        }

        public Command[] AllCommands()
        {
            UpdateArray();
            return _array;
        }

        public bool AddCommandAlreadyMatches(string trigger)
        {
            UpdateArray();
            bool ret = false;
            foreach (Command comd in _array)
            {
                if (comd.Trigger.Trim().Equals(trigger.Trim()))
                {
                    ret = true;
                }
            }
            
            return ret;
        }


        public override string ToString()
        { 
            
            string ret = "";
           
                foreach (Command comd in _array)
                {
                    if (comd != null && !comd.Trigger.Equals("!list"))
                    {
                        ret += comd.Trigger + ", ";
                    }

                }
                if (!ret.Equals(""))
            {
                ret = ret.Substring(0, ret.Length - 2);
                ret += ".";
            }

            _toString = ret;
            return ret;
        }




        public CommandList(Command[] cmds)
        {
            _array = cmds;
            foreach (Command comd in _array)
            {
                commands.Add(comd);
            }
        }

        public void UpdateArray()
        {
            _array = commands.ToArray();
            
        } 


        public void RemoveDuplicates()
        {
            //do this method eventaully :p
        }

        public bool MatchesCommandFromCommandList(Message cmd)
        {
            UpdateArray();
            foreach (Command comd in _array)
            {
                if (cmd.SaidMessage.Equals(comd.Trigger))
                {
                    return true;
                }

            }
            return false;
        }

        public void RemoveAtIndex(int index)
        {

            commands.RemoveAt(index);
            
        }

        public void RemoveCommand(string trigger)
        {
            UpdateArray();
            Command cmd = null;
            foreach (Command comd in _array)
            {
                if (trigger.Equals(comd.Trigger))
                {
                    cmd = comd;
                }
            }
            commands.Remove(cmd);
            UpdateArray();
        }

        public void ExecutecommandAtIndex(int index)
        {
            UpdateArray();
            _array[index].Execute();
        }

        public int GetWhereMatches(Command cmd)
        {
            int i = 0;
            foreach(Command comd in _array)
            {
                
                if (comd.Name.Equals(cmd.Trigger))
                {
                    return i;
                }
                i++;
            }
            throw new CommandNotFoundException("");
        }

        public int GetWhereMatches(Message cmd)
        {
            throw new CommandNotFoundException("");
        }

        public Command FindCommandFromMessage(Message msg)
        {
            UpdateArray();
            Command ret = null;
            foreach (Command comd in _array)
            {
                if (msg.SaidMessage.Equals(comd.Trigger))
                {
                    ret = comd;
                }
            }            
            return ret; 
        }
        
        public void AddCommand(Command cmd, User user)
        {
            if (user.Permission >= 1)
            {
                commands.Add(cmd);
                RemoveCommand("!list");
                _toString = ToString();
                commands.Add(new Command("!list", _toString + " Also there's !list that has to be formatted differently because of a weird recursion loop!"));
                UpdateArray();
            }
            
        }
        
        public void AddCommand(Message msg)
        {
            
        }
        
        public void AddCommand(string trigger, string todo, User user)
        {
            Command cmd = new Command(trigger, todo);
            AddCommand(cmd, user);
            
            
        }

    }
}
