using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{

    public static class MediaKeyController
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private const byte VK_MEDIA_PLAY_PAUSE = 0xB3; // Virtual key code for media play/pause
        private const byte VK_MEDIA_NEXT_TRACK = 0xb0;
        private const byte VK_MEDIA_PREV_TRACK = 0xb1;
        private const uint KEYEVENTF_EXTENDEDKEY = 0x1; // Extended key flag
        private const uint KEYEVENTF_KEYUP = 0x2; // Key up flag


        public static void TogglePlayPause()
        {
            keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENDEDKEY, UIntPtr.Zero);
            keybd_event(VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, UIntPtr.Zero);
        }

        public static void NextTrack()
        {
            keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENDEDKEY, UIntPtr.Zero);
            keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, UIntPtr.Zero);
        }

        public static void PreviousTrack()
        {
            keybd_event(VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_EXTENDEDKEY, UIntPtr.Zero);
            keybd_event(VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, UIntPtr.Zero);
        }
    }
    internal class PlayAction : Action
    {
        public override string[] Keywords
        {
            get
            {
                return new string[] { "play", "pause", "media"};
            }
        }


        public override void OnCalled(string command)
        {
            base.OnCalled(command);
            MediaKeyController.TogglePlayPause();

        }
    }
}
