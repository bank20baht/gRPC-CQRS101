using FluentValidation;

public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("id cannot be empty");
    }
}