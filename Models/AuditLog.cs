using System;
using System.ComponentModel.DataAnnotations;

namespace HallMaintenanceAPI.Models
{
    public class AuditLog
    {
        [Key]
        public int LogID { get; set; }
        public required string UserID { get; set; }
        public required string IssueID { get; set; }  // FIXED (was int)

        public required string Action { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}