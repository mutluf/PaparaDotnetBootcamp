using FluentValidation;

public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
{
    public EmployeeCreateDtoValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(20).WithMessage("Name must not exceed 50 characters.");

        RuleFor(e => e.Surname)
            .NotEmpty().WithMessage("Surname is required.")
            .MaximumLength(20).WithMessage("Surname must not exceed 50 characters.");

        RuleFor(e => e.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(e => e.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Phone number must contain only digits and can include a leading '+'.");

        RuleFor(e => e.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth is required.")
            .LessThan(DateTime.Today).WithMessage("Date of birth must be in the past.")
            .LessThan(DateTime.Today.AddYears(-18)).WithMessage("You must be at least 18 years old.");

        RuleFor(e => e.Gender.ToString())
            .NotEmpty().WithMessage("Gender is required.")
            .Must(gender => gender.ToString() == Gender.Male.ToString() || gender.ToString() == Gender.Female.ToString())
            .WithMessage("Gender must be 'Male' or 'Female'");

        RuleFor(e => e.NationalId.ToString())
            .NotEmpty().WithMessage("National ID is required.")
            .Matches(@"^[1-9]\d{10}$").WithMessage("National ID must be exactly 11 digits and cannot start with 0.");

        RuleFor(e => e.Department)
            .NotEmpty().WithMessage("Department is required.")
            .MaximumLength(100).WithMessage("Department name must not exceed 100 characters.");

        RuleFor(e => e.Salary)
            .GreaterThanOrEqualTo(0).WithMessage("Salary must be a non-negative value.");

        RuleFor(e => e.Address)
            .Length(5, 100).WithMessage("Address must be between 5 and 100 characters.");
    }
}
