using CleanArchitecture.Domain.Vehiculos;

namespace CleanArchitecture.Domain.Alquileres
{
    public interface IAlquilerRepository
    {
        Task<Alquiler?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> IsOverlappongAsync(Vehiculo vehiculo, RangoFechas duracion, CancellationToken cancellationToken = default);

        void Add(Alquiler alquiler);
    }
}
