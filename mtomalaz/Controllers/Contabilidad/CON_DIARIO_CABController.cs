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
    public class CON_DIARIO_CABController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: CON_DIARIO_CAB
        public async Task<ActionResult> Index()
        {
            var cON_DIARIO_CAB = db.CON_DIARIO_CAB.Include(c => c.GEN_ANIO).Include(c => c.SEG_EMPRESA).Include(c => c.SEG_ESTADO_AI).Include(c => c.CON_ESTADO_CONTAB).Include(c => c.SEG_USUARIO).Include(c => c.GEN_MES).Include(c => c.SEG_USUARIO1).Include(c => c.CON_DIARIO_TIPO);
            return View(await cON_DIARIO_CAB.ToListAsync());
        }

        // GET: CON_DIARIO_CAB/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_CAB cON_DIARIO_CAB = await db.CON_DIARIO_CAB.FindAsync(id);
            if (cON_DIARIO_CAB == null)
            {
                return HttpNotFound();
            }
            return View(cON_DIARIO_CAB);
        }

        // GET: CON_DIARIO_CAB/Create
        public ActionResult Create()
        {
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion");
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Con_EstCont_Id = new SelectList(db.CON_ESTADO_CONTAB, "Con_EstCont_Id", "Con_EstCont_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Gen_PrmMes_Id = new SelectList(db.GEN_MES, "Gen_PrmMes_Id", "Gen_PrmMes_Descripcion");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Con_CompTip_Id = new SelectList(db.CON_DIARIO_TIPO, "Con_CompTip_Id", "Con_CompTip_Nombre");
            return View();
        }

        // POST: CON_DIARIO_CAB/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Con_DiarioCab_Id,Gen_PrmAnio_Id,Gen_PrmMes_Id,SEG_EMPRESA_Id,Con_CompTip_Id,Con_DiarioCab_Numero,Con_DiarioCab_Fecha_Contable,Con_DiarioCab_Diario_Nombre,Con_DiarioCab_Diario_Descripcion,Con_EstCont_Id,Con_DiarioCab_Total_Debe,Con_DiarioCab_Total_Haber,Con_DiarioCab_Digitado_Fecha,Con_DiarioCab_Digitado_Usuario,Con_DiarioCab_Procesado_Fecha,Con_DiarioCab_Procesado_Usuario,Con_DiarioCab_Reg_T_P,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_DIARIO_CAB cON_DIARIO_CAB)
        {
            if (ModelState.IsValid)
            {
                db.CON_DIARIO_CAB.Add(cON_DIARIO_CAB);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_DIARIO_CAB.Gen_PrmAnio_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_DIARIO_CAB.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_CAB.Aud_EstadoAI_Id);
            ViewBag.Con_EstCont_Id = new SelectList(db.CON_ESTADO_CONTAB, "Con_EstCont_Id", "Con_EstCont_Descripcion", cON_DIARIO_CAB.Con_EstCont_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_CAB.Aud_Usuario_Ingreso);
            ViewBag.Gen_PrmMes_Id = new SelectList(db.GEN_MES, "Gen_PrmMes_Id", "Gen_PrmMes_Descripcion", cON_DIARIO_CAB.Gen_PrmMes_Id);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_CAB.Aud_Usuario_Modifica);
            ViewBag.Con_CompTip_Id = new SelectList(db.CON_DIARIO_TIPO, "Con_CompTip_Id", "Con_CompTip_Nombre", cON_DIARIO_CAB.Con_CompTip_Id);
            return View(cON_DIARIO_CAB);
        }

        // GET: CON_DIARIO_CAB/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_CAB cON_DIARIO_CAB = await db.CON_DIARIO_CAB.FindAsync(id);
            if (cON_DIARIO_CAB == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_DIARIO_CAB.Gen_PrmAnio_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_DIARIO_CAB.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_CAB.Aud_EstadoAI_Id);
            ViewBag.Con_EstCont_Id = new SelectList(db.CON_ESTADO_CONTAB, "Con_EstCont_Id", "Con_EstCont_Descripcion", cON_DIARIO_CAB.Con_EstCont_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_CAB.Aud_Usuario_Ingreso);
            ViewBag.Gen_PrmMes_Id = new SelectList(db.GEN_MES, "Gen_PrmMes_Id", "Gen_PrmMes_Descripcion", cON_DIARIO_CAB.Gen_PrmMes_Id);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_CAB.Aud_Usuario_Modifica);
            ViewBag.Con_CompTip_Id = new SelectList(db.CON_DIARIO_TIPO, "Con_CompTip_Id", "Con_CompTip_Nombre", cON_DIARIO_CAB.Con_CompTip_Id);
            return View(cON_DIARIO_CAB);
        }

        // POST: CON_DIARIO_CAB/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Con_DiarioCab_Id,Gen_PrmAnio_Id,Gen_PrmMes_Id,SEG_EMPRESA_Id,Con_CompTip_Id,Con_DiarioCab_Numero,Con_DiarioCab_Fecha_Contable,Con_DiarioCab_Diario_Nombre,Con_DiarioCab_Diario_Descripcion,Con_EstCont_Id,Con_DiarioCab_Total_Debe,Con_DiarioCab_Total_Haber,Con_DiarioCab_Digitado_Fecha,Con_DiarioCab_Digitado_Usuario,Con_DiarioCab_Procesado_Fecha,Con_DiarioCab_Procesado_Usuario,Con_DiarioCab_Reg_T_P,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_DIARIO_CAB cON_DIARIO_CAB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cON_DIARIO_CAB).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_DIARIO_CAB.Gen_PrmAnio_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_DIARIO_CAB.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_CAB.Aud_EstadoAI_Id);
            ViewBag.Con_EstCont_Id = new SelectList(db.CON_ESTADO_CONTAB, "Con_EstCont_Id", "Con_EstCont_Descripcion", cON_DIARIO_CAB.Con_EstCont_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_CAB.Aud_Usuario_Ingreso);
            ViewBag.Gen_PrmMes_Id = new SelectList(db.GEN_MES, "Gen_PrmMes_Id", "Gen_PrmMes_Descripcion", cON_DIARIO_CAB.Gen_PrmMes_Id);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_CAB.Aud_Usuario_Modifica);
            ViewBag.Con_CompTip_Id = new SelectList(db.CON_DIARIO_TIPO, "Con_CompTip_Id", "Con_CompTip_Nombre", cON_DIARIO_CAB.Con_CompTip_Id);
            return View(cON_DIARIO_CAB);
        }

        // GET: CON_DIARIO_CAB/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_CAB cON_DIARIO_CAB = await db.CON_DIARIO_CAB.FindAsync(id);
            if (cON_DIARIO_CAB == null)
            {
                return HttpNotFound();
            }
            return View(cON_DIARIO_CAB);
        }

        // POST: CON_DIARIO_CAB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CON_DIARIO_CAB cON_DIARIO_CAB = await db.CON_DIARIO_CAB.FindAsync(id);
            db.CON_DIARIO_CAB.Remove(cON_DIARIO_CAB);
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
