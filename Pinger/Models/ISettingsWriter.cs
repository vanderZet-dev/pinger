using System;
using System.Collections.Generic;
using System.Text;

namespace Pinger.Models
{
    public interface ISettingsWriter<T>
    {
        void WriteSettings(T obj, string path);
    }
}
