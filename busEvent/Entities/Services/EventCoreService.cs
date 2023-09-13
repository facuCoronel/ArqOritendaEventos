using Domain.Core.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class EventCoreService : DomainService, IEventCoreService
    {
        private readonly IEventCoreRepository _EventsCoreRepository;


        public EventCoreService(IEventCoreRepository EventsCoreRepository)
        {
            _EventsCoreRepository = EventsCoreRepository;
        }
        public List<EventCore> ValidatorKey(Guid key)
        {
            var result = _EventsCoreRepository.DoFilter<EventCore>( bdKey => bdKey.Key == key).ToList();
            return result;
        }

        public bool SendEvent(Message message)
        {
            _EventsCoreRepository.SendMessage(message);
            return true;
        }


    }
}
