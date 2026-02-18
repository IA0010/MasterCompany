using MasterCompany.Business.DTOs;
using MasterCompany.Data.Models;

namespace MasterCompany.Business.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        List<Employee> GetAllWithoutDuplicates();
        List<Employee> GetBySalaryRange(decimal minSalary, decimal maxSalary);
        List<EmployeeSalaryRaiseDto> GetSalaryRaises();
        List<GenderPercentageDto> GetGenderPercentages();
        void AddEmployee(Employee employee);
        void DeleteByDocument(string document);
    }
}