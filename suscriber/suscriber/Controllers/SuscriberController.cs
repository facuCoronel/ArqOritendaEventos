using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace suscriber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuscriberController : ControllerBase
    {



        [HttpPost]
        public IActionResult DecodingMessage(Message message)
        {
            string jsonData = Encoding.UTF8.GetString(message.Data);
            var mail = JsonSerializer.Deserialize<Mail>(jsonData);

            return Ok(mail);
        }
    }
}
