//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zoologico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Planes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Planes()
        {
            this.Compra = new HashSet<Compra>();
        }
    
        public string Id_Plan { get; set; }
        public string Nombre_Plan { get; set; }
        public string Precio_plan { get; set; }
        public string Nit_Zoologico { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }
        public virtual Zoologicos Zoologicos { get; set; }
    }
}
