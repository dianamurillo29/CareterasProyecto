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
    public class tb_departamentosController : Controller
    {
        private carreteras_finalEntities db = new carreteras_finalEntities();

        // GET: tb_departamentos
        public ActionResult Index()
        {
            var tb_departamentos = db.tb_departamentos.Include(t => t.tb_usuarios).Include(t => t.tb_usuarios1);
            return View(tb_departamentos.ToList());
        }

        // GET: tb_departamentos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_departamentos tb_departamentos = db.tb_departamentos.Find(id);
            if (tb_departamentos == null)
            {
                return HttpNotFound();
            }
            return View(tb_departamentos);
        }

        // GET: tb_departamentos/Create
        public ActionResult Create()
        {
            ViewBag.dep_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            ViewBag.dep_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            return View();
        }

        // POST: tb_departamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dep_id,dep_descripcion,dep_usuario_crea,dep_fecha_crea,dep_usuario_modifica,dep_fecha_modifica,dep_estado")] tb_departamentos tb_departamentos)
        {
            if (ModelState.IsValid)
            {
                db.tb_departamentos.Add(tb_departamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dep_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_crea);
            ViewBag.dep_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_modifica);
            return View(tb_departamentos);
        }

        // GET: tb_departamentos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_departamentos tb_departamentos = db.tb_departamentos.Find(id);
            if (tb_departamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.dep_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_crea);
            ViewBag.dep_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_modifica);
            return View(tb_departamentos);
        }

        // POST: tb_departamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dep_id,dep_descripcion,dep_usuario_crea,dep_fecha_crea,dep_usuario_modifica,dep_fecha_modifica,dep_estado")] tb_departamentos tb_departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_departamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dep_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_crea);
            ViewBag.dep_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_departamentos.dep_usuario_modifica);
            return View(tb_departamentos);
        }

        // GET: tb_departamentos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_departamentos tb_departamentos = db.tb_departamentos.Find(id);
            if (tb_departamentos == null)
            {
                return HttpNotFound();
            }
            return View(tb_departamentos);
        }

        // POST: tb_departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_departamentos tb_departamentos = db.tb_departamentos.Find(id);
            db.tb_departamentos.Remove(tb_departamentos);
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
