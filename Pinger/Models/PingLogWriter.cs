using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Pinger.Interfaces;

namespace Pinger.Models
{
    public class PingLogWriter : IPingLogWriter
    {
        public void SaveLog(IPingerLogSaveble pingerAddress)
        {
            string directory = "PingerLogs";
            Directory.CreateDirectory(directory);
            string fileName = pingerAddress?.GetSaveLogName();

            Regex regex = new Regex(@"[.:/]");
            fileName = regex.Replace(fileName, "_");

            string savePath = directory + "/" + fileName + ".txt";
            using (StreamWriter w = File.AppendText(savePath))
            {
                w.WriteLine(pingerAddress.GetSaveLogData());
            }
        }
    }
}
