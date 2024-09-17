using Microsoft.AspNetCore.Mvc;
using zadanie5.Models; 

namespace zadanie5.Controllers
{
    public class TestController : Controller
    {
        private readonly TestDbContext _context;
        public TestController(TestDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Klienci.ToList());
        }
    }
}
