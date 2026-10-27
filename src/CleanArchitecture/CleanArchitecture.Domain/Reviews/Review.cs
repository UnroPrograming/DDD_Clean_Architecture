using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Reviews.Events;

namespace CleanArchitecture.Domain.Reviews
{
    public sealed class Review: Entity
    {
        private Review(Guid id, Guid alquilerId, Guid userId, Guid vehiculoId, Rating rating, Comentario? comentario, DateTime fechaCreacion) : base(id)
        {
            AlquilerId = alquilerId;
            UserId = userId;
            VehiculoId = vehiculoId;
            Rating = rating;
            Comentario = comentario;
            FechaCreacion = fechaCreacion;
        }

        public Guid AlquilerId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid VehiculoId { get; private set; }

        public Rating Rating { get; private set; }
        public Comentario? Comentario { get; private set; }
        public DateTime FechaCreacion { get; private set; }

        public static Result<Review> Crear(Alquiler alquiler, Rating rating, Comentario? comentario, DateTime fechaCreacion)
        {
            if (alquiler.Status != AlquilerStatus.Completado)
            {
                return Result.Failure<Review>(ReviewErrors.NotEligible);
            }

            var review = new Review(
                Guid.NewGuid(),
                alquiler.Id,
                alquiler.UserId,
                alquiler.VehiculoId,
                rating,
                comentario,
                fechaCreacion);

            review.AddDomainEvent(new ReviewCreadaDomainEvent(review.Id));

            return review;
        }
    }
}
