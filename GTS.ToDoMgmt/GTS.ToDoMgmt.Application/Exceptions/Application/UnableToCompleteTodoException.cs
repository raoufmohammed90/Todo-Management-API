namespace GTS.ToDoMgmt.Application.Exceptions.Application
{
    public class UnableToCompleteTodoException : ApplicationException
    {
        public UnableToCompleteTodoException(string reason, Exception innerException = null)
            : base($"Unable to complete todo because {reason}.", innerException)
        {
        }
    }
}
