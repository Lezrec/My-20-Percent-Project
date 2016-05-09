using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    
    class OwnerCommandList : BotRelatedObject, IDataMethod
    {
        private LinkedList<OwnerCommand> OwnerCommands = new LinkedList<OwnerCommand>();
        private bool comingFromFile;

        public OwnerCommandList()
        {
            WriteFromFileToList();
        }

        internal void AddToHead(OwnerCommand comd)
        {
            if (!Contains(comd))
            {
                OwnerCommands.AddFirst(comd);
                if (!comingFromFile)
                {
                    WriteToFile();
                }


            }
            comingFromFile = false;


        }

        internal OwnerCommand GetHead()
        {
            return OwnerCommands.First.Value;
        }

        internal OwnerCommand GetTail()
        {
            return OwnerCommands.Last.Value;
        }

        internal OwnerCommand[] GetAllOwnerCommands()
        {
            return OwnerCommands.ToArray<OwnerCommand>();
        }

        internal bool Contains(OwnerCommand comd)
        {
            OwnerCommand[] all = GetAllOwnerCommands();
            foreach (OwnerCommand c in all)
            {
                if (c.Trigger == comd.Trigger)
                {
                    return true;
                }

            }
            return false;
        }

        internal void WriteToFile()
        {
            //todo make this work with the dels
            OwnerCommand[] todos = GetAllOwnerCommands();
            string write = "";
            for (int i = 0; i < todos.Length; i++)
            {
                //Θ = beginning, ☻ = end
                write += "Θ" + todos[i].Trigger + "," + todos[i].ToDo + "NEW_LINE";
            }
            TwitchChatBot.me.ownerCmdsFromFile.WriteAllText(write);

        }

        internal OwnerCommand[] GetAllOwnerCommandsFromFile()
        {
            string all = TwitchChatBot.me.ownerCmdsFromFile.ReadAllText();
            if (all == "") return null;
            string[] splitUp = all.Split(new string[] { "NEW_LINE" }, StringSplitOptions.None);
            OwnerCommand[] ret = new OwnerCommand[splitUp.Length];
            for (int i = 0; i < ret.Length; i++)
            {
                string modify = splitUp[i];
                if (modify == "") return ret;
                modify = modify.Substring(1);
                int whereTrigger = modify.IndexOf(",");
                string trigger = modify.Substring(0, whereTrigger);
                modify = modify.Substring(whereTrigger + 1);
                string todo = modify;
                ret[i] = new OwnerCommand(trigger, todo);

            }
            return ret;


        }

        internal void WriteFromFileToList()
        {
            try
            {
                OwnerCommand[] todos = GetAllOwnerCommandsFromFile();
                if (todos == null) return;
                foreach (OwnerCommand comd in todos)
                {
                    if (comd == null) return;
                    comingFromFile = true;
                    AddToHead(comd);
                }
            }
            catch (Exception e)
            {
                //TwitchChatBot.me.Client.SendChatMessage("!");
            }


        }

        public void UpdateGUI()
        {
            //TODO
        }

        internal string[] GetAllTriggers()
        {
            OwnerCommand[] use = GetAllOwnerCommands();
            string[] ret = new string[use.Length];
            for (int i = 0; i < GetAllOwnerCommands().Length; i++)
            {
                ret[i] = use[i].Trigger;
            }
            return ret;
        }

        internal OwnerCommand RemoveHead()
        {
            OwnerCommand cmd = GetHead();
            OwnerCommands.RemoveFirst();
            return cmd;
        }

        internal OwnerCommand RemoveTail()
        {
            OwnerCommand cmd = GetTail();
            OwnerCommands.RemoveLast();
            return cmd;
        }

        internal OwnerCommand RemoveOwnerCommand(OwnerCommand OwnerCommand)
        {
            OwnerCommands.Remove(OwnerCommand);
            WriteToFile();
            return OwnerCommand;
        }

        internal OwnerCommand RemoveOwnerCommandUsingOnlyTrigger(string trigger)
        {
            string[] todos = GetAllTriggers();
            for (int i = 0; i < todos.Length; i++)
            {
                if (trigger == todos[i])
                {
                    return RemoveAtIndex(i);
                }
            }
            return null;
        }

        internal OwnerCommand RemoveAtIndex(int index)
        {
            LinkedList<OwnerCommand>.Enumerator enumerator = OwnerCommands.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < index; i++)
            {
                enumerator.MoveNext();
            }
            return RemoveOwnerCommand(enumerator.Current);

        }

        internal OwnerCommand GetAtIndex(int index)
        {
            LinkedList<OwnerCommand>.Enumerator enumerator = OwnerCommands.GetEnumerator();
            for (int i = 0; i < index; i++)
            {
                enumerator.MoveNext();
            }
            return enumerator.Current;
        }

        internal void AddToTail(OwnerCommand comd)
        {
            OwnerCommands.AddLast(comd);
        }


        private const string objName = "OwnerCommandList";
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
