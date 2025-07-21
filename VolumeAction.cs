using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    internal class VolumeAction : Action
    {
        public override string[] Keywords
        {
            get
            {
                return new string[] { "volume" };
            }
        }

        public override string[] Parameters => new string[]
        {
                "max",
                "mute"
        };


        private void SetVolume(float volume)
        {
            var deviceEnum = new MMDeviceEnumerator();
            var device = deviceEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            if(volume == 0)
            {
                device.AudioEndpointVolume.Mute = true;
            }
            else
            {
                device.AudioEndpointVolume.Mute = false;
            }
            device.AudioEndpointVolume.MasterVolumeLevelScalar = volume;
        }

        public override void OnCalled(string parameters)
        {
            base.OnCalled(parameters);
            var parameter = ParseCommand(parameters);
            switch (parameter)
            {
                case "max":
                    SetVolume(1.0f); // Set volume to maximum
                    break;
                case "mute":
                    SetVolume(0.0f); // Mute the volume
                    break;
            }
        }
    }
}
