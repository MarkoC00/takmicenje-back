using DataAccessLayer.Data.Config;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Takmicar> Takmicari { get; set; }

        public DbSet<Klub> Klub { get; set; }

        public DbSet<PrijavaTakmicara> PrijavaTakmicaras { get; set; }

        public DbSet<EkipnoKate> EkipnoKate { get; set; }

        public DbSet<PrijavaTakmicaraBorbe> PrijavaTakmicaraBorbes { get; set; }

        public DbSet<EkipnoBorbe> EkipnoBorbe { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new TakmicarEntityTypeConfiguration() );
            modelBuilder.ApplyConfiguration(new KlubEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PrijavaTakmicaraEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EkipnoKateEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PrijavaTakmicaraBorbeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EkipnoBorbeEntityTypeConfiguration() );
        }

    }
}
