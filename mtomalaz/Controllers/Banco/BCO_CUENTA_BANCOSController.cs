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
    public class BCO_CUENTA_BANCOSController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: BCO_CUENTA_BANCOS
        public async Task<ActionResult> Index()
        {
            var bCO_CUENTA_BANCOS = db.BCO_CUENTA_BANCOS.Include(b => b.BCO_BANCOS).Include(b => b.SEG_EMPRESA).Include(b => b.SEG_ESTADO_AI).Include(b => b.SEG_USUARIO).Include(b => b.SEG_USUARIO1).Include(b => b.CON_CUENTA_PLAN).Include(b => b.BCO_CUENTA_TIPO);
            return View(await bCO_CUENTA_BANCOS.ToListAsync());
        }

        // GET: BCO_CUENTA_BANCOS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_CUENTA_BANCOS bCO_CUENTA_BANCOS = await db.BCO_CUENTA_BANCOS.FindAsync(id);
            if (bCO_CUENTA_BANCOS == null)
            {
                return HttpNotFound();
            }
            return View(bCO_CUENTA_BANCOS);
        }

        // GET: BCO_CUENTA_BANCOS/Create
        public ActionResult Create()
        {
            ViewBag.Bco_Ban_Id = new SelectList(db.BCO_BANCOS, "Bco_Ban_Id", "Bco_Ban_Nombre");
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Con_PlaCta_Id = new SelectList(db.CON_CUENTA_PLAN, "Con_PlaCta_Id", "Con_PlaCta_Cuenta");
            ViewBag.Bco_CtaTipo_Id = new SelectList(db.BCO_CUENTA_TIPO, "Bco_CtaTipo_Id", "Bco_CtaTipo_Descripcion");
            return View();
        }

        // POST: BCO_CUENTA_BANCOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Bco_Cta_Id,SEG_EMPRESA_Id,Bco_Ban_Id,Bco_CtaTipo_Id,Bco_Cta_Numero,Bco_Cta_FecApertura,Bco_Cta_UltCheq,Bco_Cta_FecUltCheq,Con_PlaCta_Id,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] BCO_CUENTA_BANCOS bCO_CUENTA_BANCOS)
        {
            if (ModelState.IsValid)
            {
                db.BCO_CUENTA_BANCOS.Add(bCO_CUENTA_BANCOS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Bco_Ban_Id = new SelectList(db.BCO_BANCOS, "Bco_Ban_Id", "Bco_Ban_Nombre", bCO_CUENTA_BANCOS.Bco_Ban_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", bCO_CUENTA_BANCOS.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_CUENTA_BANCOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_BANCOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_BANCOS.Aud_Usuario_Modifica);
            ViewBag.Con_PlaCta_Id = new SelectList(db.CON_CUENTA_PLAN, "Con_PlaCta_Id", "Con_PlaCta_Cuenta", bCO_CUENTA_BANCOS.Con_PlaCta_Id);
            ViewBag.Bco_CtaTipo_Id = new SelectList(db.BCO_CUENTA_TIPO, "Bco_CtaTipo_Id", "Bco_CtaTipo_Descripcion", bCO_CUENTA_BANCOS.Bco_CtaTipo_Id);
            return View(bCO_CUENTA_BANCOS);
        }

        // GET: BCO_CUENTA_BANCOS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_CUENTA_BANCOS bCO_CUENTA_BANCOS = await db.BCO_CUENTA_BANCOS.FindAsync(id);
            if (bCO_CUENTA_BANCOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bco_Ban_Id = new SelectList(db.BCO_BANCOS, "Bco_Ban_Id", "Bco_Ban_Nombre", bCO_CUENTA_BANCOS.Bco_Ban_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", bCO_CUENTA_BANCOS.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_CUENTA_BANCOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_BANCOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_BANCOS.Aud_Usuario_Modifica);
            ViewBag.Con_PlaCta_Id = new SelectList(db.CON_CUENTA_PLAN, "Con_PlaCta_Id", "Con_PlaCta_Cuenta", bCO_CUENTA_BANCOS.Con_PlaCta_Id);
            ViewBag.Bco_CtaTipo_Id = new SelectList(db.BCO_CUENTA_TIPO, "Bco_CtaTipo_Id", "Bco_CtaTipo_Descripcion", bCO_CUENTA_BANCOS.Bco_CtaTipo_Id);
            return View(bCO_CUENTA_BANCOS);
        }

        // POST: BCO_CUENTA_BANCOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Bco_Cta_Id,SEG_EMPRESA_Id,Bco_Ban_Id,Bco_CtaTipo_Id,Bco_Cta_Numero,Bco_Cta_FecApertura,Bco_Cta_UltCheq,Bco_Cta_FecUltCheq,Con_PlaCta_Id,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] BCO_CUENTA_BANCOS bCO_CUENTA_BANCOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bCO_CUENTA_BANCOS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Bco_Ban_Id = new SelectList(db.BCO_BANCOS, "Bco_Ban_Id", "Bco_Ban_Nombre", bCO_CUENTA_BANCOS.Bco_Ban_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", bCO_CUENTA_BANCOS.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_CUENTA_BANCOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_BANCOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CUENTA_BANCOS.Aud_Usuario_Modifica);
            ViewBag.Con_PlaCta_Id = new SelectList(db.CON_CUENTA_PLAN, "Con_PlaCta_Id", "Con_PlaCta_Cuenta", bCO_CUENTA_BANCOS.Con_PlaCta_Id);
            ViewBag.Bco_CtaTipo_Id = new SelectList(db.BCO_CUENTA_TIPO, "Bco_CtaTipo_Id", "Bco_CtaTipo_Descripcion", bCO_CUENTA_BANCOS.Bco_CtaTipo_Id);
            return View(bCO_CUENTA_BANCOS);
        }

        // GET: BCO_CUENTA_BANCOS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_CUENTA_BANCOS bCO_CUENTA_BANCOS = await db.BCO_CUENTA_BANCOS.FindAsync(id);
            if (bCO_CUENTA_BANCOS == null)
            {
                return HttpNotFound();
            }
            return View(bCO_CUENTA_BANCOS);
        }

        // POST: BCO_CUENTA_BANCOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BCO_CUENTA_BANCOS bCO_CUENTA_BANCOS = await db.BCO_CUENTA_BANCOS.FindAsync(id);
            db.BCO_CUENTA_BANCOS.Remove(bCO_CUENTA_BANCOS);
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
