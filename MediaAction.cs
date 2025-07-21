using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    internal class MediaAction : Action
    {
        public override string[] Keywords
        {
            get
            {
                return new string[] { "play", "pause", "next song", "last song", "next track", "previous track" };
            }
        }

        public async override void OnCalled(string command)
        {
            base.OnCalled(command);

            string phrase = "";
            foreach(var keyword in Keywords)
            {
                if(command.ToLower().Contains(keyword.ToLower()))
                {
                    phrase = keyword;
                    break;
                }
            }
            switch (phrase)
            {
                case "play":
                    MediaKeyController.TogglePlayPause();
                    break;
                case "pause":
                    MediaKeyController.TogglePlayPause();
                    break;
                case "next song":
                case "next track":
                    MediaKeyController.NextTrack();
                    break;
                case "last song":
                case "previous track":
                    MediaKeyController.PreviousTrack();
                    break;
                default:
                    Program.synth.SpeakAsync("Command not recognized");
                    break;
            }
        }
    }
       
}
