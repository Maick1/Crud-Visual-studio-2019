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
    public class COM_CAB_ORDENController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: COM_CAB_ORDEN
        public async Task<ActionResult> Index()
        {
            var cOM_CAB_ORDEN = db.COM_CAB_ORDEN.Include(c => c.SEG_EMPRESA).Include(c => c.SEG_ESTADO_AI).Include(c => c.SEG_USUARIO).Include(c => c.SEG_USUARIO1);
            return View(await cOM_CAB_ORDEN.ToListAsync());
        }

        // GET: COM_CAB_ORDEN/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_CAB_ORDEN cOM_CAB_ORDEN = await db.COM_CAB_ORDEN.FindAsync(id);
            if (cOM_CAB_ORDEN == null)
            {
                return HttpNotFound();
            }
            return View(cOM_CAB_ORDEN);
        }

        // GET: COM_CAB_ORDEN/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: COM_CAB_ORDEN/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CAB_Orden_Cab_Id,EMP_Id_Empresa,SOL_Id_Solicitud,ENT_Id_PEntidad,ENT_Id_Entidad,CAB_FechaPedido,CAB_FechaEmitida,CAB_Estado,CAB_Hora,CAB_Observacion,CAB_Descuento,CAB_Iva,CAB_Total,CAB_Ajuste,CAB_Prioridad,CAB_Tipo_Producto,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] COM_CAB_ORDEN cOM_CAB_ORDEN)
        {
            if (ModelState.IsValid)
            {
                db.COM_CAB_ORDEN.Add(cOM_CAB_ORDEN);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_CAB_ORDEN.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_CAB_ORDEN.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CAB_ORDEN.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CAB_ORDEN.Aud_Usuario_Modifica);
            return View(cOM_CAB_ORDEN);
        }

        // GET: COM_CAB_ORDEN/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_CAB_ORDEN cOM_CAB_ORDEN = await db.COM_CAB_ORDEN.FindAsync(id);
            if (cOM_CAB_ORDEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_CAB_ORDEN.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_CAB_ORDEN.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CAB_ORDEN.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CAB_ORDEN.Aud_Usuario_Modifica);
            return View(cOM_CAB_ORDEN);
        }

        // POST: COM_CAB_ORDEN/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CAB_Orden_Cab_Id,EMP_Id_Empresa,SOL_Id_Solicitud,ENT_Id_PEntidad,ENT_Id_Entidad,CAB_FechaPedido,CAB_FechaEmitida,CAB_Estado,CAB_Hora,CAB_Observacion,CAB_Descuento,CAB_Iva,CAB_Total,CAB_Ajuste,CAB_Prioridad,CAB_Tipo_Producto,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] COM_CAB_ORDEN cOM_CAB_ORDEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOM_CAB_ORDEN).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_CAB_ORDEN.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_CAB_ORDEN.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CAB_ORDEN.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CAB_ORDEN.Aud_Usuario_Modifica);
            return View(cOM_CAB_ORDEN);
        }

        // GET: COM_CAB_ORDEN/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_CAB_ORDEN cOM_CAB_ORDEN = await db.COM_CAB_ORDEN.FindAsync(id);
            if (cOM_CAB_ORDEN == null)
            {
                return HttpNotFound();
            }
            return View(cOM_CAB_ORDEN);
        }

        // POST: COM_CAB_ORDEN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            COM_CAB_ORDEN cOM_CAB_ORDEN = await db.COM_CAB_ORDEN.FindAsync(id);
            db.COM_CAB_ORDEN.Remove(cOM_CAB_ORDEN);
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
