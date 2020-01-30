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
    public class RolesController : Controller
    {
        private carreteras_finalEntities db = new carreteras_finalEntities();

        // GET: Roles
        public ActionResult Index()
        {
            var tb_roles = db.tb_roles.Include(t => t.tb_usuarios).Include(t => t.tb_usuarios1);
            return View(tb_roles.ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_roles tb_roles = db.tb_roles.Find(id);
            if (tb_roles == null)
            {
                return HttpNotFound();
            }
            return View(tb_roles);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            ViewBag.rol_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            ViewBag.rol_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion");
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "rol_id,rol_descripcion,rol_usuario_crea,rol_fecha_crea,rol_usuario_modifica,rol_fecha_modifica,rol_estado")] tb_roles tb_roles)
        {
            if (ModelState.IsValid)
            {
                db.tb_roles.Add(tb_roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rol_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_roles.rol_usuario_crea);
            ViewBag.rol_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_roles.rol_usuario_modifica);
            return View(tb_roles);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_roles tb_roles = db.tb_roles.Find(id);
            if (tb_roles == null)
            {
                return HttpNotFound();
            }
            ViewBag.rol_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_roles.rol_usuario_crea);
            ViewBag.rol_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_roles.rol_usuario_modifica);
            return View(tb_roles);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "rol_id,rol_descripcion,rol_usuario_crea,rol_fecha_crea,rol_usuario_modifica,rol_fecha_modifica,rol_estado")] tb_roles tb_roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rol_usuario_crea = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_roles.rol_usuario_crea);
            ViewBag.rol_usuario_modifica = new SelectList(db.tb_usuarios, "usu_id", "usu_descripcion", tb_roles.rol_usuario_modifica);
            return View(tb_roles);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_roles tb_roles = db.tb_roles.Find(id);
            if (tb_roles == null)
            {
                return HttpNotFound();
            }
            return View(tb_roles);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_roles tb_roles = db.tb_roles.Find(id);
            db.tb_roles.Remove(tb_roles);
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
