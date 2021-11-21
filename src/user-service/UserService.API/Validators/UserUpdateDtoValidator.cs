using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using UserService.BL.Abstractions;
using UserService.BL.Models.User;

namespace UserService.API.Validators
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        private readonly IUserManager userManager;

        private const string UserWithSameNameCodeExistsMessage = "User with this username and code combination already exists";
        private const string UsercodeInvalidMessage = "Usercode should contain 4 digits";

        private const int MinUsernameLength = 4;
        private const int MaxUsernameLength = 16;

        private const int UsercodeLength = 4;

        public UserUpdateDtoValidator(IUserManager userManager)
        {
            this.userManager = userManager;

            RuleFor(u => u)
                .MustAsync(UserWithSameNameCodeDoesNotExist)
                .WithMessage(UserWithSameNameCodeExistsMessage);

            RuleFor(u => u.Username)
                .Length(MinUsernameLength, MaxUsernameLength);

            RuleFor(u => u.Usercode)
                .Length(UsercodeLength)
                .Must(uc => int.TryParse(uc, out _))
                .WithMessage(UsercodeInvalidMessage);
        }
        
        public async Task<bool> UserWithSameNameCodeDoesNotExist(UserUpdateDto userUpdateDto, CancellationToken token)
        {
            var existingUser = await userManager.GetUserByNameCodeAsync(userUpdateDto.Username, userUpdateDto.Usercode);
            return existingUser == null;
        }
    }
}