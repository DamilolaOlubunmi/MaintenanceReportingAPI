using System;
using System.ComponentModel.DataAnnotations;

namespace HallMaintenanceAPI.Models
{
    public class Hall
    {
        [Key]
        public required string HallID { get; set; }
        public required string HallName { get; set; }
        public required string Location { get; set; }
    }
}