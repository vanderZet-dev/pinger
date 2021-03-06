﻿using System.IO;
using System.Text.RegularExpressions;
using Pinger.Interfaces;

namespace Pinger.Services
{
    public class PingLogWriter : IPingLogWriter
    {
        public string SaveLog(IPingerLogSaveble pingerAddress)
        {
            string savedData = pingerAddress.GetSaveLogData();

            string directory = "PingerLogs";
            Directory.CreateDirectory(directory);
            string fileName = pingerAddress?.GetSaveLogName();

            Regex regex = new Regex(@"[.:]|/{1,2}");
            fileName = regex.Replace(fileName, "_");

            string savePath = directory + "/" + fileName + ".txt";
            using (StreamWriter w = File.AppendText(savePath))
            {
                w.WriteLine(savedData);
            }

            return savedData;
        }
    }
}
