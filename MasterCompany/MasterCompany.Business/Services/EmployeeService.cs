using MasterCompany.Business.DTOs;
using MasterCompany.Data.Models;
using MasterCompany.Data.Repositories;

namespace MasterCompany.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        // Criterio 4: Leer todos los empleados
        public List<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        // Criterio 5: Leer todos sin duplicados
        public List<Employee> GetAllWithoutDuplicates()
        {
            return _repository.GetAll()
                .GroupBy(e => e.Document)
                .Select(g => g.First())
                .ToList();
        }

        // Criterio 3: Leer por rango salarial
        public List<Employee> GetBySalaryRange(decimal minSalary, decimal maxSalary)
        {
            return _repository.GetAll()
                .Where(e => e.Salary >= minSalary && e.Salary <= maxSalary)
                .ToList();
        }


        // Criterio 6: Mostrar aumentos 
        public List<EmployeeSalaryRaiseDto> GetSalaryRaises()
        {
            var employees = _repository.GetAll()
                .GroupBy(e => e.Document)
                .Select(g => g.First())
                .ToList();

            return employees.Select(e =>
            {
                decimal percentage = e.Salary > 100000 ? 0.25m : 0.30m;
                decimal newSalary = e.Salary + (e.Salary * percentage);

                return new EmployeeSalaryRaiseDto
                {
                    Name = e.Name,
                    LastName = e.LastName,
                    Document = e.Document,
                    Position = e.Position,
                    CurrentSalary = e.Salary,
                    NewSalary = newSalary,
                    RaisePercentage = $"{percentage * 100}%"
                };
            }).ToList();
        }

        // Criterio 7: Porcentaje por género
        public List<GenderPercentageDto> GetGenderPercentages()
        {
            var employees = _repository.GetAll()
                .GroupBy(e => e.Document)
                .Select(g => g.First())
                .ToList();

            int total = employees.Count;

            return employees
                .GroupBy(e => e.Gender)
                .Select(g => new GenderPercentageDto
                {
                    Gender = g.Key == "M" ? "Masculino" : "Femenino",
                    Count = g.Count(),
                    Percentage = $"{Math.Round((double)g.Count() / total * 100, 2)}%"
                }).ToList();
        }

        // Criterio 2: Crear empleado
        public void AddEmployee(Employee employee)
        {
            _repository.Add(employee);
        }

        // Criterio 8: Borrar por cédula
        public void DeleteByDocument(string document)
        {
            _repository.DeleteByDocument(document);
        }
    }
}