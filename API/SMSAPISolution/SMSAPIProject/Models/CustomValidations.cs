using System.ComponentModel.DataAnnotations;

namespace SMSAPIProject.Models
{
    // Custom Validation for RequestType
    public class RequestTypeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("RequestType is required.");
            }

            var requestType = value.ToString();
            if (requestType != "Save" && requestType != "Update")
            {
                return new ValidationResult("RequestType must be either 'Save' or 'Update'.");
            }

            return ValidationResult.Success!;
        }
    }

    // Custom Validation for Session
    public class SessionValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Session is required.");
            }

            var session = value.ToString();
            if (session == null || session.Length != 9 || !session.Contains("-"))
            {
                return new ValidationResult("Session must be in the format 'YYYY-YYYY'");
            }

            var years = session.Split('-');
            if (years.Length != 2 || !int.TryParse(years[0], out int startYear) || !int.TryParse(years[1], out int endYear))
            {
                return new ValidationResult("Session must be in the format 'YYYY-YYYY'.");
            }

            if (endYear != startYear + 1)
            {
                return new ValidationResult("The second year must be exactly one year after the first year.");
            }

            return ValidationResult.Success!;
        }
    }
}
