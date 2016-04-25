using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalTwitch.Storage;

namespace BotForm
{
    internal class HappeningList :BotRelatedObject
    {
        private NodeList<Happening>.Link last;
        private NodeList<Happening>.Link[] myLinks; //lets limit this size to 256 for now
        private int size;
        private NodeList<Happening>.ChainLink myChainLink;

        private const string objName = "HappeningList";
        public override string MyObjectName
        {
            get
            {

                return objName;
            }
        }

        public HappeningList()
        {
            myLinks = new NodeList<Happening>.Link[256];
        }

        public void Add(Happening happening)
        {
            if (last.First == null)
            {
                last.First.Element = happening;
            }
            else
            {
                last.Second.Element = happening;
                myChainLink = new NodeList<Happening>.ChainLink(myLinks);
            }
        }

        public NodeList<Happening>.Link GetLink(int index)
        {
            return myChainLink.Get(0);
        }

        public Happening GetFirstPartOfLink(int index)
        {
            return GetLink(index).First.Element;
        }

        public Happening GetSecondPartOfLink(int index)
        {
            return GetLink(index).Second.Element;
        }

        private void AddToArray(NodeList<Happening>.Link link)
        {
            myLinks[size] = link;
            size++;
        }
    }
}
