using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Pinger.Models
{
    public class SettingsBinaryReader : ISettingsReader<PingerSettings>
    {
        public PingerSettings ReadSettings(string path)
        {
            try
            {
                path = path + ".dat";
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    return (PingerSettings)formatter.Deserialize(fs);
                }
            }
            catch (SerializationException ex)
            {
                return new PingerSettings();
            }
            
        }
    }
}
