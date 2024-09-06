namespace EmployeeRegistrationSystem.API.Domain.Entities
{
    public class EmployeeLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ActionType ActionType { get; set; }
        public string JSON { get; set; } = string.Empty;
        public string PartitionKey { get; set; } = string.Empty;
        public string RowKey { get; set; } = string.Empty;
        public DateTimeOffset? Timestamp { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
