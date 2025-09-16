using System.ComponentModel.DataAnnotations;

namespace ClarityAndSuccess.Infrastructure.Validators;

public class ValidateCustomerAge : ValidationAttribute
{
    private readonly int _min;
    private readonly int _max;

    // public AgeRangeAttribute(int min, int max)
    // {
    //     _min = min;
    //     _max = max;
    //     ErrorMessage = $"Age must be between {min} and {max} years.";
    // }

    public ValidateCustomerAge()
    {
        _min = 18;
        _max = 99;
        ErrorMessage = $"Age must be between {_min} and {_max} years.";
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        if (DateTime.TryParse(value.ToString(), out DateTime birthDate))
        {
            var age = (int)Math.Floor((DateTime.Now.Date - birthDate).TotalDays / 365.25);

            if (age < _min || age > _max)
            {
                return new ValidationResult(
                    $"{validationContext.DisplayName} results in an age of {age}, which is outside the allowed range ({_min}-{_max})."
                );
            }
        }

        return ValidationResult.Success;
    }
}
