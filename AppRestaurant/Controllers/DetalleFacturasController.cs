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
    public class DetalleFacturasController : Controller
    {
        private appEntities db = new appEntities();

        // GET: DetalleFacturas
        public async Task<ActionResult> Index()
        {
            var tblDetalleFacturas = db.tblDetalleFacturas.Include(t => t.tblCocinero).Include(t => t.tblFactura);
            return View(await tblDetalleFacturas.ToListAsync());
        }

        // GET: DetalleFacturas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDetalleFactura tblDetalleFactura = await db.tblDetalleFacturas.FindAsync(id);
            if (tblDetalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(tblDetalleFactura);
        }

        // GET: DetalleFacturas/Create
        public ActionResult Create()
        {
            ViewBag.IdCocinero = new SelectList(db.tblCocineroes, "IdCocinero", "Nombres");
            ViewBag.IdFactura = new SelectList(db.tblFacturas, "IdFactura", "IdFactura");
            return View();
        }

        // POST: DetalleFacturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdDetalleFactura,IdFactura,IdCocinero,Plato,Importe")] tblDetalleFactura tblDetalleFactura)
        {
            if (ModelState.IsValid)
            {
                db.tblDetalleFacturas.Add(tblDetalleFactura);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCocinero = new SelectList(db.tblCocineroes, "IdCocinero", "Nombres", tblDetalleFactura.IdCocinero);
            ViewBag.IdFactura = new SelectList(db.tblFacturas, "IdFactura", "IdFactura", tblDetalleFactura.IdFactura);
            return View(tblDetalleFactura);
        }

        // GET: DetalleFacturas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDetalleFactura tblDetalleFactura = await db.tblDetalleFacturas.FindAsync(id);
            if (tblDetalleFactura == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCocinero = new SelectList(db.tblCocineroes, "IdCocinero", "Nombres", tblDetalleFactura.IdCocinero);
            ViewBag.IdFactura = new SelectList(db.tblFacturas, "IdFactura", "IdFactura", tblDetalleFactura.IdFactura);
            return View(tblDetalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdDetalleFactura,IdFactura,IdCocinero,Plato,Importe")] tblDetalleFactura tblDetalleFactura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDetalleFactura).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCocinero = new SelectList(db.tblCocineroes, "IdCocinero", "Nombres", tblDetalleFactura.IdCocinero);
            ViewBag.IdFactura = new SelectList(db.tblFacturas, "IdFactura", "IdFactura", tblDetalleFactura.IdFactura);
            return View(tblDetalleFactura);
        }

        // GET: DetalleFacturas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDetalleFactura tblDetalleFactura = await db.tblDetalleFacturas.FindAsync(id);
            if (tblDetalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(tblDetalleFactura);
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblDetalleFactura tblDetalleFactura = await db.tblDetalleFacturas.FindAsync(id);
            db.tblDetalleFacturas.Remove(tblDetalleFactura);
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
