//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Facturacion_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLESTADO_FACTURA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLESTADO_FACTURA()
        {
            this.TBLFACTURA = new HashSet<TBLFACTURA>();
        }
    
        public int IdEstadoFactura { get; set; }
        public string StrDescripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLFACTURA> TBLFACTURA { get; set; }
    }
}
