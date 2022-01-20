namespace EFCorePeliculas.Entidades
{
    public class CineOfertas
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        public int CineId { get; set; }

    }
}
