namespace EmployeeRegistrationSystem.API.Communication.Request
{
    public class EmployeeJson
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ProfessionalEmail { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTime AdmissionDate { get; set; } = DateTime.Now;
    }
}
