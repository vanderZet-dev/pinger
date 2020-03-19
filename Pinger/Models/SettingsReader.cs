using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Pinger.Interfaces;

namespace Pinger.Models
{
    public class SettingsReader: ISettingsReader<PingerSettings>
    {

        public PingerSettings ReadSettings(string path)
        {
            PingerSettings pingerSettings;
            try
            {
                using (StreamReader file = File.OpenText(path))
                {
                    pingerSettings = JsonConvert.DeserializeObject<PingerSettings>(file.ReadToEnd());
                }
            }
            catch (FileNotFoundException ex)
            {
                pingerSettings = new PingerSettings();
            }
            return pingerSettings;
        }
    }
}
