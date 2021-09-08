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
using RailWayBackend.Data;
using RailWayBackend.Models;

namespace RailWayBackend.Controllers
{
    public class SeatsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Seats
        public IQueryable<Seat> GetSeats()
        {
            return db.Seats;
        }

        // GET: api/Seats/5
        [ResponseType(typeof(Seat))]
        public async Task<IHttpActionResult> GetSeat(Guid id)
        {
            Seat seat = await db.Seats.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }

            return Ok(seat);
        }

        // PUT: api/Seats/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSeat(Guid id, Seat seat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seat.Id)
            {
                return BadRequest();
            }

            db.Entry(seat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatExists(id))
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

        // POST: api/Seats
        [ResponseType(typeof(Seat))]
        public async Task<IHttpActionResult> PostSeat(Seat seat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Seats.Add(seat);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SeatExists(seat.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = seat.Id }, seat);
        }

        // DELETE: api/Seats/5
        [ResponseType(typeof(Seat))]
        public async Task<IHttpActionResult> DeleteSeat(Guid id)
        {
            Seat seat = await db.Seats.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }

            db.Seats.Remove(seat);
            await db.SaveChangesAsync();

            return Ok(seat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SeatExists(Guid id)
        {
            return db.Seats.Count(e => e.Id == id) > 0;
        }
    }
}