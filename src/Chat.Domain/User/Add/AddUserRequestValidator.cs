using FluentValidation;

namespace Chat.Domain.User.Add
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {

        public AddUserRequestValidator()
        {
            RuleFor(x => x.Name).InjectValidator()
                .MaximumLength(10)
                .WithMessage(" Oj zły zakres zły");
        }
    }
}
