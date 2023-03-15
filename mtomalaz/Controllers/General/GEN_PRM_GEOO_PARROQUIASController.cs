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
    public class GEN_PRM_GEOO_PARROQUIASController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: GEN_PRM_GEOO_PARROQUIAS
        public async Task<ActionResult> Index()
        {
            var gEN_PRM_GEOO_PARROQUIAS = db.GEN_PRM_GEOO_PARROQUIAS.Include(g => g.GEN_PRM_GEOI_CIUDAD).Include(g => g.SEG_ESTADO_AI).Include(g => g.SEG_USUARIO).Include(g => g.SEG_USUARIO1);
            return View(await gEN_PRM_GEOO_PARROQUIAS.ToListAsync());
        }

        // GET: GEN_PRM_GEOO_PARROQUIAS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEN_PRM_GEOO_PARROQUIAS gEN_PRM_GEOO_PARROQUIAS = await db.GEN_PRM_GEOO_PARROQUIAS.FindAsync(id);
            if (gEN_PRM_GEOO_PARROQUIAS == null)
            {
                return HttpNotFound();
            }
            return View(gEN_PRM_GEOO_PARROQUIAS);
        }

        // GET: GEN_PRM_GEOO_PARROQUIAS/Create
        public ActionResult Create()
        {
            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: GEN_PRM_GEOO_PARROQUIAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Gen_PrmPrq_Id,Gen_PrmCiu_Id,Gen_PrmPrq_Codigo,Gen_PrmPrq_nombre,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] GEN_PRM_GEOO_PARROQUIAS gEN_PRM_GEOO_PARROQUIAS)
        {
            if (ModelState.IsValid)
            {
                db.GEN_PRM_GEOO_PARROQUIAS.Add(gEN_PRM_GEOO_PARROQUIAS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo", gEN_PRM_GEOO_PARROQUIAS.Gen_PrmCiu_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", gEN_PRM_GEOO_PARROQUIAS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOO_PARROQUIAS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOO_PARROQUIAS.Aud_Usuario_Modifica);
            return View(gEN_PRM_GEOO_PARROQUIAS);
        }

        // GET: GEN_PRM_GEOO_PARROQUIAS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEN_PRM_GEOO_PARROQUIAS gEN_PRM_GEOO_PARROQUIAS = await db.GEN_PRM_GEOO_PARROQUIAS.FindAsync(id);
            if (gEN_PRM_GEOO_PARROQUIAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo", gEN_PRM_GEOO_PARROQUIAS.Gen_PrmCiu_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", gEN_PRM_GEOO_PARROQUIAS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOO_PARROQUIAS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOO_PARROQUIAS.Aud_Usuario_Modifica);
            return View(gEN_PRM_GEOO_PARROQUIAS);
        }

        // POST: GEN_PRM_GEOO_PARROQUIAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Gen_PrmPrq_Id,Gen_PrmCiu_Id,Gen_PrmPrq_Codigo,Gen_PrmPrq_nombre,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] GEN_PRM_GEOO_PARROQUIAS gEN_PRM_GEOO_PARROQUIAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gEN_PRM_GEOO_PARROQUIAS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo", gEN_PRM_GEOO_PARROQUIAS.Gen_PrmCiu_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", gEN_PRM_GEOO_PARROQUIAS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOO_PARROQUIAS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOO_PARROQUIAS.Aud_Usuario_Modifica);
            return View(gEN_PRM_GEOO_PARROQUIAS);
        }

        // GET: GEN_PRM_GEOO_PARROQUIAS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEN_PRM_GEOO_PARROQUIAS gEN_PRM_GEOO_PARROQUIAS = await db.GEN_PRM_GEOO_PARROQUIAS.FindAsync(id);
            if (gEN_PRM_GEOO_PARROQUIAS == null)
            {
                return HttpNotFound();
            }
            return View(gEN_PRM_GEOO_PARROQUIAS);
        }

        // POST: GEN_PRM_GEOO_PARROQUIAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GEN_PRM_GEOO_PARROQUIAS gEN_PRM_GEOO_PARROQUIAS = await db.GEN_PRM_GEOO_PARROQUIAS.FindAsync(id);
            db.GEN_PRM_GEOO_PARROQUIAS.Remove(gEN_PRM_GEOO_PARROQUIAS);
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
