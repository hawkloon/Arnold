using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceRecognition
{
    public partial class PromptWindow : Form
    {
        public PromptWindow()
        {
            InitializeComponent();
            this.Icon = new System.Drawing.Icon("DrawerIcon.ico");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
