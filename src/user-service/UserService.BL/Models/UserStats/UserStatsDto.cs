using System;

namespace UserService.BL.Models
{
    public class UserStatsDto
    {
        public Guid Id { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public DateTime DateNoted { get; set; }
    }
}