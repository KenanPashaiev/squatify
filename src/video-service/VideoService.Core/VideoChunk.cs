using System;

namespace VideoService.Core
{
    public class VideoChunk
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Guid VideoId { get; set; }
    }
}
