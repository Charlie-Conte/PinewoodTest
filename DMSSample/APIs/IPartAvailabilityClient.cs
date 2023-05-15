namespace Pinewood.DMSSample.Business.APIs;

public interface IPartAvailabilityClient : IDisposable
{
    Task<int> GetAvailability(string stockCode);
}