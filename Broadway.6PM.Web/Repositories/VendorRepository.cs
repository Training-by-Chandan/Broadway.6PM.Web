using Broadway._6PM.Web.Models;
using Broadway._6PM.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Broadway._6PM.Web.Repositories
{
    public class VendorRepository : IBaseRepository<Vendors>
    {
        public ApplicationDbContext db;
        public VendorRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public ResponseViewModel Create(Vendors model)
        {
            throw new NotImplementedException();
        }

        public ResponseViewModel Delete(Vendors model)
        {
            throw new NotImplementedException();
        }

        public ResponseViewModel Edit(Vendors model)
        {
            throw new NotImplementedException();
        }

        public List<Vendors> GetAll()
        {
            return db.Vendors.ToList();
        }

        public Vendors GetById(object id)
        {
            return db.Vendors.Find(id);
        }
    }
}