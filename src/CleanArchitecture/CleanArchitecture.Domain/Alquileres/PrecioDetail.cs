using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Alquileres
{
    public record PrecioDetail(Moneda PrecioAlquiler, Moneda PrecioMantenimiento, Moneda PrecioAccesorios)
    {
        public Moneda PrecioTotal => PrecioAlquiler + PrecioAccesorios + PrecioMantenimiento;
    }
}
