//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NATILLERA.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class tblPrestamo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPrestamo()
        {
            this.tblPagosPrestamoes = new HashSet<tblPagosPrestamo>();
        }
    
        public int intIdPrestamoPk { get; set; }
        public int intIdClienteFk { get; set; }
        public int intIdUsuarioAprobadorFk { get; set; }
        public int intIdSedeFk { get; set; }
        public decimal decMonto { get; set; }
        public decimal decTasaInteres { get; set; }
        public System.DateTime dtFechaAprobacion { get; set; }
        public System.DateTime dtFechaVencimiento { get; set; }
    
        public virtual tblCliente tblCliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<tblPagosPrestamo> tblPagosPrestamoes { get; set; }
        public virtual tblUsuario tblUsuario { get; set; }
        public virtual tblSede tblSede { get; set; }
    }
}
