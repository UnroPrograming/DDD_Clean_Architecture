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

        public RangoFechas Duracion { get; private set; }

        public PrecioDetail PrecioAlquiler { get; private set; }

        public AlquilerStatus Status { get; private set; }

        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaConfirmacion { get; private set; }
        public DateTime? FechaDenegacion{ get; private set; }
        public DateTime? FechaCompletado { get; private set; }
        public DateTime? FechaCancelacion { get; private set; }

        public static Result<Alquiler> Reservar(Vehiculo vehiculo, Guid userId, RangoFechas duracion, DateTime fechaCreacion, PrecioService precioService)
        {
            var precioAlquiler = precioService.CalcularPrecio(vehiculo, duracion);

            var alquiler = new Alquiler(
                Guid.NewGuid(), 
                vehiculo.Id,
                userId, 
                duracion, 
                precioAlquiler,
                AlquilerStatus.Reservado,
                fechaCreacion);

            alquiler.AddDomainEvent(new AlquilerReservadoDomainEvent(alquiler.Id));

            vehiculo.FechaUltimoAlquiler  = fechaCreacion;

            // Equivale a Result.Create(alquiler): el operador implícito de Result<T>
            // convierte automáticamente Alquiler en Result<Alquiler>.
            return alquiler;
        }

        public Result Confirmar(DateTime fechaConfirmacion)
        {
            if (Status != AlquilerStatus.Reservado)
            {
                return Result.Failure(AlquilerErrors.NotReserved);
            }

            Status = AlquilerStatus.Confirmado;
            FechaConfirmacion = fechaConfirmacion;

            AddDomainEvent(new AlquilerConfirmadoDomainEvent(Id));
            return Result.Success();
        }

        public Result Rechazar(DateTime fechaRechazo)
        {
            if (Status != AlquilerStatus.Reservado)
            {
                return Result.Failure(AlquilerErrors.NotReserved);
            }

            Status = AlquilerStatus.Rechazado;
            FechaDenegacion = fechaRechazo;

            AddDomainEvent(new AlquilerRechazadoDomainEvent(Id));
            return Result.Success();
        }

        public Result Cancelar(DateTime fechaCancelacion)
        {
            if (Status != AlquilerStatus.Confirmado)
            {
                return Result.Failure(AlquilerErrors.NotConfirmed);
            }

            if (DateOnly.FromDateTime(fechaCancelacion) >= Duracion.FechaInicio)
            {
                return Result.Failure(AlquilerErrors.AlreadyStarted);
            }

            Status = AlquilerStatus.Cancelado;
            FechaCancelacion = fechaCancelacion;

            AddDomainEvent(new AlquilerCanceladoDomainEvent(Id));
            return Result.Success();
        }

        public Result Completado(DateTime fechaCompleteado)
        {
            if (Status != AlquilerStatus.Confirmado)
            {
                return Result.Failure(AlquilerErrors.NotConfirmed);
            }

            Status = AlquilerStatus.Completado;
            FechaCompletado = fechaCompleteado;

            AddDomainEvent(new AlquilerCompletadoDomainEvent(Id));
            return Result.Success();
        }
    }
}
