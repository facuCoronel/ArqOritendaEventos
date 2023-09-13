using Domain.Entities;
using ExternalIntegration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExternalIntegration.Services
{
    public class ThirdPartyService : IThirdPartyService
    {
        private string apiUrl = "https://localhost:7263/api/Event";


        public async Task<bool> SendEvent(Message message)
        {
            
            try
            {
                HttpClient client = new HttpClient();
                var payloadMessage = JsonSerializer.Serialize(message);
                var content = new StringContent(payloadMessage, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(apiUrl, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
