using Pinger.Models.Enums;

namespace Pinger.Interfaces
{
    public interface IPingerAddress
    {
        dynamic GetEndPoint();

        void SetLastState(PingResultState state);
        string GetLastState();

        void SetMessage(string message);
        string GetMessage();

        int GetCheckInterval();

        string GetProtocol();
    }
}
