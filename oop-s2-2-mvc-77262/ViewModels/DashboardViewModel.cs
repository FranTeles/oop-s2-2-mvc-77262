using oop_s2_2_mvc_77262.Enums;

namespace oop_s2_2_mvc_77262.ViewModels
{
    public class DashboardViewModel
    {
        public int InspectionsThisMonth { get; set; }
        public int FailedInspectionsThisMonth { get; set; }
        public int OverdueOpenFollowUps { get; set; }

        public string? TownFilter { get; set; }
        public RiskRating? RiskRatingFilter { get; set; }

        public List<string> Towns { get; set; } = new();
    }
}