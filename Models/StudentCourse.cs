using System.ComponentModel.DataAnnotations.Schema;

namespace Day_3_2.Models
{
    public class StudentCourse
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]

        public int CrsID { get; set;}

        public int Degree { get; set;}

        public Course Course { get; set;}

        public Student Student { get; set;}
    }
}
