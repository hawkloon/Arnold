using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    internal class NextTrackAction : Action
    {
        public override string[] Keywords
        {
            get
            {
                return new string[] { "next track", "skip", "next song" };
            }
        }

        public async override void OnCalled(string parameters)
        {
            base.OnCalled(parameters);
            MediaKeyController.NextTrack();
        }
    }
}
