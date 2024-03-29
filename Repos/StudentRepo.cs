using Day_3_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_3_2.Repos
{
  
        
    public interface IStudentRepo
    {
        public List<Student> GetAll();

        public Student GetById(int id);

        public void Add(Student student);

        public void Update(Student student);

        public void Delete(int id);



    }


    public class StudentRepo : IStudentRepo
        {
        ApplicationContext db; //= new ApplicationContext();

        public StudentRepo(ApplicationContext _db)
        {
            db = _db;
        }
        public List<Student> GetAll()
            {
                Console.WriteLine("Student list required");
                return db.Students.Include(a => a.Department).ToList();

            }

            public Student GetById(int id)
            {
                return db.Students.Include(a => a.Department).FirstOrDefault(a => a.Id == id);
            }

            public void Add(Student student)
            {
                db.Students.Add(student);
                db.SaveChanges();
            }

            public void Update(Student student)
            {
                db.Students.Update(student);
                db.SaveChanges();
            }


            public void Delete(int id)
            {
                var std = db.Students.FirstOrDefault(a => a.Id == id);

            db.Students.Remove(std);  //hard delete
            db.SaveChanges();
                Console.WriteLine("Student is deleted");
            }

        }
    }
