using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalkingpatternsCore.Models
{
    public class ProjectVersionDetailsDto
    {
        public string ProjectName { get; set; }

        public string ProjectDate { get; set; }

        public string VersionNumber { get; set; }

        public string ClientName { get; set; }

        [Required]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public ClientDetailsDto Client { get; set; }
    }
}
