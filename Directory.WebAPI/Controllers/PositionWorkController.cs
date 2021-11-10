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
    public class PositionWorkController : ControllerBase
    {
        private readonly PositionWorkLayer db;
        public PositionWorkController(ApplicationContext _db)
        {

            db = new PositionWorkLayer(_db);
        }

        [HttpGet]
        public object Get()
        {
            IQueryable<PositionWork> data = db.GetAllPositionWork().AsQueryable();
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
        public void Post([FromBody] PositionWork positionWork)
        {
            db.AddPositionWork(positionWork);
        }

        [HttpPut]
        public object Put([FromBody] PositionWork positionWork)
        {
            db.UpdatePositionWork(positionWork);
            return positionWork;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeletePositionWork(id);
        }
    }
}

