using System.Globalization;
using System.Windows.Controls;

namespace EpamTask.PrivateLibrary.InputValidation
{
    public class IntegerValidator : ValidationRule
    {
        public bool PositiveOnly { get; set; } = false;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == string.Empty)
                return new ValidationResult(false, "Value cannot be empty.");
            int integer;
            if (!int.TryParse(value.ToString(), out integer))
                return new ValidationResult(false, "Must be a number");
            if (PositiveOnly && integer <= 0)
                return new ValidationResult(false, "Must be a positive nomuber");
            return ValidationResult.ValidResult;
        }
    }
}