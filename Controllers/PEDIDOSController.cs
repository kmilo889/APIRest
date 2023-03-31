
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
using APIRest.Models;

namespace APIRest.Controllers
{
    public class PEDIDOSController : ApiController
    {
        private Modelo db = new Modelo();

        // GET: api/PEDIDOS
        public IQueryable<PEDIDOS> GetPEDIDOS()
        
        {
            return db.PEDIDOS;
        }

        // GET: api/PEDIDOS/5
        [ResponseType(typeof(PEDIDOS))]
        public async Task<IHttpActionResult> GetPEDIDOS(int id)
        {
            PEDIDOS pEDIDOS = await db.PEDIDOS.FindAsync(id);
            if (pEDIDOS == null)
            {
                return NotFound();
            }

            return Ok(pEDIDOS);
        }

        // PUT: api/PEDIDOS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPEDIDOS(int id, PEDIDOS pEDIDOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pEDIDOS.PedID)
            {
                return BadRequest();
            }

            db.Entry(pEDIDOS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PEDIDOSExists(id))
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

        // POST: api/PEDIDOS
        [ResponseType(typeof(PEDIDOS))]
        public async Task<IHttpActionResult> PostPEDIDOS(PEDIDOS pEDIDOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PEDIDOS.Add(pEDIDOS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PEDIDOSExists(pEDIDOS.PedID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pEDIDOS.PedID }, pEDIDOS);
        }

        // DELETE: api/PEDIDOS/5
        [ResponseType(typeof(PEDIDOS))]
        public async Task<IHttpActionResult> DeletePEDIDOS(int id)
        {
            PEDIDOS pEDIDOS = await db.PEDIDOS.FindAsync(id);
            if (pEDIDOS == null)
            {
                return NotFound();
            }

            db.PEDIDOS.Remove(pEDIDOS);
            await db.SaveChangesAsync();

            return Ok(pEDIDOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PEDIDOSExists(int id)
        {
            return db.PEDIDOS.Count(e => e.PedID == id) > 0;
        }
    }
}