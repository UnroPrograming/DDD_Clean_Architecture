namespace CleanArchitecture.Domain.Alquileres
{
    public sealed record RangoFechas
    {
        private RangoFechas(DateOnly fechaInicio, DateOnly fechaFin)
        {
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

        public DateOnly FechaInicio { get; init; }
        public DateOnly FechaFin { get; init; }

        public int DiasTotales => FechaFin.DayNumber - FechaInicio.DayNumber;

        public static RangoFechas Create(DateOnly fechaInicio, DateOnly fechaFin)
        {
            if (fechaInicio >= fechaFin)
            {
                throw new ArgumentException("La fecha de inicio debe ser menor a la fecha de fin.");
            }
            return new RangoFechas(fechaInicio, fechaFin);
        }
    }
}
