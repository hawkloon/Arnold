using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    public class ExtensionLoader
    {
        internal void LoadExtensions()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            foreach (var ass in Directory.GetFiles(folderPath, "*.dll"))
            {
                var assembly = Assembly.LoadFrom(ass);

                var extensionTypes = assembly.GetTypes()
                    .Where(t => typeof(Action).IsAssignableFrom(t) && !t.IsAbstract);

                foreach(var type in extensionTypes)
                {
                    var extensionInstance = (Action?)Activator.CreateInstance(type);
                    if (extensionInstance == null) continue;
                    Debug.WriteLine(extensionInstance?.ToString());
                    Program.actions.Add(extensionInstance);
                }
            }
        }
    }
}
