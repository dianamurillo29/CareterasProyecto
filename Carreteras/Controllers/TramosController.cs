using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Carreteras;

namespace Carreteras.Controllers
{
    public class TramosController : Controller
    {
        private carreteras_finalEntities db = new carreteras_finalEntities();

        // GET: Tramos
        public ActionResult Index()
        {
            var tb_tramos = db.tb_tramos.Include(t => t.tb_carreteras).Include(t => t.tb_usuarios).Include(t => t.tb_usuarios1);
            return View(tb_tramos.ToList());
        }

        // GET: Tramos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tramos tb_tramos = db.tb_tramos.Find(id);
            if (tb_tramos == null)
            {
                return HttpNotFound();
            }
            return View(tb_tramos);
        }

        // GET: Tramos/Create
        public ActionResult Create()
        {
            ViewBag.car_id = new SelectList(db.tb_carreteras, "car_id", "car_descripcion");
            ViewBag.tra_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            ViewBag.tra_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            return View();
        }

        // POST: Tramos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tra_id,tra_descripcion,tra_km_inicio,tra_km_fin,car_id,tra_usuario_crea,tra_fecha_crea,tra_usuario_modifica,tra_fecha_modifica,tra_estado")] tb_tramos tb_tramos)
        {
            if (ModelState.IsValid)
            {
                db.tb_tramos.Add(tb_tramos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.car_id = new SelectList(db.tb_carreteras, "car_id", "car_descripcion", tb_tramos.car_id);
            ViewBag.tra_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_tramos.tra_usuario_crea);
            ViewBag.tra_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_tramos.tra_usuario_modifica);
            return View(tb_tramos);
        }

        // GET: Tramos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tramos tb_tramos = db.tb_tramos.Find(id);
            if (tb_tramos == null)
            {
                return HttpNotFound();
            }
            ViewBag.car_id = new SelectList(db.tb_carreteras, "car_id", "car_descripcion", tb_tramos.car_id);
            ViewBag.tra_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_tramos.tra_usuario_crea);
            ViewBag.tra_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_tramos.tra_usuario_modifica);
            return View(tb_tramos);
        }

        // POST: Tramos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tra_id,tra_descripcion,tra_km_inicio,tra_km_fin,car_id,tra_usuario_crea,tra_fecha_crea,tra_usuario_modifica,tra_fecha_modifica,tra_estado")] tb_tramos tb_tramos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_tramos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.car_id = new SelectList(db.tb_carreteras, "car_id", "car_descripcion", tb_tramos.car_id);
            ViewBag.tra_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_tramos.tra_usuario_crea);
            ViewBag.tra_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_tramos.tra_usuario_modifica);
            return View(tb_tramos);
        }

        // GET: Tramos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tramos tb_tramos = db.tb_tramos.Find(id);
            if (tb_tramos == null)
            {
                return HttpNotFound();
            }
            return View(tb_tramos);
        }

        // POST: Tramos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_tramos tb_tramos = db.tb_tramos.Find(id);
            db.tb_tramos.Remove(tb_tramos);
            db.SaveChanges();
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
