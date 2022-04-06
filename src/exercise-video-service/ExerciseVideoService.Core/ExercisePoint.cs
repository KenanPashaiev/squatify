using System;

namespace ExerciseVideoService.Core
{
    public class ExercisePoint
    {
        public Guid Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? Rep { get; set; }
        public int? Rating { get; set; }
        public TimeSpan Time { get; set; }
        public Guid ExerciseVideoId { get; set; }
    }
}
