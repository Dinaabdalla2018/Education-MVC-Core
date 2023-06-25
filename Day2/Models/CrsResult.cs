using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public double degree { get; set; }
        [ForeignKey("course")]
        public int courseId { set; get; }
        [ForeignKey("trainee")]
        public int traineeId { set; get; }
        public virtual Course course { set; get; }
        public virtual Trainee trainee { set; get; }
    }
}
