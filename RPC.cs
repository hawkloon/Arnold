using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Logging;
using System.Diagnostics;

namespace VoiceRecognition
{
    internal static class RPC
    {
        public static DiscordRpcClient client;
        public static void SetUp()
        {
            client = new DiscordRpcClient("1394616222078861342");

            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            client.OnReady += (sender, e) =>
            {
                Debug.WriteLine("Connected to discord as " + e.User.Username);
            };

            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = "Arnold is listening",
                State = "Stalking",
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "image_key",
                }
            });
        }
    }
}
