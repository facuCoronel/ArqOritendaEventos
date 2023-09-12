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
        IRedirectTo _eventsCore;

        public EventController(IRedirectTo eventsCore)
        {
            _eventsCore = eventsCore;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(_eventsCore.redirecToSubscribe());
        }
    }
}
