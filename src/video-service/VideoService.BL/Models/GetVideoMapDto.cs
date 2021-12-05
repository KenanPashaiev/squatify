using System;

namespace VideoService.BL.Models
{
    public class GetVideoMapDto
    {
        public Guid VideoId { get; set; }
        public TimeSpan Time { get; set; }
    }
}