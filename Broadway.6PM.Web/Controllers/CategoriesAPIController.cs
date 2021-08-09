using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Broadway._6PM.Web.Models;

namespace Broadway._6PM.Web.Controllers
{
    [Authorize]
    public class CategoriesAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CategoriesAPI
        public IQueryable<Categories> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/CategoriesAPI/5
        [ResponseType(typeof(Categories))]
        public async Task<IHttpActionResult> GetCategories(int id)
        {
            Categories categories = await db.Categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        // PUT: api/CategoriesAPI/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategories(int id, Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categories.Id)
            {
                return BadRequest();
            }

            db.Entry(categories).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CategoriesAPI
        [ResponseType(typeof(Categories))]
        public async Task<IHttpActionResult> PostCategories(Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(categories);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categories.Id }, categories);
        }

        // DELETE: api/CategoriesAPI/5
        [ResponseType(typeof(Categories))]
        public async Task<IHttpActionResult> DeleteCategories(int id)
        {
            Categories categories = await db.Categories.FindAsync(id);
            if (categories == null)
            {
                return NotFound();
            }

            db.Categories.Remove(categories);
            await db.SaveChangesAsync();

            return Ok(categories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriesExists(int id)
        {
            return db.Categories.Count(e => e.Id == id) > 0;
        }
    }
}