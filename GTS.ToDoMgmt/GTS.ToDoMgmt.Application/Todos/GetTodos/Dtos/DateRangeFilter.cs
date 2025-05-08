namespace GTS.ToDoMgmt.Application.Todos.GetTodos.Dtos
{
    public record DateRangeFilter
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
