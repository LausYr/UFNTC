using Directory.Entities.Models;
using Directory.WebAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;

namespace Directory.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly OrganizationLayer db;
        public OrganizationController(ApplicationContext _db)
        {
            db = new OrganizationLayer(_db);
        }
 
        [HttpGet]
        public object Get()
        {
            IQueryable<Organization> data = db.GetAllOrganization().AsQueryable();
            var count = data.Count();
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$inlinecount"))
            {
                int skip = (queryString.TryGetValue("$skip", out StringValues Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out StringValues Take)) ? Convert.ToInt32(Take[0]) : data.Count();
                string search = queryString["$filter"];
                if (search != null)
                {
                    string key = search.Split(" or ")[^1];
                    key = search.Split("'")[key.Split(",").Length - 1];
                    data = data.Where(fil => fil.Id.ToString().Contains(key)
                    || fil.Name.ToLower().Contains(key.ToLower()));
                }
                return new { Items = data.Skip(skip).Take(top), Count = count };
            }
            return data;
        }

        [HttpPost]
        public void Post([FromBody] Organization organization)
        {
            db.AddOrganization(organization);
        }

        [HttpPut]
        public object Put([FromBody] Organization organization)
        {
            db.UpdateOrganization(organization);
            return organization;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeleteOrganization(id);
        }
    }
}
