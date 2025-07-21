using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    public class ArnoldActions : Action
    {
        internal bool muted = false;
        public override string[] Keywords
        {
            get
            {
                return muteWords.Concat(unmuteWords).ToArray();
            }
        }

        private string[] muteWords = new string[] { "mute", "shut up", "shut the fuck up", "zip it" };
        public string[] unmuteWords = new string[] { "unmute", "you're forgiven", "come back" };

        public override void OnCalled(string command)
        {
            base.OnCalled(command);

            string[] parts = command.Split(new[] { ',' }, 2); // split into max 2 parts
            string com = parts.Length > 1 ? parts[1].Trim() : command;
            if (unmuteWords.Contains(com) && muted){
                muted = false;
                Program.synth.SpeakAsync("look who came crawling back");
                return;
            }
            else if(muteWords.Contains(com) && !muted)
            {
                muted = true;
                Program.synth.SpeakAsync("I guess I will just shut the fuck up you piece of shit");
                RPC.client.SetPresence(new RichPresence()
                {
                    Details = "Arnold is NOT listening",
                    State = "On Time Out :(",
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = "image_key",
                    }
                });
            }
        }


    }
}
