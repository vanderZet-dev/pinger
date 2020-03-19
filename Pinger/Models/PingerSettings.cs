using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pinger.Models
{
    [Serializable]
    public class PingerSettings
    {
        [NonSerialized]
        private string SettingsFilePath = "pinger";

        public List<IPingerAddress> Addresses { get; set; }
        public int Interval { get; set; }

        [NonSerialized]
        private ISettingsReader<PingerSettings> _settingsReader = new SettingsBinaryReader();
        [NonSerialized]
        private ISettingsWriter<PingerSettings> _settingsWriter = new SettingsBinaryWriter();

        public void LoadSettings()
        {
            var readData = _settingsReader.ReadSettings(SettingsFilePath);
            if (readData.Addresses is null)
            {
                readData.Addresses = new List<IPingerAddress>()
                {
                    new AddressHTTP("ya.ru", "https"),
                    new AddressHTTP("ya.ru", "http"),
                    new AddressICMP("google.com"),
                    new AddressICMP("makler.md"),
                    new AddressICMP("makler12345.com"),
                    new AddressTCP("127.0.0.1", "9200"),
                    new AddressTCP("127.0.0.2", "9205")
                };

                Addresses = readData.Addresses;
                Interval = 10;
                SaveSettings();
            }
            else
            {
                Addresses = readData.Addresses;
                Interval = readData.Interval;
            }
        }

        public void SaveSettings()
        {
            _settingsWriter.WriteSettings(this, SettingsFilePath);
        }
    }
   
}
