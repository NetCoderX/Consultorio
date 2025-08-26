using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Persistence.Configuraciones;
public class ConsultoriosConfiguracion : IEntityTypeConfiguration<Domain.Entities.Consultorio>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Consultorio> builder)
    {
        builder.Property(n => n.Nombre)
            .HasMaxLength(150)
            .IsRequired();

    }
}
