
using FluentValidation;

public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
{
    public AddCustomerCommandValidator()
    {
        RuleFor(x => x.Body.FirstName).NotEmpty().WithMessage("first_name cannot be empty");
        RuleFor(x => x.Body.LastName).NotEmpty().WithMessage("last_name cannot be empty");
        RuleFor(x => x.Body.Address).NotEmpty().WithMessage("address cannot be empty");
        RuleFor(x => x.Body.MobileNumber).NotEmpty().WithMessage("mobile_number cannot be empty");
    }
}
