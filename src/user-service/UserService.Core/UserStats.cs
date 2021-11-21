using System;

namespace UserService.Core
{
    public class UserStats
    {
        public Guid Id { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public DateTime DateNoted { get; set; }
    }
}
