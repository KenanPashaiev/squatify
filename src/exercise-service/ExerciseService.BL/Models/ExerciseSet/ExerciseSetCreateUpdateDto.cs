using System;
using ExerciseService.BL.Models.ExerciseType;

namespace ExerciseService.BL.Models.ExerciseSet
{
    public class ExerciseSetCreateUpdateDto
    {
        public double? Weight { get ; set; }
        public int? RepCount { get ; set; }
        public int? Order { get ; set; }
        public DateTime Date { get; set; }
        public Guid ExerciseTypeId { get ; set; }
        public Guid? TrackingVideoId { get; set; }
        public Guid UserId { get; set; }
    }
}