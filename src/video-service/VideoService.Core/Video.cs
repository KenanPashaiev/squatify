using System;
using System.Collections.Generic;

namespace VideoService.Core
{
    public class Video
    {
        public Guid Id { get; set; }
        public TimeSpan Length { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<VideoChunk> VideoChunks { get; set; }
        public Guid UserId { get; set; }
    }
}
