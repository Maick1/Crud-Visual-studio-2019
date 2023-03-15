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

namespace mtomalaz.Controllers.Banco
{
    public class BCO_CUENTA_TIPOController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: BCO_CUENTA_TIPO
        public async Task<ActionResult> Index()
        {
            var bCO_CUENTA_TIPO = db.BCO_CUENTA_TIPO.Include(b => b.SEG_ESTADO_AI).Include(b => b.SEG_USUARIO).Include(b => b.SEG_USUARIO1);
            return View(await bCO_CUENTA_TIPO.ToListAsync());
        }

        // GET: BCO_CUENTA_TIPO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_CUENTA_TIPO bCO_CUENTA_TIPO = await db.BCO_CUENTA_TIPO.FindAsync(id);
            if (bCO_CUENTA_TIPO == null)
            {
                return HttpNotFound();
            }
            return View(bCO_CUENTA_TIPO);
        }

        // GET: BCO_CUENTA_TIPO/Create
        public ActionResult Create()
        {
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: BCO_CUENTA_TIPO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Bco_CtaTipo_Id,Bco_CtaTipo_Descripcion,Bco_CtaTipo_Abreviatura,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] BCO_CUENTA_TIPO bCO_CUENTA_TIPO)
        {
            if (ModelState.IsValid)
            {
                db.BCO_CUENTA_TIPO.Add(bCO_CUENTA_TIPO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_CUENTA_TIPO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_TIPO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_TIPO.Aud_Usuario_Modifica);
            return View(bCO_CUENTA_TIPO);
        }

        // GET: BCO_CUENTA_TIPO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_CUENTA_TIPO bCO_CUENTA_TIPO = await db.BCO_CUENTA_TIPO.FindAsync(id);
            if (bCO_CUENTA_TIPO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_CUENTA_TIPO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_TIPO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_TIPO.Aud_Usuario_Modifica);
            return View(bCO_CUENTA_TIPO);
        }

        // POST: BCO_CUENTA_TIPO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Bco_CtaTipo_Id,Bco_CtaTipo_Descripcion,Bco_CtaTipo_Abreviatura,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] BCO_CUENTA_TIPO bCO_CUENTA_TIPO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bCO_CUENTA_TIPO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_CUENTA_TIPO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_TIPO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_TIPO.Aud_Usuario_Modifica);
            return View(bCO_CUENTA_TIPO);
        }

        // GET: BCO_CUENTA_TIPO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_CUENTA_TIPO bCO_CUENTA_TIPO = await db.BCO_CUENTA_TIPO.FindAsync(id);
            if (bCO_CUENTA_TIPO == null)
            {
                return HttpNotFound();
            }
            return View(bCO_CUENTA_TIPO);
        }

        // POST: BCO_CUENTA_TIPO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BCO_CUENTA_TIPO bCO_CUENTA_TIPO = await db.BCO_CUENTA_TIPO.FindAsync(id);
            db.BCO_CUENTA_TIPO.Remove(bCO_CUENTA_TIPO);
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
