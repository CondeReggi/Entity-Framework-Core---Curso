using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Entidades
{
    public class Cine
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //[Precision( precision:9, scale: 2 )] => Una presicion de 9 digitos y 2 despues de la coma
        //public decimal Precio { get; set; }

        public Point Ubicacion { get; set; }

        //Propiedad de navegacion para relaciones 1 => 1 
        public CineOfertas CineOferta { get; set; }

        // Ventajas de usar HashSet , es mas eficiente dque ICollection, la desventaja de HashSet es que no ordena, en ese caso usar
        // ICollection o una List
        public HashSet<SalaDeCine> SalaDeCine { get; set; }

    }
}
