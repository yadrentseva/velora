using velora.Models;

namespace velora.Services
{
    public interface IEventService
    {
        List<EventResponseDto> GetEvents();
        EventResponseDto? GetEventById(int Id);
        EventResponseDto AddEvent(EventRequestDto Event);
        EventResponseDto? ChangeEvent(int Id, EventRequestDto Event);
        bool RemoveEvent(int Id);
    }

}