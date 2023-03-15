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
    public class INV_ARTICULOSController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: INV_ARTICULOS
        public async Task<ActionResult> Index()
        {
            var iNV_ARTICULOS = db.INV_ARTICULOS.Include(i => i.SEG_EMPRESA).Include(i => i.SEG_ESTADO_AI).Include(i => i.SEG_USUARIO).Include(i => i.SEG_USUARIO1);
            return View(await iNV_ARTICULOS.ToListAsync());
        }

        // GET: INV_ARTICULOS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INV_ARTICULOS iNV_ARTICULOS = await db.INV_ARTICULOS.FindAsync(id);
            if (iNV_ARTICULOS == null)
            {
                return HttpNotFound();
            }
            return View(iNV_ARTICULOS);
        }

        // GET: INV_ARTICULOS/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: INV_ARTICULOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ART_Id_Articulos,EMP_Id_Empresa,ART_Descripcion,ART_Stock,ART_Precio_Bruto,ART_Fec_Abast,MAR_Id_Marca,CAT_Id_Categoria,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] INV_ARTICULOS iNV_ARTICULOS)
        {
            if (ModelState.IsValid)
            {
                db.INV_ARTICULOS.Add(iNV_ARTICULOS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", iNV_ARTICULOS.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", iNV_ARTICULOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_ARTICULOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_ARTICULOS.Aud_Usuario_Modifica);
            return View(iNV_ARTICULOS);
        }

        // GET: INV_ARTICULOS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INV_ARTICULOS iNV_ARTICULOS = await db.INV_ARTICULOS.FindAsync(id);
            if (iNV_ARTICULOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", iNV_ARTICULOS.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", iNV_ARTICULOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_ARTICULOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_ARTICULOS.Aud_Usuario_Modifica);
            return View(iNV_ARTICULOS);
        }

        // POST: INV_ARTICULOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ART_Id_Articulos,EMP_Id_Empresa,ART_Descripcion,ART_Stock,ART_Precio_Bruto,ART_Fec_Abast,MAR_Id_Marca,CAT_Id_Categoria,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] INV_ARTICULOS iNV_ARTICULOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNV_ARTICULOS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", iNV_ARTICULOS.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", iNV_ARTICULOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_ARTICULOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_ARTICULOS.Aud_Usuario_Modifica);
            return View(iNV_ARTICULOS);
        }

        // GET: INV_ARTICULOS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INV_ARTICULOS iNV_ARTICULOS = await db.INV_ARTICULOS.FindAsync(id);
            if (iNV_ARTICULOS == null)
            {
                return HttpNotFound();
            }
            return View(iNV_ARTICULOS);
        }

        // POST: INV_ARTICULOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            INV_ARTICULOS iNV_ARTICULOS = await db.INV_ARTICULOS.FindAsync(id);
            db.INV_ARTICULOS.Remove(iNV_ARTICULOS);
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
