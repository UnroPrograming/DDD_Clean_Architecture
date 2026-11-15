using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Incidencias.Events
{
    public sealed record IncidenciaResueltaDomainEvent(Guid IncidenciaId) : IDomainEvent
    {
    }
}
