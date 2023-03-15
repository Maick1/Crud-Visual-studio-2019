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
    public class SEG_PROVINCIAController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: SEG_PROVINCIA
        public async Task<ActionResult> Index()
        {
            var sEG_PROVINCIA = db.SEG_PROVINCIA.Include(s => s.SEG_EMPRESA).Include(s => s.SEG_ESTADO_AI).Include(s => s.SEG_USUARIO).Include(s => s.SEG_USUARIO1);
            return View(await sEG_PROVINCIA.ToListAsync());
        }

        // GET: SEG_PROVINCIA/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_PROVINCIA sEG_PROVINCIA = await db.SEG_PROVINCIA.FindAsync(id);
            if (sEG_PROVINCIA == null)
            {
                return HttpNotFound();
            }
            return View(sEG_PROVINCIA);
        }

        // GET: SEG_PROVINCIA/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: SEG_PROVINCIA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SEG_PROVINCIA_Id,EMP_Id_Empresa,PAI_Id_Pais,PRO_Id_Provin,PRO_Region,PRO_Descripcion,PRO_Estado,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_PROVINCIA sEG_PROVINCIA)
        {
            if (ModelState.IsValid)
            {
                db.SEG_PROVINCIA.Add(sEG_PROVINCIA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_PROVINCIA.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_PROVINCIA.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_PROVINCIA.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_PROVINCIA.Aud_Usuario_Modifica);
            return View(sEG_PROVINCIA);
        }

        // GET: SEG_PROVINCIA/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_PROVINCIA sEG_PROVINCIA = await db.SEG_PROVINCIA.FindAsync(id);
            if (sEG_PROVINCIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_PROVINCIA.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_PROVINCIA.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_PROVINCIA.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_PROVINCIA.Aud_Usuario_Modifica);
            return View(sEG_PROVINCIA);
        }

        // POST: SEG_PROVINCIA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SEG_PROVINCIA_Id,EMP_Id_Empresa,PAI_Id_Pais,PRO_Id_Provin,PRO_Region,PRO_Descripcion,PRO_Estado,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_PROVINCIA sEG_PROVINCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEG_PROVINCIA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_PROVINCIA.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_PROVINCIA.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_PROVINCIA.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_PROVINCIA.Aud_Usuario_Modifica);
            return View(sEG_PROVINCIA);
        }

        // GET: SEG_PROVINCIA/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_PROVINCIA sEG_PROVINCIA = await db.SEG_PROVINCIA.FindAsync(id);
            if (sEG_PROVINCIA == null)
            {
                return HttpNotFound();
            }
            return View(sEG_PROVINCIA);
        }

        // POST: SEG_PROVINCIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SEG_PROVINCIA sEG_PROVINCIA = await db.SEG_PROVINCIA.FindAsync(id);
            db.SEG_PROVINCIA.Remove(sEG_PROVINCIA);
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
