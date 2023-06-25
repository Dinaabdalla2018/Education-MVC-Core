using Day2.Models;

namespace Day2.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department department);
        void Update(int id, Department department);
        void Delete(int id);
        void Save();
    }
}