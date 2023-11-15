using Chat.ApplicationServices.API.Domain;
using Chat.ApplicationServices.API.Domain;


using FluentValidation;
using FluentValidation.Validators;

namespace Chat.ApplicationServices.API.Validators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {

        public AddUserRequestValidator()
        {
            RuleFor(x => x.Name).InjectValidator().MaximumLength(10);
        }
    }
}
