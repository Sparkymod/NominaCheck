using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class Proveedore
    {
        public Proveedore()
        {
            FacturaProveedores = new HashSet<FacturaProveedore>();
        }

        public int CodProveedor { get; set; }
        public string Nombre { get; set; } = null!;
        public int Telefono { get; set; }
        public string Direccion { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<FacturaProveedore> FacturaProveedores { get; set; }
    }
}
