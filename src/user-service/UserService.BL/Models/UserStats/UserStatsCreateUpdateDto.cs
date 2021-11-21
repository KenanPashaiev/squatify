using System;

namespace UserService.BL.Models
{
    public class UserStatsCreateDto
    {
        public string Weight { get; set; }
        public string Height { get; set; }
        public DateTime DateNoted { get; set; }
    }
}