//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicio.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Provincia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Provincia()
        {
            this.Canton = new HashSet<Canton>();
        }
    
        public byte pro_id { get; set; }
        public string pro_nombre { get; set; }
        public string pro_estatus { get; set; }
        public Nullable<System.DateTime> pro_add { get; set; }
        public Nullable<System.DateTime> pro_update { get; set; }
        public Nullable<System.DateTime> pro_delete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Canton> Canton { get; set; }
    }
}
