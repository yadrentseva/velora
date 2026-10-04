using AutoMapper;
using velora.Models;

namespace velora.Services
{
    public class EventService(IMapper mapper) : IEventService
    {
        private List<Event> Events { get; set; } = [];
        private int counterId = 0;

        public List<EventResponseDto> GetEvents()
        {
            var eventsDto = Events.Select(mapper.Map<EventResponseDto>).OrderBy(e => e.StartAt).ToList(); 
            return eventsDto;
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
