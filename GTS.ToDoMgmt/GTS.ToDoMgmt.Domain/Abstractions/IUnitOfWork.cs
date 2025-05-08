namespace GTS.ToDoMgmt.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
