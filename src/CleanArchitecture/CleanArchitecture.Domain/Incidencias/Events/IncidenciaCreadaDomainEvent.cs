using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Incidencias.Events
{
    public sealed record IncidenciaCreadaDomainEvent(Guid IncidenciaId) : IDomainEvent
    {
    }
}
