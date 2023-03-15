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
    public class GEN_PRM_GEOE_PROVINCIASController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: GEN_PRM_GEOE_PROVINCIAS
        public async Task<ActionResult> Index()
        {
            var gEN_PRM_GEOE_PROVINCIAS = db.GEN_PRM_GEOE_PROVINCIAS.Include(g => g.GEN_PRM_GEOA_PAISES).Include(g => g.SEG_ESTADO_AI).Include(g => g.SEG_USUARIO).Include(g => g.SEG_USUARIO1);
            return View(await gEN_PRM_GEOE_PROVINCIAS.ToListAsync());
        }

        // GET: GEN_PRM_GEOE_PROVINCIAS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEN_PRM_GEOE_PROVINCIAS gEN_PRM_GEOE_PROVINCIAS = await db.GEN_PRM_GEOE_PROVINCIAS.FindAsync(id);
            if (gEN_PRM_GEOE_PROVINCIAS == null)
            {
                return HttpNotFound();
            }
            return View(gEN_PRM_GEOE_PROVINCIAS);
        }

        // GET: GEN_PRM_GEOE_PROVINCIAS/Create
        public ActionResult Create()
        {
            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: GEN_PRM_GEOE_PROVINCIAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Gen_PrmPro_Id,Gen_PrmPai_Id,Gen_PrmPro_Codigo,Gen_PrmPro_nombre,Gen_PrmPro_CodTelefono,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] GEN_PRM_GEOE_PROVINCIAS gEN_PRM_GEOE_PROVINCIAS)
        {
            if (ModelState.IsValid)
            {
                db.GEN_PRM_GEOE_PROVINCIAS.Add(gEN_PRM_GEOE_PROVINCIAS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo", gEN_PRM_GEOE_PROVINCIAS.Gen_PrmPai_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", gEN_PRM_GEOE_PROVINCIAS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOE_PROVINCIAS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOE_PROVINCIAS.Aud_Usuario_Modifica);
            return View(gEN_PRM_GEOE_PROVINCIAS);
        }

        // GET: GEN_PRM_GEOE_PROVINCIAS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEN_PRM_GEOE_PROVINCIAS gEN_PRM_GEOE_PROVINCIAS = await db.GEN_PRM_GEOE_PROVINCIAS.FindAsync(id);
            if (gEN_PRM_GEOE_PROVINCIAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo", gEN_PRM_GEOE_PROVINCIAS.Gen_PrmPai_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", gEN_PRM_GEOE_PROVINCIAS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOE_PROVINCIAS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOE_PROVINCIAS.Aud_Usuario_Modifica);
            return View(gEN_PRM_GEOE_PROVINCIAS);
        }

        // POST: GEN_PRM_GEOE_PROVINCIAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Gen_PrmPro_Id,Gen_PrmPai_Id,Gen_PrmPro_Codigo,Gen_PrmPro_nombre,Gen_PrmPro_CodTelefono,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] GEN_PRM_GEOE_PROVINCIAS gEN_PRM_GEOE_PROVINCIAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gEN_PRM_GEOE_PROVINCIAS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo", gEN_PRM_GEOE_PROVINCIAS.Gen_PrmPai_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", gEN_PRM_GEOE_PROVINCIAS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOE_PROVINCIAS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", gEN_PRM_GEOE_PROVINCIAS.Aud_Usuario_Modifica);
            return View(gEN_PRM_GEOE_PROVINCIAS);
        }

        // GET: GEN_PRM_GEOE_PROVINCIAS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GEN_PRM_GEOE_PROVINCIAS gEN_PRM_GEOE_PROVINCIAS = await db.GEN_PRM_GEOE_PROVINCIAS.FindAsync(id);
            if (gEN_PRM_GEOE_PROVINCIAS == null)
            {
                return HttpNotFound();
            }
            return View(gEN_PRM_GEOE_PROVINCIAS);
        }

        // POST: GEN_PRM_GEOE_PROVINCIAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GEN_PRM_GEOE_PROVINCIAS gEN_PRM_GEOE_PROVINCIAS = await db.GEN_PRM_GEOE_PROVINCIAS.FindAsync(id);
            db.GEN_PRM_GEOE_PROVINCIAS.Remove(gEN_PRM_GEOE_PROVINCIAS);
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
