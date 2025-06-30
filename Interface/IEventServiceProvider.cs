using Bean;

namespace Service
{
    public interface IEventServiceProvider
    {
        Event CreateEvent();
        Event[] GetEventDetails();
        int GetAvailableNoOfTickets(string eventName);
    }
}
