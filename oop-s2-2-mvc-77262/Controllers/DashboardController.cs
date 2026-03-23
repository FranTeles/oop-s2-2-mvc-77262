using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oop_s2_2_mvc_77262.Data;
using oop_s2_2_mvc_77262.Enums;
using oop_s2_2_mvc_77262.ViewModels;
using Serilog;

namespace oop_s2_2_mvc_77262.Controllers
{
    [Authorize(Roles = "Admin,Inspector,Viewer")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? townFilter, RiskRating? riskRatingFilter)
        {
            var today = DateTime.Today;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

            var inspectionsQuery = _context.Inspections
                .Include(i => i.Premises)
                .AsQueryable();

            var followUpsQuery = _context.FollowUps
                .Include(f => f.Inspection)
                .ThenInclude(i => i.Premises)
                .AsQueryable();

            if (!string.IsNullOrEmpty(townFilter))
            {
                inspectionsQuery = inspectionsQuery.Where(i => i.Premises != null && i.Premises.Town == townFilter);
                followUpsQuery = followUpsQuery.Where(f => f.Inspection != null && f.Inspection.Premises != null && f.Inspection.Premises.Town == townFilter);
            }

            if (riskRatingFilter.HasValue)
            {
                inspectionsQuery = inspectionsQuery.Where(i => i.Premises != null && i.Premises.RiskRating == riskRatingFilter.Value);
                followUpsQuery = followUpsQuery.Where(f => f.Inspection != null && f.Inspection.Premises != null && f.Inspection.Premises.RiskRating == riskRatingFilter.Value);
            }

            var viewModel = new DashboardViewModel
            {
                InspectionsThisMonth = inspectionsQuery.Count(i => i.InspectionDate >= firstDayOfMonth),
                FailedInspectionsThisMonth = inspectionsQuery.Count(i => i.InspectionDate >= firstDayOfMonth && i.Outcome == InspectionOutcome.Fail),
                OverdueOpenFollowUps = followUpsQuery.Count(f => f.DueDate < today && f.Status == FollowUpStatus.Open),
                TownFilter = townFilter,
                RiskRatingFilter = riskRatingFilter,
                Towns = _context.Premises
                    .Select(p => p.Town)
                    .Distinct()
                    .OrderBy(t => t)
                    .ToList()
            };

            Log.Information("Dashboard accessed");

            return View(viewModel);
        }
    }
}