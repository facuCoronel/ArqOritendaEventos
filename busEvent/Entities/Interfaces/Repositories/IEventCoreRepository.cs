using Domain.Core.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IEventCoreRepository : IBaseRepository<EventCore>
    {
        bool SendMessage(Message message);
    }
}
