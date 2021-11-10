using Directory.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
        public string GetPositionWorkId(string key)
        {
            try
            {
                int fltr = Int32.Parse(key);
                return fltr.ToString();
             
            }
            catch
            {
                PositionWork pw = db.PositionWorks.FirstOrDefault(pw => pw.Name.ToLower().Contains(key.ToLower()));
                if (pw != null)
                {
                    int a = pw.Id;
                    
                    return a.ToString();
                }
                else
                    return null;
            }
        }
        public void AddEmployee(Employee employee)
        {
            try
            {
                employee.FirstName = Formating(employee.FirstName);
                employee.LastName = Formating(employee.LastName);
                employee.Patronymic = Formating(employee.Patronymic);
                employee.PhoneNumber = '7' + employee.PhoneNumber.Remove(0, 1);
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

        private static string Formating(string name)
        {
            name = name.ToLower();
            name = name.ToUpper()[0] + name.Substring(1);
            return name;
        }
    }
}
