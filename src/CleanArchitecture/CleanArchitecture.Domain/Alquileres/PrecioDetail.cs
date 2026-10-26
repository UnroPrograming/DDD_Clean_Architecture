using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.Alquileres
{
    public record PrecioDetail(Moneda PrecioAlquiler, Moneda PrecioMantenimiento, Moneda PrecioAccesorios)
    {
        public Moneda PrecioTotal => PrecioAlquiler + PrecioMantenimiento + (PrecioAccesorios.IsZero() ? Moneda.Zero(PrecioAlquiler.Tipo) : PrecioAccesorios);
    }
}
