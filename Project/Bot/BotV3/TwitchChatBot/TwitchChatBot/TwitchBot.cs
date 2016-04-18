using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchChatBot
{
    /// <summary>
    /// The main class that is created and executed at program start.
    /// </summary>
    internal partial class TwitchBot : Form
    {
        public static TwitchBot me;
        private static int progBar;

        /// <summary>
        /// The instances label.
        /// </summary>
        public Label MyLabel
        {
            get { return label1; }
        }

        /// <summary>
        /// Writes to the label text.
        /// </summary>
        /// <param name="text"></param>
        internal void WriteToRawLabel(string text)
        {
            label1.Text += text;
        }

        internal void WriteToScrubbedLabel(string text)
        {

        }

        private void LookProductive(string text)
        {
            progBar += 1;
            if (progBar >= 100)
            {
                progBar = 0;
            }
            progressBar1.Value = progBar;
        }


        /// <summary>
        /// The constructor of the main class.
        /// </summary>
        public TwitchBot()
        {
            
            InitializeComponent();
            

            GUIManager.Bot = this;
            me = this;
        }

        /// <summary>
        /// Executed at program start.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwitchBot_Load(object sender, EventArgs e)
        {
            LookProductive("");
            GUIManager.Load();
            FileEditor.Load();
            CommandManager.Load();
            TimeFromBot.Load(timer1);
            Connector.Load();
            
            //TODO set up connections
            // Works : GUIManager.WriteToLabel("Test");
            
            


        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Double clicked on label1 8(
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LookProductive("");
            
            TimeFromBot.Tick(sender, e);
            
        }
    }
}
