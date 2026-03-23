using oop_s2_2_mvc_77262.Enums;
using System.ComponentModel.DataAnnotations;

namespace oop_s2_2_mvc_77262.Models
{
    public class Inspection
    {
        public int Id { get; set; }

        [Required]
        public int PremisesId { get; set; }

        [Required]
        [Display(Name = "Inspection Date")]
        public DateTime InspectionDate { get; set; }

        [Range(0, 100)]
        public int Score { get; set; }

        [Required]
        [Display(Name = "Inspection Outcome")]
        public InspectionOutcome Outcome { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public Premises? Premises { get; set; }

        public List<FollowUp> FollowUps { get; set; } = new List<FollowUp>();
    }
}
