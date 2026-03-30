using Microsoft.AspNetCore.Mvc;
using HallMaintenanceAPI.Data;
using System.Linq;

namespace HallMaintenanceAPI.Controllers
{
    [ApiController]
    [Route("api/auditlogs")]
    public class AuditLogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuditLogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var logs = _context.AuditLogs
                .OrderByDescending(l => l.Timestamp)
                .ToList();

            return Ok(logs);
        }
    }
}