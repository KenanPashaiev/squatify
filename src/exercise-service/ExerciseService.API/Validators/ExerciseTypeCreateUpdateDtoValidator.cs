using System.Threading;
using System.Threading.Tasks;
using ExerciseService.BL.Managers;
using ExerciseService.BL.Models.ExerciseType;
using FluentValidation;

namespace ExerciseService.API.Validators
{
    public class ExerciseTypeCreateUpdateDtoValidator : AbstractValidator<ExerciseTypeCreateUpdateDto>
    {
        public readonly IExerciseTypeManager exerciseTypeManager;

        private const string ExerciseWithSameNameExistsMessage = "Exercise with this name already exists";

        private const int MinWeight = 0;
        private const int MaxWeight = 2000;

        private const int MinRep = 0;
        private const int MaxRep = 1000;

        public ExerciseTypeCreateUpdateDtoValidator(IExerciseTypeManager exerciseTypeManager)
        {
            this.exerciseTypeManager = exerciseTypeManager;

            RuleFor(e => e.Name)
                .NotEmpty()
                .MustAsync(ExerciseWithSameNameDoesNotExist)
                .WithMessage(ExerciseWithSameNameExistsMessage);
        }
        
        public async Task<bool> ExerciseWithSameNameDoesNotExist(string name, CancellationToken token)
        {
            var existingExerciseType = await exerciseTypeManager.GetExerciseTypeByNameAsync(name);
            return existingExerciseType == null;
        }
    }
}