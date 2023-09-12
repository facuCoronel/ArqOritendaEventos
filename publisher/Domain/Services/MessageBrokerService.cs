using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class MessageBrokerService : IMessageBroker
    {
        public string? ProjectId { get; set; }
        public string? TopicId { get; set; }
        public Guid Key { get; set; }
        public MessageBrokerService(string? ProjectId, string? TopicId, Guid key)
        {
            this.ProjectId = ProjectId;
            this.TopicId = TopicId;
            Key = key;

        }


        public async Task<Message> BuildMessage(object entity)
        {
            if (this.ProjectId == null || this.TopicId == null)
                throw new Exception("the parameters are null");


            var base64 = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(entity));
            var message = new Message(base64, this.TopicId, this.ProjectId, this.Key);

            return message;

        }

    }
}
