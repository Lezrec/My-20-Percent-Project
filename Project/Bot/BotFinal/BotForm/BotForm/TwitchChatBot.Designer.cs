namespace BotForm
{
    partial class TwitchChatBot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CommandPage = new System.Windows.Forms.TabPage();
            this.whatItSay = new System.Windows.Forms.Label();
            this.cmdLab = new System.Windows.Forms.Label();
            this.doBox = new System.Windows.Forms.TextBox();
            this.trigBox = new System.Windows.Forms.TextBox();
            this.whatItDoText = new System.Windows.Forms.TextBox();
            this.cmdText = new System.Windows.Forms.TextBox();
            this.ownerCmdB = new System.Windows.Forms.Button();
            this.modCmdB = new System.Windows.Forms.Button();
            this.comdB = new System.Windows.Forms.Button();
            this.ModerationPage = new System.Windows.Forms.TabPage();
            this.secondsBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timeoutBox = new System.Windows.Forms.TextBox();
            this.banB = new System.Windows.Forms.Button();
            this.banBox = new System.Windows.Forms.TextBox();
            this.DebugPage = new System.Windows.Forms.TabPage();
            this.DebugTextBox = new System.Windows.Forms.TextBox();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.OutputPage = new System.Windows.Forms.TabPage();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.InputPage = new System.Windows.Forms.TabControl();
            this.chBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CommandPage.SuspendLayout();
            this.ModerationPage.SuspendLayout();
            this.DebugPage.SuspendLayout();
            this.OutputPage.SuspendLayout();
            this.InputPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandPage
            // 
            this.CommandPage.Controls.Add(this.whatItSay);
            this.CommandPage.Controls.Add(this.cmdLab);
            this.CommandPage.Controls.Add(this.doBox);
            this.CommandPage.Controls.Add(this.trigBox);
            this.CommandPage.Controls.Add(this.whatItDoText);
            this.CommandPage.Controls.Add(this.cmdText);
            this.CommandPage.Controls.Add(this.ownerCmdB);
            this.CommandPage.Controls.Add(this.modCmdB);
            this.CommandPage.Controls.Add(this.comdB);
            this.CommandPage.Location = new System.Drawing.Point(4, 22);
            this.CommandPage.Name = "CommandPage";
            this.CommandPage.Padding = new System.Windows.Forms.Padding(3);
            this.CommandPage.Size = new System.Drawing.Size(592, 272);
            this.CommandPage.TabIndex = 4;
            this.CommandPage.Text = "Commands";
            this.CommandPage.UseVisualStyleBackColor = true;
            // 
            // whatItSay
            // 
            this.whatItSay.AutoSize = true;
            this.whatItSay.Location = new System.Drawing.Point(148, 7);
            this.whatItSay.Name = "whatItSay";
            this.whatItSay.Size = new System.Drawing.Size(68, 13);
            this.whatItSay.TabIndex = 8;
            this.whatItSay.Text = "What it says:";
            // 
            // cmdLab
            // 
            this.cmdLab.AutoSize = true;
            this.cmdLab.Location = new System.Drawing.Point(7, 7);
            this.cmdLab.Name = "cmdLab";
            this.cmdLab.Size = new System.Drawing.Size(93, 13);
            this.cmdLab.TabIndex = 7;
            this.cmdLab.Text = "Command Trigger:";
            // 
            // doBox
            // 
            this.doBox.Location = new System.Drawing.Point(148, 29);
            this.doBox.Name = "doBox";
            this.doBox.Size = new System.Drawing.Size(100, 20);
            this.doBox.TabIndex = 6;
            // 
            // trigBox
            // 
            this.trigBox.Location = new System.Drawing.Point(7, 29);
            this.trigBox.Name = "trigBox";
            this.trigBox.Size = new System.Drawing.Size(100, 20);
            this.trigBox.TabIndex = 5;
            // 
            // whatItDoText
            // 
            this.whatItDoText.Location = new System.Drawing.Point(282, 173);
            this.whatItDoText.Multiline = true;
            this.whatItDoText.Name = "whatItDoText";
            this.whatItDoText.ReadOnly = true;
            this.whatItDoText.Size = new System.Drawing.Size(313, 103);
            this.whatItDoText.TabIndex = 1;
            // 
            // cmdText
            // 
            this.cmdText.Location = new System.Drawing.Point(0, 173);
            this.cmdText.Multiline = true;
            this.cmdText.Name = "cmdText";
            this.cmdText.ReadOnly = true;
            this.cmdText.Size = new System.Drawing.Size(291, 103);
            this.cmdText.TabIndex = 0;
            // 
            // ownerCmdB
            // 
            this.ownerCmdB.Location = new System.Drawing.Point(202, 54);
            this.ownerCmdB.Name = "ownerCmdB";
            this.ownerCmdB.Size = new System.Drawing.Size(75, 23);
            this.ownerCmdB.TabIndex = 4;
            this.ownerCmdB.Text = "Owner";
            this.ownerCmdB.UseVisualStyleBackColor = true;
            this.ownerCmdB.Click += new System.EventHandler(this.ownerCmdB_Click);
            // 
            // modCmdB
            // 
            this.modCmdB.Location = new System.Drawing.Point(104, 55);
            this.modCmdB.Name = "modCmdB";
            this.modCmdB.Size = new System.Drawing.Size(75, 23);
            this.modCmdB.TabIndex = 3;
            this.modCmdB.Text = "Mod";
            this.modCmdB.UseVisualStyleBackColor = true;
            this.modCmdB.Click += new System.EventHandler(this.modCmdB_Click);
            // 
            // comdB
            // 
            this.comdB.Location = new System.Drawing.Point(7, 55);
            this.comdB.Name = "comdB";
            this.comdB.Size = new System.Drawing.Size(75, 23);
            this.comdB.TabIndex = 2;
            this.comdB.Text = "Normal";
            this.comdB.UseVisualStyleBackColor = true;
            this.comdB.Click += new System.EventHandler(this.comdB_Click);
            // 
            // ModerationPage
            // 
            this.ModerationPage.Controls.Add(this.label3);
            this.ModerationPage.Controls.Add(this.chB);
            this.ModerationPage.Controls.Add(this.label2);
            this.ModerationPage.Controls.Add(this.chBox);
            this.ModerationPage.Controls.Add(this.secondsBox);
            this.ModerationPage.Controls.Add(this.label1);
            this.ModerationPage.Controls.Add(this.button1);
            this.ModerationPage.Controls.Add(this.timeoutBox);
            this.ModerationPage.Controls.Add(this.banB);
            this.ModerationPage.Controls.Add(this.banBox);
            this.ModerationPage.Location = new System.Drawing.Point(4, 22);
            this.ModerationPage.Name = "ModerationPage";
            this.ModerationPage.Padding = new System.Windows.Forms.Padding(3);
            this.ModerationPage.Size = new System.Drawing.Size(592, 272);
            this.ModerationPage.TabIndex = 3;
            this.ModerationPage.Text = "Moderation";
            this.ModerationPage.UseVisualStyleBackColor = true;
            // 
            // secondsBox
            // 
            this.secondsBox.Location = new System.Drawing.Point(240, 16);
            this.secondsBox.Name = "secondsBox";
            this.secondsBox.Size = new System.Drawing.Size(100, 20);
            this.secondsBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seconds";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Timeout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timeoutBox
            // 
            this.timeoutBox.Location = new System.Drawing.Point(134, 16);
            this.timeoutBox.Name = "timeoutBox";
            this.timeoutBox.Size = new System.Drawing.Size(100, 20);
            this.timeoutBox.TabIndex = 2;
            // 
            // banB
            // 
            this.banB.Location = new System.Drawing.Point(7, 42);
            this.banB.Name = "banB";
            this.banB.Size = new System.Drawing.Size(75, 23);
            this.banB.TabIndex = 1;
            this.banB.Text = "Ban";
            this.banB.UseVisualStyleBackColor = true;
            this.banB.Click += new System.EventHandler(this.banB_Click);
            // 
            // banBox
            // 
            this.banBox.Location = new System.Drawing.Point(7, 16);
            this.banBox.Name = "banBox";
            this.banBox.Size = new System.Drawing.Size(100, 20);
            this.banBox.TabIndex = 0;
            // 
            // DebugPage
            // 
            this.DebugPage.Controls.Add(this.DebugTextBox);
            this.DebugPage.Controls.Add(this.DebugLabel);
            this.DebugPage.Location = new System.Drawing.Point(4, 22);
            this.DebugPage.Name = "DebugPage";
            this.DebugPage.Padding = new System.Windows.Forms.Padding(3);
            this.DebugPage.Size = new System.Drawing.Size(592, 272);
            this.DebugPage.TabIndex = 1;
            this.DebugPage.Text = "Debug";
            this.DebugPage.UseVisualStyleBackColor = true;
            // 
            // DebugTextBox
            // 
            this.DebugTextBox.Location = new System.Drawing.Point(4, 24);
            this.DebugTextBox.Multiline = true;
            this.DebugTextBox.Name = "DebugTextBox";
            this.DebugTextBox.ReadOnly = true;
            this.DebugTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DebugTextBox.Size = new System.Drawing.Size(582, 242);
            this.DebugTextBox.TabIndex = 1;
            // 
            // DebugLabel
            // 
            this.DebugLabel.AutoSize = true;
            this.DebugLabel.Location = new System.Drawing.Point(7, 7);
            this.DebugLabel.Name = "DebugLabel";
            this.DebugLabel.Size = new System.Drawing.Size(42, 13);
            this.DebugLabel.TabIndex = 0;
            this.DebugLabel.Text = "Debug:";
            // 
            // OutputPage
            // 
            this.OutputPage.Controls.Add(this.OutputText);
            this.OutputPage.Controls.Add(this.OutputLabel);
            this.OutputPage.Location = new System.Drawing.Point(4, 22);
            this.OutputPage.Name = "OutputPage";
            this.OutputPage.Padding = new System.Windows.Forms.Padding(3);
            this.OutputPage.Size = new System.Drawing.Size(592, 272);
            this.OutputPage.TabIndex = 0;
            this.OutputPage.Text = "Output";
            this.OutputPage.UseVisualStyleBackColor = true;
            // 
            // OutputText
            // 
            this.OutputText.Location = new System.Drawing.Point(9, 20);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputText.Size = new System.Drawing.Size(561, 246);
            this.OutputText.TabIndex = 1;
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(6, 3);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(42, 13);
            this.OutputLabel.TabIndex = 0;
            this.OutputLabel.Text = "Output:";
            this.OutputLabel.Click += new System.EventHandler(this.OutputLabel_Click);
            // 
            // InputPage
            // 
            this.InputPage.Controls.Add(this.OutputPage);
            this.InputPage.Controls.Add(this.DebugPage);
            this.InputPage.Controls.Add(this.ModerationPage);
            this.InputPage.Controls.Add(this.CommandPage);
            this.InputPage.Location = new System.Drawing.Point(12, 12);
            this.InputPage.Name = "InputPage";
            this.InputPage.SelectedIndex = 0;
            this.InputPage.Size = new System.Drawing.Size(600, 298);
            this.InputPage.TabIndex = 1;
            // 
            // chBox
            // 
            this.chBox.Location = new System.Drawing.Point(7, 127);
            this.chBox.Name = "chBox";
            this.chBox.Size = new System.Drawing.Size(100, 20);
            this.chBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Change Channel:";
            // 
            // chB
            // 
            this.chB.Location = new System.Drawing.Point(10, 154);
            this.chB.Name = "chB";
            this.chB.Size = new System.Drawing.Size(75, 23);
            this.chB.TabIndex = 8;
            this.chB.Text = "Change";
            this.chB.UseVisualStyleBackColor = true;
            this.chB.Click += new System.EventHandler(this.chB_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Current Channel: ";
            // 
            // TwitchChatBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 322);
            this.Controls.Add(this.InputPage);
            this.Name = "TwitchChatBot";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CommandPage.ResumeLayout(false);
            this.CommandPage.PerformLayout();
            this.ModerationPage.ResumeLayout(false);
            this.ModerationPage.PerformLayout();
            this.DebugPage.ResumeLayout(false);
            this.DebugPage.PerformLayout();
            this.OutputPage.ResumeLayout(false);
            this.OutputPage.PerformLayout();
            this.InputPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage CommandPage;
        private System.Windows.Forms.Label whatItSay;
        private System.Windows.Forms.Label cmdLab;
        private System.Windows.Forms.TextBox doBox;
        private System.Windows.Forms.TextBox trigBox;
        private System.Windows.Forms.TextBox whatItDoText;
        private System.Windows.Forms.TextBox cmdText;
        private System.Windows.Forms.Button ownerCmdB;
        private System.Windows.Forms.Button modCmdB;
        private System.Windows.Forms.Button comdB;
        private System.Windows.Forms.TabPage ModerationPage;
        private System.Windows.Forms.TabPage DebugPage;
        private System.Windows.Forms.TextBox DebugTextBox;
        private System.Windows.Forms.Label DebugLabel;
        private System.Windows.Forms.TabPage OutputPage;
        private System.Windows.Forms.TextBox OutputText;
        public System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.TabControl InputPage;
        private System.Windows.Forms.Button banB;
        private System.Windows.Forms.TextBox banBox;
        private System.Windows.Forms.TextBox secondsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox timeoutBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button chB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox chBox;
    }
}

