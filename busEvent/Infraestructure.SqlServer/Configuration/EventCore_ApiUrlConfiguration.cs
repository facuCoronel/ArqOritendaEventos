using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.SqlServer.Configuration
{
    internal class EventCore_ApiUrlConfiguration : IEntityTypeConfiguration<Event_ApiUrl>
    {
        public void Configure(EntityTypeBuilder<Event_ApiUrl> builder)
        {
            builder.ToTable("EventsCore_ApiUrl");

        }
    }
}
