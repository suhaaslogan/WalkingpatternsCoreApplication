using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalkingpatternsCore.Data;
using WalkingpatternsCore.Models;

namespace WalkingpatternsCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("project/{clientName}")]
        public IActionResult GetProjectDetails(string clientName)
        {
            var client = _context.ClientDetails
                .SingleOrDefault(c => c.ClientName == clientName);

            if (client == null)
                return NotFound();

            var projectDetails = _context.ProjectVersionDetails
                .Where(p => p.ClientName == clientName)
                .ToList();

            foreach (var project in projectDetails)
            {
                if (DateTime.TryParse(project.projectDate, out var parsedDate))
                {
                    project.projectDate = parsedDate.ToString("dd-MM-yyyy");
                }
                else
                {
                    project.projectDate = "";
                }
            }

            return Ok(projectDetails);
        }

        [HttpPost("addProject")]
        public IActionResult AddProject([FromBody] ProjectVersionDetailsDto dto)
        {
            if (string.IsNullOrEmpty(dto.VersionNumber))
            {
                dto.VersionNumber = "Version 1A";
            }

            var existingProject = _context.ProjectVersionDetails
                .FirstOrDefault(p => p.ProjectName.ToLower() == dto.ProjectName.ToLower());

            if (existingProject != null)
            {
                return Ok(new
                {
                    success = false,
                    message = "Project name already exists"
                });
            }

            var client = _context.ClientDetails
                .FirstOrDefault(c => c.ClientName == dto.ClientName);

            if (client == null)
            {
                return Ok(new
                {
                    success = false,
                    message = "Client not found"
                });
            }

            var project = new ProjectVersionDetails
            {
                ProjectName = dto.ProjectName,
                projectDate = dto.ProjectDate,
                VersionNumber = dto.VersionNumber,
                ClientName = dto.ClientName,
                ClientId = client.ClientId,
                GrandTotal = 0,
                DiscountAmount = 0,
                DiscountedTotal = 0
            };

            _context.ProjectVersionDetails.Add(project);
            _context.SaveChanges();

            return Ok(new
            {
                success = true,
                message = "Project created successfully"
            });
        }


    }
}
