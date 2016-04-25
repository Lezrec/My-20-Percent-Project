using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace BotForm
{
    internal class FileEditor : BotRelatedObject
    {
        private string myFileDir;
        private ThreadStart myThreadStart;
        private Thread myThread;
        private PersonalTwitch.Storage.Stack<EditDelegate> myDels;
        private string queuedText;
        private Delegate lastDel;
        private int mySizeFromDel;
        private string myStringFromDel;
        

        public FileEditor(string fileDir)
        {
            myFileDir = fileDir;
            myThreadStart = new ThreadStart(Execute);
            myThread = new Thread(myThreadStart);
            
        }

        public string FileDirectory
        {
            get { return myFileDir; }
            set { myFileDir = value; }
        }

        private const string objName = "FileEditor";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }

        internal delegate void EditDelegate(string text);
        internal delegate string ReadDelegate();
        internal delegate int SizeDelegate();

        public void Queue(EditDelegate del, string text)
        {
            myThread.Start();
        }

        public void WriteLine(string text)
        {
            EditDelegate del = n => { string all = ReadAllText(); string ret = all + Environment.NewLine + n; File.WriteAllText(myFileDir, ret); };
            ExecuteEditDelegate(del, text);
        }

        public string ReadAllText()
        {
            ReadDelegate del = () => { return File.ReadAllText(myFileDir); };
            ExecuteReadDelegate(del);
            return myStringFromDel;
        }

        public void WriteAllText(string text)
        {
            EditDelegate del = n => File.WriteAllText(myFileDir , n);
            ExecuteEditDelegate(del, text);
        }

        public int GetTotalLength
        {
            get { SizeDelegate del = () => { return File.ReadAllText(myFileDir).Length; }; ExecuteSizeDelegate(del); return mySizeFromDel; }
        }

        public string ExecuteReadDelegate(ReadDelegate del)
        {
            lastDel = del;
            myThread = null;
            Execute();
            return myStringFromDel;
        }

        public void ExecuteEditDelegate(EditDelegate del, string text)
        {
            queuedText = text;
            lastDel = del;
            Execute();
        }

        public int ExecuteSizeDelegate(SizeDelegate del)
        {
            lastDel = del;
            Execute();
            return mySizeFromDel;
        }

        private void Execute() //TODO
        {
            
            
                if (lastDel is SizeDelegate) { SizeDelegate del = (SizeDelegate)lastDel; mySizeFromDel = del();  }
                else if (lastDel is ReadDelegate) { ReadDelegate del = (ReadDelegate)lastDel; myStringFromDel = del(); }
                else if (lastDel is EditDelegate) { EditDelegate del = (EditDelegate)lastDel; del(queuedText); }
                else
             {

             }

           
            
            
            
         }
    }
}
