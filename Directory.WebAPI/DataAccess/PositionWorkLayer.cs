using Directory.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Directory.WebAPI.DataAccess
{
    public class PositionWorkLayer
    {
        private readonly ApplicationContext db;
        public PositionWorkLayer(ApplicationContext _db)
        {
            db = _db;
        }

        public DbSet<PositionWork> GetAllPositionWork()
        {
            try
            {
                return db.PositionWorks;
            }
            catch
            {
                throw;
            }
        }
        public void AddPositionWork(PositionWork positionWork)
        {
            try
            {
                db.PositionWorks.Add(positionWork);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UpdatePositionWork(PositionWork positionWork)
        {
            try
            {
                db.Entry(positionWork).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void DeletePositionWork(int id)
        {
            try
            {
                PositionWork pos = db.PositionWorks.Find(id);
                db.PositionWorks.Remove(pos);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
