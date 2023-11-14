using Chat.ApplicationServices.API.Domain;

using FluentValidation;

namespace Chat.ApplicationServices.API.Validators
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(x => x.Name).Length(1, 30);
        }
    }
}
