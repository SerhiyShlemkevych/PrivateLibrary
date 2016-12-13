using System;
using System.Globalization;
using System.Windows.Controls;

namespace EpamTask.PrivateLibrary.InputValidation
{
    public class YearValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Review IP: there is a shortcut for this - string.IsNullOrEpty
            if (value == null || value.ToString() == string.Empty)
                return new ValidationResult(false, "Value cannot be empty.");

            int year;
            int.TryParse(value.ToString(),out year);
            if (year <= 0 || year > DateTime.Now.Year)
                return new ValidationResult(false, "Must be in range 1-" + DateTime.Now.Year);
            return ValidationResult.ValidResult;
        }
    }
}