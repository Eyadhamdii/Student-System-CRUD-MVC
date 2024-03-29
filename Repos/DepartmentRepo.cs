using Day_3_2.Models;


namespace Day_3_2.Repos
{
    // awl haga b3ml interface

    public interface IDeptRepo
    {
        List<Department> GetAll();
        Department GetById(int id);

        void Add(Department department);

        void Update(Department department);

        void Delete(int id);

    }

    // b3d kda b implement l repo
    public class DepartmentRepo : IDeptRepo
    {


        ApplicationContext db; //= new ApplicationContext();

        public DepartmentRepo(ApplicationContext _db)
        {
            db = _db;
        }
        public List<Department> GetAll()
        {
            Console.WriteLine("Department list required");
            return db.Departments.Where(a => a.Status == true).ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.SingleOrDefault(a => a.DeptId == id);
        }

        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }

        public void Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
        }


        public void Delete(int id)
        {
            var dept = GetById(id);
            dept.Status = false;
            db.SaveChanges();
            Console.WriteLine("Department is deleted");
        }
    }

    //public class NewDeptRepo : IDeptRepo
    //{
    //    public void Add(Department department)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Delete(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public List<Department> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Department GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(Department department)
    //    {
    //        throw new NotImplementedException();
    //    }
    }

