using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace EpamTask.PrivateLibrary.InputValidation
{
    public class EmailValidator : ValidationRule
    {
        public override ValidationResult Validate (object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Value cannot be empty.");

            var regex = new Regex(@"[a-z0-9!#$%&'*+=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            Match match = regex.Match(value.ToString());
            return !(match.Success) ? new ValidationResult(false, "name@domainname.domain") : ValidationResult.ValidResult;
        }
    }
}