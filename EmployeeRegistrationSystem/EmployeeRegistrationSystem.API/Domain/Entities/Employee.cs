namespace EmployeeRegistrationSystem.API.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ProfessionalEmail { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime AdmissionDate { get; set; } = DateTime.Now;
        public ICollection<EmployeeLog> Logs { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
    }
}
