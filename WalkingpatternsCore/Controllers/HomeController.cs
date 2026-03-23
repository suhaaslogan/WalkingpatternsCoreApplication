using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalkingpatternsCore.Data;
using WalkingpatternsCore.Models;

namespace WalkingpatternsCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = _context.ClientDetails.ToList();

            if (clients == null || !clients.Any())
            {
                return Ok(new List<ClientDetails>()); // returns []
            }

            return Ok(clients);
        }

        [HttpPost]
        public IActionResult AddClient([FromBody] ClientDetailsDto dto)
        {
            if (_context.ClientDetails.Any(c => c.ClientName == dto.ClientName))
            {
                return BadRequest("Client already exists");
            }

            var client = new ClientDetails
            {
                ClientName = dto.ClientName,
                Phone = dto.Phone,
                Email = dto.Email,
                Address = dto.Address
            };

            _context.ClientDetails.Add(client);
            _context.SaveChanges();

            return Ok(client);
        }

        [HttpDelete("{clientName}")]
        public IActionResult DeleteClient(string clientName)
        {
            var client = _context.ClientDetails
                .FirstOrDefault(c => c.ClientName == clientName);

            if (client == null)
                return NotFound();

            _context.ClientDetails.Remove(client);
            _context.SaveChanges();

            return Ok();
        }
    }
}
