using System;
using System.ComponentModel.DataAnnotations;

namespace HallMaintenanceAPI.Models
{
    public class Attachment
    {
        [Key]
        public required int AttachmentID { get; set; }
        public required string IssueID { get; set; }
        public required string FilePath { get; set; } // FIXED
        public required string UploadedBy { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.Now;
    }
}