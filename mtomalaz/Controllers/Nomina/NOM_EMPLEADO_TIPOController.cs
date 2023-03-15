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

namespace mtomalaz.Controllers.Nomina
{
    public class NOM_EMPLEADO_TIPOController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: NOM_EMPLEADO_TIPO
        public async Task<ActionResult> Index()
        {
            var nOM_EMPLEADO_TIPO = db.NOM_EMPLEADO_TIPO.Include(n => n.SEG_EMPRESA).Include(n => n.SEG_ESTADO_AI).Include(n => n.SEG_USUARIO).Include(n => n.SEG_USUARIO1);
            return View(await nOM_EMPLEADO_TIPO.ToListAsync());
        }

        // GET: NOM_EMPLEADO_TIPO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOM_EMPLEADO_TIPO nOM_EMPLEADO_TIPO = await db.NOM_EMPLEADO_TIPO.FindAsync(id);
            if (nOM_EMPLEADO_TIPO == null)
            {
                return HttpNotFound();
            }
            return View(nOM_EMPLEADO_TIPO);
        }

        // GET: NOM_EMPLEADO_TIPO/Create
        public ActionResult Create()
        {
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: NOM_EMPLEADO_TIPO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nom_EpdTip_Id,SEG_EMPRESA_Id,Nom_EpdTip_Descripcion,Nom_EpdTip_Codigo,Nom_EpdTip_Abreviatura,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] NOM_EMPLEADO_TIPO nOM_EMPLEADO_TIPO)
        {
            if (ModelState.IsValid)
            {
                db.NOM_EMPLEADO_TIPO.Add(nOM_EMPLEADO_TIPO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", nOM_EMPLEADO_TIPO.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADO_TIPO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADO_TIPO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADO_TIPO.Aud_Usuario_Modifica);
            return View(nOM_EMPLEADO_TIPO);
        }

        // GET: NOM_EMPLEADO_TIPO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOM_EMPLEADO_TIPO nOM_EMPLEADO_TIPO = await db.NOM_EMPLEADO_TIPO.FindAsync(id);
            if (nOM_EMPLEADO_TIPO == null)
            {
                return HttpNotFound();
            }
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", nOM_EMPLEADO_TIPO.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADO_TIPO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADO_TIPO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADO_TIPO.Aud_Usuario_Modifica);
            return View(nOM_EMPLEADO_TIPO);
        }

        // POST: NOM_EMPLEADO_TIPO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Nom_EpdTip_Id,SEG_EMPRESA_Id,Nom_EpdTip_Descripcion,Nom_EpdTip_Codigo,Nom_EpdTip_Abreviatura,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] NOM_EMPLEADO_TIPO nOM_EMPLEADO_TIPO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOM_EMPLEADO_TIPO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", nOM_EMPLEADO_TIPO.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADO_TIPO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADO_TIPO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADO_TIPO.Aud_Usuario_Modifica);
            return View(nOM_EMPLEADO_TIPO);
        }

        // GET: NOM_EMPLEADO_TIPO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOM_EMPLEADO_TIPO nOM_EMPLEADO_TIPO = await db.NOM_EMPLEADO_TIPO.FindAsync(id);
            if (nOM_EMPLEADO_TIPO == null)
            {
                return HttpNotFound();
            }
            return View(nOM_EMPLEADO_TIPO);
        }

        // POST: NOM_EMPLEADO_TIPO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NOM_EMPLEADO_TIPO nOM_EMPLEADO_TIPO = await db.NOM_EMPLEADO_TIPO.FindAsync(id);
            db.NOM_EMPLEADO_TIPO.Remove(nOM_EMPLEADO_TIPO);
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
