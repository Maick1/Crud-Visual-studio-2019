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
    public class BCO_CODIGO_FINANCIEROController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: BCO_CODIGO_FINANCIERO
        public async Task<ActionResult> Index()
        {
            var bCO_CODIGO_FINANCIERO = db.BCO_CODIGO_FINANCIERO.Include(b => b.SEG_ESTADO_AI).Include(b => b.SEG_USUARIO).Include(b => b.SEG_USUARIO1);
            return View(await bCO_CODIGO_FINANCIERO.ToListAsync());
        }

        // GET: BCO_CODIGO_FINANCIERO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_CODIGO_FINANCIERO bCO_CODIGO_FINANCIERO = await db.BCO_CODIGO_FINANCIERO.FindAsync(id);
            if (bCO_CODIGO_FINANCIERO == null)
            {
                return HttpNotFound();
            }
            return View(bCO_CODIGO_FINANCIERO);
        }

        // GET: BCO_CODIGO_FINANCIERO/Create
        public ActionResult Create()
        {
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: BCO_CODIGO_FINANCIERO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Bco_CodFinan_Id,Bco_CodFinan_Codigo,Bco_CodFinan_Nombre,Bco_CodFinan_Abreviatura,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] BCO_CODIGO_FINANCIERO bCO_CODIGO_FINANCIERO)
        {
            if (ModelState.IsValid)
            {
                db.BCO_CODIGO_FINANCIERO.Add(bCO_CODIGO_FINANCIERO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_CODIGO_FINANCIERO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CODIGO_FINANCIERO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CODIGO_FINANCIERO.Aud_Usuario_Modifica);
            return View(bCO_CODIGO_FINANCIERO);
        }

        // GET: BCO_CODIGO_FINANCIERO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_CODIGO_FINANCIERO bCO_CODIGO_FINANCIERO = await db.BCO_CODIGO_FINANCIERO.FindAsync(id);
            if (bCO_CODIGO_FINANCIERO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_CODIGO_FINANCIERO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CODIGO_FINANCIERO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CODIGO_FINANCIERO.Aud_Usuario_Modifica);
            return View(bCO_CODIGO_FINANCIERO);
        }

        // POST: BCO_CODIGO_FINANCIERO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Bco_CodFinan_Id,Bco_CodFinan_Codigo,Bco_CodFinan_Nombre,Bco_CodFinan_Abreviatura,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] BCO_CODIGO_FINANCIERO bCO_CODIGO_FINANCIERO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bCO_CODIGO_FINANCIERO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_CODIGO_FINANCIERO.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CODIGO_FINANCIERO.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_CODIGO_FINANCIERO.Aud_Usuario_Modifica);
            return View(bCO_CODIGO_FINANCIERO);
        }

        // GET: BCO_CODIGO_FINANCIERO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_CODIGO_FINANCIERO bCO_CODIGO_FINANCIERO = await db.BCO_CODIGO_FINANCIERO.FindAsync(id);
            if (bCO_CODIGO_FINANCIERO == null)
            {
                return HttpNotFound();
            }
            return View(bCO_CODIGO_FINANCIERO);
        }

        // POST: BCO_CODIGO_FINANCIERO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BCO_CODIGO_FINANCIERO bCO_CODIGO_FINANCIERO = await db.BCO_CODIGO_FINANCIERO.FindAsync(id);
            db.BCO_CODIGO_FINANCIERO.Remove(bCO_CODIGO_FINANCIERO);
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
