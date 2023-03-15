﻿using System;
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
    public class NOM_VENDEDORESController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: NOM_VENDEDORES
        public async Task<ActionResult> Index()
        {
            var nOM_VENDEDORES = db.NOM_VENDEDORES.Include(n => n.NOM_VENDEDOR_TIPO).Include(n => n.SEG_EMPRESA).Include(n => n.SEG_ESTADO_AI).Include(n => n.SEG_USUARIO).Include(n => n.SEG_USUARIO1);
            return View(await nOM_VENDEDORES.ToListAsync());
        }

        // GET: NOM_VENDEDORES/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOM_VENDEDORES nOM_VENDEDORES = await db.NOM_VENDEDORES.FindAsync(id);
            if (nOM_VENDEDORES == null)
            {
                return HttpNotFound();
            }
            return View(nOM_VENDEDORES);
        }

        // GET: NOM_VENDEDORES/Create
        public ActionResult Create()
        {
            ViewBag.Nom_VendT_Id = new SelectList(db.NOM_VENDEDOR_TIPO, "Nom_VendT_Id", "Nom_VendT_Descripcion");
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: NOM_VENDEDORES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nom_Ven_Id,SEG_EMPRESA_Id,Nom_VendT_Id,Nom_Ven_Cedula,Nom_Ven_Nombre,Nom_Ven_Apellido,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] NOM_VENDEDORES nOM_VENDEDORES)
        {
            if (ModelState.IsValid)
            {
                db.NOM_VENDEDORES.Add(nOM_VENDEDORES);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Nom_VendT_Id = new SelectList(db.NOM_VENDEDOR_TIPO, "Nom_VendT_Id", "Nom_VendT_Descripcion", nOM_VENDEDORES.Nom_VendT_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", nOM_VENDEDORES.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_VENDEDORES.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_VENDEDORES.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_VENDEDORES.Aud_Usuario_Modifica);
            return View(nOM_VENDEDORES);
        }

        // GET: NOM_VENDEDORES/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOM_VENDEDORES nOM_VENDEDORES = await db.NOM_VENDEDORES.FindAsync(id);
            if (nOM_VENDEDORES == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nom_VendT_Id = new SelectList(db.NOM_VENDEDOR_TIPO, "Nom_VendT_Id", "Nom_VendT_Descripcion", nOM_VENDEDORES.Nom_VendT_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", nOM_VENDEDORES.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_VENDEDORES.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_VENDEDORES.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_VENDEDORES.Aud_Usuario_Modifica);
            return View(nOM_VENDEDORES);
        }

        // POST: NOM_VENDEDORES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Nom_Ven_Id,SEG_EMPRESA_Id,Nom_VendT_Id,Nom_Ven_Cedula,Nom_Ven_Nombre,Nom_Ven_Apellido,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] NOM_VENDEDORES nOM_VENDEDORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOM_VENDEDORES).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Nom_VendT_Id = new SelectList(db.NOM_VENDEDOR_TIPO, "Nom_VendT_Id", "Nom_VendT_Descripcion", nOM_VENDEDORES.Nom_VendT_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", nOM_VENDEDORES.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_VENDEDORES.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_VENDEDORES.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_VENDEDORES.Aud_Usuario_Modifica);
            return View(nOM_VENDEDORES);
        }

        // GET: NOM_VENDEDORES/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOM_VENDEDORES nOM_VENDEDORES = await db.NOM_VENDEDORES.FindAsync(id);
            if (nOM_VENDEDORES == null)
            {
                return HttpNotFound();
            }
            return View(nOM_VENDEDORES);
        }

        // POST: NOM_VENDEDORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NOM_VENDEDORES nOM_VENDEDORES = await db.NOM_VENDEDORES.FindAsync(id);
            db.NOM_VENDEDORES.Remove(nOM_VENDEDORES);
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
