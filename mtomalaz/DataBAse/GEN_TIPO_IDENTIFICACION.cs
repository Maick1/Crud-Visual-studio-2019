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
    
    public partial class GEN_TIPO_IDENTIFICACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GEN_TIPO_IDENTIFICACION()
        {
            this.NOM_EMPLEADOS = new HashSet<NOM_EMPLEADOS>();
            this.NOM_EMPLEADOS1 = new HashSet<NOM_EMPLEADOS>();
        }
    
        public int Gen_TipIden_Id { get; set; }
        public string Gen_TipIden_Descripcion { get; set; }
        public string Gen_TipIden_Codigo_Sistem { get; set; }
        public string Gen_TipIden_Abreviatura { get; set; }
        public Nullable<int> Aud_EstadoAI_Id { get; set; }
        public Nullable<int> Aud_Usuario_Ingreso { get; set; }
        public Nullable<System.DateTime> Aud_Fecha_Ingreso { get; set; }
        public string Aud_PC_Ingreso { get; set; }
        public Nullable<int> Aud_Usuario_Modifica { get; set; }
        public Nullable<System.DateTime> Aud_Fecha_Modifica { get; set; }
        public string Aud_PC_Modifica { get; set; }
    
        public virtual SEG_ESTADO_AI SEG_ESTADO_AI { get; set; }
        public virtual SEG_USUARIO SEG_USUARIO { get; set; }
        public virtual SEG_USUARIO SEG_USUARIO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOM_EMPLEADOS> NOM_EMPLEADOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOM_EMPLEADOS> NOM_EMPLEADOS1 { get; set; }
    }
}
