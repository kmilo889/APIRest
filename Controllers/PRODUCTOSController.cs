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
//using WebApiOauth2.Models;

namespace APIRest.Controllers
{
    public class PRODUCTOSController : ApiController
    {
      //  ModeloUsuario modelo;
        //public PRODUCTOSController() {
        //    modelo = new ModeloUsuario();
        //}
        private Modelo db = new Modelo();
        [Authorize(Roles = "ADMINISTRADOR")]
        // GET: api/PRODUCTOS
        public IQueryable<PRODUCTOS> GetPRODUCTOS()
        {
            return db.PRODUCTOS;
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        // GET: api/PRODUCTOS/5
        [ResponseType(typeof(PRODUCTOS))]
        public async Task<IHttpActionResult> GetPRODUCTOS(int id)
        {
            PRODUCTOS pRODUCTOS = await db.PRODUCTOS.FindAsync(id);
            if (pRODUCTOS == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTOS);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        // PUT: api/PRODUCTOS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPRODUCTOS(int id, PRODUCTOS pRODUCTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCTOS.ProID)
            {
                return BadRequest();
            }

            db.Entry(pRODUCTOS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTOSExists(id))
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

        [Authorize(Roles = "ADMINISTRADOR")]
        // POST: api/PRODUCTOS
        [ResponseType(typeof(PRODUCTOS))]
        public async Task<IHttpActionResult> PostPRODUCTOS(PRODUCTOS pRODUCTOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTOS.Add(pRODUCTOS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PRODUCTOSExists(pRODUCTOS.ProID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pRODUCTOS.ProID }, pRODUCTOS);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        // DELETE: api/PRODUCTOS/5
        [ResponseType(typeof(PRODUCTOS))]
        public async Task<IHttpActionResult> DeletePRODUCTOS(int id)
        {
            PRODUCTOS pRODUCTOS = await db.PRODUCTOS.FindAsync(id);
            if (pRODUCTOS == null)
            {
                return NotFound();
            }

            db.PRODUCTOS.Remove(pRODUCTOS);
            await db.SaveChangesAsync();

            return Ok(pRODUCTOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTOSExists(int id)
        {
            return db.PRODUCTOS.Count(e => e.ProID == id) > 0;
        }
    }
}