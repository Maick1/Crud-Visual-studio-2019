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
    public class CON_CUENTA_NIVELController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: CON_CUENTA_NIVEL
        public async Task<ActionResult> Index()
        {
            var cON_CUENTA_NIVEL = db.CON_CUENTA_NIVEL.Include(c => c.SEG_ESTADO_AI).Include(c => c.SEG_USUARIO).Include(c => c.SEG_USUARIO1).Include(c => c.SEG_ESTADO_AI1);
            return View(await cON_CUENTA_NIVEL.ToListAsync());
        }

        // GET: CON_CUENTA_NIVEL/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_CUENTA_NIVEL cON_CUENTA_NIVEL = await db.CON_CUENTA_NIVEL.FindAsync(id);
            if (cON_CUENTA_NIVEL == null)
            {
                return HttpNotFound();
            }
            return View(cON_CUENTA_NIVEL);
        }

        // GET: CON_CUENTA_NIVEL/Create
        public ActionResult Create()
        {
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Con_NivCta_Separador_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            return View();
        }

        // POST: CON_CUENTA_NIVEL/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Con_NivCta_Id,Con_NivCta_Nivel,Con_NivCta_Descripcion,Con_NivCta_Cant_Caracter,Con_NivCta_Separador_SN,Con_NivCta_Separador_Caracter,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_CUENTA_NIVEL cON_CUENTA_NIVEL)
        {
            if (ModelState.IsValid)
            {
                db.CON_CUENTA_NIVEL.Add(cON_CUENTA_NIVEL);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_NIVEL.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_NIVEL.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_NIVEL.Aud_Usuario_Modifica);
            ViewBag.Con_NivCta_Separador_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_NIVEL.Con_NivCta_Separador_SN);
            return View(cON_CUENTA_NIVEL);
        }

        // GET: CON_CUENTA_NIVEL/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_CUENTA_NIVEL cON_CUENTA_NIVEL = await db.CON_CUENTA_NIVEL.FindAsync(id);
            if (cON_CUENTA_NIVEL == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_NIVEL.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_NIVEL.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_NIVEL.Aud_Usuario_Modifica);
            ViewBag.Con_NivCta_Separador_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_NIVEL.Con_NivCta_Separador_SN);
            return View(cON_CUENTA_NIVEL);
        }

        // POST: CON_CUENTA_NIVEL/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Con_NivCta_Id,Con_NivCta_Nivel,Con_NivCta_Descripcion,Con_NivCta_Cant_Caracter,Con_NivCta_Separador_SN,Con_NivCta_Separador_Caracter,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_CUENTA_NIVEL cON_CUENTA_NIVEL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cON_CUENTA_NIVEL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_NIVEL.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_NIVEL.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_NIVEL.Aud_Usuario_Modifica);
            ViewBag.Con_NivCta_Separador_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_NIVEL.Con_NivCta_Separador_SN);
            return View(cON_CUENTA_NIVEL);
        }

        // GET: CON_CUENTA_NIVEL/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_CUENTA_NIVEL cON_CUENTA_NIVEL = await db.CON_CUENTA_NIVEL.FindAsync(id);
            if (cON_CUENTA_NIVEL == null)
            {
                return HttpNotFound();
            }
            return View(cON_CUENTA_NIVEL);
        }

        // POST: CON_CUENTA_NIVEL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CON_CUENTA_NIVEL cON_CUENTA_NIVEL = await db.CON_CUENTA_NIVEL.FindAsync(id);
            db.CON_CUENTA_NIVEL.Remove(cON_CUENTA_NIVEL);
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
