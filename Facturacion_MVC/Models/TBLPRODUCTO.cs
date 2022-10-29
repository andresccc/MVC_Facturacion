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
    
    public partial class TBLPRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLPRODUCTO()
        {
            this.TBLDETALLE_FACTURA = new HashSet<TBLDETALLE_FACTURA>();
        }
    
        public int IdProducto { get; set; }
        public string StrNombre { get; set; }
        public string StrCodigo { get; set; }
        public double NumPrecioCompra { get; set; }
        public double NumPrecioVenta { get; set; }
        public int IdCategoria { get; set; }
        public string StrDetalle { get; set; }
        public string strFoto { get; set; }
        public Nullable<int> NumStock { get; set; }
        public System.DateTime DtmFechaModifica { get; set; }
        public string StrUsuarioModifica { get; set; }
    
        public virtual TBLCATEGORIA_PROD TBLCATEGORIA_PROD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLDETALLE_FACTURA> TBLDETALLE_FACTURA { get; set; }
    }
}