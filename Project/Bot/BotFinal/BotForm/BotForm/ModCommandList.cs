using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class ModCommandList : BotRelatedObject, IDataMethod
    {
        private LinkedList<ModCommand> ModCommands = new LinkedList<ModCommand>();
        private bool comingFromFile;

        public ModCommandList()
        {
            WriteFromFileToList();
        }

        internal void AddToHead(ModCommand comd)
        {
            if (!Contains(comd))
            {
                ModCommands.AddFirst(comd);
                if (!comingFromFile)
                {
                    WriteToFile();
                }


            }
            comingFromFile = false;


        }

        internal ModCommand GetHead()
        {
            return ModCommands.First.Value;
        }

        internal ModCommand GetTail()
        {
            return ModCommands.Last.Value;
        }

        internal ModCommand[] GetAllModCommands()
        {
            return ModCommands.ToArray<ModCommand>();
        }

        internal bool Contains(ModCommand comd)
        {
            ModCommand[] all = GetAllModCommands();
            foreach (ModCommand c in all)
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
            ModCommand[] todos = GetAllModCommands();
            string write = "";
            for (int i = 0; i < todos.Length; i++)
            {
                //Θ = beginning, ☻ = end
                write += "Θ" + todos[i].Trigger + "," + todos[i].ToDo + "NEW_LINE";
            }
            TwitchChatBot.me.modCmdsFromFile.WriteAllText(write);

        }

        internal ModCommand[] GetAllModCommandsFromFile()
        {
            string all = TwitchChatBot.me.modCmdsFromFile.ReadAllText();
            if (all == "") return null;
            string[] splitUp = all.Split(new string[] { "NEW_LINE" }, StringSplitOptions.None);
            ModCommand[] ret = new ModCommand[splitUp.Length];
            for (int i = 0; i < ret.Length; i++)
            {
                string modify = splitUp[i];
                if (modify == "") return ret;
                modify = modify.Substring(1);
                int whereTrigger = modify.IndexOf(",");
                string trigger = modify.Substring(0, whereTrigger);
                modify = modify.Substring(whereTrigger + 1);
                string todo = modify;
                ret[i] = new ModCommand(trigger, todo);

            }
            return ret;


        }

        internal void WriteFromFileToList()
        {
            try
            {
                ModCommand[] todos = GetAllModCommandsFromFile();
                if (todos == null) return;
                foreach (ModCommand comd in todos)
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
            ModCommand[] use = GetAllModCommands();
            string[] ret = new string[use.Length];
            for (int i = 0; i < GetAllModCommands().Length; i++)
            {
                ret[i] = use[i].Trigger;
            }
            return ret;
        }

        internal ModCommand RemoveHead()
        {
            ModCommand cmd = GetHead();
            ModCommands.RemoveFirst();
            return cmd;
        }

        internal ModCommand RemoveTail()
        {
            ModCommand cmd = GetTail();
            ModCommands.RemoveLast();
            return cmd;
        }

        internal ModCommand RemoveModCommand(ModCommand ModCommand)
        {
            ModCommands.Remove(ModCommand);
            WriteToFile();
            return ModCommand;
        }

        internal ModCommand RemoveModCommandUsingOnlyTrigger(string trigger)
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

        internal ModCommand RemoveAtIndex(int index)
        {
            LinkedList<ModCommand>.Enumerator enumerator = ModCommands.GetEnumerator();
            enumerator.MoveNext();
            for (int i = 0; i < index; i++)
            {
                enumerator.MoveNext();
            }
            return RemoveModCommand(enumerator.Current);

        }

        internal ModCommand GetAtIndex(int index)
        {
            LinkedList<ModCommand>.Enumerator enumerator = ModCommands.GetEnumerator();
            for (int i = 0; i < index; i++)
            {
                enumerator.MoveNext();
            }
            return enumerator.Current;
        }

        internal void AddToTail(ModCommand comd)
        {
            ModCommands.AddLast(comd);
        }


        private const string objName = "ModCommandList";
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
