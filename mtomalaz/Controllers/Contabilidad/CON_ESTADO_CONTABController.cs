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

namespace mtomalaz.Controllers.Contabilidad
{
    public class CON_ESTADO_CONTABController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: CON_ESTADO_CONTAB
        public async Task<ActionResult> Index()
        {
            var cON_ESTADO_CONTAB = db.CON_ESTADO_CONTAB.Include(c => c.SEG_ESTADO_AI).Include(c => c.SEG_USUARIO).Include(c => c.SEG_USUARIO1);
            return View(await cON_ESTADO_CONTAB.ToListAsync());
        }

        // GET: CON_ESTADO_CONTAB/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_ESTADO_CONTAB cON_ESTADO_CONTAB = await db.CON_ESTADO_CONTAB.FindAsync(id);
            if (cON_ESTADO_CONTAB == null)
            {
                return HttpNotFound();
            }
            return View(cON_ESTADO_CONTAB);
        }

        // GET: CON_ESTADO_CONTAB/Create
        public ActionResult Create()
        {
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: CON_ESTADO_CONTAB/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Con_EstCont_Id,Con_EstCont_Descripcion,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_ESTADO_CONTAB cON_ESTADO_CONTAB)
        {
            if (ModelState.IsValid)
            {
                db.CON_ESTADO_CONTAB.Add(cON_ESTADO_CONTAB);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_ESTADO_CONTAB.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_ESTADO_CONTAB.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_ESTADO_CONTAB.Aud_Usuario_Modifica);
            return View(cON_ESTADO_CONTAB);
        }

        // GET: CON_ESTADO_CONTAB/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_ESTADO_CONTAB cON_ESTADO_CONTAB = await db.CON_ESTADO_CONTAB.FindAsync(id);
            if (cON_ESTADO_CONTAB == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_ESTADO_CONTAB.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_ESTADO_CONTAB.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_ESTADO_CONTAB.Aud_Usuario_Modifica);
            return View(cON_ESTADO_CONTAB);
        }

        // POST: CON_ESTADO_CONTAB/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Con_EstCont_Id,Con_EstCont_Descripcion,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_ESTADO_CONTAB cON_ESTADO_CONTAB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cON_ESTADO_CONTAB).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_ESTADO_CONTAB.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_ESTADO_CONTAB.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_ESTADO_CONTAB.Aud_Usuario_Modifica);
            return View(cON_ESTADO_CONTAB);
        }

        // GET: CON_ESTADO_CONTAB/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_ESTADO_CONTAB cON_ESTADO_CONTAB = await db.CON_ESTADO_CONTAB.FindAsync(id);
            if (cON_ESTADO_CONTAB == null)
            {
                return HttpNotFound();
            }
            return View(cON_ESTADO_CONTAB);
        }

        // POST: CON_ESTADO_CONTAB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CON_ESTADO_CONTAB cON_ESTADO_CONTAB = await db.CON_ESTADO_CONTAB.FindAsync(id);
            db.CON_ESTADO_CONTAB.Remove(cON_ESTADO_CONTAB);
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
