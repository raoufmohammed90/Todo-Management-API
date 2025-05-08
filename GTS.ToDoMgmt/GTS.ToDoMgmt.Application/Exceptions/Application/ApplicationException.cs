namespace GTS.ToDoMgmt.Application.Exceptions.Application
{
    public abstract class ApplicationException : Exception
    {
        public ApplicationException(string message, Exception innerException = null)
            : base(message, innerException)
        {
            
        }
    }
}
