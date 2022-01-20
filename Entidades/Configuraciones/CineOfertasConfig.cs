using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class CineOfertasConfig : IEntityTypeConfiguration<CineOfertas>
    {
        public void Configure(EntityTypeBuilder<CineOfertas> builder)
        {
            builder.Property(e => e.PorcentajeDescuento)
                .HasPrecision(precision: 5, scale: 2);
        }
    }
}
