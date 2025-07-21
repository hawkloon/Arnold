using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceRecognition
{
    public abstract class Action
    {
        public Action()
        {
            OnLoad();
        }
        public virtual string[] Keywords { get;set; } = Array.Empty<string>();


        public virtual string[] Parameters { get; set; } = Array.Empty<string>();


        public string ParseCommand(string command)
        {
            foreach(var parameter in Parameters)
            {
                if (command.Contains(parameter.ToLower()))
                {
                    return parameter.ToLower();
                }
            }

            return null;
        }

        public virtual void OnLoad()
        {

        }
        public virtual void OnCalled(string command)
        {
            var parameters = ParseCommand(command);
        }
    }
}
