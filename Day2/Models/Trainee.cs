using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { set; get; }
        public char grade { set; get; }
        [ForeignKey("department")]
        public int departmentId { set; get; }
        public virtual Department department { set; get; }
        public virtual List<CrsResult> Results { set; get; } = new List<CrsResult>();


    }
}
