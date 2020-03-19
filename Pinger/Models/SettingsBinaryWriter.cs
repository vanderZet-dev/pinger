using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Pinger.Models
{
    public class SettingsBinaryWriter : ISettingsWriter<PingerSettings>
    {
        public void WriteSettings(PingerSettings obj, string path)
        {
            path = path + ".dat";
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
    }
}
