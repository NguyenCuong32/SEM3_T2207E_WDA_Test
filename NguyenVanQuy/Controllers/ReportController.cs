using Microsoft.AspNetCore.Mvc;
using NguyenVanQuy.Data;
using NguyenVanQuy.Models;

namespace NguyenVanQuy.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Report> reports = new List<Report>();
            var departments = _context.Department.ToList();
            foreach (var item in departments)
            {
                Report report = new Report();
                var employee = _context.Employee.Where(e => e.DepartmentId == item.Id).ToList();
                report.department = item;
                report.employees = employee;
                reports.Add(report);
            }

            return View(reports);
        }
    }
}
