using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalkingpatternsCore.Models
{
    public class ProjectVersionDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string projectDate { get; set; }

        [Required]
        public string VersionNumber { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public ClientDetails Client { get; set; }

        public double GrandTotal { get; set; }
        public double DiscountAmount { get; set; }
        public double DiscountedTotal { get; set; }

        // Navigation
        public ICollection<ProjectDetails> ProjectDetails { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
