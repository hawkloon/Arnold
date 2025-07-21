using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
namespace VoiceRecognition
{
    internal class SpotifyAction : Action
    {

        public override string[] Keywords
        {
            get
            {
                return new string[] { "Spotify" };
                
            }
        }
        private static EmbedIOAuthServer _server;
        public async Task TestQuery()
        {
            _server = new EmbedIOAuthServer(new Uri("https://reifdiego.nl/oauth-pages/spotify-callback.html"), 8888);
            await _server.Start();
            Debug.WriteLine("Server started");
            _server.ImplictGrantReceived += _server_ImplictGrantReceived;
            _server.AuthorizationCodeReceived += _server_AuthorizationCodeReceived;
            _server.ErrorReceived += _server_ErrorReceived;
            var request = new LoginRequest(_server.BaseUri, "a9e8bfab592d44d89b5c5631b07e22a4", LoginRequest.ResponseType.Code)
            {
                Scope = new List<string>
                {
                    Scopes.UserTopRead,
                    Scopes.UserReadEmail
                }
            };

            BrowserUtil.Open(request.ToUri());
        }

        private async Task _server_ImplictGrantReceived(object arg1, ImplictGrantResponse arg2)
        {
            Debug.WriteLine("Implicit Grant recieved");
            await _server.Stop();
            Debug.WriteLine("Server Stopped");
            var spotify = new SpotifyClient(arg2.AccessToken);

            var userReq = new UsersTopItemsRequest(TimeRange.ShortTerm);
            var topArtists = await spotify.UserProfile.GetTopArtists(userReq);
            var top = topArtists.Items[0].Name;
            Program.synth.SpeakAsync(top);
        }

        private Task _server_ErrorReceived(object arg1, string arg2, string? arg3)
        {
            throw new NotImplementedException();
        }

        private async Task _server_AuthorizationCodeReceived(object arg1, AuthorizationCodeResponse arg2)
        {
            Debug.WriteLine("Auth Code Recieved");
            await _server.Stop();
            Debug.WriteLine("Server Stopped");
            var config = SpotifyClientConfig.CreateDefault();
            var tokenResponse = await new OAuthClient(config).RequestToken(
                new AuthorizationCodeTokenRequest(
                    "a9e8bfab592d44d89b5c5631b07e22a4", "134007c09466491cb04b904479b6d05d", arg2.Code, new Uri("https://reifdiego.nl/oauth-pages/spotify-callback.html")));


            var spotify = new SpotifyClient(tokenResponse.AccessToken);

            var userReq = new UsersTopItemsRequest(TimeRange.ShortTerm);
            var topArtists = await spotify.UserProfile.GetTopArtists(userReq);
            var top = topArtists.Items[0].Name;
            Program.synth.SpeakAsync(top);
        }

        public async override void OnCalled(string command)
        {
            base.OnCalled(command);
            await TestQuery();
        }
    }
}
