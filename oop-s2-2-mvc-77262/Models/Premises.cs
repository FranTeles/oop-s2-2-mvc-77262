using oop_s2_2_mvc_77262.Enums;
using System.ComponentModel.DataAnnotations;

namespace oop_s2_2_mvc_77262.Models
{
    public class Premises
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Premises Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Town { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Risk Rating")]
        public RiskRating RiskRating { get; set; }

        public List<Inspection> Inspections { get; set; } = new List<Inspection>();
    }
}
