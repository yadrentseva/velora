using velora.Models;

namespace velora.Services
{
    public interface IEventService
    {
        List<EventResponseDto> GetEvents();
        EventResponseDto? GetEventById(int Id);
        EventResponseDto AddEvent(EventRequestDTO Event);
        EventResponseDto? ChangeEvent(int Id, EventRequestDTO Event);
        bool RemoveEvent(int Id);
    }

}