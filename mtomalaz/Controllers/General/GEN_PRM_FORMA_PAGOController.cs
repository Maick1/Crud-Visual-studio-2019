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

namespace mtomalaz.Controllers.General
{
    public class GEN_PRM_FORMA_PAGOController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: GEN_PRM_FORMA_PAGO
        public async Task<ActionResult> Index()
        {
            var gEN_PRM_FORMA_PAGO = db.GEN_PRM_FORMA_PAGO.Include(g => g.SEG_ESTADO_AI).Include(g => g.SEG_USUARIO).Include(g => g.SEG_USUARIO1);
            return View(await gEN_PRM_FORMA_PAGO.ToListAsync());
        }

        // GET: GEN_PRM_FORMA_PAGO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEN_PRM_FORMA_PAGO gEN_PRM_FORMA_PAGO = await db.GEN_PRM_FORMA_PAGO.FindAsync(id);
            if (gEN_PRM_FORMA_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(gEN_PRM_FORMA_PAGO);
        }

        // GET: GEN_PRM_FORMA_PAGO/Create
        public ActionResult Create()
        {
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: GEN_PRM_FORMA_PAGO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Gen_PrmForPag_Id,Gen_PrmForPag_Descripcion,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] GEN_PRM_FORMA_PAGO gEN_PRM_FORMA_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.GEN_PRM_FORMA_PAGO.Add(gEN_PRM_FORMA_PAGO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", gEN_PRM_FORMA_PAGO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_FORMA_PAGO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_FORMA_PAGO.Aud_Usuario_Modifica);
            return View(gEN_PRM_FORMA_PAGO);
        }

        // GET: GEN_PRM_FORMA_PAGO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEN_PRM_FORMA_PAGO gEN_PRM_FORMA_PAGO = await db.GEN_PRM_FORMA_PAGO.FindAsync(id);
            if (gEN_PRM_FORMA_PAGO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", gEN_PRM_FORMA_PAGO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_FORMA_PAGO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_FORMA_PAGO.Aud_Usuario_Modifica);
            return View(gEN_PRM_FORMA_PAGO);
        }

        // POST: GEN_PRM_FORMA_PAGO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Gen_PrmForPag_Id,Gen_PrmForPag_Descripcion,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] GEN_PRM_FORMA_PAGO gEN_PRM_FORMA_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gEN_PRM_FORMA_PAGO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", gEN_PRM_FORMA_PAGO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_FORMA_PAGO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_FORMA_PAGO.Aud_Usuario_Modifica);
            return View(gEN_PRM_FORMA_PAGO);
        }

        // GET: GEN_PRM_FORMA_PAGO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEN_PRM_FORMA_PAGO gEN_PRM_FORMA_PAGO = await db.GEN_PRM_FORMA_PAGO.FindAsync(id);
            if (gEN_PRM_FORMA_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(gEN_PRM_FORMA_PAGO);
        }

        // POST: GEN_PRM_FORMA_PAGO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GEN_PRM_FORMA_PAGO gEN_PRM_FORMA_PAGO = await db.GEN_PRM_FORMA_PAGO.FindAsync(id);
            db.GEN_PRM_FORMA_PAGO.Remove(gEN_PRM_FORMA_PAGO);
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
