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
    public class CON_CUENTA_PLANController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: CON_CUENTA_PLAN
        public async Task<ActionResult> Index()
        {
            var cON_CUENTA_PLAN = db.CON_CUENTA_PLAN.Include(c => c.CON_CUENTA_CLASE).Include(c => c.CON_CUENTA_NIVEL).Include(c => c.GEN_ANIO).Include(c => c.CON_CUENTA_TIPO).Include(c => c.SEG_EMPRESA).Include(c => c.SEG_ESTADO_AI).Include(c => c.SEG_USUARIO).Include(c => c.SEG_USUARIO1).Include(c => c.SEG_ESTADO_AI1).Include(c => c.SEG_ESTADO_AI2).Include(c => c.SEG_ESTADO_AI3).Include(c => c.SEG_ESTADO_AI4);
            return View(await cON_CUENTA_PLAN.ToListAsync());
        }

        // GET: CON_CUENTA_PLAN/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_CUENTA_PLAN cON_CUENTA_PLAN = await db.CON_CUENTA_PLAN.FindAsync(id);
            if (cON_CUENTA_PLAN == null)
            {
                return HttpNotFound();
            }
            return View(cON_CUENTA_PLAN);
        }

        // GET: CON_CUENTA_PLAN/Create
        public ActionResult Create()
        {
            ViewBag.Con_ClasCta_Id = new SelectList(db.CON_CUENTA_CLASE, "Con_ClasCta_Id", "Con_ClasCta_Grupo");
            ViewBag.Con_NivCta_Id = new SelectList(db.CON_CUENTA_NIVEL, "Con_NivCta_Id", "Con_NivCta_Descripcion");
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion");
            ViewBag.Con_TipCta_Id = new SelectList(db.CON_CUENTA_TIPO, "Con_TipCta_Id", "Con_TipCta_Descripcion");
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Con_PlaCta_Req_Aux_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Con_PlaCta_GeneMov_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Con_PlaCta_Req_Cc_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Con_PlaCta_Req_AuxSub_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            return View();
        }

        // POST: CON_CUENTA_PLAN/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Con_PlaCta_Id,Gen_PrmAnio_Id,SEG_EMPRESA_Id,Con_NivCta_Id,Con_TipCta_Id,Con_ClasCta_Id,Con_PlaCta_Cuenta,Con_PlaCta_Nombre,Con_PlaCta_GeneMov_SN,Con_PlaCta_Req_Aux_SN,Con_PlaCta_Req_AuxSub_SN,Con_PlaCta_Req_Cc_SN,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_CUENTA_PLAN cON_CUENTA_PLAN)
        {
            if (ModelState.IsValid)
            {
                db.CON_CUENTA_PLAN.Add(cON_CUENTA_PLAN);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Con_ClasCta_Id = new SelectList(db.CON_CUENTA_CLASE, "Con_ClasCta_Id", "Con_ClasCta_Grupo", cON_CUENTA_PLAN.Con_ClasCta_Id);
            ViewBag.Con_NivCta_Id = new SelectList(db.CON_CUENTA_NIVEL, "Con_NivCta_Id", "Con_NivCta_Descripcion", cON_CUENTA_PLAN.Con_NivCta_Id);
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_CUENTA_PLAN.Gen_PrmAnio_Id);
            ViewBag.Con_TipCta_Id = new SelectList(db.CON_CUENTA_TIPO, "Con_TipCta_Id", "Con_TipCta_Descripcion", cON_CUENTA_PLAN.Con_TipCta_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_CUENTA_PLAN.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_PLAN.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_PLAN.Aud_Usuario_Modifica);
            ViewBag.Con_PlaCta_Req_Aux_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_Req_Aux_SN);
            ViewBag.Con_PlaCta_GeneMov_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_GeneMov_SN);
            ViewBag.Con_PlaCta_Req_Cc_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_Req_Cc_SN);
            ViewBag.Con_PlaCta_Req_AuxSub_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_Req_AuxSub_SN);
            return View(cON_CUENTA_PLAN);
        }

        // GET: CON_CUENTA_PLAN/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_CUENTA_PLAN cON_CUENTA_PLAN = await db.CON_CUENTA_PLAN.FindAsync(id);
            if (cON_CUENTA_PLAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.Con_ClasCta_Id = new SelectList(db.CON_CUENTA_CLASE, "Con_ClasCta_Id", "Con_ClasCta_Grupo", cON_CUENTA_PLAN.Con_ClasCta_Id);
            ViewBag.Con_NivCta_Id = new SelectList(db.CON_CUENTA_NIVEL, "Con_NivCta_Id", "Con_NivCta_Descripcion", cON_CUENTA_PLAN.Con_NivCta_Id);
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_CUENTA_PLAN.Gen_PrmAnio_Id);
            ViewBag.Con_TipCta_Id = new SelectList(db.CON_CUENTA_TIPO, "Con_TipCta_Id", "Con_TipCta_Descripcion", cON_CUENTA_PLAN.Con_TipCta_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_CUENTA_PLAN.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_PLAN.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_PLAN.Aud_Usuario_Modifica);
            ViewBag.Con_PlaCta_Req_Aux_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_Req_Aux_SN);
            ViewBag.Con_PlaCta_GeneMov_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_GeneMov_SN);
            ViewBag.Con_PlaCta_Req_Cc_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_Req_Cc_SN);
            ViewBag.Con_PlaCta_Req_AuxSub_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_Req_AuxSub_SN);
            return View(cON_CUENTA_PLAN);
        }

        // POST: CON_CUENTA_PLAN/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Con_PlaCta_Id,Gen_PrmAnio_Id,SEG_EMPRESA_Id,Con_NivCta_Id,Con_TipCta_Id,Con_ClasCta_Id,Con_PlaCta_Cuenta,Con_PlaCta_Nombre,Con_PlaCta_GeneMov_SN,Con_PlaCta_Req_Aux_SN,Con_PlaCta_Req_AuxSub_SN,Con_PlaCta_Req_Cc_SN,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_CUENTA_PLAN cON_CUENTA_PLAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cON_CUENTA_PLAN).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Con_ClasCta_Id = new SelectList(db.CON_CUENTA_CLASE, "Con_ClasCta_Id", "Con_ClasCta_Grupo", cON_CUENTA_PLAN.Con_ClasCta_Id);
            ViewBag.Con_NivCta_Id = new SelectList(db.CON_CUENTA_NIVEL, "Con_NivCta_Id", "Con_NivCta_Descripcion", cON_CUENTA_PLAN.Con_NivCta_Id);
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_CUENTA_PLAN.Gen_PrmAnio_Id);
            ViewBag.Con_TipCta_Id = new SelectList(db.CON_CUENTA_TIPO, "Con_TipCta_Id", "Con_TipCta_Descripcion", cON_CUENTA_PLAN.Con_TipCta_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_CUENTA_PLAN.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_PLAN.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CUENTA_PLAN.Aud_Usuario_Modifica);
            ViewBag.Con_PlaCta_Req_Aux_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_Req_Aux_SN);
            ViewBag.Con_PlaCta_GeneMov_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_GeneMov_SN);
            ViewBag.Con_PlaCta_Req_Cc_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_Req_Cc_SN);
            ViewBag.Con_PlaCta_Req_AuxSub_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CUENTA_PLAN.Con_PlaCta_Req_AuxSub_SN);
            return View(cON_CUENTA_PLAN);
        }

        // GET: CON_CUENTA_PLAN/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_CUENTA_PLAN cON_CUENTA_PLAN = await db.CON_CUENTA_PLAN.FindAsync(id);
            if (cON_CUENTA_PLAN == null)
            {
                return HttpNotFound();
            }
            return View(cON_CUENTA_PLAN);
        }

        // POST: CON_CUENTA_PLAN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CON_CUENTA_PLAN cON_CUENTA_PLAN = await db.CON_CUENTA_PLAN.FindAsync(id);
            db.CON_CUENTA_PLAN.Remove(cON_CUENTA_PLAN);
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
