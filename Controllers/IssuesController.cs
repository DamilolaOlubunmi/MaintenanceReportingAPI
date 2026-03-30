using Microsoft.AspNetCore.Mvc;
using HallMaintenanceAPI.Data;
using HallMaintenanceAPI.Models;
using System.Linq;

namespace HallMaintenanceAPI.Controllers
{
    [ApiController]
    [Route("api/issues")]
    public class IssuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IssuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateIssue(Issue issue)
        {
            issue.IssueID = Guid.NewGuid().ToString();
            issue.Status = IssueStatus.Pending;
            issue.DateReported = DateTime.Now;

            var officer = _context.Users
                .FirstOrDefault(u => u.Role == "Officer" && u.HallID == issue.HallID);

            if (officer != null)
            {
                issue.AssignedTo = officer.UserID;
                issue.Status = IssueStatus.Assigned;
                issue.DateAssigned = DateTime.Now;
            }

            _context.Issues.Add(issue);

            _context.AuditLogs.Add(new AuditLog
            {
                LogID = Guid.NewGuid().GetHashCode(), // Simple way to generate a unique LogI
                UserID = issue.ReportedBy,
                IssueID = issue.IssueID,
                Action = "Issue created"
            });

            _context.SaveChanges();

            return Ok(issue);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Issues.ToList());

        [HttpGet("hall/{HallID}")]
        public IActionResult GetIssuesByHall(string HallID)
        {
            var issues = _context.Issues.Where(i => i.HallID == HallID).ToList();
            return Ok(issues);
        }

        [HttpGet("category/{CategoryID}")]
        public IActionResult GetIssuesByCategory(string CategoryID)
        {
            var issues = _context.Issues.Where(i => i.CategoryID == CategoryID).ToList();
            return Ok(issues);
        }

        [HttpGet("status/{status}")]
        public IActionResult GetIssuesByStatus(IssueStatus status)
        {
            var issues = _context.Issues.Where(i => i.Status == status).ToList();
            return Ok(issues);
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(string id, IssueStatus newStatus)
        {
            var issue = _context.Issues.FirstOrDefault(i => i.IssueID == id);
            if (issue == null) return NotFound();

            issue.Status = newStatus;
            if (newStatus == IssueStatus.Resolved)
                issue.DateResolved = DateTime.Now;

            _context.AuditLogs.Add(new AuditLog
            {
                LogID = Guid.NewGuid().GetHashCode(),
                UserID = issue.AssignedTo ?? issue.ReportedBy,
                IssueID = issue.IssueID,
                Action = $"Issue status updated to {newStatus}"
            });

            _context.SaveChanges();
            return Ok(issue);
        }
    }
}