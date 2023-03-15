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

namespace mtomalaz.Controllers.Compras
{
    public class COM_DET_DEVController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: COM_DET_DEV
        public async Task<ActionResult> Index()
        {
            var cOM_DET_DEV = db.COM_DET_DEV.Include(c => c.SEG_EMPRESA).Include(c => c.SEG_ESTADO_AI).Include(c => c.SEG_USUARIO).Include(c => c.SEG_USUARIO1);
            return View(await cOM_DET_DEV.ToListAsync());
        }

        // GET: COM_DET_DEV/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_DET_DEV cOM_DET_DEV = await db.COM_DET_DEV.FindAsync(id);
            if (cOM_DET_DEV == null)
            {
                return HttpNotFound();
            }
            return View(cOM_DET_DEV);
        }

        // GET: COM_DET_DEV/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: COM_DET_DEV/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DET_Devolucion_Id,EMP_Id_Empresa,CAB_Devolucion_Id,CAB_Orden_Cab_Id,CAT_Prov_Id,DET_Secuencial,DET_Producto,DET_Costo,DET_Cantidad,DET_Subtotal,DET_Observacion,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] COM_DET_DEV cOM_DET_DEV)
        {
            if (ModelState.IsValid)
            {
                db.COM_DET_DEV.Add(cOM_DET_DEV);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_DET_DEV.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_DET_DEV.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_DET_DEV.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_DET_DEV.Aud_Usuario_Modifica);
            return View(cOM_DET_DEV);
        }

        // GET: COM_DET_DEV/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_DET_DEV cOM_DET_DEV = await db.COM_DET_DEV.FindAsync(id);
            if (cOM_DET_DEV == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_DET_DEV.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_DET_DEV.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_DET_DEV.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_DET_DEV.Aud_Usuario_Modifica);
            return View(cOM_DET_DEV);
        }

        // POST: COM_DET_DEV/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DET_Devolucion_Id,EMP_Id_Empresa,CAB_Devolucion_Id,CAB_Orden_Cab_Id,CAT_Prov_Id,DET_Secuencial,DET_Producto,DET_Costo,DET_Cantidad,DET_Subtotal,DET_Observacion,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] COM_DET_DEV cOM_DET_DEV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOM_DET_DEV).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_DET_DEV.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_DET_DEV.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_DET_DEV.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_DET_DEV.Aud_Usuario_Modifica);
            return View(cOM_DET_DEV);
        }

        // GET: COM_DET_DEV/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_DET_DEV cOM_DET_DEV = await db.COM_DET_DEV.FindAsync(id);
            if (cOM_DET_DEV == null)
            {
                return HttpNotFound();
            }
            return View(cOM_DET_DEV);
        }

        // POST: COM_DET_DEV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            COM_DET_DEV cOM_DET_DEV = await db.COM_DET_DEV.FindAsync(id);
            db.COM_DET_DEV.Remove(cOM_DET_DEV);
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
