namespace Pinger.Interfaces
{
    public interface IPingLogWriter
    {
        void SaveLog(IPingerLogSaveble pingerAddress);
    }
}