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
    public class COM_CATEGORIA_PROVEEDORESController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: COM_CATEGORIA_PROVEEDORES
        public async Task<ActionResult> Index()
        {
            var cOM_CATEGORIA_PROVEEDORES = db.COM_CATEGORIA_PROVEEDORES.Include(c => c.SEG_EMPRESA).Include(c => c.SEG_ESTADO_AI).Include(c => c.SEG_USUARIO).Include(c => c.SEG_USUARIO1);
            return View(await cOM_CATEGORIA_PROVEEDORES.ToListAsync());
        }

        // GET: COM_CATEGORIA_PROVEEDORES/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_CATEGORIA_PROVEEDORES cOM_CATEGORIA_PROVEEDORES = await db.COM_CATEGORIA_PROVEEDORES.FindAsync(id);
            if (cOM_CATEGORIA_PROVEEDORES == null)
            {
                return HttpNotFound();
            }
            return View(cOM_CATEGORIA_PROVEEDORES);
        }

        // GET: COM_CATEGORIA_PROVEEDORES/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: COM_CATEGORIA_PROVEEDORES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CAT_Prov_Id,EMP_Id_Empresa,CAT_Descripcion,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] COM_CATEGORIA_PROVEEDORES cOM_CATEGORIA_PROVEEDORES)
        {
            if (ModelState.IsValid)
            {
                db.COM_CATEGORIA_PROVEEDORES.Add(cOM_CATEGORIA_PROVEEDORES);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_CATEGORIA_PROVEEDORES.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_CATEGORIA_PROVEEDORES.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CATEGORIA_PROVEEDORES.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CATEGORIA_PROVEEDORES.Aud_Usuario_Modifica);
            return View(cOM_CATEGORIA_PROVEEDORES);
        }

        // GET: COM_CATEGORIA_PROVEEDORES/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_CATEGORIA_PROVEEDORES cOM_CATEGORIA_PROVEEDORES = await db.COM_CATEGORIA_PROVEEDORES.FindAsync(id);
            if (cOM_CATEGORIA_PROVEEDORES == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_CATEGORIA_PROVEEDORES.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_CATEGORIA_PROVEEDORES.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CATEGORIA_PROVEEDORES.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CATEGORIA_PROVEEDORES.Aud_Usuario_Modifica);
            return View(cOM_CATEGORIA_PROVEEDORES);
        }

        // POST: COM_CATEGORIA_PROVEEDORES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CAT_Prov_Id,EMP_Id_Empresa,CAT_Descripcion,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] COM_CATEGORIA_PROVEEDORES cOM_CATEGORIA_PROVEEDORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOM_CATEGORIA_PROVEEDORES).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cOM_CATEGORIA_PROVEEDORES.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cOM_CATEGORIA_PROVEEDORES.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CATEGORIA_PROVEEDORES.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cOM_CATEGORIA_PROVEEDORES.Aud_Usuario_Modifica);
            return View(cOM_CATEGORIA_PROVEEDORES);
        }

        // GET: COM_CATEGORIA_PROVEEDORES/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COM_CATEGORIA_PROVEEDORES cOM_CATEGORIA_PROVEEDORES = await db.COM_CATEGORIA_PROVEEDORES.FindAsync(id);
            if (cOM_CATEGORIA_PROVEEDORES == null)
            {
                return HttpNotFound();
            }
            return View(cOM_CATEGORIA_PROVEEDORES);
        }

        // POST: COM_CATEGORIA_PROVEEDORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            COM_CATEGORIA_PROVEEDORES cOM_CATEGORIA_PROVEEDORES = await db.COM_CATEGORIA_PROVEEDORES.FindAsync(id);
            db.COM_CATEGORIA_PROVEEDORES.Remove(cOM_CATEGORIA_PROVEEDORES);
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
