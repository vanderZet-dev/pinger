using System;
using System.Collections.Generic;
using System.Text;

namespace Pinger.Interfaces
{
    public interface ISettingsReader<T>
    {
        T ReadSettings(string path);
    }
}
