using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    //[Table("TablaNombre", Schema = "peliculas")]
    public class Genero
    {

        //Si queremos una PrimaryKey que tenga un nombre que no contenga Id , podemos utilizar un atributo
        //[Key] Con este nameSpace identificamos como PrimaryKey
        public int Id { get; set; }

        //Para configurar el limite de string 
        //[StringLength(150)] o [MaxLength(150)]
        //[Required] => El campo no puede ser nulo
        //[Column("NombreDeLaColumna")] Cambiar nombre de la columna en la base de datos diferente a Nombre
        public string Nombre { get; set; }
        public HashSet<Pelicula> Peliculas { get; set;}
    }
}
