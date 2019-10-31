using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TendenciasControl.Models;

namespace TendenciasControl.Controllers
{
    public class PedidosController : Controller
    {
        private AppWebContext db = new AppWebContext();
        // GET: Pedidos
        public ActionResult Index()
        {
            var error = "";
            var pedido = new List<Pedido>();
            try
            {
                db.Database.Connection.Open();
                pedido = db.Pedidos.ToList();
                db.Database.Connection.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            ViewBag.Error = error;
            return View(pedido);
        }
        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db.Database.Connection.Open();
            Pedido pedido = db.Pedidos.Find(id);
            db.Database.Connection.Close();
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }
        // GET: Pedidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DescripcionPedido,NombreCliente,Latitud,Longitud,Foto,Precio,Domicilio")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {

                db.Database.Connection.Open();
                db.Pedidos.Add(pedido);
                db.SaveChanges();
                db.Database.Connection.Close();
                return RedirectToAction("Index");
            }

            return View(pedido);
        }
        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db.Database.Connection.Open();
            Pedido pedido = db.Pedidos.Find(id);

            db.Database.Connection.Close();
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }
        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DescripcionPedido,NombreCliente,Latitud,Longitud,Foto,Precio,Domicilio")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {

                db.Database.Connection.Open();
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();

                db.Database.Connection.Close();
                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db.Database.Connection.Open();
            Pedido pedido = db.Pedidos.Find(id);

            db.Database.Connection.Close();
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            db.Database.Connection.Open();
            Pedido pedido = db.Pedidos.Find(id);


            db.Pedidos.Remove(pedido);
            db.SaveChanges();
            db.Database.Connection.Close();
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