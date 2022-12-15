using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnikOpstart.Services.KundeProjekter.Domain.Models;

namespace UnikOpstart.Services.KundeProjekter.Database.SqlContext.Configurations
{
    public class ProjektTypeConfiguration : IEntityTypeConfiguration<ProjektEntity>
    {
        public void Configure(EntityTypeBuilder<ProjektEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.Kunde)
                .WithMany(x => x.Projekter)
                .HasForeignKey(x => x.KundeId);
        }
    }
}