using System;

namespace ExerciseService.Core
{
    public class ExerciseSet
    {
        public Guid Id { get ; set; }
        public ExerciseType ExerciseType { get ; set; }
        public double? Weight { get ; set; }
        public int? RepCount { get ; set; }
        public int Order { get ; set; }
        public DateTime Date { get; set; }
        public Guid? TrackingVideoId { get; set; }
        public Guid UserId { get; set; }
    }
}
