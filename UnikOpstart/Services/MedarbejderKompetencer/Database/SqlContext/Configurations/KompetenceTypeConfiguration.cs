using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UnikOpstart.Services.MedarbejderKompetencer.Database.SqlContext.Configurations
{
    public class KompetenceTypeConfiguration : IEntityTypeConfiguration<KompetenceEntity>
    {
        public void Configure(EntityTypeBuilder<KompetenceEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}