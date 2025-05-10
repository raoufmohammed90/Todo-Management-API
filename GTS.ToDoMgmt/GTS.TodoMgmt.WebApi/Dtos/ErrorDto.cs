namespace GTS.TodoMgmt.WebApi.Dtos
{
    public record ErrorDto
    {
        public Guid CorrelationId { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public Context[] Context { get; set; } = [];
        public DateTime Timestamp { get; set; }
    }

    public class Context
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
