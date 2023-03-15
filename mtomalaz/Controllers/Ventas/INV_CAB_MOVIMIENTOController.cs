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

namespace mtomalaz.Controllers.Ventas
{
    public class INV_CAB_MOVIMIENTOController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: INV_CAB_MOVIMIENTO
        public async Task<ActionResult> Index()
        {
            var iNV_CAB_MOVIMIENTO = db.INV_CAB_MOVIMIENTO.Include(i => i.SEG_EMPRESA).Include(i => i.SEG_ESTADO_AI).Include(i => i.SEG_USUARIO).Include(i => i.SEG_USUARIO1);
            return View(await iNV_CAB_MOVIMIENTO.ToListAsync());
        }

        // GET: INV_CAB_MOVIMIENTO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INV_CAB_MOVIMIENTO iNV_CAB_MOVIMIENTO = await db.INV_CAB_MOVIMIENTO.FindAsync(id);
            if (iNV_CAB_MOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            return View(iNV_CAB_MOVIMIENTO);
        }

        // GET: INV_CAB_MOVIMIENTO/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: INV_CAB_MOVIMIENTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MOV_Id_Movimiento,EMP_Id_Empresa,MOV_CAB_Fechamov,MOV_Observacion,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] INV_CAB_MOVIMIENTO iNV_CAB_MOVIMIENTO)
        {
            if (ModelState.IsValid)
            {
                db.INV_CAB_MOVIMIENTO.Add(iNV_CAB_MOVIMIENTO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", iNV_CAB_MOVIMIENTO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", iNV_CAB_MOVIMIENTO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_CAB_MOVIMIENTO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_CAB_MOVIMIENTO.Aud_Usuario_Modifica);
            return View(iNV_CAB_MOVIMIENTO);
        }

        // GET: INV_CAB_MOVIMIENTO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INV_CAB_MOVIMIENTO iNV_CAB_MOVIMIENTO = await db.INV_CAB_MOVIMIENTO.FindAsync(id);
            if (iNV_CAB_MOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", iNV_CAB_MOVIMIENTO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", iNV_CAB_MOVIMIENTO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_CAB_MOVIMIENTO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_CAB_MOVIMIENTO.Aud_Usuario_Modifica);
            return View(iNV_CAB_MOVIMIENTO);
        }

        // POST: INV_CAB_MOVIMIENTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MOV_Id_Movimiento,EMP_Id_Empresa,MOV_CAB_Fechamov,MOV_Observacion,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] INV_CAB_MOVIMIENTO iNV_CAB_MOVIMIENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNV_CAB_MOVIMIENTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", iNV_CAB_MOVIMIENTO.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", iNV_CAB_MOVIMIENTO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_CAB_MOVIMIENTO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_CAB_MOVIMIENTO.Aud_Usuario_Modifica);
            return View(iNV_CAB_MOVIMIENTO);
        }

        // GET: INV_CAB_MOVIMIENTO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INV_CAB_MOVIMIENTO iNV_CAB_MOVIMIENTO = await db.INV_CAB_MOVIMIENTO.FindAsync(id);
            if (iNV_CAB_MOVIMIENTO == null)
            {
                return HttpNotFound();
            }
            return View(iNV_CAB_MOVIMIENTO);
        }

        // POST: INV_CAB_MOVIMIENTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            INV_CAB_MOVIMIENTO iNV_CAB_MOVIMIENTO = await db.INV_CAB_MOVIMIENTO.FindAsync(id);
            db.INV_CAB_MOVIMIENTO.Remove(iNV_CAB_MOVIMIENTO);
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
