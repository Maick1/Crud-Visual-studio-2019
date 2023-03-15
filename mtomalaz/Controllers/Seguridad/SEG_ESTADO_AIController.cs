using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mtomalaz.DataBAse;

namespace mtomalaz.Controllers.Seguridad
{
    public class SEG_ESTADO_AIController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: SEG_ESTADO_AI
        public async Task<ActionResult> Index()
        {
            var sEG_ESTADO_AI = db.SEG_ESTADO_AI.Include(s => s.SEG_EMPRESA1).Include(s => s.SEG_USUARIO).Include(s => s.SEG_USUARIO1);
            return View(await sEG_ESTADO_AI.ToListAsync());
        }

        // GET: SEG_ESTADO_AI/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_ESTADO_AI sEG_ESTADO_AI = await db.SEG_ESTADO_AI.FindAsync(id);
            if (sEG_ESTADO_AI == null)
            {
                return HttpNotFound();
            }
            return View(sEG_ESTADO_AI);
        }

        // GET: SEG_ESTADO_AI/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: SEG_ESTADO_AI/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Seg_EstadoAI_Id,EMP_Id_Empresa,Gen_PrmSn_Descripcion,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_ESTADO_AI sEG_ESTADO_AI)
        {
            if (ModelState.IsValid)
            {
                db.SEG_ESTADO_AI.Add(sEG_ESTADO_AI);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_ESTADO_AI.EMP_Id_Empresa);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ESTADO_AI.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ESTADO_AI.Aud_Usuario_Modifica);
            return View(sEG_ESTADO_AI);
        }

        // GET: SEG_ESTADO_AI/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_ESTADO_AI sEG_ESTADO_AI = await db.SEG_ESTADO_AI.FindAsync(id);
            if (sEG_ESTADO_AI == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_ESTADO_AI.EMP_Id_Empresa);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ESTADO_AI.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ESTADO_AI.Aud_Usuario_Modifica);
            return View(sEG_ESTADO_AI);
        }

        // POST: SEG_ESTADO_AI/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Seg_EstadoAI_Id,EMP_Id_Empresa,Gen_PrmSn_Descripcion,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_ESTADO_AI sEG_ESTADO_AI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEG_ESTADO_AI).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_ESTADO_AI.EMP_Id_Empresa);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ESTADO_AI.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ESTADO_AI.Aud_Usuario_Modifica);
            return View(sEG_ESTADO_AI);
        }

        // GET: SEG_ESTADO_AI/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_ESTADO_AI sEG_ESTADO_AI = await db.SEG_ESTADO_AI.FindAsync(id);
            if (sEG_ESTADO_AI == null)
            {
                return HttpNotFound();
            }
            return View(sEG_ESTADO_AI);
        }

        // POST: SEG_ESTADO_AI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SEG_ESTADO_AI sEG_ESTADO_AI = await db.SEG_ESTADO_AI.FindAsync(id);
            db.SEG_ESTADO_AI.Remove(sEG_ESTADO_AI);
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
