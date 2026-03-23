using Microsoft.EntityFrameworkCore;
using oop_s2_2_mvc_77262.Enums;
using oop_s2_2_mvc_77262.Models;

namespace oop_s2_2_mvc_77262.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (context.Premises.Any())
            {
                return;
            }

            var premisesList = new List<Premises>
            {
                new Premises { Name = "Fran Café", Address = "12 Main Street", Town = "Dublin", RiskRating = RiskRating.Medium },
                new Premises { Name = "Temple Bites", Address = "4 River Lane", Town = "Dublin", RiskRating = RiskRating.High },
                new Premises { Name = "Green Spoon", Address = "28 Market Road", Town = "Dublin", RiskRating = RiskRating.Low },
                new Premises { Name = "Dockside Grill", Address = "90 Quay Street", Town = "Dublin", RiskRating = RiskRating.High },

                new Premises { Name = "Cork Kitchen", Address = "8 Patrick Street", Town = "Cork", RiskRating = RiskRating.Medium },
                new Premises { Name = "Lee Bakery", Address = "21 Bridge Road", Town = "Cork", RiskRating = RiskRating.Low },
                new Premises { Name = "Harbour Deli", Address = "7 Marina View", Town = "Cork", RiskRating = RiskRating.High },
                new Premises { Name = "South Feast", Address = "33 Grand Parade", Town = "Cork", RiskRating = RiskRating.Medium },

                new Premises { Name = "Galway Treats", Address = "5 Eyre Square", Town = "Galway", RiskRating = RiskRating.Low },
                new Premises { Name = "Bay Pizza", Address = "41 Shop Street", Town = "Galway", RiskRating = RiskRating.High },
                new Premises { Name = "West Coast Café", Address = "16 Harbour Road", Town = "Galway", RiskRating = RiskRating.Medium },
                new Premises { Name = "Claddagh Foods", Address = "52 Sea View", Town = "Galway", RiskRating = RiskRating.High }
            };

            context.Premises.AddRange(premisesList);
            context.SaveChanges();

            var inspectionsList = new List<Inspection>
            {
                new Inspection { PremisesId = premisesList[0].Id, InspectionDate = DateTime.Today.AddDays(-2), Score = 82, Outcome = InspectionOutcome.Pass, Notes = "Good hygiene standards." },
                new Inspection { PremisesId = premisesList[1].Id, InspectionDate = DateTime.Today.AddDays(-5), Score = 48, Outcome = InspectionOutcome.Fail, Notes = "Temperature records incomplete." },
                new Inspection { PremisesId = premisesList[2].Id, InspectionDate = DateTime.Today.AddDays(-8), Score = 91, Outcome = InspectionOutcome.Pass, Notes = "Very clean kitchen." },
                new Inspection { PremisesId = premisesList[3].Id, InspectionDate = DateTime.Today.AddDays(-12), Score = 39, Outcome = InspectionOutcome.Fail, Notes = "Poor food storage." },

                new Inspection { PremisesId = premisesList[4].Id, InspectionDate = DateTime.Today.AddDays(-15), Score = 76, Outcome = InspectionOutcome.Pass, Notes = "Minor issues found." },
                new Inspection { PremisesId = premisesList[5].Id, InspectionDate = DateTime.Today.AddDays(-18), Score = 88, Outcome = InspectionOutcome.Pass, Notes = "Well managed site." },
                new Inspection { PremisesId = premisesList[6].Id, InspectionDate = DateTime.Today.AddDays(-21), Score = 44, Outcome = InspectionOutcome.Fail, Notes = "Cross contamination risk." },
                new Inspection { PremisesId = premisesList[7].Id, InspectionDate = DateTime.Today.AddDays(-24), Score = 67, Outcome = InspectionOutcome.Pass, Notes = "Needs better labeling." },

                new Inspection { PremisesId = premisesList[8].Id, InspectionDate = DateTime.Today.AddDays(-27), Score = 95, Outcome = InspectionOutcome.Pass, Notes = "Excellent standards." },
                new Inspection { PremisesId = premisesList[9].Id, InspectionDate = DateTime.Today.AddDays(-30), Score = 41, Outcome = InspectionOutcome.Fail, Notes = "Cleaning schedule not followed." },
                new Inspection { PremisesId = premisesList[10].Id, InspectionDate = DateTime.Today.AddDays(-35), Score = 73, Outcome = InspectionOutcome.Pass, Notes = "Acceptable with minor improvements." },
                new Inspection { PremisesId = premisesList[11].Id, InspectionDate = DateTime.Today.AddDays(-40), Score = 36, Outcome = InspectionOutcome.Fail, Notes = "Pest control issue." },

                new Inspection { PremisesId = premisesList[0].Id, InspectionDate = DateTime.Today.AddDays(-45), Score = 79, Outcome = InspectionOutcome.Pass, Notes = "Improved since last visit." },
                new Inspection { PremisesId = premisesList[1].Id, InspectionDate = DateTime.Today.AddDays(-50), Score = 52, Outcome = InspectionOutcome.Fail, Notes = "Hand washing station issue." },
                new Inspection { PremisesId = premisesList[2].Id, InspectionDate = DateTime.Today.AddDays(-55), Score = 84, Outcome = InspectionOutcome.Pass, Notes = "Consistent compliance." },
                new Inspection { PremisesId = premisesList[3].Id, InspectionDate = DateTime.Today.AddDays(-60), Score = 47, Outcome = InspectionOutcome.Fail, Notes = "Waste disposal problem." },

                new Inspection { PremisesId = premisesList[4].Id, InspectionDate = DateTime.Today.AddDays(-65), Score = 69, Outcome = InspectionOutcome.Pass, Notes = "Staff training recommended." },
                new Inspection { PremisesId = premisesList[5].Id, InspectionDate = DateTime.Today.AddDays(-70), Score = 90, Outcome = InspectionOutcome.Pass, Notes = "Very strong compliance." },
                new Inspection { PremisesId = premisesList[6].Id, InspectionDate = DateTime.Today.AddDays(-75), Score = 43, Outcome = InspectionOutcome.Fail, Notes = "Unsafe refrigeration temperatures." },
                new Inspection { PremisesId = premisesList[7].Id, InspectionDate = DateTime.Today.AddDays(-80), Score = 71, Outcome = InspectionOutcome.Pass, Notes = "Small improvement needed." },

                new Inspection { PremisesId = premisesList[8].Id, InspectionDate = DateTime.Today.AddDays(-85), Score = 87, Outcome = InspectionOutcome.Pass, Notes = "Clean and organized." },
                new Inspection { PremisesId = premisesList[9].Id, InspectionDate = DateTime.Today.AddDays(-90), Score = 38, Outcome = InspectionOutcome.Fail, Notes = "Major hygiene issue." },
                new Inspection { PremisesId = premisesList[10].Id, InspectionDate = DateTime.Today.AddDays(-95), Score = 75, Outcome = InspectionOutcome.Pass, Notes = "Satisfactory overall." },
                new Inspection { PremisesId = premisesList[11].Id, InspectionDate = DateTime.Today.AddDays(-100), Score = 42, Outcome = InspectionOutcome.Fail, Notes = "Storage and labeling issues." },

                new Inspection { PremisesId = premisesList[0].Id, InspectionDate = DateTime.Today.AddDays(-110), Score = 80, Outcome = InspectionOutcome.Pass, Notes = "Routine inspection passed." }
            };

            context.Inspections.AddRange(inspectionsList);
            context.SaveChanges();

            var followUpsList = new List<FollowUp>
            {
                new FollowUp { InspectionId = inspectionsList[1].Id, DueDate = DateTime.Today.AddDays(-2), Status = FollowUpStatus.Open, ClosedDate = null },
                new FollowUp { InspectionId = inspectionsList[3].Id, DueDate = DateTime.Today.AddDays(5), Status = FollowUpStatus.Open, ClosedDate = null },
                new FollowUp { InspectionId = inspectionsList[6].Id, DueDate = DateTime.Today.AddDays(-7), Status = FollowUpStatus.Open, ClosedDate = null },
                new FollowUp { InspectionId = inspectionsList[9].Id, DueDate = DateTime.Today.AddDays(-15), Status = FollowUpStatus.Closed, ClosedDate = DateTime.Today.AddDays(-3) },
                new FollowUp { InspectionId = inspectionsList[11].Id, DueDate = DateTime.Today.AddDays(10), Status = FollowUpStatus.Open, ClosedDate = null },
                new FollowUp { InspectionId = inspectionsList[13].Id, DueDate = DateTime.Today.AddDays(-12), Status = FollowUpStatus.Closed, ClosedDate = DateTime.Today.AddDays(-4) },
                new FollowUp { InspectionId = inspectionsList[15].Id, DueDate = DateTime.Today.AddDays(-1), Status = FollowUpStatus.Open, ClosedDate = null },
                new FollowUp { InspectionId = inspectionsList[18].Id, DueDate = DateTime.Today.AddDays(8), Status = FollowUpStatus.Open, ClosedDate = null },
                new FollowUp { InspectionId = inspectionsList[21].Id, DueDate = DateTime.Today.AddDays(-20), Status = FollowUpStatus.Closed, ClosedDate = DateTime.Today.AddDays(-5) },
                new FollowUp { InspectionId = inspectionsList[23].Id, DueDate = DateTime.Today.AddDays(-6), Status = FollowUpStatus.Open, ClosedDate = null }
            };

            context.FollowUps.AddRange(followUpsList);
            context.SaveChanges();
        }
    }
}