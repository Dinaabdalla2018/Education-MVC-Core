using Day2.Models;

namespace Day2.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        DB_Context db;
        public DepartmentRepository(DB_Context _context)
        {
            db = _context;
        }
        public void Delete(int id)
        {
            Department oldDept = GetById(id);
            db.departments.Remove(oldDept);
        }

        public List<Department> GetAll()
        {
           return  db.departments.ToList();
        }

        public Department GetById(int id)
        {
            return db.departments.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Department department)
        {
             db.departments.Add(department);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(int id, Department department)
        {
            Department oldDept = GetById(id);
            oldDept.Name = department.Name;
            oldDept.Manager = department.Manager;
        }
    }
}
