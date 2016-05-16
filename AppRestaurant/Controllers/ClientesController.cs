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
    
    public class ClientesController : ApiController
    {
        private appEntities db = new appEntities();
        
        //get all cliente
        [HttpGet]
        public IEnumerable<tblCliente> Get()
        {
            return db.tblClientes.AsEnumerable();
        }

        //get client by id
        public tblCliente Get(int id)
        {
            tblCliente cliente = db.tblClientes.Find(id);
            if (cliente == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return cliente;
        }
        //insert client
        public HttpResponseMessage Post(tblCliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.tblClientes.Add(cliente);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cliente);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = cliente.IdCliente }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        //update client
        public HttpResponseMessage Put(int id, tblCliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != cliente.IdCliente)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(cliente).State = EntityState.Modified;
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
            tblCliente customer = db.tblClientes.Find(id);
            if (customer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.tblClientes.Remove(customer);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
        //prevent memory leak
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
