using NAudio.CoreAudioApi;
using NAudio.Wave;
using Newtonsoft.Json;
using System.Diagnostics;

namespace VoiceRecognition
{
    public partial class Form1 : Form
    {
        private static Form1? instance;

        public static Form1 Instance => instance != null ? instance : null;
        public Form1()
        {
            InitializeComponent();
            if (instance != null) this.Close();
            instance = this;

        }
        public void LoadSettings()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string myFolder = Path.Combine(appDataPath, "Hawkloon", "VoiceRecognition");
            string settingsFile = Path.Combine(myFolder, "settings.json");

            if (!Directory.Exists(myFolder) || !File.Exists(settingsFile))
                return;

            string json = File.ReadAllText(settingsFile);
            var saveSettings = JsonConvert.DeserializeObject<SaveSettings>(json);

            if (saveSettings == null) return;
            ApplySettings(saveSettings);
        }

        public void ApplySettings(SaveSettings saveSettings)
        {
            Program.assistantName = saveSettings.AssistantName;
            Program.minConfidence = saveSettings.Confidence;
            Program.ChangeAssistantName();
        }
        public void SetSettings()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string myFolder = Path.Combine(appDataPath, "Hawkloon", "VoiceRecognition");
            string settingsFile = Path.Combine(myFolder, "settings.json");
            if (!Directory.Exists(myFolder))
            {
                Directory.CreateDirectory(myFolder);
            }

            var saveSettings = new SaveSettings
            {
                AssistantName = Program.assistantName,
                Confidence = Program.minConfidence
            };

            ApplySettings(saveSettings);

            string json = JsonConvert.SerializeObject(saveSettings, Formatting.Indented);
            File.WriteAllText(settingsFile, json);
        }

        private float ConvertPercentToDecimal(float percent)
        {
            return percent / 100;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsWindow = new SettingsWindow();

            settingsWindow.ShowDialog();
        }


        private void openPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var promptWindow = new PromptWindow();

            promptWindow.ShowDialog();
        }

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.arnoldActions.muted)
            {
                Program.arnoldActions.OnCalled("arnold, unmute");
                muteToolStripMenuItem.Text = "Mute";
            }

            else
            {
                Program.arnoldActions.OnCalled("arnold, mute");
                muteToolStripMenuItem.Text = "Unmute";
            }

            Program.arnoldActions.muted = !Program.arnoldActions.muted;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}