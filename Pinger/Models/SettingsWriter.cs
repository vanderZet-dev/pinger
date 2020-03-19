using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pinger.Models
{
    public class SettingsWriter : ISettingsWriter<PingerSettings>
    {
        public void WriteSettings(PingerSettings obj, string path)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                string serializedData = JsonConvert.SerializeObject(obj, Formatting.None);
                file.Write(serializedData);
            }
        }
    }
}
