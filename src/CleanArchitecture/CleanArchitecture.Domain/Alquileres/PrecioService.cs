using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.Alquileres
{
    public class PrecioService
    {
        public PrecioDetail CalcularPrecio(Vehiculo vehiculo, RangoFechas rangoFechas)
        {
            TipoMoneda tipoMoneda = vehiculo.Precio!.Tipo;

            Moneda precioAlquiler = new (vehiculo.Precio.Cantidad * rangoFechas.DiasTotales, tipoMoneda);

            decimal porcentageChange = 0;

            foreach (var accesorio in vehiculo.Accesorios)
            {
                porcentageChange += accesorio switch
                {
                    Accesorio.AppleCar or Accesorio.AndroidCar => 0.05m,
                    Accesorio.AireAcondicionado => 0.01m,
                    Accesorio.Mapas => 0.01m,
                    _ => 0
                };
            }

            var precioAccesorios = Moneda.Zero(tipoMoneda);

            if (porcentageChange > 0)
            {
                precioAccesorios = new Moneda(precioAlquiler.Cantidad * porcentageChange, tipoMoneda);
            }

            return new PrecioDetail(precioAlquiler, vehiculo.Mantenimiento!, precioAccesorios);
        }
    }
}
