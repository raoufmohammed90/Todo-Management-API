namespace GTS.ToDoMgmt.Application.Exceptions.Application
{
    public abstract class UseCaseException : Exception
    {
        public UseCaseException(string message, Exception innerException = null)
            : base(message, innerException)
        {
            
        }
    }
}
