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

namespace mtomalaz.Controllers.Seguridad
{
    public class SEG_ENTIDADController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: SEG_ENTIDAD
        public async Task<ActionResult> Index()
        {
            var sEG_ENTIDAD = db.SEG_ENTIDAD.Include(s => s.SEG_EMPRESA).Include(s => s.SEG_ESTADO_AI).Include(s => s.SEG_USUARIO).Include(s => s.SEG_USUARIO1);
            return View(await sEG_ENTIDAD.ToListAsync());
        }

        // GET: SEG_ENTIDAD/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_ENTIDAD sEG_ENTIDAD = await db.SEG_ENTIDAD.FindAsync(id);
            if (sEG_ENTIDAD == null)
            {
                return HttpNotFound();
            }
            return View(sEG_ENTIDAD);
        }

        // GET: SEG_ENTIDAD/Create
        public ActionResult Create()
        {
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: SEG_ENTIDAD/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SEG_ENTIDAD_Id,EMP_Id_Empresa,ENT_Id_Entidad,ENT_Nombre,ENT_Apellido,ENT_Ced_Ruc,ENT_Est_Civil,ENT_Titulo,ENT_Sexo,ENT_Persona,ENT_Direccion,ENT_Telefono,ENT_Fax,ENT_Email,PAI_Continente,PAI_Id_Pais,PRO_Id_Provin,CIU_Id_Ciudad,ENT_Descripcion,ENT_Estado,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_ENTIDAD sEG_ENTIDAD)
        {
            if (ModelState.IsValid)
            {
                db.SEG_ENTIDAD.Add(sEG_ENTIDAD);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_ENTIDAD.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_ENTIDAD.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ENTIDAD.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ENTIDAD.Aud_Usuario_Modifica);
            return View(sEG_ENTIDAD);
        }

        // GET: SEG_ENTIDAD/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_ENTIDAD sEG_ENTIDAD = await db.SEG_ENTIDAD.FindAsync(id);
            if (sEG_ENTIDAD == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_ENTIDAD.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_ENTIDAD.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ENTIDAD.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ENTIDAD.Aud_Usuario_Modifica);
            return View(sEG_ENTIDAD);
        }

        // POST: SEG_ENTIDAD/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SEG_ENTIDAD_Id,EMP_Id_Empresa,ENT_Id_Entidad,ENT_Nombre,ENT_Apellido,ENT_Ced_Ruc,ENT_Est_Civil,ENT_Titulo,ENT_Sexo,ENT_Persona,ENT_Direccion,ENT_Telefono,ENT_Fax,ENT_Email,PAI_Continente,PAI_Id_Pais,PRO_Id_Provin,CIU_Id_Ciudad,ENT_Descripcion,ENT_Estado,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] SEG_ENTIDAD sEG_ENTIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEG_ENTIDAD).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_Id_Empresa = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", sEG_ENTIDAD.EMP_Id_Empresa);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", sEG_ENTIDAD.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ENTIDAD.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", sEG_ENTIDAD.Aud_Usuario_Modifica);
            return View(sEG_ENTIDAD);
        }

        // GET: SEG_ENTIDAD/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEG_ENTIDAD sEG_ENTIDAD = await db.SEG_ENTIDAD.FindAsync(id);
            if (sEG_ENTIDAD == null)
            {
                return HttpNotFound();
            }
            return View(sEG_ENTIDAD);
        }

        // POST: SEG_ENTIDAD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SEG_ENTIDAD sEG_ENTIDAD = await db.SEG_ENTIDAD.FindAsync(id);
            db.SEG_ENTIDAD.Remove(sEG_ENTIDAD);
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
