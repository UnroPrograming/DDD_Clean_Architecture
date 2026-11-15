using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Incidencias
{
    public sealed record PrecioDetail (Moneda PrecioReparacion, Moneda RecargoGravedad)
    {
        public Moneda PrecioTotal => PrecioReparacion + RecargoGravedad;
    }
}
