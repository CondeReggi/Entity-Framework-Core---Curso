using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    public class Actor
    {
        public int Id { get; set; } 
        public string Nombre  { get; set; } 
        public string Biografia { get; set; }   

        //[Column(TypeName = "Date")] => El signo de interrogacion marca que puede ser Nulleable
        public DateTime? FechaNacimiento { get; set; }

        public HashSet<PeliculaActor> PeliculasActores { get; set; }
    }
}
