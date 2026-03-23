using oop_s2_2_mvc_77262.Enums;
using System.ComponentModel.DataAnnotations;

namespace oop_s2_2_mvc_77262.Models
{
    public class FollowUp
    {
        public int Id { get; set; }

        [Required]
        public int InspectionId { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Required]
        public FollowUpStatus Status { get; set; }

        [Display(Name = "Closed Date")]
        public DateTime? ClosedDate { get; set; }

        [Display(Name = "Inspection Id")]
        public Inspection? Inspection { get; set; }
    }
}
