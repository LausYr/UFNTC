using Directory.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Directory.WebAPI.DataAccess
{
    public class OrganizationLayer
    {

        private readonly ApplicationContext db;
        public OrganizationLayer(ApplicationContext _db)
        {
            db = _db;
        }

        public DbSet<Organization> GetAllOrganization()
        {
            try
            {
                return db.Organizations;
            }
            catch
            {
                throw;
            }
        }
        public void AddOrganization(Organization organization)
        {
            try
            {
                db.Organizations.Add(organization);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UpdateOrganization(Organization organization)
        {
            try
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void DeleteOrganization(int id)
        {
            try
            {
                Organization org = db.Organizations.Find(id);
                var sub = db.Subdivisions.Where(s => s.OrganizationId == id);
                
                foreach (Subdivision subdivision in sub) {
                   db.Subdivisions.Remove(subdivision);
                }
                db.Organizations.Remove(org);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}