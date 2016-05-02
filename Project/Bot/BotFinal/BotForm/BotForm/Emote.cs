using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotForm
{
    public enum EmoteID //TODO add all emotes
    {
        Kappa,
        PogChamp,
        EleGiggle,
        DansGame,
        WutFace,
        SeemsGood,
        FeelsBadMan,

    }

    public class Emote : BotRelatedObject //TODO const all emotes
    {
        private EmoteID myId;
        private string name;
        public Emote(string name, EmoteID id)
        {
            this.name = name;
            myId = id;
        }

        private const string objName = "Emote";
        public override string MyObjectName
        {
            get
            {
                return objName;
            }
        }
    } 
}
