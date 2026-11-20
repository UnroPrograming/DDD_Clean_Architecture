using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Domain.Incidencias
{
    public interface IIncidenciaRepository
    {
        Task<Incidencia?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(Incidencia incidencia);
    }
}
