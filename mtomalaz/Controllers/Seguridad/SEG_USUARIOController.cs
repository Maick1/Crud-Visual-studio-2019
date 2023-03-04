using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mtomalaz.DataBAse;

namespace mtomalaz.Controllers
{
    public class SEG_USUARIOController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: SEG_USUARIO
        public ActionResult Index()
        {
            var sEG_USUARIO = db.SEG_USUARIO.Include(s => s.SEG_EMPRESA2).Include(s => s.SEG_ESTADO_AI2);
            return View(sEG_USUARIO.ToList());
        }

        // GET: SEG_USUARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_USUARIO sEG_USUARIO = db.SEG_USUARIO.Find(id);
            if (sEG_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(sEG_USUARIO);
        }

        // GET: SEG_USUARIO/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            return View();
        }

        // POST: SEG_USUARIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Seg_Usr_Id,EMP_Id_Empresa,USU_Login,ENT_Id_Entidad,USU_Password,USU_Discoduro,USU_Ip,USU_Creacion,USU_Activacion,USU_Fechabaja,Aud_EstadoAI_Id")] SEG_USUARIO sEG_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.SEG_USUARIO.Add(sEG_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_USUARIO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_USUARIO.Aud_EstadoAI_Id);
            return View(sEG_USUARIO);
        }

        // GET: SEG_USUARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_USUARIO sEG_USUARIO = db.SEG_USUARIO.Find(id);
            if (sEG_USUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_USUARIO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_USUARIO.Aud_EstadoAI_Id);
            return View(sEG_USUARIO);
        }

        // POST: SEG_USUARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Seg_Usr_Id,EMP_Id_Empresa,USU_Login,ENT_Id_Entidad,USU_Password,USU_Discoduro,USU_Ip,USU_Creacion,USU_Activacion,USU_Fechabaja,Aud_EstadoAI_Id")] SEG_USUARIO sEG_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEG_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_USUARIO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_USUARIO.Aud_EstadoAI_Id);
            return View(sEG_USUARIO);
        }

        // GET: SEG_USUARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_USUARIO sEG_USUARIO = db.SEG_USUARIO.Find(id);
            if (sEG_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(sEG_USUARIO);
        }

        // POST: SEG_USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SEG_USUARIO sEG_USUARIO = db.SEG_USUARIO.Find(id);
            db.SEG_USUARIO.Remove(sEG_USUARIO);
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
