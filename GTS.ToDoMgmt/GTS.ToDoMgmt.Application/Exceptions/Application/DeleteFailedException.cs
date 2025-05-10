namespace GTS.ToDoMgmt.Application.Exceptions.Application
{
    public class DeleteFailedException : UseCaseException
    {
        public DeleteFailedException(Guid todoId, string reason,Exception innerException = null)
            : base($"Failed to delete Todo : {todoId}, Reason: {reason}.", innerException)
        {
        }
    }
}
