using Microsoft.EntityFrameworkCore;
using oop_s2_2_mvc_77262.Data;
using oop_s2_2_mvc_77262.Models;
using oop_s2_2_mvc_77262.Enums;
using Xunit;

namespace oop_s2_2_mvc_77262.Tests
{
    public class DashboardTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_Dashboard")
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void DashboardCounts_ReturnCorrectValues()
        {
            // Arrange
            var context = GetDbContext();

            var premises = new Premises
            {
                Name = "Test Place",
                Address = "Test Address",
                Town = "Dublin",
                RiskRating = RiskRating.Medium
            };

            context.Premises.Add(premises);
            context.SaveChanges();

            context.Inspections.AddRange(
                new Inspection
                {
                    PremisesId = premises.Id,
                    InspectionDate = DateTime.Today.AddDays(-2), // this month
                    Score = 80,
                    Outcome = InspectionOutcome.Pass
                },
                new Inspection
                {
                    PremisesId = premises.Id,
                    InspectionDate = DateTime.Today.AddDays(-3), // this month
                    Score = 40,
                    Outcome = InspectionOutcome.Fail
                },
                new Inspection
                {
                    PremisesId = premises.Id,
                    InspectionDate = DateTime.Today.AddMonths(-1), // last month
                    Score = 30,
                    Outcome = InspectionOutcome.Fail
                }
            );

            context.SaveChanges();

            var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            // Act
            var inspectionsThisMonth = context.Inspections
                .Count(i => i.InspectionDate >= firstDayOfMonth);

            var failedThisMonth = context.Inspections
                .Count(i => i.InspectionDate >= firstDayOfMonth && i.Outcome == InspectionOutcome.Fail);

            // Assert
            Assert.Equal(2, inspectionsThisMonth);
            Assert.Equal(1, failedThisMonth);
        }

        [Fact]
        public void FollowUp_OverdueCondition_WorksCorrectly()
        {
            // Arrange
            var followUp = new FollowUp
            {
                DueDate = DateTime.Today.AddDays(-1),
                Status = FollowUpStatus.Open
            };

            // Act
            var isOverdue = followUp.DueDate < DateTime.Today && followUp.Status == FollowUpStatus.Open;

            // Assert
            Assert.True(isOverdue);
        }
    }
}
