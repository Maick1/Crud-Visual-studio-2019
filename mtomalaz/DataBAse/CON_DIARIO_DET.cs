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
    
    public partial class CON_DIARIO_DET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CON_DIARIO_DET()
        {
            this.CON_DIARIO_AUX = new HashSet<CON_DIARIO_AUX>();
        }
    
        public int Con_DiarioDet_Id { get; set; }
        public int SEG_EMPRESA_Id { get; set; }
        public int Con_DiarioCab_Id { get; set; }
        public int Con_DiarioDet_NumLin { get; set; }
        public int Con_PlaCta_Id { get; set; }
        public string Con_DiarioDet_Glosa { get; set; }
        public decimal Con_DiarioDet_Debe { get; set; }
        public decimal Con_DiarioDet_Haber { get; set; }
        public int Con_DiarioReqAux_SN { get; set; }
        public decimal Con_DiarioDet_Aux_Total { get; set; }
        public string Con_DiarioDet_Referencia { get; set; }
        public string Con_DiarioDet_Reg_T_P { get; set; }
        public Nullable<int> Aud_EstadoAI_Id { get; set; }
        public Nullable<int> Aud_Usuario_Ingreso { get; set; }
        public Nullable<System.DateTime> Aud_Fecha_Ingreso { get; set; }
        public string Aud_PC_Ingreso { get; set; }
        public Nullable<int> Aud_Usuario_Modifica { get; set; }
        public Nullable<System.DateTime> Aud_Fecha_Modifica { get; set; }
        public string Aud_PC_Modifica { get; set; }
    
        public virtual CON_CUENTA_PLAN CON_CUENTA_PLAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CON_DIARIO_AUX> CON_DIARIO_AUX { get; set; }
        public virtual CON_DIARIO_CAB CON_DIARIO_CAB { get; set; }
        public virtual SEG_EMPRESA SEG_EMPRESA { get; set; }
        public virtual SEG_ESTADO_AI SEG_ESTADO_AI { get; set; }
        public virtual SEG_USUARIO SEG_USUARIO { get; set; }
        public virtual SEG_USUARIO SEG_USUARIO1 { get; set; }
        public virtual SEG_ESTADO_AI SEG_ESTADO_AI1 { get; set; }
    }
}
