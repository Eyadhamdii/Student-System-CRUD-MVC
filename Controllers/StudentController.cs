using Day_3_2.Models;
using Day_3_2.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day_3_2.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        //ApplicationContext db = new ApplicationContext();
        //IDeptRepo dbtrepo;
        //DepartmentRepo dbtrepo = new DepartmentRepo();
        //StudentRepo StudentRepo = new StudentRepo();

        //public StudentController(IDeptRepo _dbtrepo)
        //{
        //    this.dbtrepo = _dbtrepo;
        //}

        IStudentRepo studentRepo;
        IDeptRepo dbtRepo;

        public StudentController(IDeptRepo _deptRepo , IStudentRepo _studentRepo)
        {
            studentRepo = _studentRepo;
            dbtRepo = _deptRepo;
        }

        public IActionResult Index()
        {
            var model =  studentRepo.GetAll(); // db.Students.Include(a => a.Department).ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.deptlist = dbtRepo.GetAll(); 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            //  model state
            
            studentRepo.Add(student);
            //db.Students.Add(student);
            //db.SaveChanges();
            return RedirectToAction("Index");
           
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var model =   studentRepo.GetById(id.Value); // db.Students.Include(a=>a.Department).FirstOrDefault(a => a.Id == id); 
            if (model == null)
                return NotFound();
            return View(model);

        }
        public IActionResult Details2(int? id)
        {
           
            var model = studentRepo.GetById(id.Value);
          
            return PartialView(model);

        }

       
        public IActionResult Update(int? id)
        {
            if (id == null)
                return BadRequest();
            var model =   studentRepo.GetById(id.Value); //  db.Students.Include(a => a.Department).FirstOrDefault(a => a.Id == id);
            if (model == null)
                return NotFound();

            ViewBag.deptlist = dbtRepo.GetAll();

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            studentRepo.Update(student);
            //db.Students.Update(student);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public IActionResult CheckEmail(string email)
        //{
        //    var model = db.Students.FirstOrDefault(a => a.Email == email);
        //    if (model != null)
        //        return Json(false);
        //    else 
        //        return Json(true);

        //}
        public IActionResult Delete(int id)
        {
            studentRepo.Delete(id);
            //db.Students.Update(student);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

    }


}
