using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Instructor
    {
        public int Id { set; get; }
        public string Name { set; get; }
        [Required(ErrorMessage = "Please choose file to upload.")]
        public string Image { set; get; }
        public string address { set; get; }
        public double salary { set; get; }
        [ForeignKey("department")]
        public int departmentId { set; get; }
        [ForeignKey("course")]
        public int courseId { set; get; }
        public virtual Course course { set; get; }
        public virtual Department department { set; get; }
    }
}
