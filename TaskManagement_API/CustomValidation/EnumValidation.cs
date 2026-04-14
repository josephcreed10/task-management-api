using System.ComponentModel.DataAnnotations;

namespace TaskManagement_API.CustomValidation
{
    public class EnumValidation: ValidationAttribute
    {
        private readonly Type _enumType;
        public EnumValidation(Type enumType)
        {
            _enumType = enumType;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            if (!Enum.IsDefined(_enumType, value))
            {
                var validValues = string.Join(", ", Enum.GetNames(_enumType));
                return new ValidationResult($"Invalid value. Allowed values are: {validValues}");
            }
            return ValidationResult.Success;
        }
    }
}
