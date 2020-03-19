
namespace Pinger.Interfaces
{
    public interface IPingerAdressWithValidation : IPingerAddress
    {
        int GetValidStatusCode();
    }
}
