using MediatR;

namespace CleanArchitecture.Domain.Abstractions
{
    /// <summary>
    /// Interfaz que sirve para subscribir eventos de dominio a un manejador de eventos.
    /// De esta forma se puede desacoplar la lógica de negocio de la lógica de infraestructura.
    /// </summary>
    public interface IDomainEvent : INotification
    {

    }
}
