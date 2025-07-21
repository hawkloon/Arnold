using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    internal class SettingsAction : Action
    {
        public override string[] Keywords
        {
            get
            {
                return new string[] { "settings", "open settings" };
            }
        }


        public override void OnCalled(string command)
        {
            base.OnCalled(command);
            var settings = new SettingsWindow();
            settings.Show();
        }
    }
}
