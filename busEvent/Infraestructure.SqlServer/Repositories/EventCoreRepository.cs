using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infraestructure.SqlServer.EventsDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.SqlServer.Repositories
{
    public class RedirectToRepository : BaseRepository<EventCore>, IRedirectToepository
    {
        public RedirectToRepository(EventDbContext db) : base(db) {}

    }
}
