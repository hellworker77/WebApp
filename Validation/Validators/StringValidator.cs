using FluentValidation;
using System.Text.RegularExpressions;

namespace Validation.Validators;

public class StringValidator : AbstractValidator<String>
{
    public StringValidator()
    {
        string pattern = "^[0-9]+$";
        RuleFor(x => x).NotEmpty();
        RuleFor(x => Regex.IsMatch(x, pattern)).Equal(true);
        RuleFor(x => x.StartsWith("0")).Equal(false);
    }
}