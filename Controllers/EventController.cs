using Microsoft.AspNetCore.Mvc;
using velora.Models;
using velora.Services;

namespace velora.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController(IEventService _eventService): ControllerBase
    {
        
        [HttpGet]
        public ActionResult<List<Event>> Get()
        {
            var events = _eventService.GetEvents();
            return Ok(events);
        }
                
        [HttpGet("{id:int}")]
        public ActionResult<Event> Get(int id)
        {
            var _event = _eventService.GetEventById(id);
            if (_event is null)
                return NotFound();

            return Ok(_event); 
        }

        [HttpPost]
        public ActionResult<Event> Post([FromBody] Event newEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _eventService.AddEvent(newEvent);
            
            return Created($"/api/events/{result.Id}", result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Event> Put(int id, [FromBody] Event updatedEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _eventService.ChangeEvent(id, updatedEvent);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _eventService.RemoveEvent(id);
            if (result == false)
                return NotFound();

            return NoContent();
        }
        
    }
}
