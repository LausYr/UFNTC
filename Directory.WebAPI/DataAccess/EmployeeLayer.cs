using Directory.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Directory.WebAPI.DataAccess
{
    public class EmployeeLayer
    {
        private readonly ApplicationContext db;
        public EmployeeLayer(ApplicationContext _db)
        {
            db = _db;
        }

        public DbSet<Employee> GetAllEmployee()
        {
            try
            {
                return db.Employees;
            }
            catch
            {
                throw;
            }
        }
        public void AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void DeleteEmployee(int id)
        {
            try
            {
                Employee emp = db.Employees.Find(id);
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
