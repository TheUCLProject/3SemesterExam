using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UnikOpstart.Services.MedarbejderKompetencer.Database.SqlContext.Configurations
{
    public class MedarbejderKompTypeConfiguration : IEntityTypeConfiguration<MedarbejderKompEntity>
    {
        public void Configure(EntityTypeBuilder<MedarbejderKompEntity> builder)
        {
            builder
                .HasKey(x => new { x.MedarbejderId, x.KompetenceId });
            builder
                .HasOne(x => x.Kompetence)
                .WithMany(x => x.Medarbejdere)
                .HasForeignKey(x => x.KompetenceId);
            builder
                .HasOne(x => x.Medarbejder)
                .WithMany(x => x.Kompetencer)
                .HasForeignKey(x => x.MedarbejderId);
        }
    }
}