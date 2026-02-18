using MasterCompany.Data.Models;

namespace MasterCompany.Data.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        void Add(Employee employee);
        void DeleteByDocument(string document);
        void SaveAll(List<Employee> employees);
    }
}