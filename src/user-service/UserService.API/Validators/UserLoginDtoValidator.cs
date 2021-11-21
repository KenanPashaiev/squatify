using FluentValidation;
using UserService.BL.Models.User;

namespace UserService.API.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        private const int MinPasswordLength = 6;
        private const int MaxPasswordLength = 24;

        public UserLoginDtoValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress();

            RuleFor(u => u.Password)
                .Length(MinPasswordLength, MaxPasswordLength);
        }
    }
}