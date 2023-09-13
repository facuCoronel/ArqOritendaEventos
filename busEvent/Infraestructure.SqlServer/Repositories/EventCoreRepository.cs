using Domain.Entities;
using Domain.Interfaces.Repositories;
using ExternalIntegration.Interfaces;
using Infraestructure.SqlServer.EventsDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.SqlServer.Repositories
{
    public class EventCoreRepository : BaseRepository<EventCore>, IEventCoreRepository
    {
        IThirdPartyService _thirdPartyService;
        public EventCoreRepository(EventDbContext db, IThirdPartyService thirdPartyService) : base(db) {
        
            _thirdPartyService = thirdPartyService;
        }


        public bool SendMessage(Message message){
            _thirdPartyService.SendEvent(message);
            return true;
        }
    }
}
