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
    public class MesasController : ApiController
    {
        private appEntities db = new appEntities();

        //get all cliente
        [HttpGet]
        public IEnumerable<tblMesa> Get()
        {
            return db.tblMesas.AsEnumerable();
        }

        //get client by id
        public tblMesa Get(int id)
        {
            tblMesa mesa = db.tblMesas.Find(id);
            if (mesa == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return mesa;
        }
        //insert client
        public HttpResponseMessage Post(tblMesa mesa)
        {
            if (ModelState.IsValid)
            {
                db.tblMesas.Add(mesa);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created,mesa);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = mesa.IdMesa }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        //update client
        public HttpResponseMessage Put(int id, tblMesa mesa)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != mesa.IdMesa)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(mesa).State = EntityState.Modified;
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
            tblMesa mesa = db.tblMesas.Find(id);
            if (mesa == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.tblMesas.Remove(mesa);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, mesa);
        }
        //prevent memory leak
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}