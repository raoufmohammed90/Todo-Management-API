namespace GTS.ToDoMgmt.Application.Exceptions.Application
{
    internal class TodosNotFoundException : ApplicationException
    {
        public TodosNotFoundException(Exception innerException = null) 
            : base("No todos found. Please try to change the specified filters.", innerException)
        {
        }
    }
}
