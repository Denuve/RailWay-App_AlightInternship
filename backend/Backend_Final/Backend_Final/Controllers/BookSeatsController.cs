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
using Backend_Final.Data;
using Backend_Final.Models;

namespace Backend_Final.Controllers
{
    public class BookSeatsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BookSeats
        public IQueryable<BookSeats> GetBookSeats()
        {
            return db.BookSeats;
        }

        // GET: api/BookSeats/5
        [ResponseType(typeof(BookSeats))]
        public async Task<IHttpActionResult> GetBookSeats(Guid id)
        {
            BookSeats bookSeats = await db.BookSeats.FindAsync(id);
            if (bookSeats == null)
            {
                return NotFound();
            }

            return Ok(bookSeats);
        }

        // PUT: api/BookSeats/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookSeats(Guid id, BookSeats bookSeats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookSeats.Id)
            {
                return BadRequest();
            }

            db.Entry(bookSeats).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookSeatsExists(id))
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

        // POST: api/BookSeats
        [ResponseType(typeof(BookSeats))]
        public async Task<IHttpActionResult> PostBookSeats(BookSeats bookSeats)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bookSeats.Id = Guid.NewGuid();

            db.BookSeats.Add(bookSeats);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookSeatsExists(bookSeats.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bookSeats.Id }, bookSeats);
        }

        // DELETE: api/BookSeats/5
        [ResponseType(typeof(BookSeats))]
        public async Task<IHttpActionResult> DeleteBookSeats(Guid id)
        {
            BookSeats bookSeats = await db.BookSeats.FindAsync(id);
            if (bookSeats == null)
            {
                return NotFound();
            }

            db.BookSeats.Remove(bookSeats);
            await db.SaveChangesAsync();

            return Ok(bookSeats);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookSeatsExists(Guid id)
        {
            return db.BookSeats.Count(e => e.Id == id) > 0;
        }
    }
}