using EFCorePeliculas.Entidades;
using EFCorePeliculas.Entidades.Configuraciones;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCorePeliculas
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)  
        {

        }

        protected override void ConfigureConventions( ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date"); //Con esto no es necesario hacer lo de abajo
        }

        //API FLUENTE Para poner como clavePrimaria un Atributo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Formas de añadir las Configuraciones a partir de las clases creadas son:

            //modelBuilder.ApplyConfiguration(new GeneroConfig()); =>Esto lo hace 1 x 1
            //Pero para hacerlo todas juntas

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            //modelBuilder.Entity<Genero>().HasKey(e => e.NombreDelAtributo);

            //modelBuilder.Entity<Genero>().Property(e => e.Nombre)
            //    .HasMaxLength(150)
            //    .IsRequired();
            //.HasColumnName("NombreGenero");


            //modelBuilder.Entity<Actor>().Property(e => e.Nombre)
            //    .HasMaxLength(150)
            //    .IsRequired();

            //modelBuilder.Entity<Actor>().Property(e => e.FechaNacimiento)
            //    .HasColumnType("date");

            //modelBuilder.Entity<Cine>().Property(e => e.Nombre)
            //    .HasMaxLength(150)
            //    .IsRequired();

            //modelBuilder.Entity<SalaDeCine>().Property(e => e.Precio)
            //    .HasPrecision(9, 2);

            //modelBuilder.Entity<SalaDeCine>().Property(e => e.TipoSalaDeCine)
            //    //.HasDefaultValueSql("GETDATE()")
            //    .HasDefaultValue(TipoSalaDeCine.DosDimenciones); // Envia el valor del ENUM como valor predeterminado

            //modelBuilder.Entity<Pelicula>().Property(e => e.Titulo)
            //    .HasMaxLength(150)
            //    .IsRequired();

            //modelBuilder.Entity<Pelicula>().Property(e => e.fechaEstreno)
            //    .HasColumnType("date");

            //modelBuilder.Entity<Pelicula>().Property(e => e.PosterUrl)
            //    .HasMaxLength(500)
            //    .IsUnicode(false); // Se refiere a los caracteres que vas a poner en este campo, podemos utiliar esto para amacenar la data

            //modelBuilder.Entity<CineOfertas>().Property(e => e.PorcentajeDescuento)
            //    .HasPrecision(precision: 5, scale: 2);

            //modelBuilder.Entity<CineOfertas>().Property(e => e.FechaInicio)
            //    .HasColumnType("date");

            //modelBuilder.Entity<CineOfertas>().Property(e => e.FechaFin)
            //    .HasColumnType("date");

            //modelBuilder.Entity<PeliculaActor>().HasKey(e => new { e.ActorId, e.PeliculaId });

            //modelBuilder.Entity<PeliculaActor>().Property(e => e.Personaje)
            //    .HasMaxLength(150);

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<CineOfertas> CineOfertas { get; set; }
        public DbSet<SalaDeCine> SalaDeCines { get; set; }
        public DbSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
