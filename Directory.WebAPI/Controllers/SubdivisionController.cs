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
    public class SubdivisionController : ControllerBase
    {
        private readonly SubdivisionLayer db;
        public SubdivisionController(ApplicationContext _db)
        {
            db = new SubdivisionLayer(_db);
        }

        [HttpGet]
        public object Get()
        {
            IQueryable<Subdivision> data = db.GetAllSubdivision().AsQueryable();
            var count = data.Count();
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
                        data = data.Where(f => f.OrganizationId == fltr).AsQueryable();
                    }
                }
                catch
                {
                    if (search != null)
                    {
                        string key = search.Split(" or ")[^1];
                        key = search.Split("'")[key.Split(",").Length - 1];
                        data = data.Where(fil => fil.Id.ToString().Contains(key)
                        || fil.Name.ToLower().Contains(key.ToLower()));
                    }
                }
                return new { Items = data.Skip(skip).Take(top), Count = count };
            }
            return data;
        }

        [HttpPost]
        public void Post([FromBody] Subdivision subdivision)
        {
            db.AddSubdivision(subdivision);
        }

        [HttpPut]
        public object Put([FromBody] Subdivision subdivision)
        {
            db.UpdateSubdivision(subdivision);
            return subdivision;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeleteSubdivision(id);
        }
    }
}
