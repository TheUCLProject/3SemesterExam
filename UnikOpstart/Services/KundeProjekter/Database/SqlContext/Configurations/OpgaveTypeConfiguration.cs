using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnikOpstart.Services.KundeProjekter.Domain.Models;

namespace UnikOpstart.Services.KundeProjekter.Database.SqlContext.Configurations
{
    public class OpgaveTypeConfiguration : IEntityTypeConfiguration<OpgaveEntity>
    {
        public void Configure(EntityTypeBuilder<OpgaveEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}