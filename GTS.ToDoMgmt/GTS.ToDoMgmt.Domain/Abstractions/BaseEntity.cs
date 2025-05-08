namespace GTS.ToDoMgmt.Domain.Abstractions
{
    public abstract class BaseEntity
    {
        private readonly ICollection<IDomainEvent> _domainEvents;

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
