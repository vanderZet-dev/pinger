using Pinger.Models.Enums;

namespace Pinger.Interfaces
{
    public interface IPingerAddress : IPingerLogSaveble
    {
        dynamic GetEndPoint();

        void SetLastState(string state);
        string GetLastState();

        void SetMessage(string message);
        string GetMessage();

        int GetCheckInterval();

        string GetProtocol();
    }
}
