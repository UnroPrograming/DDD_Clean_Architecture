using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres.Events;
using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.Alquileres
{
    public sealed class Alquiler : Entity
    {
        private Alquiler(Guid id, Guid vehiculoId, Guid userId, RangoFechas duracion, PrecioDetail precioAlquiler, AlquilerStatus status, DateTime fechaCreacion) : base(id)
        {
            VehiculoId = vehiculoId;
            UserId = userId;
            Duracion = duracion;
            PrecioAlquiler = precioAlquiler;
            Status = status;
            FechaCreacion = fechaCreacion;
  
        }

        public Guid VehiculoId { get; private set; }
        public Guid UserId { get; private set; }

        public RangoFechas Duracion { get; init; }

        public PrecioDetail PrecioAlquiler { get; init; }

        public AlquilerStatus Status { get; private set; }

        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaConfirmacion { get; private set; }
        public DateTime? FechaDenegacion{ get; private set; }
        public DateTime? FechaCompletado { get; private set; }
        public DateTime? FechaCancelacion { get; private set; }

        public static Alquiler Reservar(Guid vehiculoId, Guid userId, RangoFechas duracion, DateTime fechaCreacion, PrecioDetail precioAlquiler)
        {
            var alquiler = new Alquiler(
                Guid.NewGuid(), 
                vehiculoId, 
                userId, 
                duracion, 
                precioAlquiler,
                AlquilerStatus.Reservado,
                fechaCreacion);

            alquiler.AddDomainEvent(new AlquilerReservadoDomainEvent(alquiler.Id));

            return alquiler;
        }
    }
}
