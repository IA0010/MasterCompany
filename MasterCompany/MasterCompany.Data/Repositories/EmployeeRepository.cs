using System.Text.Json;
using MasterCompany.Data.Models;

namespace MasterCompany.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _filePath;

        public EmployeeRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Employee> GetAll()
        {
            if (!File.Exists(_filePath))
                return new List<Employee>();

            var json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Employee>();

            return JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
        }

        public void Add(Employee employee)
        {
            var employees = GetAll();
            employees.Add(employee);
            SaveAll(employees);
        }

        public void DeleteByDocument(string document)
        {
            var employees = GetAll();
            employees.RemoveAll(e => e.Document == document);
            SaveAll(employees);
        }

        public void SaveAll(List<Employee> employees)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(employees, options);
            File.WriteAllText(_filePath, json);
        }
    }
}