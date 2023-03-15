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
    public class SEG_CENTRO_COSTOController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: SEG_CENTRO_COSTO
        public async Task<ActionResult> Index()
        {
            var sEG_CENTRO_COSTO = db.SEG_CENTRO_COSTO.Include(s => s.SEG_EMPRESA).Include(s => s.SEG_ESTADO_AI).Include(s => s.SEG_USUARIO).Include(s => s.SEG_USUARIO1);
            return View(await sEG_CENTRO_COSTO.ToListAsync());
        }

        // GET: SEG_CENTRO_COSTO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_CENTRO_COSTO sEG_CENTRO_COSTO = await db.SEG_CENTRO_COSTO.FindAsync(id);
            if (sEG_CENTRO_COSTO == null)
            {
                return HttpNotFound();
            }
            return View(sEG_CENTRO_COSTO);
        }

        // GET: SEG_CENTRO_COSTO/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: SEG_CENTRO_COSTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SEG_CENTRO_COSTO_Id,EMP_Id_Empresa,CEN_Id_Costo,CEN_Descripcion,CEN_Costo,CEN_Estado,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_CENTRO_COSTO sEG_CENTRO_COSTO)
        {
            if (ModelState.IsValid)
            {
                db.SEG_CENTRO_COSTO.Add(sEG_CENTRO_COSTO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_CENTRO_COSTO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_CENTRO_COSTO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_CENTRO_COSTO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_CENTRO_COSTO.Aud_Usuario_Modifica);
            return View(sEG_CENTRO_COSTO);
        }

        // GET: SEG_CENTRO_COSTO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_CENTRO_COSTO sEG_CENTRO_COSTO = await db.SEG_CENTRO_COSTO.FindAsync(id);
            if (sEG_CENTRO_COSTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_CENTRO_COSTO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_CENTRO_COSTO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_CENTRO_COSTO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_CENTRO_COSTO.Aud_Usuario_Modifica);
            return View(sEG_CENTRO_COSTO);
        }

        // POST: SEG_CENTRO_COSTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SEG_CENTRO_COSTO_Id,EMP_Id_Empresa,CEN_Id_Costo,CEN_Descripcion,CEN_Costo,CEN_Estado,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_CENTRO_COSTO sEG_CENTRO_COSTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEG_CENTRO_COSTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_CENTRO_COSTO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_CENTRO_COSTO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_CENTRO_COSTO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_CENTRO_COSTO.Aud_Usuario_Modifica);
            return View(sEG_CENTRO_COSTO);
        }

        // GET: SEG_CENTRO_COSTO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_CENTRO_COSTO sEG_CENTRO_COSTO = await db.SEG_CENTRO_COSTO.FindAsync(id);
            if (sEG_CENTRO_COSTO == null)
            {
                return HttpNotFound();
            }
            return View(sEG_CENTRO_COSTO);
        }

        // POST: SEG_CENTRO_COSTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SEG_CENTRO_COSTO sEG_CENTRO_COSTO = await db.SEG_CENTRO_COSTO.FindAsync(id);
            db.SEG_CENTRO_COSTO.Remove(sEG_CENTRO_COSTO);
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
