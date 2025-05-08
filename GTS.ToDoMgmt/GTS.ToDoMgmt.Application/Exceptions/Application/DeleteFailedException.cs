namespace GTS.ToDoMgmt.Application.Exceptions.Application
{
    public class DeleteFailedException : ApplicationException
    {
        public DeleteFailedException(Guid todoId, Exception innerException = null) 
            : base($"Todo {todoId} not found and cannot be deleted.", innerException)
        {
        }
    }
}
