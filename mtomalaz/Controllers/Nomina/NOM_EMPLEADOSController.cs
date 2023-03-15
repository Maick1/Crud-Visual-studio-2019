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
    public class NOM_EMPLEADOSController : Controller
    {
        private empresaEntities db = new empresaEntities();

        // GET: NOM_EMPLEADOS
        public async Task<ActionResult> Index()
        {
            var nOM_EMPLEADOS = db.NOM_EMPLEADOS.Include(n => n.BCO_BANCOS).Include(n => n.BCO_CUENTA_TIPO).Include(n => n.GEN_PRM_DISCAPCIDA_TIPO).Include(n => n.GEN_PRM_EDUCACION_NIVEL).Include(n => n.GEN_PRM_ESTADO_CIVL).Include(n => n.GEN_PRM_FORMA_PAGO).Include(n => n.GEN_PRM_GEOA_PAISES).Include(n => n.GEN_PRM_GEOE_PROVINCIAS).Include(n => n.GEN_PRM_GEOI_CIUDAD).Include(n => n.GEN_PRM_GEOO_PARROQUIAS).Include(n => n.GEN_PRM_OPERADORA_MOVIL).Include(n => n.GEN_PRM_PARENTESCO).Include(n => n.GEN_PRM_SEXO).Include(n => n.GEN_TIPO_IDENTIFICACION).Include(n => n.GEN_TIPO_IDENTIFICACION1).Include(n => n.NOM_EMPLEADO_TIPO).Include(n => n.SEG_EMPRESA).Include(n => n.SEG_ESTADO_AI).Include(n => n.SEG_USUARIO).Include(n => n.SEG_USUARIO1).Include(n => n.SEG_ESTADO_AI1).Include(n => n.SEG_ESTADO_AI2).Include(n => n.SEG_ESTADO_AI3).Include(n => n.SEG_USUARIO2);
            return View(await nOM_EMPLEADOS.ToListAsync());
        }

        // GET: NOM_EMPLEADOS/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOM_EMPLEADOS nOM_EMPLEADOS = await db.NOM_EMPLEADOS.FindAsync(id);
            if (nOM_EMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(nOM_EMPLEADOS);
        }

        // GET: NOM_EMPLEADOS/Create
        public ActionResult Create()
        {
            ViewBag.Bco_Ban_Id = new SelectList(db.BCO_BANCOS, "Bco_Ban_Id", "Bco_Ban_Nombre");
            ViewBag.Bco_CtaTipo_Id = new SelectList(db.BCO_CUENTA_TIPO, "Bco_CtaTipo_Id", "Bco_CtaTipo_Descripcion");
            ViewBag.Gen_PrmDiscaT_Id = new SelectList(db.GEN_PRM_DISCAPCIDA_TIPO, "Gen_PrmDiscaT_Id", "Gen_DisT_Descripcion");
            ViewBag.Gen_PrmEducN_Id = new SelectList(db.GEN_PRM_EDUCACION_NIVEL, "Gen_PrmEducN_Id", "Gen_PrmEducN_Descripcion");
            ViewBag.Gen_PrmCivilE_Id = new SelectList(db.GEN_PRM_ESTADO_CIVL, "Gen_PrmCivilE_Id", "Gen_PrmCivilE_Descripcion");
            ViewBag.Gen_PrmForPag_Id = new SelectList(db.GEN_PRM_FORMA_PAGO, "Gen_PrmForPag_Id", "Gen_PrmForPag_Descripcion");
            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo");
            ViewBag.Gen_PrmPro_Id = new SelectList(db.GEN_PRM_GEOE_PROVINCIAS, "Gen_PrmPro_Id", "Gen_PrmPro_Codigo");
            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo");
            ViewBag.Gen_PrmPrq_Id = new SelectList(db.GEN_PRM_GEOO_PARROQUIAS, "Gen_PrmPrq_Id", "Gen_PrmPrq_Codigo");
            ViewBag.Gen_PrmOperM_Id = new SelectList(db.GEN_PRM_OPERADORA_MOVIL, "Gen_PrmOperM_Id", "Gen_PrmOperM_Descripcion");
            ViewBag.Gen_PrmParenT_Id = new SelectList(db.GEN_PRM_PARENTESCO, "Gen_PrmParenT_Id", "Gen_PrmParenT_Descripcion");
            ViewBag.Gen_PrmSex_Id = new SelectList(db.GEN_PRM_SEXO, "Gen_PrmSex_Id", "Gen_PrmSex_Descripcion");
            ViewBag.Gen_TipIden_Id = new SelectList(db.GEN_TIPO_IDENTIFICACION, "Gen_TipIden_Id", "Gen_TipIden_Descripcion");
            ViewBag.Nom_Epd_Contac_Tii_Id = new SelectList(db.GEN_TIPO_IDENTIFICACION, "Gen_TipIden_Id", "Gen_TipIden_Descripcion");
            ViewBag.Nom_EpdTip_Id = new SelectList(db.NOM_EMPLEADO_TIPO, "Nom_EpdTip_Id", "Nom_EpdTip_Descripcion");
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante");
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            ViewBag.Nom_Epd_Discap_Carnet_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Nom_Epd_AsistenciaComp_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Nom_Epd_Discapacidad_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion");
            ViewBag.Nom_Epd_Usu_Sistema = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login");
            return View();
        }

        // POST: NOM_EMPLEADOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nom_Epd_Id,SEG_EMPRESA_Id,Gen_TipIden_Id,Nom_Epd_Documento,Nom_Epd_Nombre1,Nom_Epd_Nombre2,Nom_Epd_Apellido1,Nom_Epd_Apellido2,Nom_Epd_Mail_Personal,Nom_Epd_Mail_Empresa,Gen_PrmCivilE_Id,Nom_Epd_Movil,Gen_PrmOperM_Id,Nom_Epd_FecNac,Gen_PrmSex_Id,Nom_Epd_Foto,Gen_PrmForPag_Id,Nom_Epd_Usu_Sistema,Nom_Epd_Discapacidad_SN,Gen_PrmDiscaT_Id,Nom_Epd_Discap_Porc,Nom_Epd_Discap_Grad,Nom_Epd_Discap_Carnet_SN,Nom_Epd_Discap_Carnet_Num,Nom_Epd_AsistenciaComp_SN,Gen_PrmPai_Id,Gen_PrmPro_Id,Gen_PrmCiu_Id,Gen_PrmPrq_Id,Nom_Epd_Direccion,Nom_Epd_Direccion_Referen,Nom_Epd_Procedencia,Gen_PrmEducN_Id,Bco_Ban_Id,Bco_CtaTipo_Id,Nom_Epd_Banco_Cuenta,Gen_PrmParenT_Id,Nom_Epd_Contac_Nombre,Nom_Epd_Contac_Apellido,Nom_Epd_Contac_Telefono,Nom_Epd_Contac_Tii_Id,Nom_Epd_Contac_Documento,Nom_Epd_Contac_Direccion,Nom_Epd_Codigo_Reloj0,Nom_Epd_Codigo_Reloj1,Nom_Epd_Codigo_Reloj2,Nom_Epd_Codigo_Reloj3,Nom_Epd_Codigo_Reloj4,Nom_EpdTip_Id,Nom_Epd_Contrato,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] NOM_EMPLEADOS nOM_EMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.NOM_EMPLEADOS.Add(nOM_EMPLEADOS);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Bco_Ban_Id = new SelectList(db.BCO_BANCOS, "Bco_Ban_Id", "Bco_Ban_Nombre", nOM_EMPLEADOS.Bco_Ban_Id);
            ViewBag.Bco_CtaTipo_Id = new SelectList(db.BCO_CUENTA_TIPO, "Bco_CtaTipo_Id", "Bco_CtaTipo_Descripcion", nOM_EMPLEADOS.Bco_CtaTipo_Id);
            ViewBag.Gen_PrmDiscaT_Id = new SelectList(db.GEN_PRM_DISCAPCIDA_TIPO, "Gen_PrmDiscaT_Id", "Gen_DisT_Descripcion", nOM_EMPLEADOS.Gen_PrmDiscaT_Id);
            ViewBag.Gen_PrmEducN_Id = new SelectList(db.GEN_PRM_EDUCACION_NIVEL, "Gen_PrmEducN_Id", "Gen_PrmEducN_Descripcion", nOM_EMPLEADOS.Gen_PrmEducN_Id);
            ViewBag.Gen_PrmCivilE_Id = new SelectList(db.GEN_PRM_ESTADO_CIVL, "Gen_PrmCivilE_Id", "Gen_PrmCivilE_Descripcion", nOM_EMPLEADOS.Gen_PrmCivilE_Id);
            ViewBag.Gen_PrmForPag_Id = new SelectList(db.GEN_PRM_FORMA_PAGO, "Gen_PrmForPag_Id", "Gen_PrmForPag_Descripcion", nOM_EMPLEADOS.Gen_PrmForPag_Id);
            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo", nOM_EMPLEADOS.Gen_PrmPai_Id);
            ViewBag.Gen_PrmPro_Id = new SelectList(db.GEN_PRM_GEOE_PROVINCIAS, "Gen_PrmPro_Id", "Gen_PrmPro_Codigo", nOM_EMPLEADOS.Gen_PrmPro_Id);
            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo", nOM_EMPLEADOS.Gen_PrmCiu_Id);
            ViewBag.Gen_PrmPrq_Id = new SelectList(db.GEN_PRM_GEOO_PARROQUIAS, "Gen_PrmPrq_Id", "Gen_PrmPrq_Codigo", nOM_EMPLEADOS.Gen_PrmPrq_Id);
            ViewBag.Gen_PrmOperM_Id = new SelectList(db.GEN_PRM_OPERADORA_MOVIL, "Gen_PrmOperM_Id", "Gen_PrmOperM_Descripcion", nOM_EMPLEADOS.Gen_PrmOperM_Id);
            ViewBag.Gen_PrmParenT_Id = new SelectList(db.GEN_PRM_PARENTESCO, "Gen_PrmParenT_Id", "Gen_PrmParenT_Descripcion", nOM_EMPLEADOS.Gen_PrmParenT_Id);
            ViewBag.Gen_PrmSex_Id = new SelectList(db.GEN_PRM_SEXO, "Gen_PrmSex_Id", "Gen_PrmSex_Descripcion", nOM_EMPLEADOS.Gen_PrmSex_Id);
            ViewBag.Gen_TipIden_Id = new SelectList(db.GEN_TIPO_IDENTIFICACION, "Gen_TipIden_Id", "Gen_TipIden_Descripcion", nOM_EMPLEADOS.Gen_TipIden_Id);
            ViewBag.Nom_Epd_Contac_Tii_Id = new SelectList(db.GEN_TIPO_IDENTIFICACION, "Gen_TipIden_Id", "Gen_TipIden_Descripcion", nOM_EMPLEADOS.Nom_Epd_Contac_Tii_Id);
            ViewBag.Nom_EpdTip_Id = new SelectList(db.NOM_EMPLEADO_TIPO, "Nom_EpdTip_Id", "Nom_EpdTip_Descripcion", nOM_EMPLEADOS.Nom_EpdTip_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", nOM_EMPLEADOS.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADOS.Aud_Usuario_Modifica);
            ViewBag.Nom_Epd_Discap_Carnet_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Nom_Epd_Discap_Carnet_SN);
            ViewBag.Nom_Epd_AsistenciaComp_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Nom_Epd_AsistenciaComp_SN);
            ViewBag.Nom_Epd_Discapacidad_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Nom_Epd_Discapacidad_SN);
            ViewBag.Nom_Epd_Usu_Sistema = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADOS.Nom_Epd_Usu_Sistema);
            return View(nOM_EMPLEADOS);
        }

        // GET: NOM_EMPLEADOS/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOM_EMPLEADOS nOM_EMPLEADOS = await db.NOM_EMPLEADOS.FindAsync(id);
            if (nOM_EMPLEADOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bco_Ban_Id = new SelectList(db.BCO_BANCOS, "Bco_Ban_Id", "Bco_Ban_Nombre", nOM_EMPLEADOS.Bco_Ban_Id);
            ViewBag.Bco_CtaTipo_Id = new SelectList(db.BCO_CUENTA_TIPO, "Bco_CtaTipo_Id", "Bco_CtaTipo_Descripcion", nOM_EMPLEADOS.Bco_CtaTipo_Id);
            ViewBag.Gen_PrmDiscaT_Id = new SelectList(db.GEN_PRM_DISCAPCIDA_TIPO, "Gen_PrmDiscaT_Id", "Gen_DisT_Descripcion", nOM_EMPLEADOS.Gen_PrmDiscaT_Id);
            ViewBag.Gen_PrmEducN_Id = new SelectList(db.GEN_PRM_EDUCACION_NIVEL, "Gen_PrmEducN_Id", "Gen_PrmEducN_Descripcion", nOM_EMPLEADOS.Gen_PrmEducN_Id);
            ViewBag.Gen_PrmCivilE_Id = new SelectList(db.GEN_PRM_ESTADO_CIVL, "Gen_PrmCivilE_Id", "Gen_PrmCivilE_Descripcion", nOM_EMPLEADOS.Gen_PrmCivilE_Id);
            ViewBag.Gen_PrmForPag_Id = new SelectList(db.GEN_PRM_FORMA_PAGO, "Gen_PrmForPag_Id", "Gen_PrmForPag_Descripcion", nOM_EMPLEADOS.Gen_PrmForPag_Id);
            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo", nOM_EMPLEADOS.Gen_PrmPai_Id);
            ViewBag.Gen_PrmPro_Id = new SelectList(db.GEN_PRM_GEOE_PROVINCIAS, "Gen_PrmPro_Id", "Gen_PrmPro_Codigo", nOM_EMPLEADOS.Gen_PrmPro_Id);
            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo", nOM_EMPLEADOS.Gen_PrmCiu_Id);
            ViewBag.Gen_PrmPrq_Id = new SelectList(db.GEN_PRM_GEOO_PARROQUIAS, "Gen_PrmPrq_Id", "Gen_PrmPrq_Codigo", nOM_EMPLEADOS.Gen_PrmPrq_Id);
            ViewBag.Gen_PrmOperM_Id = new SelectList(db.GEN_PRM_OPERADORA_MOVIL, "Gen_PrmOperM_Id", "Gen_PrmOperM_Descripcion", nOM_EMPLEADOS.Gen_PrmOperM_Id);
            ViewBag.Gen_PrmParenT_Id = new SelectList(db.GEN_PRM_PARENTESCO, "Gen_PrmParenT_Id", "Gen_PrmParenT_Descripcion", nOM_EMPLEADOS.Gen_PrmParenT_Id);
            ViewBag.Gen_PrmSex_Id = new SelectList(db.GEN_PRM_SEXO, "Gen_PrmSex_Id", "Gen_PrmSex_Descripcion", nOM_EMPLEADOS.Gen_PrmSex_Id);
            ViewBag.Gen_TipIden_Id = new SelectList(db.GEN_TIPO_IDENTIFICACION, "Gen_TipIden_Id", "Gen_TipIden_Descripcion", nOM_EMPLEADOS.Gen_TipIden_Id);
            ViewBag.Nom_Epd_Contac_Tii_Id = new SelectList(db.GEN_TIPO_IDENTIFICACION, "Gen_TipIden_Id", "Gen_TipIden_Descripcion", nOM_EMPLEADOS.Nom_Epd_Contac_Tii_Id);
            ViewBag.Nom_EpdTip_Id = new SelectList(db.NOM_EMPLEADO_TIPO, "Nom_EpdTip_Id", "Nom_EpdTip_Descripcion", nOM_EMPLEADOS.Nom_EpdTip_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", nOM_EMPLEADOS.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADOS.Aud_Usuario_Modifica);
            ViewBag.Nom_Epd_Discap_Carnet_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Nom_Epd_Discap_Carnet_SN);
            ViewBag.Nom_Epd_AsistenciaComp_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Nom_Epd_AsistenciaComp_SN);
            ViewBag.Nom_Epd_Discapacidad_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Nom_Epd_Discapacidad_SN);
            ViewBag.Nom_Epd_Usu_Sistema = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADOS.Nom_Epd_Usu_Sistema);
            return View(nOM_EMPLEADOS);
        }

        // POST: NOM_EMPLEADOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Nom_Epd_Id,SEG_EMPRESA_Id,Gen_TipIden_Id,Nom_Epd_Documento,Nom_Epd_Nombre1,Nom_Epd_Nombre2,Nom_Epd_Apellido1,Nom_Epd_Apellido2,Nom_Epd_Mail_Personal,Nom_Epd_Mail_Empresa,Gen_PrmCivilE_Id,Nom_Epd_Movil,Gen_PrmOperM_Id,Nom_Epd_FecNac,Gen_PrmSex_Id,Nom_Epd_Foto,Gen_PrmForPag_Id,Nom_Epd_Usu_Sistema,Nom_Epd_Discapacidad_SN,Gen_PrmDiscaT_Id,Nom_Epd_Discap_Porc,Nom_Epd_Discap_Grad,Nom_Epd_Discap_Carnet_SN,Nom_Epd_Discap_Carnet_Num,Nom_Epd_AsistenciaComp_SN,Gen_PrmPai_Id,Gen_PrmPro_Id,Gen_PrmCiu_Id,Gen_PrmPrq_Id,Nom_Epd_Direccion,Nom_Epd_Direccion_Referen,Nom_Epd_Procedencia,Gen_PrmEducN_Id,Bco_Ban_Id,Bco_CtaTipo_Id,Nom_Epd_Banco_Cuenta,Gen_PrmParenT_Id,Nom_Epd_Contac_Nombre,Nom_Epd_Contac_Apellido,Nom_Epd_Contac_Telefono,Nom_Epd_Contac_Tii_Id,Nom_Epd_Contac_Documento,Nom_Epd_Contac_Direccion,Nom_Epd_Codigo_Reloj0,Nom_Epd_Codigo_Reloj1,Nom_Epd_Codigo_Reloj2,Nom_Epd_Codigo_Reloj3,Nom_Epd_Codigo_Reloj4,Nom_EpdTip_Id,Nom_Epd_Contrato,Aud_EstadoAI_Id,Aud_Usuario_Ingreso,Aud_Fecha_Ingreso,Aud_PC_Ingreso,Aud_Usuario_Modifica,Aud_Fecha_Modifica,Aud_PC_Modifica")] NOM_EMPLEADOS nOM_EMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOM_EMPLEADOS).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Bco_Ban_Id = new SelectList(db.BCO_BANCOS, "Bco_Ban_Id", "Bco_Ban_Nombre", nOM_EMPLEADOS.Bco_Ban_Id);
            ViewBag.Bco_CtaTipo_Id = new SelectList(db.BCO_CUENTA_TIPO, "Bco_CtaTipo_Id", "Bco_CtaTipo_Descripcion", nOM_EMPLEADOS.Bco_CtaTipo_Id);
            ViewBag.Gen_PrmDiscaT_Id = new SelectList(db.GEN_PRM_DISCAPCIDA_TIPO, "Gen_PrmDiscaT_Id", "Gen_DisT_Descripcion", nOM_EMPLEADOS.Gen_PrmDiscaT_Id);
            ViewBag.Gen_PrmEducN_Id = new SelectList(db.GEN_PRM_EDUCACION_NIVEL, "Gen_PrmEducN_Id", "Gen_PrmEducN_Descripcion", nOM_EMPLEADOS.Gen_PrmEducN_Id);
            ViewBag.Gen_PrmCivilE_Id = new SelectList(db.GEN_PRM_ESTADO_CIVL, "Gen_PrmCivilE_Id", "Gen_PrmCivilE_Descripcion", nOM_EMPLEADOS.Gen_PrmCivilE_Id);
            ViewBag.Gen_PrmForPag_Id = new SelectList(db.GEN_PRM_FORMA_PAGO, "Gen_PrmForPag_Id", "Gen_PrmForPag_Descripcion", nOM_EMPLEADOS.Gen_PrmForPag_Id);
            ViewBag.Gen_PrmPai_Id = new SelectList(db.GEN_PRM_GEOA_PAISES, "Gen_PrmPai_Id", "Gen_PrmPai_Codigo", nOM_EMPLEADOS.Gen_PrmPai_Id);
            ViewBag.Gen_PrmPro_Id = new SelectList(db.GEN_PRM_GEOE_PROVINCIAS, "Gen_PrmPro_Id", "Gen_PrmPro_Codigo", nOM_EMPLEADOS.Gen_PrmPro_Id);
            ViewBag.Gen_PrmCiu_Id = new SelectList(db.GEN_PRM_GEOI_CIUDAD, "Gen_PrmCiu_Id", "Gen_PrmCiu_Codigo", nOM_EMPLEADOS.Gen_PrmCiu_Id);
            ViewBag.Gen_PrmPrq_Id = new SelectList(db.GEN_PRM_GEOO_PARROQUIAS, "Gen_PrmPrq_Id", "Gen_PrmPrq_Codigo", nOM_EMPLEADOS.Gen_PrmPrq_Id);
            ViewBag.Gen_PrmOperM_Id = new SelectList(db.GEN_PRM_OPERADORA_MOVIL, "Gen_PrmOperM_Id", "Gen_PrmOperM_Descripcion", nOM_EMPLEADOS.Gen_PrmOperM_Id);
            ViewBag.Gen_PrmParenT_Id = new SelectList(db.GEN_PRM_PARENTESCO, "Gen_PrmParenT_Id", "Gen_PrmParenT_Descripcion", nOM_EMPLEADOS.Gen_PrmParenT_Id);
            ViewBag.Gen_PrmSex_Id = new SelectList(db.GEN_PRM_SEXO, "Gen_PrmSex_Id", "Gen_PrmSex_Descripcion", nOM_EMPLEADOS.Gen_PrmSex_Id);
            ViewBag.Gen_TipIden_Id = new SelectList(db.GEN_TIPO_IDENTIFICACION, "Gen_TipIden_Id", "Gen_TipIden_Descripcion", nOM_EMPLEADOS.Gen_TipIden_Id);
            ViewBag.Nom_Epd_Contac_Tii_Id = new SelectList(db.GEN_TIPO_IDENTIFICACION, "Gen_TipIden_Id", "Gen_TipIden_Descripcion", nOM_EMPLEADOS.Nom_Epd_Contac_Tii_Id);
            ViewBag.Nom_EpdTip_Id = new SelectList(db.NOM_EMPLEADO_TIPO, "Nom_EpdTip_Id", "Nom_EpdTip_Descripcion", nOM_EMPLEADOS.Nom_EpdTip_Id);
            ViewBag.SEG_EMPRESA_Id = new SelectList(db.SEG_EMPRESA, "SEG_EMPRESA_Id", "EMP_Representante", nOM_EMPLEADOS.SEG_EMPRESA_Id);
            ViewBag.Aud_EstadoAI_Id = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Aud_EstadoAI_Id);
            ViewBag.Aud_Usuario_Ingreso = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADOS.Aud_Usuario_Ingreso);
            ViewBag.Aud_Usuario_Modifica = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADOS.Aud_Usuario_Modifica);
            ViewBag.Nom_Epd_Discap_Carnet_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Nom_Epd_Discap_Carnet_SN);
            ViewBag.Nom_Epd_AsistenciaComp_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Nom_Epd_AsistenciaComp_SN);
            ViewBag.Nom_Epd_Discapacidad_SN = new SelectList(db.SEG_ESTADO_AI, "Seg_EstadoAI_Id", "Gen_PrmSn_Descripcion", nOM_EMPLEADOS.Nom_Epd_Discapacidad_SN);
            ViewBag.Nom_Epd_Usu_Sistema = new SelectList(db.SEG_USUARIO, "Seg_Usr_Id", "USU_Login", nOM_EMPLEADOS.Nom_Epd_Usu_Sistema);
            return View(nOM_EMPLEADOS);
        }

        // GET: NOM_EMPLEADOS/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOM_EMPLEADOS nOM_EMPLEADOS = await db.NOM_EMPLEADOS.FindAsync(id);
            if (nOM_EMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(nOM_EMPLEADOS);
        }

        // POST: NOM_EMPLEADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NOM_EMPLEADOS nOM_EMPLEADOS = await db.NOM_EMPLEADOS.FindAsync(id);
            db.NOM_EMPLEADOS.Remove(nOM_EMPLEADOS);
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
