using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day_3_2.Models
{
    public class Student
    {
        // naming convention
        // data annotation
        // fluent api   highest priority 
        public int Id { get; set; }

        [Required ]
        [StringLength(10,MinimumLength=3 , ErrorMessage ="Must Be letters")]
        //[MinLength(3)]
        //[MaxLength(10)]
        [Display(Name="Full Name")]
        public string Name { get; set; }

        [Range(20,30)]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        //[Remote("Check Email" , "student")]
        //[NotMapped]
        //[Compare("Email")]
        //public string ConfirmEmail { get; set; }

        [ForeignKey("Department")]
        public int DeptNo { get; set; }

        public Department Department { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }
     }
}
