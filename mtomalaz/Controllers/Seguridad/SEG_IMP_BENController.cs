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
    public class SEG_IMP_BENController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: SEG_IMP_BEN
        public async Task<ActionResult> Index()
        {
            var sEG_IMP_BEN = db.SEG_IMP_BEN.Include(s => s.SEG_EMPRESA).Include(s => s.SEG_ESTADO_AI).Include(s => s.SEG_USUARIO).Include(s => s.SEG_USUARIO1);
            return View(await sEG_IMP_BEN.ToListAsync());
        }

        // GET: SEG_IMP_BEN/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_IMP_BEN sEG_IMP_BEN = await db.SEG_IMP_BEN.FindAsync(id);
            if (sEG_IMP_BEN == null)
            {
                return HttpNotFound();
            }
            return View(sEG_IMP_BEN);
        }

        // GET: SEG_IMP_BEN/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: SEG_IMP_BEN/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SEG_IMP_BEN_Id,EMP_Id_Empresa,IMB_Id_Impben,IMB_Descripcion,IMB_Tipo,IMB_Porcentaje,IMB_Valor,IMB_Estado,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_IMP_BEN sEG_IMP_BEN)
        {
            if (ModelState.IsValid)
            {
                db.SEG_IMP_BEN.Add(sEG_IMP_BEN);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_IMP_BEN.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_IMP_BEN.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_IMP_BEN.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_IMP_BEN.Aud_Usuario_Modifica);
            return View(sEG_IMP_BEN);
        }

        // GET: SEG_IMP_BEN/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_IMP_BEN sEG_IMP_BEN = await db.SEG_IMP_BEN.FindAsync(id);
            if (sEG_IMP_BEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_IMP_BEN.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_IMP_BEN.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_IMP_BEN.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_IMP_BEN.Aud_Usuario_Modifica);
            return View(sEG_IMP_BEN);
        }

        // POST: SEG_IMP_BEN/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SEG_IMP_BEN_Id,EMP_Id_Empresa,IMB_Id_Impben,IMB_Descripcion,IMB_Tipo,IMB_Porcentaje,IMB_Valor,IMB_Estado,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_IMP_BEN sEG_IMP_BEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEG_IMP_BEN).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_IMP_BEN.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_IMP_BEN.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_IMP_BEN.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_IMP_BEN.Aud_Usuario_Modifica);
            return View(sEG_IMP_BEN);
        }

        // GET: SEG_IMP_BEN/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_IMP_BEN sEG_IMP_BEN = await db.SEG_IMP_BEN.FindAsync(id);
            if (sEG_IMP_BEN == null)
            {
                return HttpNotFound();
            }
            return View(sEG_IMP_BEN);
        }

        // POST: SEG_IMP_BEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SEG_IMP_BEN sEG_IMP_BEN = await db.SEG_IMP_BEN.FindAsync(id);
            db.SEG_IMP_BEN.Remove(sEG_IMP_BEN);
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
