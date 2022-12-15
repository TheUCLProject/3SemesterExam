using Microsoft.EntityFrameworkCore;
using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using UnikOpstart.Services.MedarbejderKompetencer.Database.SqlContext.Configurations;

namespace UnikOpstart.Services.MedarbejderKompetencer.Database.SqlContext;
public class MedarbejderKompetencerContext : DbContext
{
		public MedarbejderKompetencerContext(DbContextOptions<MedarbejderKompetencerContext> options) : base(options)
		{
		}

		public DbSet<MedarbejderEntity> MedarbejderEntities { get; set; }
		public DbSet<KompetenceEntity> KompetenceEntities { get; set; }
		public DbSet<MedarbejderKompEntity> MedarbejderKompetencer { get; set; }

		protected override void OnModelCreating (ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MedarbejderTypeConfiguration());
			builder.ApplyConfiguration(new KompetenceTypeConfiguration());
			builder.ApplyConfiguration(new MedarbejderKompTypeConfiguration());
        }
}