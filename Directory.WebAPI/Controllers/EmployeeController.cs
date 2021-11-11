using Directory.Entities.Models;
using Directory.WebAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Directory.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeLayer db;
        public EmployeeController(ApplicationContext _db)
        {
            db = new EmployeeLayer(_db);
        }

        [HttpGet]
        public object Get()
        {
            IQueryable<Employee> data = db.GetAllEmployee().AsQueryable();
            var count = data.Count();
            List<Employee> Emp = new List<Employee>() ;
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$inlinecount"))
            {
                int skip = (queryString.TryGetValue("$skip", out StringValues Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out StringValues Take)) ? Convert.ToInt32(Take[0]) : data.Count();
                string search = queryString["$filter"];
                try
                {
                    if (queryString.Keys.Contains("$filter"))
                    {
                        queryString.TryGetValue("$filter", out StringValues filter);
                        int fltr = Int32.Parse(filter[0].ToString().Split("eq")[1]);
                        data = data.Where(f => f.SubdivisionId == fltr).AsQueryable();
                        count = data.Count();

                    }
                }
                catch
                {
                    if (search != null)
                    {
                        string key = search.Split(" or ")[^1];
                        key = search.Split("'")[key.Split(",").Length - 1];
                        data = data.Where(
                            fil => fil.Id.ToString().Contains(key)
                        || fil.FirstName.ToLower().Contains(key.ToLower())
                        || fil.LastName.ToLower().Contains(key.ToLower())
                        || fil.Patronymic.ToLower().Contains(key.ToLower())
                        || fil.PhoneNumber.ToLower().Contains(key.ToLower())
                        || fil.Email.ToLower().Contains(key.ToLower())
                        || fil.PositionWork.ToLower().Contains(key.ToLower())
                        || fil.OrganizationId.ToString().Contains(key.ToLower())
                        || fil.SubdivisionId.ToString().Contains(key.ToLower())
                        );
                    }
                }
              
                if (data.Count() == 0)
                {
                    Emp = data.ToList();
                    Emp.Add(new Employee {Id = 0, OrganizationId = 0, SubdivisionId = 0});
                    return new { Items = Emp.Skip(skip).Take(top), Count = Emp.Count()};
                }
                return new { Items = data.Skip(skip).Take(top), Count = count };
            }
            return data;
        }

        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            db.AddEmployee(employee);
        }

        [HttpPut]
        public object Put([FromBody] Employee employee)
        {
            db.UpdateEmployee(employee);
            return employee;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeleteEmployee(id);
        }
    }
}
