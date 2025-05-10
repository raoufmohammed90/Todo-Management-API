namespace GTS.ToDoMgmt.Application.Exceptions.Application
{
    public class UpdateFailedException : UseCaseException
    {
        public UpdateFailedException(Guid todoId, string reason, Exception innerException = null)
            : base($"Failed to update Todo : {todoId}, Reason: {reason}.", innerException)
        {
        }
    }
}
