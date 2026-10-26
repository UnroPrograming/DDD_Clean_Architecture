namespace CleanArchitecture.Domain.Abstractions
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }


        //TODO -> Incluir todos estos médos en una interfaz
        public IReadOnlyList<IDomainEvent> ReadOnlyDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
