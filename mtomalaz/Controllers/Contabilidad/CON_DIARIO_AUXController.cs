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
    public class CON_DIARIO_AUXController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: CON_DIARIO_AUX
        public async Task<ActionResult> Index()
        {
            var cON_DIARIO_AUX = db.CON_DIARIO_AUX.Include(c => c.CON_CENTRO_COSTOS).Include(c => c.CON_DIARIO_AUX_TIPO).Include(c => c.CON_DIARIO_CAB).Include(c => c.CON_DIARIO_DET).Include(c => c.SEG_EMPRESA).Include(c => c.SEG_ESTADO_AI).Include(c => c.SEG_USUARIO).Include(c => c.SEG_USUARIO1);
            return View(await cON_DIARIO_AUX.ToListAsync());
        }

        // GET: CON_DIARIO_AUX/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_AUX cON_DIARIO_AUX = await db.CON_DIARIO_AUX.FindAsync(id);
            if (cON_DIARIO_AUX == null)
            {
                return HttpNotFound();
            }
            return View(cON_DIARIO_AUX);
        }

        // GET: CON_DIARIO_AUX/Create
        public ActionResult Create()
        {
            ViewBag.Con_CCos_Id = new SelectList(db.CON_CENTRO_COSTOS, "Con_CCos_Id", "Con_CCos_Codigo");
            ViewBag.Con_AuxTipo_Id = new SelectList(db.CON_DIARIO_AUX_TIPO, "Con_AuxTipo_Id", "Con_Aux_Descripcion");
            ViewBag.Con_DiarioCab_Id = new SelectList(db.CON_DIARIO_CAB, "Con_DiarioCab_Id", "Con_DiarioCab_Numero");
            ViewBag.Con_DiarioDet_Id = new SelectList(db.CON_DIARIO_DET, "Con_DiarioDet_Id", "Con_DiarioDet_Glosa");
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: CON_DIARIO_AUX/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Con_DiarioAux_Id,SEG_EMPRESA_Id,Con_DiarioCab_Id,Con_DiarioDet_Id,Con_AuxTipo_Id,Con_DiarioAux_Codigo,Con_DiarioAux_Nombre,Con_CCos_Id,Con_DiarioAux_Glosa,Con_DiarioAux_Total,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_DIARIO_AUX cON_DIARIO_AUX)
        {
            if (ModelState.IsValid)
            {
                db.CON_DIARIO_AUX.Add(cON_DIARIO_AUX);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Con_CCos_Id = new SelectList(db.CON_CENTRO_COSTOS, "Con_CCos_Id", "Con_CCos_Codigo", cON_DIARIO_AUX.Con_CCos_Id);
            ViewBag.Con_AuxTipo_Id = new SelectList(db.CON_DIARIO_AUX_TIPO, "Con_AuxTipo_Id", "Con_Aux_Descripcion", cON_DIARIO_AUX.Con_AuxTipo_Id);
            ViewBag.Con_DiarioCab_Id = new SelectList(db.CON_DIARIO_CAB, "Con_DiarioCab_Id", "Con_DiarioCab_Numero", cON_DIARIO_AUX.Con_DiarioCab_Id);
            ViewBag.Con_DiarioDet_Id = new SelectList(db.CON_DIARIO_DET, "Con_DiarioDet_Id", "Con_DiarioDet_Glosa", cON_DIARIO_AUX.Con_DiarioDet_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_DIARIO_AUX.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_AUX.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_AUX.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_AUX.Aud_Usuario_Modifica);
            return View(cON_DIARIO_AUX);
        }

        // GET: CON_DIARIO_AUX/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_AUX cON_DIARIO_AUX = await db.CON_DIARIO_AUX.FindAsync(id);
            if (cON_DIARIO_AUX == null)
            {
                return HttpNotFound();
            }
            ViewBag.Con_CCos_Id = new SelectList(db.CON_CENTRO_COSTOS, "Con_CCos_Id", "Con_CCos_Codigo", cON_DIARIO_AUX.Con_CCos_Id);
            ViewBag.Con_AuxTipo_Id = new SelectList(db.CON_DIARIO_AUX_TIPO, "Con_AuxTipo_Id", "Con_Aux_Descripcion", cON_DIARIO_AUX.Con_AuxTipo_Id);
            ViewBag.Con_DiarioCab_Id = new SelectList(db.CON_DIARIO_CAB, "Con_DiarioCab_Id", "Con_DiarioCab_Numero", cON_DIARIO_AUX.Con_DiarioCab_Id);
            ViewBag.Con_DiarioDet_Id = new SelectList(db.CON_DIARIO_DET, "Con_DiarioDet_Id", "Con_DiarioDet_Glosa", cON_DIARIO_AUX.Con_DiarioDet_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_DIARIO_AUX.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_AUX.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_AUX.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_AUX.Aud_Usuario_Modifica);
            return View(cON_DIARIO_AUX);
        }

        // POST: CON_DIARIO_AUX/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Con_DiarioAux_Id,SEG_EMPRESA_Id,Con_DiarioCab_Id,Con_DiarioDet_Id,Con_AuxTipo_Id,Con_DiarioAux_Codigo,Con_DiarioAux_Nombre,Con_CCos_Id,Con_DiarioAux_Glosa,Con_DiarioAux_Total,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_DIARIO_AUX cON_DIARIO_AUX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cON_DIARIO_AUX).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Con_CCos_Id = new SelectList(db.CON_CENTRO_COSTOS, "Con_CCos_Id", "Con_CCos_Codigo", cON_DIARIO_AUX.Con_CCos_Id);
            ViewBag.Con_AuxTipo_Id = new SelectList(db.CON_DIARIO_AUX_TIPO, "Con_AuxTipo_Id", "Con_Aux_Descripcion", cON_DIARIO_AUX.Con_AuxTipo_Id);
            ViewBag.Con_DiarioCab_Id = new SelectList(db.CON_DIARIO_CAB, "Con_DiarioCab_Id", "Con_DiarioCab_Numero", cON_DIARIO_AUX.Con_DiarioCab_Id);
            ViewBag.Con_DiarioDet_Id = new SelectList(db.CON_DIARIO_DET, "Con_DiarioDet_Id", "Con_DiarioDet_Glosa", cON_DIARIO_AUX.Con_DiarioDet_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_DIARIO_AUX.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_DIARIO_AUX.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_AUX.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_DIARIO_AUX.Aud_Usuario_Modifica);
            return View(cON_DIARIO_AUX);
        }

        // GET: CON_DIARIO_AUX/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_DIARIO_AUX cON_DIARIO_AUX = await db.CON_DIARIO_AUX.FindAsync(id);
            if (cON_DIARIO_AUX == null)
            {
                return HttpNotFound();
            }
            return View(cON_DIARIO_AUX);
        }

        // POST: CON_DIARIO_AUX/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CON_DIARIO_AUX cON_DIARIO_AUX = await db.CON_DIARIO_AUX.FindAsync(id);
            db.CON_DIARIO_AUX.Remove(cON_DIARIO_AUX);
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
