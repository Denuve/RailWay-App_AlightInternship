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
    public class TrainsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Trains
        public IQueryable<Train> GetTrains()
        {
            return db.Trains;
        }

        // GET: api/Trains/5
        [ResponseType(typeof(Train))]
        public async Task<IHttpActionResult> GetTrain(Guid id)
        {
            Train train = await db.Trains.FindAsync(id);
            if (train == null)
            {
                return NotFound();
            }

            return Ok(train);
        }

        // PUT: api/Trains/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrain(Guid id, Train train)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != train.Id)
            {
                return BadRequest();
            }

            db.Entry(train).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainExists(id))
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

        // POST: api/Trains
        [ResponseType(typeof(Train))]
        public async Task<IHttpActionResult> PostTrain(Train train)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            train.Id = Guid.NewGuid();

            db.Trains.Add(train);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainExists(train.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = train.Id }, train);
        }

        // DELETE: api/Trains/5
        [ResponseType(typeof(Train))]
        public async Task<IHttpActionResult> DeleteTrain(Guid id)
        {
            Train train = await db.Trains.FindAsync(id);
            if (train == null)
            {
                return NotFound();
            }

            db.Trains.Remove(train);
            await db.SaveChangesAsync();

            return Ok(train);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainExists(Guid id)
        {
            return db.Trains.Count(e => e.Id == id) > 0;
        }
    }
}