using Domain.Entities;
using Domain.Interfaces;
using ExternalIntegration.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherEventsController : ControllerBase
    {
        private readonly IThirdParty _thirdParty;
        private readonly IMessageBroker _messageBroker;
        public PublisherEventsController(IThirdParty thirdParty, IMessageBroker messageBroker)
        {
            this._thirdParty = thirdParty;
            this._messageBroker = messageBroker;
        }


        [HttpPost]
        public async Task<IActionResult> SendEvent(EntityTest message)
        {
            try
            {
                var buildMessage = _messageBroker.BuildMessage(message);
                //var sendMessage = 

                return Ok(buildMessage);
                //_thirdParty.SendEvent(message);
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
