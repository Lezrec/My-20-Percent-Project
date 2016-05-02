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
            this.OutputLabel = new System.Windows.Forms.Label();
            this.InputPage = new System.Windows.Forms.TabControl();
            this.OutputPage = new System.Windows.Forms.TabPage();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.DebugPage = new System.Windows.Forms.TabPage();
            this.DebugTextBox = new System.Windows.Forms.TextBox();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.InputPg = new System.Windows.Forms.TabPage();
            this.ModerationPage = new System.Windows.Forms.TabPage();
            this.CommandPage = new System.Windows.Forms.TabPage();
            this.whatItDoText = new System.Windows.Forms.TextBox();
            this.cmdText = new System.Windows.Forms.TextBox();
            this.InputPage.SuspendLayout();
            this.OutputPage.SuspendLayout();
            this.DebugPage.SuspendLayout();
            this.CommandPage.SuspendLayout();
            this.SuspendLayout();
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
            this.InputPage.Controls.Add(this.InputPg);
            this.InputPage.Controls.Add(this.ModerationPage);
            this.InputPage.Controls.Add(this.CommandPage);
            this.InputPage.Location = new System.Drawing.Point(12, 12);
            this.InputPage.Name = "InputPage";
            this.InputPage.SelectedIndex = 0;
            this.InputPage.Size = new System.Drawing.Size(600, 298);
            this.InputPage.TabIndex = 1;
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
            // InputPg
            // 
            this.InputPg.Location = new System.Drawing.Point(4, 22);
            this.InputPg.Name = "InputPg";
            this.InputPg.Padding = new System.Windows.Forms.Padding(3);
            this.InputPg.Size = new System.Drawing.Size(592, 272);
            this.InputPg.TabIndex = 2;
            this.InputPg.Text = "Input";
            this.InputPg.UseVisualStyleBackColor = true;
            // 
            // ModerationPage
            // 
            this.ModerationPage.Location = new System.Drawing.Point(4, 22);
            this.ModerationPage.Name = "ModerationPage";
            this.ModerationPage.Padding = new System.Windows.Forms.Padding(3);
            this.ModerationPage.Size = new System.Drawing.Size(592, 272);
            this.ModerationPage.TabIndex = 3;
            this.ModerationPage.Text = "Moderation";
            this.ModerationPage.UseVisualStyleBackColor = true;
            // 
            // CommandPage
            // 
            this.CommandPage.Controls.Add(this.whatItDoText);
            this.CommandPage.Controls.Add(this.cmdText);
            this.CommandPage.Location = new System.Drawing.Point(4, 22);
            this.CommandPage.Name = "CommandPage";
            this.CommandPage.Padding = new System.Windows.Forms.Padding(3);
            this.CommandPage.Size = new System.Drawing.Size(592, 272);
            this.CommandPage.TabIndex = 4;
            this.CommandPage.Text = "Commands";
            this.CommandPage.UseVisualStyleBackColor = true;
            // 
            // whatItDoText
            // 
            this.whatItDoText.Location = new System.Drawing.Point(282, 0);
            this.whatItDoText.Multiline = true;
            this.whatItDoText.Name = "whatItDoText";
            this.whatItDoText.ReadOnly = true;
            this.whatItDoText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.whatItDoText.Size = new System.Drawing.Size(309, 272);
            this.whatItDoText.TabIndex = 1;
            // 
            // cmdText
            // 
            this.cmdText.Location = new System.Drawing.Point(-3, 0);
            this.cmdText.Multiline = true;
            this.cmdText.Name = "cmdText";
            this.cmdText.ReadOnly = true;
            this.cmdText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cmdText.Size = new System.Drawing.Size(287, 272);
            this.cmdText.TabIndex = 0;
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
            this.InputPage.ResumeLayout(false);
            this.OutputPage.ResumeLayout(false);
            this.OutputPage.PerformLayout();
            this.DebugPage.ResumeLayout(false);
            this.DebugPage.PerformLayout();
            this.CommandPage.ResumeLayout(false);
            this.CommandPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.TabControl InputPage;
        private System.Windows.Forms.TabPage OutputPage;
        private System.Windows.Forms.TabPage DebugPage;
        private System.Windows.Forms.TabPage InputPg;
        private System.Windows.Forms.TabPage ModerationPage;
        private System.Windows.Forms.TabPage CommandPage;
        private System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.TextBox DebugTextBox;
        private System.Windows.Forms.Label DebugLabel;
        private System.Windows.Forms.TextBox whatItDoText;
        private System.Windows.Forms.TextBox cmdText;
    }
}

