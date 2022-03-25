using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class TiposEmpleado
    {
        public TiposEmpleado()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int CodTipoEmpleado { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
