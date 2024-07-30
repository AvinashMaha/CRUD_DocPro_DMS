using CRUD_DocPro_DMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUD_DocPro_DMS.Controllers
{
    public class HomeController : Controller
    {
        public StudentDbContext Context { get; }
        private readonly StudentDbContext student_DB;

        public HomeController(StudentDbContext studentDB)
        {
           this.student_DB = studentDB;
        }
        public async Task< IActionResult> Index()
        {
            var stddata = await student_DB.Students_Info.ToListAsync();
            return View(stddata);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await student_DB.Students_Info.AddAsync(std);
                await student_DB.SaveChangesAsync();
               return RedirectToAction("Index", "Home");
            }
            return View(std);
        }
        public async Task< IActionResult> Details(int? id)
        { 
            if(id==null || student_DB.Students_Info ==null)
            {
                return NotFound();
            }
            var detailsData = await student_DB.Students_Info.FirstOrDefaultAsync(x=>x.Student_Id == id);
            if(detailsData==null)
            {
                return NotFound();
            }
            return View(detailsData);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || student_DB.Students_Info == null)
            {
                return NotFound();
            }
            var editData = await student_DB.Students_Info.FindAsync(id);
            if (editData == null)
            {
                return NotFound();
            }
            return View(editData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id,Student std)
        {
            if(id != std.Student_Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                student_DB.Update(std);
                await student_DB.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null || student_DB.Students_Info == null)
            {
                return NotFound();
            }
            var deleteData = await student_DB.Students_Info.FirstOrDefaultAsync(x=>x.Student_Id==id);
            if (deleteData == null)
            {
                return NotFound();
            }
            return View(deleteData);
        }

        [HttpPost ,ActionName("Delete")]
        public async Task <IActionResult> DeleteConfirmed(int? id)
        {
            var deleteData = await student_DB.Students_Info.FindAsync(id);
            if(deleteData != null)
            {
                student_DB.Students_Info.Remove(deleteData);
            }
            await student_DB.SaveChangesAsync();
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
