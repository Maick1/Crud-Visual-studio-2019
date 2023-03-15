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
    public class COM_PROVEEDORController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: COM_PROVEEDOR
        public async Task<ActionResult> Index()
        {
            var cOM_PROVEEDOR = db.COM_PROVEEDOR.Include(c => c.SEG_EMPRESA).Include(c => c.SEG_ESTADO_AI).Include(c => c.SEG_USUARIO).Include(c => c.SEG_USUARIO1);
            return View(await cOM_PROVEEDOR.ToListAsync());
        }

        // GET: COM_PROVEEDOR/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_PROVEEDOR cOM_PROVEEDOR = await db.COM_PROVEEDOR.FindAsync(id);
            if (cOM_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(cOM_PROVEEDOR);
        }

        // GET: COM_PROVEEDOR/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: COM_PROVEEDOR/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ENT_Id_Entidad,EMP_Id_Empresa,PRO_Secuencial,SEG_Id_Tipo,SEG_Id_Banco,PRO_Categoria,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] COM_PROVEEDOR cOM_PROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.COM_PROVEEDOR.Add(cOM_PROVEEDOR);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_PROVEEDOR.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_PROVEEDOR.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_PROVEEDOR.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_PROVEEDOR.Aud_Usuario_Modifica);
            return View(cOM_PROVEEDOR);
        }

        // GET: COM_PROVEEDOR/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_PROVEEDOR cOM_PROVEEDOR = await db.COM_PROVEEDOR.FindAsync(id);
            if (cOM_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_PROVEEDOR.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_PROVEEDOR.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_PROVEEDOR.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_PROVEEDOR.Aud_Usuario_Modifica);
            return View(cOM_PROVEEDOR);
        }

        // POST: COM_PROVEEDOR/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ENT_Id_Entidad,EMP_Id_Empresa,PRO_Secuencial,SEG_Id_Tipo,SEG_Id_Banco,PRO_Categoria,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] COM_PROVEEDOR cOM_PROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOM_PROVEEDOR).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_PROVEEDOR.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_PROVEEDOR.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_PROVEEDOR.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_PROVEEDOR.Aud_Usuario_Modifica);
            return View(cOM_PROVEEDOR);
        }

        // GET: COM_PROVEEDOR/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_PROVEEDOR cOM_PROVEEDOR = await db.COM_PROVEEDOR.FindAsync(id);
            if (cOM_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(cOM_PROVEEDOR);
        }

        // POST: COM_PROVEEDOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            COM_PROVEEDOR cOM_PROVEEDOR = await db.COM_PROVEEDOR.FindAsync(id);
            db.COM_PROVEEDOR.Remove(cOM_PROVEEDOR);
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
