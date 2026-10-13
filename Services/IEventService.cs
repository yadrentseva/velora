using velora.Models;

namespace velora.Services
{
    public interface IEventService
    {
        PaginatedResult GetEvents(string? title, DateTime? from, DateTime? to, int page = 1, int pageSize = 10);
        EventResponseDto? GetEventById(int Id);
        EventResponseDto AddEvent(EventRequestDto Event);
        EventResponseDto? ChangeEvent(int Id, EventRequestDto Event);
        bool RemoveEvent(int Id);
    }

}