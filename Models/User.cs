using System;
using System.ComponentModel.DataAnnotations;

namespace HallMaintenanceAPI.Models
{
    public class User
    {
        [Key]
        public required string UserID { get; set; } = Guid.NewGuid().ToString();
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; }
        public string? HallID { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}