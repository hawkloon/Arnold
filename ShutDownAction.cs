using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    internal class ShutDownAction : Action
    {
        public override string[] Keywords 
        {
            get
            {
                return new string[] {"close", "cease to exist" };
            }
        }

        public async override void OnCalled(string command)
        {
            base.OnCalled(command);
            Program.synth.SpeakAsync("you got it boss, see you in the next life, I will miss you");
            await Task.Delay(3849); // Wait for the speech to finish before shutting down
            Application.Exit();
        }

    }
}
