using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class ModList : BotRelatedObject, IDataMethod
    {
        private List<Mod> mods = new List<Mod>();
        private Channel currentChannel;
        internal static FileEditor modFile;

        private const string objName = "ModList";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }

        public void Fill(Mod[] mods)
        {
            foreach(Mod mod in mods)
            {
                this.mods.Add(mod);
            }
            WriteFromFileToList();


        }

        private void WriteToFile()
        {
            string write = "";
            Mod[] todos = ToArray();
            for(int i = 0; i < todos.Length; i++)
            {
                string modName = todos[i].Name.ToLower().Trim() ;
                write += $"Θ{modName}NEW_LINE";

            }
            modFile.WriteAllText(write);
        }

        private void WriteFromFileToList() //TODO test this
        {
            string allText = modFile.ReadAllText();
            string[] splitUp = allText.Split(new string[] { "NEW_LINE" }, StringSplitOptions.RemoveEmptyEntries);
            bool last = false;
            foreach(string str in splitUp)
            {
                string modify = str.ToLower().Trim();
                if (!modify.Contains("Θ")) break; // just making sure :P
                modify = modify.Substring(1);
                Mod mod = new Mod(modify, 1); // second number doesnt do anything xd
                if (!mods.Contains(mod))
                {
                    Add(mod);
                }
                
            }
        }

        public Mod[] ToArray()
        {
            return mods.ToArray();
        }

        public void Add(Mod mod)
        {
            mods.Add(mod);
        }

        public bool Contains(Mod mod)
        {
            return mods.Contains(mod);
        }

        public bool ContainsName(string name)
        {
            foreach(Mod n in ToArray())
            {
                if (name == n.Name) return true;
            }
            return false;
        }

        public bool Contains(string str)
        {
            return mods.Contains(new Mod(str, 1));
        }

        public Mod Remove(Mod mod)
        {
            mods.Remove(mod);
            return mod;
        }

        public Mod Remove(string name)
        {
            mods.Remove(new Mod(name, 1));
            return new Mod(name, 1);
        }

        public void RemoveModByName(string name)
        {
            Remove(name);
        }

        public void SendData()
        {
            
        }
    }
}
