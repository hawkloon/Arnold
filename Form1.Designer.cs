namespace VoiceRecognition
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            trayContextMenu = new ContextMenuStrip(components);
            settingsToolStripMenuItem = new ToolStripMenuItem();
            openPromptToolStripMenuItem = new ToolStripMenuItem();
            muteToolStripMenuItem = new ToolStripMenuItem();
            saveSettingsToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            mainIcon = new NotifyIcon(components);
            button1 = new Button();
            trayContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // trayContextMenu
            // 
            trayContextMenu.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, openPromptToolStripMenuItem, muteToolStripMenuItem, saveSettingsToolStripMenuItem, quitToolStripMenuItem });
            trayContextMenu.Name = "contextMenuStrip1";
            trayContextMenu.Size = new Size(147, 114);
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(146, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // openPromptToolStripMenuItem
            // 
            openPromptToolStripMenuItem.Name = "openPromptToolStripMenuItem";
            openPromptToolStripMenuItem.Size = new Size(146, 22);
            openPromptToolStripMenuItem.Text = "Open Prompt";
            openPromptToolStripMenuItem.Click += openPromptToolStripMenuItem_Click;
            // 
            // muteToolStripMenuItem
            // 
            muteToolStripMenuItem.Name = "muteToolStripMenuItem";
            muteToolStripMenuItem.Size = new Size(146, 22);
            muteToolStripMenuItem.Text = "Mute";
            muteToolStripMenuItem.Click += muteToolStripMenuItem_Click;
            // 
            // saveSettingsToolStripMenuItem
            // 
            saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            saveSettingsToolStripMenuItem.Size = new Size(146, 22);
            saveSettingsToolStripMenuItem.Text = "Save Settings";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(146, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // mainIcon
            // 
            mainIcon.Icon = (Icon)resources.GetObject("mainIcon.Icon");
            mainIcon.Text = "Hawkloons Uber Cool Voice Recognition";
            // 
            // button1
            // 
            button1.Location = new Point(637, 408);
            button1.Name = "button1";
            button1.Size = new Size(151, 30);
            button1.TabIndex = 1;
            button1.Text = "Save Settings";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            trayContextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem muteToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private Button button1;
        internal ContextMenuStrip trayContextMenu;
        internal NotifyIcon mainIcon;
        private ToolStripMenuItem saveSettingsToolStripMenuItem;
        private ToolStripMenuItem openPromptToolStripMenuItem;
    }
}