using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace EpamTask.PrivateLibrary.InputValidation
{
    public class PhoneValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Value cannot be empty.");

            var regex = new Regex(@"^\d{1,3}\-[(]\d{3}[)]\d{3}\-\d{4}$");
            Match match = regex.Match(value.ToString());
            return !(match.Success) ? new ValidationResult(false, "x-(xxx)xxx-xxxx") : ValidationResult.ValidResult;
        }
    }
}