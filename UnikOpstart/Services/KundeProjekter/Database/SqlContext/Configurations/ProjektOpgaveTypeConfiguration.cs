using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnikOpstart.Services.KundeProjekter.Domain.Models;

namespace UnikOpstart.Services.KundeProjekter.Database.SqlContext.Configurations
{
    public class ProjektOpgaveTypeConfiguration : IEntityTypeConfiguration<ProjektOpgaveEntity>
    {
        public void Configure(EntityTypeBuilder<ProjektOpgaveEntity> builder)
        {
            builder
                .HasKey(x => new {x.ProjektId, x.OpgaveId });
            builder.HasOne(po => po.Projekt)
                .WithMany(po => po.Opgaver)
                .HasForeignKey(po => po.ProjektId);
            builder.HasOne(po => po.Opgave)
                .WithMany(po => po.Projekter)
                .HasForeignKey(po => po.OpgaveId);
        }
    }
}