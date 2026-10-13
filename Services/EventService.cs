using AutoMapper;
using velora.Models;

namespace velora.Services
{
    public class EventService(IMapper mapper) : IEventService
    {
        private List<Event> Events { get; set; } = [];
        private int counterId = 0;

        public PaginatedResult GetEvents(string? title, DateTime? from, DateTime? to, int page = 1, int pageSize = 10)
        {
            var filteredEvents = Events.AsEnumerable();

            if (!string.IsNullOrEmpty(title))
            {
                filteredEvents = filteredEvents.Where(e => e.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            }

            if (from.HasValue)
            {
                filteredEvents = filteredEvents.Where(e => e.StartAt >= from);
            }

            if (to.HasValue)
            {
                filteredEvents = filteredEvents.Where(e => e.EndAt <= to);
            }

            var eventsDto = filteredEvents.Select(mapper.Map<EventResponseDto>).OrderBy(e => e.StartAt).ToList();
            var paginatedEventsDto = eventsDto.Skip((page - 1) * pageSize).Take(pageSize).ToArray();

            return new PaginatedResult
            {
                TotalCount = Events.Count,
                CurrentPageNumber = page,
                PageCount = paginatedEventsDto.Length,
                Events = paginatedEventsDto
            };
        }

        public EventResponseDto? GetEventById(int id)
        {
            var _event = Events.Find(e => e.Id == id);
            if (_event == null)
                return null;

            var eventDto = mapper.Map<EventResponseDto>(_event);
            return eventDto;
        }

        public EventResponseDto AddEvent(EventRequestDto newEvent)
        {
            var _event = mapper.Map<Event>(newEvent);
            
            _event.Id = Interlocked.Increment(ref counterId);
            Events.Add(_event);

            var eventDto = mapper.Map<EventResponseDto>(_event);
            return eventDto;
        }

        public EventResponseDto? ChangeEvent(int id, EventRequestDto updatedEvent)
        {
            var _event = Events.Find(e => e.Id == id);
            if (_event == null)
                return null;

            mapper.Map<EventRequestDto, Event>(updatedEvent, _event);

            var _eventDto = mapper.Map<EventResponseDto>(_event);
            return _eventDto;
        }

        public bool RemoveEvent(int id)
        {
            var _event = Events.Find(e => e.Id == id);
            if (_event is null)
                return false;

            Events.Remove(_event);
            return true;
        }

    }

}
