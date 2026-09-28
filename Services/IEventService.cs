using velora.Models;

namespace velora.Services
{
    public interface IEventService
    {
        List<Event> GetEvents();
        Event? GetEventById(int Id);
        Event AddEvent(Event Event);
        Event? ChangeEvent(int Id, Event Event);
        bool RemoveEvent(int Id);
    }

}
