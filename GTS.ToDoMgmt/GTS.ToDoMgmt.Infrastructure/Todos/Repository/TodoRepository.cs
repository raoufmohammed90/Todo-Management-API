using GTS.ToDoMgmt.Domain.Todos;
using Microsoft.EntityFrameworkCore;

namespace GTS.ToDoMgmt.Infrastructure.Todos.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoManagementDbContext _todoManagementDbContext;

        public TodoRepository(TodoManagementDbContext todoManagementDbContext)
        {
            _todoManagementDbContext = todoManagementDbContext;
        }

        public async Task CreateAsync(Todo todo, CancellationToken cancellationToken = default)
        {
            await _todoManagementDbContext.Todos.AddAsync(todo);
        }

        public bool Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = _todoManagementDbContext.Todos.FirstOrDefault(e => e.Id == id);
            bool entityFound = entity != null;
            if (entityFound) 
                _todoManagementDbContext.Todos.Remove(entity!);
            return entityFound;
        }

        public async Task<IEnumerable<Todo>?> GetByFilterAsync(ICollection<Func<Todo, bool>> filters, CancellationToken cancellationToken = default)
        {
            var query = _todoManagementDbContext.Todos.AsQueryable();
            foreach (var filter in filters)
            {
                query.Union(_todoManagementDbContext.Todos.Where(filter));
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
