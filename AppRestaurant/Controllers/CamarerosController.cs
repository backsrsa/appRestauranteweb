using AppRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppRestaurant.Controllers
{
    public class CamarerosController : ApiController
    {
        private appEntities db = new appEntities();

        //get all cliente
        [HttpGet]
        public IEnumerable<tblCamarero> Get()
        {
            return db.tblCamareroes.AsEnumerable();
        }

        //get client by id
        public tblCamarero Get(int id)
        {
            tblCamarero camarero = db.tblCamareroes.Find(id);
            if (camarero == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return camarero;
        }
        //insert client
        public HttpResponseMessage Post(tblCamarero camarero)
        {
            if (ModelState.IsValid)
            {
                db.tblCamareroes.Add(camarero);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, camarero);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = camarero.IdCamarero }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        //update client
        public HttpResponseMessage Put(int id, tblCamarero camarero)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != camarero.IdCamarero)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(camarero).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        //delete client by id
        public HttpResponseMessage Delete(int id)
        {
            tblCamarero camarero = db.tblCamareroes.Find(id);
            if (camarero == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.tblCamareroes.Remove(camarero);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, camarero);
        }
        //prevent memory leak
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}