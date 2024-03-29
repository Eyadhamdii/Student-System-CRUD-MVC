using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Day_3_2.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Display(Name = "Department ID")]
        public int DeptId { get; set; }

        [Display(Name = "Department Name")]
        public string DeptName { get; set; }

        public bool Status { get; set; } = true;

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();  // Foreign Key

        public List<Course> Courses { get; set; } 
    }
}
