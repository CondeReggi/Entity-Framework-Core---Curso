using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class SalaDeCineConfig : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
            builder.Property(e => e.Precio)
                .HasPrecision(9, 2);

            builder.Property(e => e.TipoSalaDeCine)
                //.HasDefaultValueSql("GETDATE()")
                .HasDefaultValue(TipoSalaDeCine.DosDimenciones);
        }
    }
}
