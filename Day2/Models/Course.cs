using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Day2.Models
{
    public class Course
    {
        public int Id { get; set; }
        [MaxLength(25)]
        [MinLength(2)]
        [UniqueNamePerDept]
        public string Name { get; set; }
        [Range(50,100)]
        public double degree { get; set; }
        [Remote("testDegree","Course",  ErrorMessage = "Salary Must be less than degree",    AdditionalFields="degree")]
        public double minDegree { get; set; }

        [ForeignKey("department")]
        public int departmentId { set; get; }
        public virtual Department? department { set; get; }
       public virtual List<CrsResult> results { set; get; } = new List<CrsResult> ();
        public virtual List<Instructor> Instructors { set; get; }= new List<Instructor>();
    }
}
