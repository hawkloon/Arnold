using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    internal class TimeAction : Action
    {
        public override string[] Keywords
        {
            get
            {
                return new string[] { "time", "what's the time", "what time is it" };
            }
        }


        public override void OnCalled(string command)
        {
            base.OnCalled(command);

            TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);
            string t= time.ToString("hh:mm tt");

            Program.synth.SpeakAsync($"if you had fucking eyes, you'd know it's {t}");
        }
    }
}
