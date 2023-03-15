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
    public class CON_DIARIO_TIPOController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: CON_DIARIO_TIPO
        public async Task<ActionResult> Index()
        {
            var cON_DIARIO_TIPO = db.CON_DIARIO_TIPO.Include(c => c.GEN_ANIO).Include(c => c.SEG_ESTADO_AI).Include(c => c.SEG_USUARIO).Include(c => c.SEG_USUARIO1).Include(c => c.SEG_ESTADO_AI1);
            return View(await cON_DIARIO_TIPO.ToListAsync());
        }

        // GET: CON_DIARIO_TIPO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_TIPO cON_DIARIO_TIPO = await db.CON_DIARIO_TIPO.FindAsync(id);
            if (cON_DIARIO_TIPO == null)
            {
                return HttpNotFound();
            }
            return View(cON_DIARIO_TIPO);
        }

        // GET: CON_DIARIO_TIPO/Create
        public ActionResult Create()
        {
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Con_CompTip_Tipo_Manual_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            return View();
        }

        // POST: CON_DIARIO_TIPO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Con_CompTip_Id,Gen_PrmAnio_Id,Con_CompTip_Nombre,Con_CompTip_Tipo_Manual_SN,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_DIARIO_TIPO cON_DIARIO_TIPO)
        {
            if (ModelState.IsValid)
            {
                db.CON_DIARIO_TIPO.Add(cON_DIARIO_TIPO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_DIARIO_TIPO.Gen_PrmAnio_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_TIPO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_TIPO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_TIPO.Aud_Usuario_Modifica);
            ViewBag.Con_CompTip_Tipo_Manual_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_TIPO.Con_CompTip_Tipo_Manual_SN);
            return View(cON_DIARIO_TIPO);
        }

        // GET: CON_DIARIO_TIPO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_TIPO cON_DIARIO_TIPO = await db.CON_DIARIO_TIPO.FindAsync(id);
            if (cON_DIARIO_TIPO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_DIARIO_TIPO.Gen_PrmAnio_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_TIPO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_TIPO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_TIPO.Aud_Usuario_Modifica);
            ViewBag.Con_CompTip_Tipo_Manual_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_TIPO.Con_CompTip_Tipo_Manual_SN);
            return View(cON_DIARIO_TIPO);
        }

        // POST: CON_DIARIO_TIPO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Con_CompTip_Id,Gen_PrmAnio_Id,Con_CompTip_Nombre,Con_CompTip_Tipo_Manual_SN,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_DIARIO_TIPO cON_DIARIO_TIPO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cON_DIARIO_TIPO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_DIARIO_TIPO.Gen_PrmAnio_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_TIPO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_TIPO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_TIPO.Aud_Usuario_Modifica);
            ViewBag.Con_CompTip_Tipo_Manual_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_TIPO.Con_CompTip_Tipo_Manual_SN);
            return View(cON_DIARIO_TIPO);
        }

        // GET: CON_DIARIO_TIPO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_TIPO cON_DIARIO_TIPO = await db.CON_DIARIO_TIPO.FindAsync(id);
            if (cON_DIARIO_TIPO == null)
            {
                return HttpNotFound();
            }
            return View(cON_DIARIO_TIPO);
        }

        // POST: CON_DIARIO_TIPO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CON_DIARIO_TIPO cON_DIARIO_TIPO = await db.CON_DIARIO_TIPO.FindAsync(id);
            db.CON_DIARIO_TIPO.Remove(cON_DIARIO_TIPO);
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
