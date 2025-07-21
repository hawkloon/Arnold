using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    public class OpenAction : Action
    {
        public override string[] Keywords
        {
            get
            {
                return new string[] { "open", "launch", "start", "run" };
            }
        }
        public Dictionary<string, string> OpenableApps { get; set; } = new Dictionary<string, string>
        {
            ["Test"] = "Test"
        };

        public override string[] Parameters => OpenableApps.Keys.ToArray();

        public override void OnLoad()
        {
            base.OnLoad();
            LoadRegisteredApps();
        }

        public void LoadRegisteredApps()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string myFolder = Path.Combine(appDataPath, "Hawkloon", "VoiceRecognition");
            string registeredAppsFile = Path.Combine(myFolder, "registered_apps.json");
            if (!Directory.Exists(myFolder) || !File.Exists(registeredAppsFile))
                return;
            string json = File.ReadAllText(registeredAppsFile);
            var registeredApps = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            OpenableApps = registeredApps ?? new Dictionary<string, string>();
        }

        public void SaveRegisteredApps()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string myFolder = Path.Combine(appDataPath, "Hawkloon", "VoiceRecognition");    
            string registeredAppsFile = Path.Combine(myFolder, "registered_apps.json");

            if (!Directory.Exists(myFolder))
            {
                Directory.CreateDirectory(myFolder);
            }
            var json = System.Text.Json.JsonSerializer.Serialize(OpenableApps);

            File.WriteAllText(registeredAppsFile, json);
        }

        public void AddOpenable(string path, string name)
        {
            OpenableApps.Add(name.ToLowerInvariant(), path);
            Program.ChangeAssistantName();
            SaveRegisteredApps();
        }
        public override void OnCalled(string parameters)
        {
            Program.synth.SpeakAsync("I am opening your fuck ass app, hang on");

            var name = ParseCommand(parameters);
            Debug.WriteLine(name);

            if (OpenableApps.ContainsKey(name))
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = OpenableApps[name];
                start.WindowStyle = ProcessWindowStyle.Maximized;

                int exitCode;

                Process.Start(start);
            }
        }
    }
}
