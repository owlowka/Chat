using Chat.ApplicationServices.API.Domain.Models;


using FluentValidation;

namespace Chat.ApplicationServices.API.Validators
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
