using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;
using OpenHardwareMonitor.Hardware;
namespace VoiceRecognition
{
    internal class TemperatureAction : Action
    {
        public override string[] Keywords
        {
            get
            {
                return new string[]{"temperature", "temp"};
            }
        }

        public override void OnCalled(string command)
        {
            base.OnCalled(command);

            double temp = 0;
            string instance = "";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");

            foreach(ManagementObject obj in searcher.Get())
            {
                temp = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                temp = (temp - 2732) / 10.0;

                instance = obj["InstanceName"].ToString();
            }



            Program.synth.SpeakAsync($"According to {instance} it is {temp} degrees");
        }
    }


}
