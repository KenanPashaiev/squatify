using System;
using System.Collections.Generic;

namespace ExerciseVideoService.Core
{
    public class ExerciseVideo
    {
        public Guid Id { get; set; }
        public string Link { get; set; }
        public string ExternalLink { get; set; }
        public int FPS { get; set; }
        public TimeSpan Length { get; set; }
        public TimeSpan StartTime { get; set; }
        public List<ExercisePoint> ExercisePoints { get; set; }
    }
}
