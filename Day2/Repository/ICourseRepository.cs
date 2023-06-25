using Day2.Models;

namespace Day2.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Insert(Course course);
        void Update(int id,Course course);
        void Delete(int id);
        void Save();
    }
}