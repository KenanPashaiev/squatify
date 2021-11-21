using System;

namespace ExerciseService.BL.Models.ExerciseType
{
    public class ExerciseTypeCreateUpdateDto
    {
        public string Name { get ; set; }
        public bool IsActive = true;
    }
}