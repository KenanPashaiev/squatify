using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using UserService.BL.Abstractions;
using UserService.BL.Models.User;

namespace UserService.API.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        private readonly IUserManager userManager;

        private const string UserWithSameEmailExistsMessage = "User with this email already exists";

        private const int MinPasswordLength = 6;
        private const int MaxPasswordLength = 24;

        private const int MinUsernameLength = 4;
        private const int MaxUsernameLength = 16;

        public UserRegisterDtoValidator(IUserManager userManager)
        {
            this.userManager = userManager;

            RuleFor(u => u.Email)
                .EmailAddress()
                .MustAsync(UserWithSameEmailDoesNotExist)
                .WithMessage(UserWithSameEmailExistsMessage);

            RuleFor(u => u.Password)
                .Length(MinPasswordLength, MaxPasswordLength);

            RuleFor(u => u.Username)
                .Length(MinUsernameLength, MaxUsernameLength);
        }
        
        public async Task<bool> UserWithSameEmailDoesNotExist(string email, CancellationToken token)
        {
            var existingUser = await userManager.GetUserByEmailAsync(email);
            return existingUser == null;
        }
    }
}