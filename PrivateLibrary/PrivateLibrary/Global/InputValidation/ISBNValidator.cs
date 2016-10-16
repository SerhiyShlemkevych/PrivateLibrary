using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace EpamTask.PrivateLibrary.InputValidation
{
    public class ISBNValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Value cannot be empty.");
            var isnb = value.ToString();
            if (isnb.Count(x => x == '-') != 3)
                return new ValidationResult(false, "Invalid ISBN format");
            var isbn13 = new Regex(@"(?=.{17}$)97(?:8|9)([ -])\d{1,5}\1\d{1,7}\1\d{1,6}\1\d$");
            var isbn10 = new Regex(@"\b(?:ISBN(?:: ?| ))?((?:97[89])?\d{9}[\dx])\b");
            Match match13 = isbn13.Match(isnb);
            Match match10 = isbn10.Match(isnb.Replace("-", ""));
            if (!(match10.Success) && !(match13.Success))
                return new ValidationResult(false, "ISBN 10/13 required!");
            return ValidationResult.ValidResult;
        }
    }
}