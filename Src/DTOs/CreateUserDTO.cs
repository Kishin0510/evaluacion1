using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace evaluacion1.Src.DTOs
{
    public class CreateUserDTO
    {

        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}-\d{1}$", ErrorMessage = "El RUT debe tener el formato xx.xxx.xxx-x.")]
        public required string RUT { get; set; }
        
         [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public required string Name { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public required string Email { get; set; }

        [RegularExpression("^(masculino|femenino|otro|prefiero no decirlo)$", ErrorMessage = "El género debe ser 'masculino', 'femenino', 'otro' o 'prefiero no decirlo'.")]
        public required string Gender { get; set; }
        
        [DataType(DataType.Date)]
        [CustomValidation(typeof(CreateUserDTO), nameof(ValidateBirthDate))]
        public required DateTime Birthdate { get; set; }

        public static ValidationResult ValidateBirthDate(DateTime birthDate, ValidationContext context)
        {
            if (birthDate >= DateTime.Now)
            {
                return new ValidationResult("La fecha de nacimiento debe ser menor a la fecha actual.");
            }
            return ValidationResult.Success;
        }
    }
}