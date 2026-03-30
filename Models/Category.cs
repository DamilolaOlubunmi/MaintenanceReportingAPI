using System;
using System.ComponentModel.DataAnnotations;

namespace HallMaintenanceAPI.Models
{
    public class Category
    {
        [Key]
        public required string CategoryID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}