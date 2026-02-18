using System.ComponentModel.DataAnnotations;

namespace MasterCompany.Data.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El documento es requerido.")]
        public string Document { get; set; } = string.Empty;

        [Required(ErrorMessage = "El salario es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "El salario debe ser mayor a 0.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "El género es requerido.")]
        [RegularExpression("^(M|F)$", ErrorMessage = "El género debe ser 'M' o 'F'.")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "La posición es requerida.")]
        public string Position { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de inicio es requerida.")]
        public string StartDate { get; set; } = string.Empty;
    }
}