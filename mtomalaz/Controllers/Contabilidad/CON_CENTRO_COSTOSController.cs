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
    public class CON_CENTRO_COSTOSController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: CON_CENTRO_COSTOS
        public async Task<ActionResult> Index()
        {
            var cON_CENTRO_COSTOS = db.CON_CENTRO_COSTOS.Include(c => c.GEN_ANIO).Include(c => c.CON_CENTRO_COSTOS_TIPO).Include(c => c.SEG_EMPRESA).Include(c => c.SEG_ESTADO_AI).Include(c => c.SEG_USUARIO).Include(c => c.SEG_USUARIO1);
            return View(await cON_CENTRO_COSTOS.ToListAsync());
        }

        // GET: CON_CENTRO_COSTOS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_CENTRO_COSTOS cON_CENTRO_COSTOS = await db.CON_CENTRO_COSTOS.FindAsync(id);
            if (cON_CENTRO_COSTOS == null)
            {
                return HttpNotFound();
            }
            return View(cON_CENTRO_COSTOS);
        }

        // GET: CON_CENTRO_COSTOS/Create
        public ActionResult Create()
        {
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion");
            ViewBag.Con_CCosTip_Id = new SelectList(db.CON_CENTRO_COSTOS_TIPO, "Con_CCosTip_Id", "Gen_CcoT_Nombre");
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: CON_CENTRO_COSTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Con_CCos_Id,Gen_PrmAnio_Id,SEG_EMPRESA_Id,Con_CCosTip_Id,Con_CCos_Codigo,Con_CCos_Nombre,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_CENTRO_COSTOS cON_CENTRO_COSTOS)
        {
            if (ModelState.IsValid)
            {
                db.CON_CENTRO_COSTOS.Add(cON_CENTRO_COSTOS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_CENTRO_COSTOS.Gen_PrmAnio_Id);
            ViewBag.Con_CCosTip_Id = new SelectList(db.CON_CENTRO_COSTOS_TIPO, "Con_CCosTip_Id", "Gen_CcoT_Nombre", cON_CENTRO_COSTOS.Con_CCosTip_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_CENTRO_COSTOS.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CENTRO_COSTOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CENTRO_COSTOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CENTRO_COSTOS.Aud_Usuario_Modifica);
            return View(cON_CENTRO_COSTOS);
        }

        // GET: CON_CENTRO_COSTOS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_CENTRO_COSTOS cON_CENTRO_COSTOS = await db.CON_CENTRO_COSTOS.FindAsync(id);
            if (cON_CENTRO_COSTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_CENTRO_COSTOS.Gen_PrmAnio_Id);
            ViewBag.Con_CCosTip_Id = new SelectList(db.CON_CENTRO_COSTOS_TIPO, "Con_CCosTip_Id", "Gen_CcoT_Nombre", cON_CENTRO_COSTOS.Con_CCosTip_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_CENTRO_COSTOS.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CENTRO_COSTOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CENTRO_COSTOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CENTRO_COSTOS.Aud_Usuario_Modifica);
            return View(cON_CENTRO_COSTOS);
        }

        // POST: CON_CENTRO_COSTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Con_CCos_Id,Gen_PrmAnio_Id,SEG_EMPRESA_Id,Con_CCosTip_Id,Con_CCos_Codigo,Con_CCos_Nombre,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] CON_CENTRO_COSTOS cON_CENTRO_COSTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cON_CENTRO_COSTOS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Gen_PrmAnio_Id = new SelectList(db.GEN_ANIO, "Gen_PrmAnio_Id", "Gen_PrmAnio_Descripcion", cON_CENTRO_COSTOS.Gen_PrmAnio_Id);
            ViewBag.Con_CCosTip_Id = new SelectList(db.CON_CENTRO_COSTOS_TIPO, "Con_CCosTip_Id", "Gen_CcoT_Nombre", cON_CENTRO_COSTOS.Con_CCosTip_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", cON_CENTRO_COSTOS.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", cON_CENTRO_COSTOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CENTRO_COSTOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", cON_CENTRO_COSTOS.Aud_Usuario_Modifica);
            return View(cON_CENTRO_COSTOS);
        }

        // GET: CON_CENTRO_COSTOS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CON_CENTRO_COSTOS cON_CENTRO_COSTOS = await db.CON_CENTRO_COSTOS.FindAsync(id);
            if (cON_CENTRO_COSTOS == null)
            {
                return HttpNotFound();
            }
            return View(cON_CENTRO_COSTOS);
        }

        // POST: CON_CENTRO_COSTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CON_CENTRO_COSTOS cON_CENTRO_COSTOS = await db.CON_CENTRO_COSTOS.FindAsync(id);
            db.CON_CENTRO_COSTOS.Remove(cON_CENTRO_COSTOS);
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
