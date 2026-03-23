using System.ComponentModel.DataAnnotations;

namespace WalkingpatternsCore.Models
{
    public class ClientDetails
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        [MaxLength(500)]
        public string ClientName { get; set; }

        [Required]
        [MaxLength(500)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(500)]
        public string Email { get; set; }

        [MaxLength(1000)]
        public string Address { get; set; }

        public ICollection<ProjectVersionDetails> ProjectVersions { get; set; }
    }
}
