using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class FacturaProveedore
    {
        public int CodFactura { get; set; }
        public string Descrpcion { get; set; } = null!;
        public decimal ValorMensual { get; set; }
        public int CodProveedor { get; set; }

        public virtual Proveedore CodProveedorNavigation { get; set; } = null!;
    }
}
