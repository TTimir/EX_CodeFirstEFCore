using EX_CodeFirstEFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EX_CodeFirstEFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext studentDb;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentDbContext studentDb)
        {
            this.studentDb = studentDb;
        }

        public async Task<IActionResult> Index()
        {
            var studData = await studentDb.Students.ToListAsync();
            return View(studData);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // defend against CSFR(Cross-Site Request Forgery)
        public async Task<IActionResult> Create(Student stud)
        {
            if (ModelState.IsValid)
            {
                await studentDb.Students.AddAsync(stud);
                await studentDb.SaveChangesAsync();
                TempData["Message"] = "Data has been inserted..";
                return RedirectToAction("Index", "Home");
            }
            return View(stud);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null || studentDb.Students != null)
            {
                var studData = await studentDb.Students.FirstOrDefaultAsync(x => x.SID == id);
                return View(studData);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null || studentDb.Students != null)
            {
                var studData = await studentDb.Students.FindAsync(id);
                return View(studData);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student student)
        {
            if (id != student.SID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                studentDb.Students.Update(student);
                await studentDb.SaveChangesAsync();
                TempData["Update_Message"] = "Data has been updated..";
                return RedirectToAction("Index", "Home");
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null || studentDb.Students != null)
            {
                var studData = await studentDb.Students.FirstOrDefaultAsync(x => x.SID == id);
                return View(studData);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var studData = await studentDb.Students.FindAsync(id);
            if (studData != null)
            {
                studentDb.Students.Remove(studData);
                TempData["Delete_Message"] = "Data has been deleted..";
            }
            await studentDb.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
