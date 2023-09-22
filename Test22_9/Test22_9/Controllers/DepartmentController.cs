using Microsoft.AspNetCore.Mvc;
using Test22_9.Models;
using Test22_9.Repositories;

namespace Test22_9.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentController(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return View(departments);
        }

        
    }
}
