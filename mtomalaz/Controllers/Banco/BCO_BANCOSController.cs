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
    public class BCO_BANCOSController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: BCO_BANCOS
        public async Task<ActionResult> Index()
        {
            var bCO_BANCOS = db.BCO_BANCOS.Include(b => b.GEN_PRM_GEOI_CIUDAD).Include(b => b.SEG_ESTADO_AI).Include(b => b.BCO_CODIGO_FINANCIERO).Include(b => b.SEG_USUARIO).Include(b => b.SEG_USUARIO1).Include(b => b.GEN_PRM_GEOA_PAISES).Include(b => b.GEN_PRM_GEOE_PROVINCIAS).Include(b => b.GEN_PRM_GEOO_PARROQUIAS);
            return View(await bCO_BANCOS.ToListAsync());
        }

        // GET: BCO_BANCOS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_BANCOS bCO_BANCOS = await db.BCO_BANCOS.FindAsync(id);
            if (bCO_BANCOS == null)
            {
                return HttpNotFound();
            }
            return View(bCO_BANCOS);
        }

        // GET: BCO_BANCOS/Create
        public ActionResult Create()
        {
            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Bco_CodFinan_Id = new SelectList(db.BCO_CODIGO_FINANCIERO, "Bco_CodFinan_Id", "Bco_CodFinan_Codigo");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo");
            ViewBag.Gen_PrmPro_Id = new SelectList(db.GEN_PRM_GEOE_PROVINCIAS, "Gen_PrmPro_Id", "Gen_PrmPro_Codigo");
            ViewBag.Gen_PrmPrq_Id = new SelectList(db.GEN_PRM_GEOO_PARROQUIAS, "Gen_PrmPrq_Id", "Gen_PrmPrq_Codigo");
            return View();
        }

        // POST: BCO_BANCOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Bco_Ban_Id,Bco_Ban_Nombre,Bco_CodFinan_Id,Bco_Ban_Agencia,Bco_Ban_RUC,Gen_PrmPai_Id,Gen_PrmPro_Id,Gen_PrmCiu_Id,Gen_PrmPrq_Id,Bco_Ban_Direccion,Bco_Ban_OficialCta,Bco_Ban_Telefono,Bco_Ban_Email,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] BCO_BANCOS bCO_BANCOS)
        {
            if (ModelState.IsValid)
            {
                db.BCO_BANCOS.Add(bCO_BANCOS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo", bCO_BANCOS.Gen_PrmCiu_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_BANCOS.Aud_EstadoAI_Id);
            ViewBag.Bco_CodFinan_Id = new SelectList(db.BCO_CODIGO_FINANCIERO, "Bco_CodFinan_Id", "Bco_CodFinan_Codigo", bCO_BANCOS.Bco_CodFinan_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_BANCOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_BANCOS.Aud_Usuario_Modifica);
            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo", bCO_BANCOS.Gen_PrmPai_Id);
            ViewBag.Gen_PrmPro_Id = new SelectList(db.GEN_PRM_GEOE_PROVINCIAS, "Gen_PrmPro_Id", "Gen_PrmPro_Codigo", bCO_BANCOS.Gen_PrmPro_Id);
            ViewBag.Gen_PrmPrq_Id = new SelectList(db.GEN_PRM_GEOO_PARROQUIAS, "Gen_PrmPrq_Id", "Gen_PrmPrq_Codigo", bCO_BANCOS.Gen_PrmPrq_Id);
            return View(bCO_BANCOS);
        }

        // GET: BCO_BANCOS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_BANCOS bCO_BANCOS = await db.BCO_BANCOS.FindAsync(id);
            if (bCO_BANCOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo", bCO_BANCOS.Gen_PrmCiu_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_BANCOS.Aud_EstadoAI_Id);
            ViewBag.Bco_CodFinan_Id = new SelectList(db.BCO_CODIGO_FINANCIERO, "Bco_CodFinan_Id", "Bco_CodFinan_Codigo", bCO_BANCOS.Bco_CodFinan_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_BANCOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_BANCOS.Aud_Usuario_Modifica);
            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo", bCO_BANCOS.Gen_PrmPai_Id);
            ViewBag.Gen_PrmPro_Id = new SelectList(db.GEN_PRM_GEOE_PROVINCIAS, "Gen_PrmPro_Id", "Gen_PrmPro_Codigo", bCO_BANCOS.Gen_PrmPro_Id);
            ViewBag.Gen_PrmPrq_Id = new SelectList(db.GEN_PRM_GEOO_PARROQUIAS, "Gen_PrmPrq_Id", "Gen_PrmPrq_Codigo", bCO_BANCOS.Gen_PrmPrq_Id);
            return View(bCO_BANCOS);
        }

        // POST: BCO_BANCOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Bco_Ban_Id,Bco_Ban_Nombre,Bco_CodFinan_Id,Bco_Ban_Agencia,Bco_Ban_RUC,Gen_PrmPai_Id,Gen_PrmPro_Id,Gen_PrmCiu_Id,Gen_PrmPrq_Id,Bco_Ban_Direccion,Bco_Ban_OficialCta,Bco_Ban_Telefono,Bco_Ban_Email,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] BCO_BANCOS bCO_BANCOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bCO_BANCOS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo", bCO_BANCOS.Gen_PrmCiu_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", bCO_BANCOS.Aud_EstadoAI_Id);
            ViewBag.Bco_CodFinan_Id = new SelectList(db.BCO_CODIGO_FINANCIERO, "Bco_CodFinan_Id", "Bco_CodFinan_Codigo", bCO_BANCOS.Bco_CodFinan_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_BANCOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", bCO_BANCOS.Aud_Usuario_Modifica);
            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo", bCO_BANCOS.Gen_PrmPai_Id);
            ViewBag.Gen_PrmPro_Id = new SelectList(db.GEN_PRM_GEOE_PROVINCIAS, "Gen_PrmPro_Id", "Gen_PrmPro_Codigo", bCO_BANCOS.Gen_PrmPro_Id);
            ViewBag.Gen_PrmPrq_Id = new SelectList(db.GEN_PRM_GEOO_PARROQUIAS, "Gen_PrmPrq_Id", "Gen_PrmPrq_Codigo", bCO_BANCOS.Gen_PrmPrq_Id);
            return View(bCO_BANCOS);
        }

        // GET: BCO_BANCOS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCO_BANCOS bCO_BANCOS = await db.BCO_BANCOS.FindAsync(id);
            if (bCO_BANCOS == null)
            {
                return HttpNotFound();
            }
            return View(bCO_BANCOS);
        }

        // POST: BCO_BANCOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BCO_BANCOS bCO_BANCOS = await db.BCO_BANCOS.FindAsync(id);
            db.BCO_BANCOS.Remove(bCO_BANCOS);
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
