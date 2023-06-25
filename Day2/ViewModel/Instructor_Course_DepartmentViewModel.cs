using Day2.Models;

namespace Day2.ViewModel
{
    public class Instructor_Course_DepartmentViewModel
    {
        public Department dep { set; get; }
        public Course course { set; get;}
        public int course_id { set; get; }
        public string course_name { set; get; }
        public string instructor_name { set; get; }
        public int instructor_id { set; get; }
        public string instructor_image { set; get; }
        public string instructor_Address { set; get; }
    }
}
