using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.SqlServer.Configuration
{
    public class EventCoreConfigration : IEntityTypeConfiguration<EventCore>
    {
        public void Configure(EntityTypeBuilder<EventCore> builder)
        {
            builder.ToTable("EventsCore");

            builder.HasKey(x => x.Key);
        }
    }
}
