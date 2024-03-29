using Day_3_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day_3_2.Controllers
{
    public class DepartmentCourseController : Controller
    {
        ApplicationContext db = new ApplicationContext();
        public IActionResult ShowCourses(int id)
        {
            var model = db.Departments.Include(a=>a.Courses).FirstOrDefault(a => a.DeptId == id);
            return View(model);
        }
        public IActionResult ManageCourses(int id)
        {
            var model = db.Departments.Include(a => a.Courses).FirstOrDefault(a => a.DeptId == id);
            var allcourses = db.Courses.ToList();
            var coursesInDept = model.Courses;
            var coursesNotInDept = allcourses.Except(coursesInDept);
            ViewBag.coursesNotInDept = coursesNotInDept;
            return View(model);
        }

        [HttpPost]
        public IActionResult ManageCourses(int id , List<int> CoursetoRemove , List<int> CoursetoAdd)
        {
            Department dept = db.Departments.Include(a=>a.Courses).FirstOrDefault(a => a.DeptId == id);
            foreach (var item in CoursetoRemove)
            {
                Course c = db.Courses.FirstOrDefault(a => a.Id == item);
                dept.Courses.Remove(c);

            }

            foreach (var item in CoursetoAdd)
            {
                Course c = db.Courses.FirstOrDefault(a => a.Id == item);
                dept.Courses.Add(c);

            }
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }

        public IActionResult addStudentDegree(int deptid , int crsid)
        {
            Department dept = db.Departments.Include(a=>a.Students).FirstOrDefault(a=> a.DeptId == deptid);
            Course crs = db.Courses.FirstOrDefault(a => a.Id == crsid);

            ViewBag.course = crs;
            return View(dept);

        }
        [HttpPost]
        public IActionResult addStudentDegree(int deptid, int crsid , Dictionary<int,int> degree)
        {
           foreach (var item in degree)
            {
              var stcrs =  db.StudentCourses.FirstOrDefault(a=>a.StudentId== item.Key && a.CrsID ==  crsid);
                if(stcrs == null)
                {
                    StudentCourse studentCourse = new StudentCourse() { StudentId = item.Key, CrsID = crsid, Degree = item.Value };
                    db.StudentCourses.Add(studentCourse);
                }
                else
                stcrs.Degree = item.Value;
          
            }
            db.SaveChanges();
            return RedirectToAction("index", "department");
        }

    }
}
