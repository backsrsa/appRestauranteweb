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
    public class CocinerosController : ApiController
    {
        private appEntities db = new appEntities();

        //get all cliente
        [HttpGet]
        public IEnumerable<tblCocinero> Get()
        {
            return db.tblCocineroes.AsEnumerable();
        }

        //get client by id
        public tblCocinero Get(int id)
        {
            tblCocinero cocinero = db.tblCocineroes.Find(id);
            if (cocinero == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return cocinero;
        }
        //insert client
        public HttpResponseMessage Post(tblCocinero cocinero)
        {
            if (ModelState.IsValid)
            {
                db.tblCocineroes.Add(cocinero);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cocinero);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = cocinero.IdCocinero }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        //update client
        public HttpResponseMessage Put(int id, tblCocinero cocinero)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != cocinero.IdCocinero)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(cocinero).State = EntityState.Modified;
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
            tblCocinero cocinero = db.tblCocineroes.Find(id);
            if (cocinero == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.tblCocineroes.Remove(cocinero);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, cocinero);
        }
        //prevent memory leak
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}