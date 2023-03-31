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
    public class USUARIOSController : ApiController
    {
        private readonly Modelo db = new Modelo();

             // GET: api/USUARIOS
             //HttpGet]
       public IQueryable<USUARIOS> GetUSUARIOS()
        {
           return db.USUARIOS;
        }
        // GET: api/USUARIOS
       //HttpGet]
        //public IEnumerable<USUARIOS> GetUSUARIOS() {

        //    var Listado = db.USUARIOS.ToList();
        //    return Listado;
        //}
        // GET: api/USUARIOS/5
        [ResponseType(typeof(USUARIOS))]
        public async Task<IHttpActionResult> GetUSUARIOS(int id)
        {
            USUARIOS uSUARIOS = await db.USUARIOS.FindAsync(id);
            if (uSUARIOS == null)
            {
                return NotFound();
            }

            return Ok(uSUARIOS);
        }

        // PUT: api/USUARIOS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUSUARIOS(int id, USUARIOS uSUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSUARIOS.UsuID)
            {
                return BadRequest();
            }

            db.Entry(uSUARIOS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USUARIOSExists(id))
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

        // POST: api/USUARIOS
        [ResponseType(typeof(USUARIOS))]
        public async Task<IHttpActionResult> PostUSUARIOS(USUARIOS uSUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USUARIOS.Add(uSUARIOS);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (USUARIOSExists(uSUARIOS.UsuID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = uSUARIOS.UsuID }, uSUARIOS);
        }

        // DELETE: api/USUARIOS/5
        [ResponseType(typeof(USUARIOS))]
        public async Task<IHttpActionResult> DeleteUSUARIOS(int id)
        {
            USUARIOS uSUARIOS = await db.USUARIOS.FindAsync(id);
            if (uSUARIOS == null)
            {
                return NotFound();
            }

            db.USUARIOS.Remove(uSUARIOS);
            await db.SaveChangesAsync();

            return Ok(uSUARIOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USUARIOSExists(int id)
        {
            return db.USUARIOS.Count(e => e.UsuID == id) > 0;
        }
    }
}