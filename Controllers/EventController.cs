using Microsoft.AspNetCore.Mvc;
using velora.Models;
using velora.Services;

namespace velora.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventController(IEventService _eventService) : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<List<EventResponseDto>> Get()
        {
            var result = _eventService.GetEvents();
            return Ok(result);
        }
                
        [HttpGet("{id:int}")]
        public ActionResult<EventResponseDto> Get(int id)
        {
            var result = _eventService.GetEventById(id);
            if (result is null)
                return NotFound();

            return Ok(result); 
        }

        [HttpPost]
        public ActionResult<EventResponseDto> Post([FromBody] EventRequestDto newEvent)
        {
            var result = _eventService.AddEvent(newEvent);
            
            return Created($"/api/events/{result.Id}", result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<EventResponseDto> Put(int id, [FromBody] EventRequestDto updatedEvent)
        {

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