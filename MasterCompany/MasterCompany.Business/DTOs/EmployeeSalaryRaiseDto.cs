namespace MasterCompany.Business.DTOs
{
    public class EmployeeSalaryRaiseDto
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal CurrentSalary { get; set; }
        public decimal NewSalary { get; set; }
        public string RaisePercentage { get; set; } = string.Empty;
    }
}