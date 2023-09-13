using Domain.Core.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
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
    public class MessageBrokerService : DomainService, IMessageBroker
    {
        IMessageBrokerRepository _messageBrokerRepository;

        public MessageBrokerService(IMessageBrokerRepository messageBrokerRepository, IConfiguration configuration) : base(configuration)
        {
            _messageBrokerRepository = messageBrokerRepository;
        }


        public async Task<bool> BuildMessage(object entity)
        {
            if ( _projectId == null || _topicId == null)
                throw new Exception("the parameters are null");

            var base64 = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(entity));
            var message = new Message(base64, _topicId, _projectId, _key);

            var messages = new Queue<Message>();
            messages.Enqueue(message);
            var response = _messageBrokerRepository.SendMessage(messages.Dequeue());

            return response;

        }

    }
}
