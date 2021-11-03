using Directory.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Directory.WebAPI.DataAccess
{
    public class SubdivisionLayer
    {

        private readonly ApplicationContext db;
        public SubdivisionLayer(ApplicationContext _db)
        {
            db = _db;
        }

        public DbSet<Subdivision> GetAllSubdivision()
        {
            try
            {
                return db.Subdivisions;
            }
            catch
            {
                throw;
            }
        }
        public void AddSubdivision(Subdivision subdivision)
        {
            try
            {
                db.Subdivisions.Add(subdivision);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UpdateSubdivision(Subdivision subdivision)
        {
            try
            {
                db.Entry(subdivision).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void DeleteSubdivision(int id)
        {
            try
            {
                Subdivision sub = db.Subdivisions.Find(id);
                db.Subdivisions.Remove(sub);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
