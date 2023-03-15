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
    public class INV_DET_KARDEXController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: INV_DET_KARDEX
        public async Task<ActionResult> Index()
        {
            var iNV_DET_KARDEX = db.INV_DET_KARDEX.Include(i => i.SEG_EMPRESA).Include(i => i.SEG_ESTADO_AI).Include(i => i.SEG_USUARIO).Include(i => i.SEG_USUARIO1);
            return View(await iNV_DET_KARDEX.ToListAsync());
        }

        // GET: INV_DET_KARDEX/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INV_DET_KARDEX iNV_DET_KARDEX = await db.INV_DET_KARDEX.FindAsync(id);
            if (iNV_DET_KARDEX == null)
            {
                return HttpNotFound();
            }
            return View(iNV_DET_KARDEX);
        }

        // GET: INV_DET_KARDEX/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: INV_DET_KARDEX/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "KAR_Id_Kardex_Det,EMP_Id_Empresa,KAR_Id_Kardex,KAR_Secuencial,KAR_Ingreso,KAR_Egreso,ART_Id_Articulo,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] INV_DET_KARDEX iNV_DET_KARDEX)
        {
            if (ModelState.IsValid)
            {
                db.INV_DET_KARDEX.Add(iNV_DET_KARDEX);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", iNV_DET_KARDEX.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", iNV_DET_KARDEX.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_DET_KARDEX.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_DET_KARDEX.Aud_Usuario_Modifica);
            return View(iNV_DET_KARDEX);
        }

        // GET: INV_DET_KARDEX/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INV_DET_KARDEX iNV_DET_KARDEX = await db.INV_DET_KARDEX.FindAsync(id);
            if (iNV_DET_KARDEX == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", iNV_DET_KARDEX.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", iNV_DET_KARDEX.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_DET_KARDEX.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_DET_KARDEX.Aud_Usuario_Modifica);
            return View(iNV_DET_KARDEX);
        }

        // POST: INV_DET_KARDEX/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "KAR_Id_Kardex_Det,EMP_Id_Empresa,KAR_Id_Kardex,KAR_Secuencial,KAR_Ingreso,KAR_Egreso,ART_Id_Articulo,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] INV_DET_KARDEX iNV_DET_KARDEX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNV_DET_KARDEX).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", iNV_DET_KARDEX.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", iNV_DET_KARDEX.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_DET_KARDEX.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", iNV_DET_KARDEX.Aud_Usuario_Modifica);
            return View(iNV_DET_KARDEX);
        }

        // GET: INV_DET_KARDEX/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INV_DET_KARDEX iNV_DET_KARDEX = await db.INV_DET_KARDEX.FindAsync(id);
            if (iNV_DET_KARDEX == null)
            {
                return HttpNotFound();
            }
            return View(iNV_DET_KARDEX);
        }

        // POST: INV_DET_KARDEX/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            INV_DET_KARDEX iNV_DET_KARDEX = await db.INV_DET_KARDEX.FindAsync(id);
            db.INV_DET_KARDEX.Remove(iNV_DET_KARDEX);
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
