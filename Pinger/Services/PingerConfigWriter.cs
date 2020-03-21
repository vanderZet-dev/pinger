using System.IO;
using System.Text;
using Newtonsoft.Json;
using Pinger.Exceptions;
using Pinger.Interfaces;

namespace Pinger.Services
{
    public class PingerConfigWriter : IPingerConfigWriter
    {
        public void Write(string filePath)
        {
            if (File.Exists(filePath))
            {
                throw new PingerConfigFileAlreadyExistsException();
            }

            using (StreamWriter file = File.CreateText(filePath))
            using (JsonTextWriter writer = new JsonTextWriter(file))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartArray();

                writer.WriteStartObject();
                writer.WritePropertyName("baseAddress");
                writer.WriteValue("127.0.0.1");
                writer.WritePropertyName("myProtocolType");
                writer.WriteValue("Tcp");
                writer.WritePropertyName("checkInterval");
                writer.WriteValue("10");
                writer.WritePropertyName("port");
                writer.WriteValue("9200");
                writer.WriteEndObject();

                writer.WriteStartObject();
                writer.WritePropertyName("baseAddress");
                writer.WriteValue("ya.ru");
                writer.WritePropertyName("myProtocolType");
                writer.WriteValue("Http");
                writer.WritePropertyName("checkInterval");
                writer.WriteValue("15");
                writer.WritePropertyName("prefix");
                writer.WriteValue("http");
                writer.WritePropertyName("validStatusCode");
                writer.WriteValue("200");
                writer.WriteEndObject();

                writer.WriteEndArray();
            }
        }
    }
}
