using MasterCompany.Business.Services;
using MasterCompany.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterCompany.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Criterio 4
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        // Criterio 5
        [HttpGet("without-duplicates")]
        public IActionResult GetAllWithoutDuplicates()
        {
            var employees = _employeeService.GetAllWithoutDuplicates();
            return Ok(employees);
        }

        // Criterio 3
        [HttpGet("by-salary-range")]
        public IActionResult GetBySalaryRange([FromQuery] decimal minSalary, [FromQuery] decimal maxSalary)
        {
            if (minSalary < 0 || maxSalary < 0)
                return BadRequest("Los rangos salariales no pueden ser negativos.");

            if (minSalary > maxSalary)
                return BadRequest("El salario mínimo no puede ser mayor al máximo.");

            var employees = _employeeService.GetBySalaryRange(minSalary, maxSalary);
            return Ok(employees);
        }

        // Criterio 6
        [HttpGet("salary-raises")]
        public IActionResult GetSalaryRaises()
        {
            var raises = _employeeService.GetSalaryRaises();
            return Ok(raises);
        }

        // Criterio 7
        [HttpGet("gender-percentages")]
        public IActionResult GetGenderPercentages()
        {
            var percentages = _employeeService.GetGenderPercentages();
            return Ok(percentages);
        }

        // Criterio 2
        // Criterio 2: Crear empleado
        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetAll), employee);
        }

        // Criterio 8
        [HttpDelete("{document}")]
        public IActionResult Delete(string document)
        {
            if (string.IsNullOrWhiteSpace(document))
                return BadRequest("El documento es requerido.");

            _employeeService.DeleteByDocument(document);
            return NoContent();
        }
    }
}