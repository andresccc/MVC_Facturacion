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
    
    public partial class TBLCLIENTES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLCLIENTES()
        {
            this.TBLFACTURA = new HashSet<TBLFACTURA>();
        }
    
        public int IdCliente { get; set; }
        public string StrNombre { get; set; }
        public Nullable<long> NumDocumento { get; set; }
        public string StrDireccion { get; set; }
        public string StrTelefono { get; set; }
        public string StrEmail { get; set; }
        public Nullable<System.DateTime> DtmFechaModifica { get; set; }
        public string StrUsuarioModifica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLFACTURA> TBLFACTURA { get; set; }
    }
}