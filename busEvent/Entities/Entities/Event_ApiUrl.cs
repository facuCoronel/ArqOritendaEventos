using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event_ApiUrl : Entity<Guid>
    {
        public string ApiUrl { get; set; }
        public Guid EventCoreId { get; set; }
        public virtual EventCore EventCore { get; set; }
    }
}
