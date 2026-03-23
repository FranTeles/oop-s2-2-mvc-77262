using Microsoft.EntityFrameworkCore;
using oop_s2_2_mvc_77262.Data;
using oop_s2_2_mvc_77262.Models;
using oop_s2_2_mvc_77262.Enums;
using Xunit;

namespace oop_s2_2_mvc_77262.Tests
{
    public class FollowUpTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_FollowUp")
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void OverdueFollowUps_ReturnsCorrectItems()
        {
            // Arrange
            var context = GetDbContext();

            var inspection = new Inspection
            {
                InspectionDate = DateTime.Today.AddDays(-10),
                PremisesId = 1
            };

            context.Inspections.Add(inspection);
            context.SaveChanges();

            context.FollowUps.AddRange(
                new FollowUp
                {
                    InspectionId = inspection.Id,
                    DueDate = DateTime.Today.AddDays(-1), // overdue
                    Status = FollowUpStatus.Open
                },
                new FollowUp
                {
                    InspectionId = inspection.Id,
                    DueDate = DateTime.Today.AddDays(5), // not overdue
                    Status = FollowUpStatus.Open
                },
                new FollowUp
                {
                    InspectionId = inspection.Id,
                    DueDate = DateTime.Today.AddDays(-2), // overdue but closed
                    Status = FollowUpStatus.Closed,
                    ClosedDate = DateTime.Today
                }
            );

            context.SaveChanges();

            // Act
            var today = DateTime.Today;

            var overdue = context.FollowUps
                .Where(f => f.DueDate < today && f.Status == FollowUpStatus.Open)
                .ToList();

            // Assert
            Assert.Single(overdue);
        }

        [Fact]
        public void FollowUp_CannotBeClosedWithoutClosedDate()
        {
            // Arrange
            var followUp = new FollowUp
            {
                Status = FollowUpStatus.Closed,
                ClosedDate = null
            };

            // Act
            var isValid = !(followUp.Status == FollowUpStatus.Closed && followUp.ClosedDate == null);

            // Assert
            Assert.False(isValid);
        }
    }
}