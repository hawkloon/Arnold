using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    internal class DebugAction : Action
    {
        public override string[] Keywords
        {
            get
            {
                return new string[] { "debug" };
            }
        }

        public async override void OnCalled(string parameters)
        {
            base.OnCalled(parameters);
        }
    }
}
