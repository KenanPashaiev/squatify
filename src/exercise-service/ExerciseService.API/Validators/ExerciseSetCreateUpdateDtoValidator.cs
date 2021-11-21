using System;
using System.Threading;
using System.Threading.Tasks;
using ExerciseService.BL.Managers;
using ExerciseService.BL.Models.ExerciseSet;
using FluentValidation;

namespace ExerciseService.API.Validators
{
    public class ExerciseSetCreateUpdateDtoValidator : AbstractValidator<ExerciseSetCreateUpdateDto>
    {
        private readonly IExerciseTypeManager exerciseTypeManager;

        private const string ExerciseTypeDoesNotExistMessage = "Exercise Type with this id does not exist";

        private const int MinWeight = 0;
        private const int MaxWeight = 2000;

        private const int MinRep = 0;
        private const int MaxRep = 1000;

        public ExerciseSetCreateUpdateDtoValidator(IExerciseTypeManager exerciseTypeManager)
        {
            this.exerciseTypeManager = exerciseTypeManager;

            RuleFor(e => e.ExerciseTypeId)
                .NotNull()
                .MustAsync(ExerciseTypeExists)
                .WithMessage(ExerciseTypeDoesNotExistMessage);

            RuleFor(e => e.Weight)
                .InclusiveBetween(MinWeight, MaxWeight)
                .When(e => e.Weight != null);

            RuleFor(e => e.RepCount)
                .ExclusiveBetween(MinRep, MaxRep)
                .When(e => e.Weight != null);

            RuleFor(e => e.Order)
                .GreaterThan(0)
                .When(e => e.Order != null);
        }

        public async Task<bool> ExerciseTypeExists(Guid exerciseTypeId, CancellationToken token)
        {
            var existingExerciseType = await exerciseTypeManager.GetExerciseTypeAsync(exerciseTypeId);
            return existingExerciseType != null;
        }
    }
}