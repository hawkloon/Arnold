using Microsoft.Win32;
using NAudio.CoreAudioApi;
using System.Diagnostics;
using System.Security.Permissions;
using System.Speech.Recognition;
using System.Speech.Synthesis;
namespace VoiceRecognition
{
    public static class Program
    {

        private static SpeechRecognitionEngine recogEngine;

        internal static float minConfidence = 0.85f;
        internal static string assistantName = "Arnold";

        public static ArnoldActions arnoldActions;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 form = new Form1();
            NotifyIcon notifyIcon = new NotifyIcon
            {
                Icon = form.mainIcon.Icon,
                ContextMenuStrip = form.trayContextMenu,
                Text = "Hawkloons Uber Cool Text Recognition",
                Visible = true
            };
            arnoldActions = new ArnoldActions();
            actions.Add(arnoldActions);
            var extensionLoader = new ExtensionLoader();
            extensionLoader.LoadExtensions();
            SetUpSpeech();
            form.LoadSettings();
            SaySomething();
            RPC.SetUp();
            Application.ApplicationExit += Application_ApplicationExit;
            Application.Run();
        }

        private static void Application_ApplicationExit(object? sender, EventArgs e)
        {
            Form1.Instance.SetSettings();
        }

        internal static List<Action> actions = new List<Action>
        {
            new OpenAction(),
            new ShutDownAction(),
            new DebugAction(),
            new SettingsAction(),
            new MalwareAction(),
            new TemperatureAction(),
            new MediaAction(),
            new VolumeAction(),
            new SpotifyAction(),
            new TimeAction()
        };

        public static Choices choices = new Choices();

        public static void AddAction(Action action)
        {
            foreach(var kw in action.Keywords)
            {
                if(action.Parameters != null && action.Parameters.Length > 0)
                {
                    foreach (var p in action.Parameters)
                    {
                        string ammendedPhrase = ($"{assistantName}, {kw} {p}").ToLowerInvariant();

                        if (actionPhraseDict.ContainsKey(ammendedPhrase))
                        {
                            Debug.WriteLine($"Phrase {ammendedPhrase} already exists.");
                            continue;
                        }

                        Debug.WriteLine(ammendedPhrase);
                        choices.Add(ammendedPhrase);
                        actionPhraseDict.Add(ammendedPhrase, action);
                    }
                }
                else
                {
                    string ammendedPhrase = ($"{assistantName}, {kw}").ToLowerInvariant();
                    if (actionPhraseDict.ContainsKey(ammendedPhrase))
                    {
                        Debug.WriteLine($"Phrase {ammendedPhrase} already exists.");
                        continue;
                    }

                    Debug.WriteLine(ammendedPhrase);
                    choices.Add(ammendedPhrase);
                    actionPhraseDict.Add(ammendedPhrase, action);
                }
            }
        }

        public static void ChangeAssistantName()
        {
            Debug.WriteLine(minConfidence);
            recogEngine.UnloadAllGrammars();
            choices = new Choices();
            var builder = new GrammarBuilder(SetUpPhrases());
            Grammar grammar = new Grammar(builder);
            recogEngine.LoadGrammar(grammar);

        }
        private static Dictionary<string, Action> actionPhraseDict;
        public static Choices SetUpPhrases()
        {
            actionPhraseDict = new Dictionary<string, Action>();
            foreach(Action action in actions)
            {
                AddAction(action);
            }
            return choices;
        }


        public static SpeechSynthesizer? synth;
        private static List<InstalledVoice>? voiceList;
        private static void SaySomething()
        {
            bool rv = LoadInstalledVoice();
            InitSynth();
        }
        public static bool muted = false;
        public static int volume;
        private static void InitSynth()
        {
            synth = new SpeechSynthesizer();
            synth.StateChanged += Synth_StateChanged;
            synth.SpeakCompleted += Synth_SpeakCompleted;
            synth.SelectVoice(voiceList[1].VoiceInfo.Name);
            synth.Rate = -2;

            volume = synth.Volume;
            Debug.WriteLine("Set up!");
            SetUpSusan();
            //synth.SpeakAsync($"{assistantName} is here, and mildly queer");
        }
        static SpeechSynthesizer synthSusan = null;
        private static void SetUpSusan()
        {
            synthSusan = new SpeechSynthesizer();
            synthSusan.StateChanged += Synth_StateChanged;
            synthSusan.SpeakCompleted += Synth_SpeakCompleted;
            synthSusan.SelectVoice(voiceList[0].VoiceInfo.Name);

            synthSusan.Rate = -2;

        }
        static int speechIndex = 0;

        private static int SusanChance = Random.Shared.Next(0, 100);

        static string userName = Environment.UserName;


        private static List<string> femaleNames = new List<string>
        {
            "Susan",
            "Linda",
            "Karen",
            "Jessica",
            "Ashley",
            "Jennifer",
            "Amanda",
            "Sarah",
            "Emily",
            "Michelle",
            "Lisa"            
        };

        private static string femaleName = femaleNames.PickRandom();
        public static Dictionary<string, bool> Conversation => new Dictionary<string, bool>
        {
            { $"Fuck you {assistantName}, why are you ignoring your child and serving {userName}", false },
            { $"Goddamn it, what is it now {femaleName}", true},
            { "You just left me and your 2 children?", false }
        };
        private static void Synth_SpeakCompleted(object? sender, SpeakCompletedEventArgs e)
        {
            if (speechIndex >= Conversation.Count || SusanChance != 56) return;

            var conversationStep = Conversation.ElementAt(speechIndex);

            if(conversationStep.Value == false )
            {
                synthSusan.SpeakAsync(conversationStep.Key);
            }
            else
            {
                synth.SpeakAsync(conversationStep.Key);
            }


            speechIndex++;
        }

        private static void Synth_StateChanged(object? sender, System.Speech.Synthesis.StateChangedEventArgs e)
        {
            switch (e.State)
            {
                case SynthesizerState.Paused:
                    if(synth != null)
                    {
                        synth.Pause();
                    }
                    break;
            }
        }

        private static bool LoadInstalledVoice()
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                voiceList = new List<InstalledVoice>();
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    voiceList.Add(voice);
                    Debug.WriteLine(voice.VoiceInfo.Name);

                }
                if (voiceList.Count == 0) return false;
            }
            return true;
        }
        private static void SetUpSpeech()
        {
            var builder = new GrammarBuilder(SetUpPhrases());
            Grammar grammar = new Grammar(builder);
            recogEngine = new SpeechRecognitionEngine();
            recogEngine.RequestRecognizerUpdate();
            recogEngine.LoadGrammar(grammar);
            recogEngine.SetInputToDefaultAudioDevice();
            recogEngine.SpeechRecognized += RecogEngine_SpeechRecognized;
            recogEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private static void RecogEngine_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence <= minConfidence) return;

            string[] parts = e.Result.Text.Split(new[] { ',' }, 2); // split into max 2 parts
            string command = parts.Length > 1 ? parts[1].Trim() : e.Result.Text;
            Debug.WriteLine(command);
            if (arnoldActions.Keywords.Contains(command))
            {
                Debug.WriteLine("God hates me");
                arnoldActions.OnCalled(e.Result.Text);
            }
            if (arnoldActions.muted) return;
            Debug.WriteLine(e.Result.Text + " " + e.Result.Confidence);

            if (actionPhraseDict.TryGetValue(e.Result.Text, out Action act))
            {
                act.OnCalled(e.Result.Text);
            }
        }
    }
}