using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Incidencias.Events
{
    public sealed record IncidenciaEnReparacionDomainEvent(Guid IncidenciaId) : IDomainEvent
    {
    }
}
