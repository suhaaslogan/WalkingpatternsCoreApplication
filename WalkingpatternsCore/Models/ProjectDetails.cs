using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalkingpatternsCore.Models
{
    public class ProjectDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public ProjectVersionDetails Project { get; set; }

        [Required]
        public string RoomName { get; set; }
        [Required]

        public string Woodwork { get; set; }
        [Required]
        public string Accessories { get; set; }
        [Required]
        public string Services { get; set; }
        [Required]
        public string Total { get; set; }
        [Required]
        public string Width { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public string Depth { get; set; }


    }
}
