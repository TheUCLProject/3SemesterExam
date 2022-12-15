using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnikOpstart.Services.KundeProjekter.Domain.Models;

namespace UnikOpstart.Services.KundeProjekter.Database.SqlContext.Configurations
{
    public class KundeTypeConfiguration : IEntityTypeConfiguration<KundeEntity>
    {
        public void Configure(EntityTypeBuilder<KundeEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasMany(x => x.Projekter)
                .WithOne(x => x.Kunde)
                .HasForeignKey(x => x.KundeId);

        }
    }
}