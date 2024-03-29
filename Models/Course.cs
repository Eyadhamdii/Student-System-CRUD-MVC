namespace Day_3_2.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Crs_Name { get; set; }

        public int Duration { get; set; }

        public List<Department> Departments { get; set; } 

        public List<StudentCourse> CourseStudents { get; set; }
    }
}
