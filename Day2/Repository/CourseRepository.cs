using Day2.Models;

namespace Day2.Repository
{
    public class CourseRepository: ICourseRepository
    {
        DB_Context db;
        public CourseRepository(DB_Context _context)
        {
            db= _context;
        }

        public void Delete(int id)
        {
            db.courses.Remove(GetById(id));
        }

        public List<Course> GetAll()
        {
            return db.courses.ToList();
        }

        public Course GetById(int id)
        {
            return db.courses.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(Course course)
        {
            db.courses.Add(course);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(int id,Course _course)
        {
            Course course = GetById(id);
            course.Name=_course.Name;
            course.minDegree=_course.minDegree;
            course.degree = _course.degree;
            course.departmentId=_course.departmentId;

        }
    }
}
