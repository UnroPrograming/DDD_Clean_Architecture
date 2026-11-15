using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Incidencias.Events;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.Incidencias
{
    public sealed class Incidencia : Entity
    {
        private Incidencia(Guid id, Guid vehiculoId, Guid alquilerId, Descripcion descripcion, Gravedad gravedad, PrecioDetail precioReparacion) : base(id)
        {
            VehiculoId = vehiculoId;
            AlquilerId = alquilerId;
            Descripcion = descripcion;
            Gravedad = gravedad;
            PrecioReparacion = precioReparacion;
            Estado = IncidenciaStatus.Create();
        }

        public Guid VehiculoId { get; private set; }
        public Guid AlquilerId { get; private set; }
        public Descripcion Descripcion { get; private set; }
        public Gravedad Gravedad { get; private set; }
        public PrecioDetail PrecioReparacion { get; private set; }
        public IncidenciaStatus Estado { get; private set; }

        public static Result<Incidencia> Crear(Vehiculo vehiculo, Alquiler alquiler, Descripcion descripcion, Gravedad gravedad, Moneda precioReparacion)
        {
            var precioDetail = PrecioIncidenciaService.CalcularPrecio(precioReparacion, gravedad, alquiler);

            var incidencia = new Incidencia(
                Guid.NewGuid(),
                vehiculo.Id,
                alquiler.Id,
                descripcion,
                gravedad,
                precioDetail
             );

            incidencia.AddDomainEvent(new IncidenciaCreadaDomainEvent(incidencia.Id));

            // Equivale a Result.Create(Incidencia): el operador implícito de Result<T>
            // convierte automáticamente Incidencia en Result<Incidencia>.
            return incidencia;
        }

        public Result CambiarEstado()
        {
            Estado.ChangeStatus();

            switch (Estado.ActiveStatus)
            {
                case Status.EnReparacion:
                    AddDomainEvent(new IncidenciaEnReparacionDomainEvent(Id));
                    break;
                case Status.Resuelta:
                    AddDomainEvent(new IncidenciaResueltaDomainEvent(Id));
                    break;
            }

            return Result.Success();
        }
    }
}
    