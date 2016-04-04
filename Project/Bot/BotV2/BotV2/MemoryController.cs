using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BotV2
{
    public class MemoryController
    {
        private Owner channelOwner;
        private string ownerName;


        private class MemoryHandler
        {
            private BotFile file;

            

        }

        private MemoryHandler handler;
        private List<BotFile> files;

        public MemoryController(Owner owner)
        {
            channelOwner = owner;
            ownerName = channelOwner.Name;

            files = new List<BotFile>();

        }

        public void GetAllChannelFiles()
        {
            int i = 0;
            switch(i)
            {
                case 0: files.Add(new BotFile(ownerName + "_Mods"));
                    files.Add(new BotFile(ownerName + "_Commands"));
                    break;
            }    
        }

        public void AddToList(BotFile file)
        {
            files.Add(file);
        }

        public void RemoveFromList(BotFile file)
        {
            files.Remove(file);
        }

        public BotFile GetFileAtIndex(int index)
        {
            return files.ToArray()[index];
        }

        public BotFile[] ToArray()
        {
            return files.ToArray();
        }
       


    }
}
