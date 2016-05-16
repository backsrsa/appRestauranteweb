using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppRestaurant.Models;

namespace AppRestaurant.Controllers
{
    public class FacturaController : Controller
    {
        private appEntities db = new appEntities();

        // GET: Factura
        public async Task<ActionResult> Index()
        {
            var tblFacturas = db.tblFacturas.Include(t => t.tblCamarero).Include(t => t.tblCliente).Include(t => t.tblMesa);
            return View(await tblFacturas.ToListAsync());
        }

        // GET: Factura/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFactura tblFactura = await db.tblFacturas.FindAsync(id);
            if (tblFactura == null)
            {
                return HttpNotFound();
            }
            return View(tblFactura);
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            ViewBag.IdCamarero = new SelectList(db.tblCamareroes, "IdCamarero", "Nombres");
            ViewBag.IdCliente = new SelectList(db.tblClientes, "IdCliente", "Nombres");
            ViewBag.IdMesa = new SelectList(db.tblMesas, "IdMesa", "Ubicacion");
            return View();
        }

        // POST: Factura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdFactura,IdCliente,IdCamarero,IdMesa,FechaFactura")] tblFactura tblFactura)
        {
            if (ModelState.IsValid)
            {
                db.tblFacturas.Add(tblFactura);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCamarero = new SelectList(db.tblCamareroes, "IdCamarero", "Nombres", tblFactura.IdCamarero);
            ViewBag.IdCliente = new SelectList(db.tblClientes, "IdCliente", "Nombres", tblFactura.IdCliente);
            ViewBag.IdMesa = new SelectList(db.tblMesas, "IdMesa", "Ubicacion", tblFactura.IdMesa);
            return View(tblFactura);
        }

        // GET: Factura/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFactura tblFactura = await db.tblFacturas.FindAsync(id);
            if (tblFactura == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCamarero = new SelectList(db.tblCamareroes, "IdCamarero", "Nombres", tblFactura.IdCamarero);
            ViewBag.IdCliente = new SelectList(db.tblClientes, "IdCliente", "Nombres", tblFactura.IdCliente);
            ViewBag.IdMesa = new SelectList(db.tblMesas, "IdMesa", "Ubicacion", tblFactura.IdMesa);
            return View(tblFactura);
        }

        // POST: Factura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdFactura,IdCliente,IdCamarero,IdMesa,FechaFactura")] tblFactura tblFactura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFactura).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCamarero = new SelectList(db.tblCamareroes, "IdCamarero", "Nombres", tblFactura.IdCamarero);
            ViewBag.IdCliente = new SelectList(db.tblClientes, "IdCliente", "Nombres", tblFactura.IdCliente);
            ViewBag.IdMesa = new SelectList(db.tblMesas, "IdMesa", "Ubicacion", tblFactura.IdMesa);
            return View(tblFactura);
        }

        // GET: Factura/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFactura tblFactura = await db.tblFacturas.FindAsync(id);
            if (tblFactura == null)
            {
                return HttpNotFound();
            }
            return View(tblFactura);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblFactura tblFactura = await db.tblFacturas.FindAsync(id);
            db.tblFacturas.Remove(tblFactura);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
