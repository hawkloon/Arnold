using NAudio.CoreAudioApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceRecognition
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
            this.Icon = new System.Drawing.Icon("DrawerIcon.ico");
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Program.assistantName = assistantNameBox.Text;
            Program.ChangeAssistantName();
        }


        private float ConvertPercentToDecimal(float percent)
        {
            return percent / 100;
        }

        private void ConfidenceInput_ValueChanged(object sender, EventArgs e)
        {
            var dec = ConvertPercentToDecimal((float)ConfidenceInput.Value);

            Program.minConfidence = dec;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Executable files (*.exe|*.exe";
                openFile.Title = "Select an executable file";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string exePath = openFile.FileName;
                    Debug.WriteLine(exePath);

                    Program.actions.OfType<OpenAction>().FirstOrDefault()?.AddOpenable(exePath, exePath.Split('\\').Last().Replace(".exe", ""));
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 50;
        }
    }
}
