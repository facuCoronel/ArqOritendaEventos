using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        IEventCoreService _eventsCore;

        public EventController(IEventCoreService eventsCore)
        {
            _eventsCore = eventsCore;
        }

        [HttpPost]
        public IActionResult SendEvents(Message message)
        {
            var validatorKey = _eventsCore.ValidatorKey(message.Key);
            if(validatorKey.Count > 0)
                return Ok(_eventsCore.SendEvent(message));
            else return BadRequest();
        }
    }
}
