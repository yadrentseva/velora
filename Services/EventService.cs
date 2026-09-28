using velora.Models;

namespace velora.Services
{
    public class EventService : IEventService
    {
        private List<Event> Events { get; set; }

        public EventService()
        {
            Events = [];
        }

        public List<Event> GetEvents()
        {
            return Events;
        }

        public Event? GetEventById(int id)
        {
            var _event = Events.Find(e => e.Id == id);
            return _event;
        }

        public Event AddEvent(Event newEvent)
        {
            var _event = new Event();
            _event.Id = (Events.Count == 0) ? 1 : Events.Max(e => e.Id) + 1;
            _event.UpdateFrom(newEvent); 
            
            Events.Add(_event);
            return _event;
        }

        public Event? ChangeEvent(int id, Event updatedEvent)
        {
            var _event = Events.Find(e => e.Id == id);
            _event?.UpdateFrom(updatedEvent);
            return _event;
        }    

        public bool RemoveEvent(int id)
        {
            var _event = GetEventById(id);
            if (_event is null)
                return false;
            
            Events.Remove(_event);
            return true; 
        }

    }

}
