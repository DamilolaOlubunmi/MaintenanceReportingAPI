using System;
using System.ComponentModel.DataAnnotations;

namespace HallMaintenanceAPI.Models
{
    public enum IssueStatus
    {
        Pending,
        Assigned,
        InProgress,
        Resolved
    }

    public class Issue
    {
        [Key]
        public required string IssueID { get; set; } = Guid.NewGuid().ToString();
        public required string Title { get; set; }
        public string? Description { get; set; }

        public required string CategoryID { get; set; }
        public required string HallID { get; set; }

        public required string RoomNumber { get; set; }

        public required string ReportedBy { get; set; }
        public string? AssignedTo { get; set; }

        public IssueStatus Status { get; set; } = IssueStatus.Pending;

        public required string Priority { get; set; }

        public DateTime DateReported { get; set; } = DateTime.Now;
        public DateTime? DateResolved { get; set; }
        public DateTime? DateAssigned { get; set; }
    }
}