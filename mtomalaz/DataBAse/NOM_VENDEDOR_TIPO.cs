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
    
    public partial class NOM_VENDEDOR_TIPO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NOM_VENDEDOR_TIPO()
        {
            this.NOM_VENDEDORES = new HashSet<NOM_VENDEDORES>();
        }
    
        public int Nom_VendT_Id { get; set; }
        public int SEG_EMPRESA_Id { get; set; }
        public string Nom_VendT_Descripcion { get; set; }
        public Nullable<int> Aud_EstadoAI_Id { get; set; }
        public Nullable<int> Aud_Usuario_Ingreso { get; set; }
        public Nullable<System.DateTime> Aud_Fecha_Ingreso { get; set; }
        public string Aud_PC_Ingreso { get; set; }
        public Nullable<int> Aud_Usuario_Modifica { get; set; }
        public Nullable<System.DateTime> Aud_Fecha_Modifica { get; set; }
        public string Aud_PC_Modifica { get; set; }
    
        public virtual SEG_EMPRESA SEG_EMPRESA { get; set; }
        public virtual SEG_ESTADO_AI SEG_ESTADO_AI { get; set; }
        public virtual SEG_USUARIO SEG_USUARIO { get; set; }
        public virtual SEG_USUARIO SEG_USUARIO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOM_VENDEDORES> NOM_VENDEDORES { get; set; }
    }
}
