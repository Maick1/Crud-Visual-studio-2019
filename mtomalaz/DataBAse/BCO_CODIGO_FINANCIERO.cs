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
    
    public partial class BCO_CODIGO_FINANCIERO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BCO_CODIGO_FINANCIERO()
        {
            this.BCO_BANCOS = new HashSet<BCO_BANCOS>();
        }
    
        public int Bco_CodFinan_Id { get; set; }
        public string Bco_CodFinan_Codigo { get; set; }
        public string Bco_CodFinan_Nombre { get; set; }
        public string Bco_CodFinan_Abreviatura { get; set; }
        public Nullable<int> Aud_EstadoAI_Id { get; set; }
        public Nullable<int> Aud_Usuario_Ingreso { get; set; }
        public Nullable<System.DateTime> Aud_Fecha_Ingreso { get; set; }
        public string Aud_PC_Ingreso { get; set; }
        public Nullable<int> Aud_Usuario_Modifica { get; set; }
        public Nullable<System.DateTime> Aud_Fecha_Modifica { get; set; }
        public string Aud_PC_Modifica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BCO_BANCOS> BCO_BANCOS { get; set; }
        public virtual SEG_ESTADO_AI SEG_ESTADO_AI { get; set; }
        public virtual SEG_USUARIO SEG_USUARIO { get; set; }
        public virtual SEG_USUARIO SEG_USUARIO1 { get; set; }
    }
}
