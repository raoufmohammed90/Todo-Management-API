using System.Linq.Expressions;

namespace GTS.ToDoMgmt.Domain.Todos
{
    public interface ITodoRepository
    {
        Task<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Todo>?> GetByFilterAsync(ICollection<Expression<Func<Todo, bool>>> filters, CancellationToken cancellationToken = default);
        public bool Delete(Guid id);
        public void Create(Todo todo);
    }
}
