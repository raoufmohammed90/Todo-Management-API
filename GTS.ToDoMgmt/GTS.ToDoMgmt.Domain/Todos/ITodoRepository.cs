namespace GTS.ToDoMgmt.Domain.Todos
{
    public interface ITodoRepository
    {
        Task<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Todo>?> GetByFilterAsync(ICollection<Func<Todo, bool>> filters, CancellationToken cancellationToken = default);
        public bool Delete(Guid id, CancellationToken cancellationToken = default);
        public Task CreateAsync(Todo todo, CancellationToken cancellationToken = default);
    }
}
