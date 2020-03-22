namespace Pinger.Interfaces
{
    public interface IPingLogWriter
    {
        string SaveLog(IPingerLogSaveble pingerAddress);
    }
}