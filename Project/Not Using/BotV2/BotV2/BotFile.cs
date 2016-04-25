using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BotV2
{
    public class BotFile
    {
        protected string directory;
        public BotFile(string name)
        {
            directory = name;
            if (!File.Exists(directory))
            {
                File.Create(directory);
            }
        }

        public void MakeSureYouCanWrite()
        {
            try
            {
                File.ReadAllText(directory);
            }
            catch(Exception exc)
            {
            
            }
        }

        public void WriteNewLine(string text)
        {
            string previousText = File.ReadAllText(directory);
            string writeText = previousText + Environment.NewLine + text;
            File.WriteAllText(directory, writeText);
        }

        public void Delete(bool areYouSure)
        {
            if (areYouSure)
            {
                File.Delete(directory);
            }
            else
            {
                try
                {
                    throw new IOException("!!!");
                    
                }
                catch(Exception e)
                {
                    TwitchChatBot.UseBot.AddToLabel("You tried to delete a file and under default that throws this message!");
                    TwitchChatBot.UseBot.AddToLabel(e.ToString());
                }
                
                
            }
            
        }

        public void Delete()
        {
            Delete(false);
        }

        //INCLUDES A SPACE
        public void WriteOnSameLine(string text)
        {
            string previousText = File.ReadAllText(directory);
            string writeText = previousText + " " + text;
            File.WriteAllText(directory, writeText);
        }

        public void WriteOver(string text)
        {
            File.WriteAllText(directory, text);
        }
    }
}
