namespace Day2.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }

        public virtual List<Instructor> Instructors { set; get; } = new List<Instructor>();
        public virtual List<Trainee> Trainees { set; get; } = new List<Trainee> ();    
        public virtual List<Course> Courses { set; get; }=new List<Course> ();

    }
}
