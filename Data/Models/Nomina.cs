using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class Nomina
    {
        public Nomina()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int CodNomina { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public int CodEmpleado { get; set; }

        public virtual Empleado CodEmpleadoNavigation { get; set; } = null!;
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
