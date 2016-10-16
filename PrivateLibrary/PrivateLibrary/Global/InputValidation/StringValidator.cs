using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace EpamTask.PrivateLibrary.InputValidation
{
    public class StringValidator : ValidationRule
    {
        public bool AllowStartWithNumber { get; set; } = false;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {            
            if (value == null)
                return new ValidationResult(false, "Required field");

            var str = value.ToString();

            if(string.IsNullOrEmpty(str))
                return new ValidationResult(false, "Required field");

            if (str.Trim().Length < 2 || str.All(char.IsDigit))
                return new ValidationResult(false, "Invalid value");

            if (!(AllowStartWithNumber) && (!char.IsDigit(str[0]) && !char.IsLetter(str[0])))
                return new ValidationResult(false, "Invalid first character!");
            else if(!char.IsLetter(str[0]) && !char.IsDigit(str[0]))
                return new ValidationResult(false, "Invalid first character!");

            return ValidationResult.ValidResult;
        }
    }
}