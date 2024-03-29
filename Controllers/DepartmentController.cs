using Day_3_2.Models;
using Day_3_2.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Day_3_2.Controllers
{

    // Crud
   // [Authorize(Roles ="Admins")]
    public class DepartmentController : Controller
    {
        IDeptRepo dbtrepo;
        public DepartmentController(IDeptRepo deptRepo)
        {
            dbtrepo = deptRepo; 
        }
        //ApplicationContext db = new ApplicationContext();

        //DepartmentRepo dbtrepo = new DepartmentRepo();
        //public DepartmentController(IDeptRepo _departmentrepo)
        //{
        //    dbtrepo = _departmentrepo;
        //}

        //DepartmentRepo dbtrepo = new DepartmentRepo();
        public IActionResult Index()
        {
            var model = dbtrepo.GetAll();
            return View(model);
        }
        public IActionResult Create ()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (!ModelState.IsValid) {
            dbtrepo.Add(department);
            //if(model.DeptId != null && model.DeptName?.Length > 2)
            //{
            //   db.Departments.Add(model);
            //    db.SaveChanges();
                // return View("index");
                return RedirectToAction("Index");
                
            } 
            else
                return View(department);
        }

        public IActionResult Details (int? id)
        {
            if (id == null)
                return BadRequest();
            var model = dbtrepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }

        public IActionResult Edit (int? id ) 
        {
            if (id == null)
                return BadRequest();
            var model = dbtrepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Department department , int id)
        {
            department.DeptId = id;
            dbtrepo.Update(department);
            //var old = db.Departments.FirstOrDefault(a => a.DeptId == id);
            //old.DeptName = department.DeptName;
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var model = dbtrepo.GetById(id.Value);
            if (model == null)
                return NotFound();
            dbtrepo.Delete(id.Value);
            //db.Departments.Remove(model);
            //db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
