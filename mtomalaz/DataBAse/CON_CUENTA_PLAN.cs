//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class CON_CUENTA_PLAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CON_CUENTA_PLAN()
        {
            this.BCO_CUENTA_BANCOS = new HashSet<BCO_CUENTA_BANCOS>();
            this.CON_DIARIO_DET = new HashSet<CON_DIARIO_DET>();
        }
    
        public int Con_PlaCta_Id { get; set; }
        public int Gen_PrmAnio_Id { get; set; }
        public int SEG_EMPRESA_Id { get; set; }
        public int Con_NivCta_Id { get; set; }
        public int Con_TipCta_Id { get; set; }
        public int Con_ClasCta_Id { get; set; }
        public string Con_PlaCta_Cuenta { get; set; }
        public string Con_PlaCta_Nombre { get; set; }
        public int Con_PlaCta_GeneMov_SN { get; set; }
        public int Con_PlaCta_Req_Aux_SN { get; set; }
        public int Con_PlaCta_Req_AuxSub_SN { get; set; }
        public int Con_PlaCta_Req_Cc_SN { get; set; }
        public Nullable<int> Aud_EstadoAI_Id { get; set; }
        public Nullable<int> Aud_Usuario_Ingreso { get; set; }
        public Nullable<System.DateTime> Aud_Fecha_Ingreso { get; set; }
        public string Aud_PC_Ingreso { get; set; }
        public Nullable<int> Aud_Usuario_Modifica { get; set; }
        public Nullable<System.DateTime> Aud_Fecha_Modifica { get; set; }
        public string Aud_PC_Modifica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BCO_CUENTA_BANCOS> BCO_CUENTA_BANCOS { get; set; }
        public virtual CON_CUENTA_CLASE CON_CUENTA_CLASE { get; set; }
        public virtual CON_CUENTA_NIVEL CON_CUENTA_NIVEL { get; set; }
        public virtual GEN_ANIO GEN_ANIO { get; set; }
        public virtual CON_CUENTA_TIPO CON_CUENTA_TIPO { get; set; }
        public virtual SEG_EMPRESA SEG_EMPRESA { get; set; }
        public virtual SEG_ESTADO_AI SEG_ESTADO_AI { get; set; }
        public virtual SEG_USUARIO SEG_USUARIO { get; set; }
        public virtual SEG_USUARIO SEG_USUARIO1 { get; set; }
        public virtual SEG_ESTADO_AI SEG_ESTADO_AI1 { get; set; }
        public virtual SEG_ESTADO_AI SEG_ESTADO_AI2 { get; set; }
        public virtual SEG_ESTADO_AI SEG_ESTADO_AI3 { get; set; }
        public virtual SEG_ESTADO_AI SEG_ESTADO_AI4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CON_DIARIO_DET> CON_DIARIO_DET { get; set; }
    }
}
