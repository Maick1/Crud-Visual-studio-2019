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
    public class SEG_DEPARTAMENTOController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: SEG_DEPARTAMENTO
        public async Task<ActionResult> Index()
        {
            var sEG_DEPARTAMENTO = db.SEG_DEPARTAMENTO.Include(s => s.SEG_EMPRESA).Include(s => s.SEG_ESTADO_AI).Include(s => s.SEG_USUARIO).Include(s => s.SEG_USUARIO1);
            return View(await sEG_DEPARTAMENTO.ToListAsync());
        }

        // GET: SEG_DEPARTAMENTO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_DEPARTAMENTO sEG_DEPARTAMENTO = await db.SEG_DEPARTAMENTO.FindAsync(id);
            if (sEG_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(sEG_DEPARTAMENTO);
        }

        // GET: SEG_DEPARTAMENTO/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: SEG_DEPARTAMENTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SEG_DEPARTAMENTO_Id,EMP_Id_Empresa,DEP_Id_Departamento,DEP_Descripcion,DEP_Estado,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_DEPARTAMENTO sEG_DEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.SEG_DEPARTAMENTO.Add(sEG_DEPARTAMENTO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_DEPARTAMENTO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_DEPARTAMENTO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_DEPARTAMENTO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_DEPARTAMENTO.Aud_Usuario_Modifica);
            return View(sEG_DEPARTAMENTO);
        }

        // GET: SEG_DEPARTAMENTO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_DEPARTAMENTO sEG_DEPARTAMENTO = await db.SEG_DEPARTAMENTO.FindAsync(id);
            if (sEG_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_DEPARTAMENTO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_DEPARTAMENTO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_DEPARTAMENTO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_DEPARTAMENTO.Aud_Usuario_Modifica);
            return View(sEG_DEPARTAMENTO);
        }

        // POST: SEG_DEPARTAMENTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SEG_DEPARTAMENTO_Id,EMP_Id_Empresa,DEP_Id_Departamento,DEP_Descripcion,DEP_Estado,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_DEPARTAMENTO sEG_DEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEG_DEPARTAMENTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_DEPARTAMENTO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_DEPARTAMENTO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_DEPARTAMENTO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_DEPARTAMENTO.Aud_Usuario_Modifica);
            return View(sEG_DEPARTAMENTO);
        }

        // GET: SEG_DEPARTAMENTO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_DEPARTAMENTO sEG_DEPARTAMENTO = await db.SEG_DEPARTAMENTO.FindAsync(id);
            if (sEG_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(sEG_DEPARTAMENTO);
        }

        // POST: SEG_DEPARTAMENTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SEG_DEPARTAMENTO sEG_DEPARTAMENTO = await db.SEG_DEPARTAMENTO.FindAsync(id);
            db.SEG_DEPARTAMENTO.Remove(sEG_DEPARTAMENTO);
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
