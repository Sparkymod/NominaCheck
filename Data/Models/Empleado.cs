using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            PagoEmpleados = new HashSet<PagoEmpleado>();
        }

        public int CodEmpleados { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int CodNomina { get; set; }
        public int CodCargo { get; set; }
        public int CodTipoEmpleado { get; set; }

        public virtual Cargo CodCargoNavigation { get; set; } = null!;
        public virtual TiposEmpleado CodTipoEmpleadoNavigation { get; set; } = null!;
        public virtual ICollection<PagoEmpleado> PagoEmpleados { get; set; }
    }
}
