using Microsoft.AspNetCore.Mvc;
using HallMaintenanceAPI.Data;

namespace HallMaintenanceAPI.Controllers
{
    [ApiController]
    [Route("api/halls")]
    public class HallController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HallController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var halls = _context.Halls.ToList();
            return Ok(halls);
        }
    }
}