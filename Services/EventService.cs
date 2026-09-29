using AutoMapper;
using velora.Models;

namespace velora.Services
{
    public class EventService(IMapper mapper) : IEventService
    {
        private List<Event> Events { get; set; } = [];

        public List<EventResponseDto> GetEvents()
        {
            var eventsDto = new List<EventResponseDto>();
            foreach (Event _event in Events)
            {
                eventsDto.Add(mapper.Map<EventResponseDto>(_event));
            }
            return eventsDto;
        }

        public EventResponseDto? GetEventById(int id)
        {
            var _event = Events.Find(e => e.Id == id);
            var eventDto = mapper.Map<EventResponseDto>(_event);
            return eventDto;
        }

        public EventResponseDto AddEvent(EventRequestDTO newEvent)
        {
            var _event = mapper.Map<Event>(newEvent);
            _event.Id = (Events.Count == 0) ? 1 : Events.Max(e => e.Id) + 1; 
            Events.Add(_event);

            var eventDto = mapper.Map<EventResponseDto>(_event);
            return eventDto;
        }

        public EventResponseDto? ChangeEvent(int id, EventRequestDTO updatedEvent)
        {
            var _event = Events.Find(e => e.Id == id);
            if (_event == null)
                return null;

            mapper.Map<EventRequestDTO, Event>(updatedEvent, _event);

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
