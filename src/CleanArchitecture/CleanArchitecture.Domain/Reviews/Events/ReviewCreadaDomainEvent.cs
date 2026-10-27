using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Reviews.Events
{
    public sealed record ReviewCreadaDomainEvent (Guid reviewId) : IDomainEvent
    {
    }
}
