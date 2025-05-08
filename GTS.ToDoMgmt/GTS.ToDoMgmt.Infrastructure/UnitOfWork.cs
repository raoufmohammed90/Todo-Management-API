using GTS.ToDoMgmt.Domain.Abstractions;

namespace GTS.ToDoMgmt.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoManagementDbContext _todoManagementDbContext;

        public UnitOfWork(TodoManagementDbContext todoManagementDbContext)
        {
            _todoManagementDbContext = todoManagementDbContext;
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _todoManagementDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
