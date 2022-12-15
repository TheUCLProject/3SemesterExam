using Microsoft.EntityFrameworkCore;
using UnikOpstart.Services.KundeProjekter.Domain.Models;
using UnikOpstart.Services.KundeProjekter.Database.SqlContext.Configurations;

namespace UnikOpstart.Services.KundeProjekter.Database.SqlContext
{
    public class KundeProjekterContext : DbContext
    {
        public KundeProjekterContext(DbContextOptions<KundeProjekterContext> options) : base(options)
        {
        }

        public DbSet<KundeEntity> Kunder { get; set; }
        public DbSet<OpgaveEntity> Opgaver { get; set; }
        public DbSet<ProjektEntity> Projekter { get; set; }
        public DbSet<ProjektOpgaveEntity> ProjektOpgaver { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new KundeTypeConfiguration());
            builder.ApplyConfiguration(new ProjektTypeConfiguration());
            builder.ApplyConfiguration(new OpgaveTypeConfiguration());
            builder.ApplyConfiguration(new ProjektOpgaveTypeConfiguration());
        }
    }
}