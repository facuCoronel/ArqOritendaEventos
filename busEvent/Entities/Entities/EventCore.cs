using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EventCore
    {
        public Guid Key { get; set; }
        public string ProjectId { get; set; }
        public string TopicId { get; set; }

    }
}
