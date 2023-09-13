using Domain.Entities;
using Domain.Interfaces.Repositories;
using ExternalIntegration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.SqlServer.Repositories
{
    public class MessageBrokerRepository : IMessageBrokerRepository
    {
        IThirdPartyService _thirdPartyService;

        public MessageBrokerRepository(IThirdPartyService thirdPartyService)
        {
            _thirdPartyService = thirdPartyService;
        }

        public bool SendMessage(Message message)
        {
            _thirdPartyService.SendEvent(message);
            return true;
        }
    }
}
