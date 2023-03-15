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
    public class CON_DIARIO_DETController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: CON_DIARIO_DET
        public async Task<ActionResult> Index()
        {
            var cON_DIARIO_DET = db.CON_DIARIO_DET.Include(c => c.CON_CUENTA_PLAN).Include(c => c.CON_DIARIO_CAB).Include(c => c.SEG_EMPRESA).Include(c => c.SEG_ESTADO_AI).Include(c => c.SEG_USUARIO).Include(c => c.SEG_USUARIO1).Include(c => c.SEG_ESTADO_AI1);
            return View(await cON_DIARIO_DET.ToListAsync());
        }

        // GET: CON_DIARIO_DET/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_DET cON_DIARIO_DET = await db.CON_DIARIO_DET.FindAsync(id);
            if (cON_DIARIO_DET == null)
            {
                return HttpNotFound();
            }
            return View(cON_DIARIO_DET);
        }

        // GET: CON_DIARIO_DET/Create
        public ActionResult Create()
        {
            ViewBag.Con_PlaCta_Id = new SelectList(db.CON_CUENTA_PLAN, "Con_PlaCta_Id", "Con_PlaCta_Cuenta");
            ViewBag.Con_DiarioCab_Id = new SelectList(db.CON_DIARIO_CAB, "Con_DiarioCab_Id", "Con_DiarioCab_Numero");
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Con_DiarioReqAux_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            return View();
        }

        // POST: CON_DIARIO_DET/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Con_DiarioDet_Id,SEG_EMPRESA_Id,Con_DiarioCab_Id,Con_DiarioDet_NumLin,Con_PlaCta_Id,Con_DiarioDet_Glosa,Con_DiarioDet_Debe,Con_DiarioDet_Haber,Con_DiarioReqAux_SN,Con_DiarioDet_Aux_Total,Con_DiarioDet_Referencia,Con_DiarioDet_Reg_T_P,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_DIARIO_DET cON_DIARIO_DET)
        {
            if (ModelState.IsValid)
            {
                db.CON_DIARIO_DET.Add(cON_DIARIO_DET);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Con_PlaCta_Id = new SelectList(db.CON_CUENTA_PLAN, "Con_PlaCta_Id", "Con_PlaCta_Cuenta", cON_DIARIO_DET.Con_PlaCta_Id);
            ViewBag.Con_DiarioCab_Id = new SelectList(db.CON_DIARIO_CAB, "Con_DiarioCab_Id", "Con_DiarioCab_Numero", cON_DIARIO_DET.Con_DiarioCab_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_DIARIO_DET.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_DET.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_DET.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_DET.Aud_Usuario_Modifica);
            ViewBag.Con_DiarioReqAux_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_DET.Con_DiarioReqAux_SN);
            return View(cON_DIARIO_DET);
        }

        // GET: CON_DIARIO_DET/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_DET cON_DIARIO_DET = await db.CON_DIARIO_DET.FindAsync(id);
            if (cON_DIARIO_DET == null)
            {
                return HttpNotFound();
            }
            ViewBag.Con_PlaCta_Id = new SelectList(db.CON_CUENTA_PLAN, "Con_PlaCta_Id", "Con_PlaCta_Cuenta", cON_DIARIO_DET.Con_PlaCta_Id);
            ViewBag.Con_DiarioCab_Id = new SelectList(db.CON_DIARIO_CAB, "Con_DiarioCab_Id", "Con_DiarioCab_Numero", cON_DIARIO_DET.Con_DiarioCab_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_DIARIO_DET.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_DET.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_DET.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_DET.Aud_Usuario_Modifica);
            ViewBag.Con_DiarioReqAux_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_DET.Con_DiarioReqAux_SN);
            return View(cON_DIARIO_DET);
        }

        // POST: CON_DIARIO_DET/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Con_DiarioDet_Id,SEG_EMPRESA_Id,Con_DiarioCab_Id,Con_DiarioDet_NumLin,Con_PlaCta_Id,Con_DiarioDet_Glosa,Con_DiarioDet_Debe,Con_DiarioDet_Haber,Con_DiarioReqAux_SN,Con_DiarioDet_Aux_Total,Con_DiarioDet_Referencia,Con_DiarioDet_Reg_T_P,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_DIARIO_DET cON_DIARIO_DET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cON_DIARIO_DET).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Con_PlaCta_Id = new SelectList(db.CON_CUENTA_PLAN, "Con_PlaCta_Id", "Con_PlaCta_Cuenta", cON_DIARIO_DET.Con_PlaCta_Id);
            ViewBag.Con_DiarioCab_Id = new SelectList(db.CON_DIARIO_CAB, "Con_DiarioCab_Id", "Con_DiarioCab_Numero", cON_DIARIO_DET.Con_DiarioCab_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_DIARIO_DET.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_DET.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_DET.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_DET.Aud_Usuario_Modifica);
            ViewBag.Con_DiarioReqAux_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_DET.Con_DiarioReqAux_SN);
            return View(cON_DIARIO_DET);
        }

        // GET: CON_DIARIO_DET/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_DET cON_DIARIO_DET = await db.CON_DIARIO_DET.FindAsync(id);
            if (cON_DIARIO_DET == null)
            {
                return HttpNotFound();
            }
            return View(cON_DIARIO_DET);
        }

        // POST: CON_DIARIO_DET/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CON_DIARIO_DET cON_DIARIO_DET = await db.CON_DIARIO_DET.FindAsync(id);
            db.CON_DIARIO_DET.Remove(cON_DIARIO_DET);
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
