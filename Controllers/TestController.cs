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

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Klienci klient)
        {
            if (klient.PESEL.Length != 11)
            {
                ModelState.AddModelError("PESEL", "Numer PESEL musi mieć dokładnie 11 znaków.");
            }
            else
            {
                int rok = int.Parse(klient.PESEL.Substring(0, 2));
                int miesiac = int.Parse(klient.PESEL.Substring(2, 2));

                if (miesiac <= 12)
                {
                    rok += 1900;
                }
                else if (miesiac <= 32)
                {
                    rok += 2000;
                }
                else if (miesiac <= 52)
                {
                    rok += 2100;
                }
                else if (miesiac <= 72)
                {
                    rok += 1800;
                }
                if (rok != klient.BirthYear)
                {
                    ModelState.AddModelError("Rok Urodzenia", "Rok urodzenia nie zgadza się z numerem PESEL");
                }
                else
                {
                    int gender = int.Parse(klient.PESEL[9].ToString());
                    if (gender % 2 == 0)
                    {
                        gender = 1; 
                    }else
                    {
                        gender = 2;
                    }

                    if (gender != klient.Płeć)
                    {
                        ModelState.AddModelError("Plec", "Płeć nie zgadza się z numerem PESEL");
                    }
                }
            }
            if (!ModelState.IsValid) return View(klient);
            _context.Klienci.Add(klient);
            _context.SaveChanges();
            ViewBag.SuccessMessage = "Klient pomyślnie stworzony";
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Klienci? klient = _context.Klienci.Find(id);
            if (klient != null) _context.Klienci.Remove(klient);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
