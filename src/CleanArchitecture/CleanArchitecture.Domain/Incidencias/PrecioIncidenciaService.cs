using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Incidencias
{
    public class PrecioIncidenciaService
    {
        public static PrecioDetail CalcularPrecio(Moneda PrecioReparacion, Gravedad gravedad, Alquiler alquiler)
        {
            TipoMoneda tipoMoneda = alquiler.PrecioAlquiler.PrecioTotal.Tipo;

            Moneda incrementoGravedad = new Moneda(gravedad.Cantidad, tipoMoneda);

            return new PrecioDetail(PrecioReparacion, incrementoGravedad);
        }
    }
}
