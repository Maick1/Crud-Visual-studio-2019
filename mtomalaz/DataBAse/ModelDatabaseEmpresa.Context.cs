﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mtomalaz.DataBAse
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class empresaEntities : DbContext
    {
        public empresaEntities()
            : base("name=empresaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BCO_BANCOS> BCO_BANCOS { get; set; }
        public virtual DbSet<BCO_CODIGO_FINANCIERO> BCO_CODIGO_FINANCIERO { get; set; }
        public virtual DbSet<BCO_CUENTA_BANCOS> BCO_CUENTA_BANCOS { get; set; }
        public virtual DbSet<BCO_CUENTA_TIPO> BCO_CUENTA_TIPO { get; set; }
        public virtual DbSet<Clases_Tipos> Clases_Tipos { get; set; }
        public virtual DbSet<COM_CAB_DEV> COM_CAB_DEV { get; set; }
        public virtual DbSet<COM_CAB_ORDEN> COM_CAB_ORDEN { get; set; }
        public virtual DbSet<COM_CATEGORIA_PROVEEDORES> COM_CATEGORIA_PROVEEDORES { get; set; }
        public virtual DbSet<COM_DET_DEV> COM_DET_DEV { get; set; }
        public virtual DbSet<COM_DET_ORDEN> COM_DET_ORDEN { get; set; }
        public virtual DbSet<COM_PROVEEDOR> COM_PROVEEDOR { get; set; }
        public virtual DbSet<CON_CENTRO_COSTOS> CON_CENTRO_COSTOS { get; set; }
        public virtual DbSet<CON_CENTRO_COSTOS_TIPO> CON_CENTRO_COSTOS_TIPO { get; set; }
        public virtual DbSet<CON_CUENTA_CLASE> CON_CUENTA_CLASE { get; set; }
        public virtual DbSet<CON_CUENTA_NIVEL> CON_CUENTA_NIVEL { get; set; }
        public virtual DbSet<CON_CUENTA_PLAN> CON_CUENTA_PLAN { get; set; }
        public virtual DbSet<CON_CUENTA_TIPO> CON_CUENTA_TIPO { get; set; }
        public virtual DbSet<CON_DIARIO_AUX> CON_DIARIO_AUX { get; set; }
        public virtual DbSet<CON_DIARIO_AUX_TIPO> CON_DIARIO_AUX_TIPO { get; set; }
        public virtual DbSet<CON_DIARIO_CAB> CON_DIARIO_CAB { get; set; }
        public virtual DbSet<CON_DIARIO_DET> CON_DIARIO_DET { get; set; }
        public virtual DbSet<CON_DIARIO_SECUENCIA> CON_DIARIO_SECUENCIA { get; set; }
        public virtual DbSet<CON_DIARIO_TIPO> CON_DIARIO_TIPO { get; set; }
        public virtual DbSet<CON_ESTADO_CONTAB> CON_ESTADO_CONTAB { get; set; }
        public virtual DbSet<GEN_ANIO> GEN_ANIO { get; set; }
        public virtual DbSet<GEN_MES> GEN_MES { get; set; }
        public virtual DbSet<GEN_PRM_DISCAPCIDA_TIPO> GEN_PRM_DISCAPCIDA_TIPO { get; set; }
        public virtual DbSet<GEN_PRM_EDUCACION_NIVEL> GEN_PRM_EDUCACION_NIVEL { get; set; }
        public virtual DbSet<GEN_PRM_ESTADO_CIVL> GEN_PRM_ESTADO_CIVL { get; set; }
        public virtual DbSet<GEN_PRM_FORMA_PAGO> GEN_PRM_FORMA_PAGO { get; set; }
        public virtual DbSet<GEN_PRM_GEOA_PAISES> GEN_PRM_GEOA_PAISES { get; set; }
        public virtual DbSet<GEN_PRM_GEOE_PROVINCIAS> GEN_PRM_GEOE_PROVINCIAS { get; set; }
        public virtual DbSet<GEN_PRM_GEOI_CIUDAD> GEN_PRM_GEOI_CIUDAD { get; set; }
        public virtual DbSet<GEN_PRM_GEOO_PARROQUIAS> GEN_PRM_GEOO_PARROQUIAS { get; set; }
        public virtual DbSet<GEN_PRM_OPERADORA_MOVIL> GEN_PRM_OPERADORA_MOVIL { get; set; }
        public virtual DbSet<GEN_PRM_PARENTESCO> GEN_PRM_PARENTESCO { get; set; }
        public virtual DbSet<GEN_PRM_SEXO> GEN_PRM_SEXO { get; set; }
        public virtual DbSet<GEN_TIPO_IDENTIFICACION> GEN_TIPO_IDENTIFICACION { get; set; }
        public virtual DbSet<INV_ARTICULOS> INV_ARTICULOS { get; set; }
        public virtual DbSet<INV_CAB_KARDEX> INV_CAB_KARDEX { get; set; }
        public virtual DbSet<INV_CAB_MOVIMIENTO> INV_CAB_MOVIMIENTO { get; set; }
        public virtual DbSet<INV_CAB_SOLICITUD> INV_CAB_SOLICITUD { get; set; }
        public virtual DbSet<INV_CATEGORIA> INV_CATEGORIA { get; set; }
        public virtual DbSet<INV_DET_KARDEX> INV_DET_KARDEX { get; set; }
        public virtual DbSet<INV_DET_MOVIMIENTO> INV_DET_MOVIMIENTO { get; set; }
        public virtual DbSet<INV_DET_SOLICITUD> INV_DET_SOLICITUD { get; set; }
        public virtual DbSet<INV_MARCA> INV_MARCA { get; set; }
        public virtual DbSet<INV_SUBTIPO> INV_SUBTIPO { get; set; }
        public virtual DbSet<INV_TIPO_ARTICULO> INV_TIPO_ARTICULO { get; set; }
        public virtual DbSet<INV_TIPSUBART> INV_TIPSUBART { get; set; }
        public virtual DbSet<NOM_EMPLEADO_TIPO> NOM_EMPLEADO_TIPO { get; set; }
        public virtual DbSet<NOM_EMPLEADOS> NOM_EMPLEADOS { get; set; }
        public virtual DbSet<NOM_VENDEDOR_TIPO> NOM_VENDEDOR_TIPO { get; set; }
        public virtual DbSet<NOM_VENDEDORES> NOM_VENDEDORES { get; set; }
        public virtual DbSet<SEG_APLICACION> SEG_APLICACION { get; set; }
        public virtual DbSet<SEG_BANCO> SEG_BANCO { get; set; }
        public virtual DbSet<SEG_BODEGA> SEG_BODEGA { get; set; }
        public virtual DbSet<SEG_CAB_PURGA> SEG_CAB_PURGA { get; set; }
        public virtual DbSet<SEG_CENTRO_COSTO> SEG_CENTRO_COSTO { get; set; }
        public virtual DbSet<SEG_CIUDAD> SEG_CIUDAD { get; set; }
        public virtual DbSet<SEG_CTA_BANCO> SEG_CTA_BANCO { get; set; }
        public virtual DbSet<SEG_DEPARTAMENTO> SEG_DEPARTAMENTO { get; set; }
        public virtual DbSet<SEG_DET_PURGA> SEG_DET_PURGA { get; set; }
        public virtual DbSet<SEG_EMPRESA> SEG_EMPRESA { get; set; }
        public virtual DbSet<SEG_ENT_TIP> SEG_ENT_TIP { get; set; }
        public virtual DbSet<SEG_ENTIDAD> SEG_ENTIDAD { get; set; }
        public virtual DbSet<SEG_ESTADO_AI> SEG_ESTADO_AI { get; set; }
        public virtual DbSet<SEG_GRUPO> SEG_GRUPO { get; set; }
        public virtual DbSet<SEG_HISTORICO> SEG_HISTORICO { get; set; }
        public virtual DbSet<SEG_IMP_BEN> SEG_IMP_BEN { get; set; }
        public virtual DbSet<SEG_INICIO> SEG_INICIO { get; set; }
        public virtual DbSet<SEG_MENSAJE> SEG_MENSAJE { get; set; }
        public virtual DbSet<SEG_MENU> SEG_MENU { get; set; }
        public virtual DbSet<SEG_NIVEL_PRECIO> SEG_NIVEL_PRECIO { get; set; }
        public virtual DbSet<SEG_PAIS> SEG_PAIS { get; set; }
        public virtual DbSet<SEG_PER_CON> SEG_PER_CON { get; set; }
        public virtual DbSet<SEG_PERFIL_EMP> SEG_PERFIL_EMP { get; set; }
        public virtual DbSet<SEG_PROVINCIA> SEG_PROVINCIA { get; set; }
        public virtual DbSet<SEG_TIPO> SEG_TIPO { get; set; }
        public virtual DbSet<SEG_USU_GRUPO> SEG_USU_GRUPO { get; set; }
        public virtual DbSet<SEG_USUARIO> SEG_USUARIO { get; set; }
        public virtual DbSet<SEG_ZONA> SEG_ZONA { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
