using Domain.Entities;
using Infraestructure.SqlServer.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.SqlServer.EventsDbContext
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions options) : base(options)
        {
        }


        DbSet<EventCore> EventsCore { get; set; }
        DbSet<Event_ApiUrl> Event_ApiUrl { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventCoreConfigration());
            modelBuilder.ApplyConfiguration(new EventCore_ApiUrlConfiguration());
        }
    }
}
