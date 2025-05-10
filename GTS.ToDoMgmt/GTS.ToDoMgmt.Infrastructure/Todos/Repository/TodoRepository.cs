using GTS.ToDoMgmt.Domain.Todos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GTS.ToDoMgmt.Infrastructure.Todos.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoManagementDbContext _todoManagementDbContext;

        public TodoRepository(TodoManagementDbContext todoManagementDbContext)
        {
            _todoManagementDbContext = todoManagementDbContext;
        }

        public void Create(Todo todo)
        {
            _todoManagementDbContext.Todos.Add(todo);
        }

        public bool Delete(Guid id)
        {
            var entity = _todoManagementDbContext.Todos.FirstOrDefault(e => e.Id == id);
            bool entityFound = entity != null;
            if (entityFound) 
                _todoManagementDbContext.Todos.Remove(entity!);
            return entityFound;
        }

        public async Task<IEnumerable<Todo>?> GetByFilterAsync(ICollection<Expression<Func<Todo, bool>>> filters, CancellationToken cancellationToken = default)
        {
            if(!filters.Any())
                return _todoManagementDbContext.Todos.ToList();

            var query = _todoManagementDbContext.Todos.Where(filters.First());

            foreach (var filter in filters.Skip(1))
            {
                query = query.Union(_todoManagementDbContext.Todos.Where(filter));
            }

            IEnumerable<Todo>? todos = await query.ToListAsync(cancellationToken);
            return todos;
        }

        public async Task<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
           return  await _todoManagementDbContext.Todos.FindAsync([id], cancellationToken);
        }
    }
}
