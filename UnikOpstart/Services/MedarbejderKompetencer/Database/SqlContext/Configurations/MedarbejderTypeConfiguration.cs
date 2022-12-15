using UnikOpstart.Services.MedarbejderKompetencer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UnikOpstart.Services.MedarbejderKompetencer.Database.SqlContext.Configurations
{
    public class MedarbejderTypeConfiguration : IEntityTypeConfiguration<MedarbejderEntity>
    {
        public void Configure(EntityTypeBuilder<MedarbejderEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}