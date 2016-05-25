using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    internal class Word : BotRelatedObject
    {

        public enum WordState
        {
            Restricted,
            Banned,
            Allowed,
            Trigger
        }

        private readonly string myWord;
        private WordState state;
        

        private const string objName = "Word";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }

        public Word(string word, WordState state)
        {
            myWord = word;
            this.state = state;
        }

        public bool Equals(string text)
        {
            return myWord == text;
        }

        public bool IsBanned
        {
            get { return state.Equals(WordState.Banned); }
        }

        public bool IsRestricted
        {
            get { return state.Equals(WordState.Restricted); }
        }

        public void Restrict()
        {
            state = WordState.Restricted;
        }

        public void Ban()
        {
            state = WordState.Banned;
        }

        public void Allow()
        {
            state = WordState.Allowed;
        }

        public WordState State
        {
            get { return state; }
        }

        public bool Contains(string text)
        {
            return myWord.Contains(text);
        }
    }
}
