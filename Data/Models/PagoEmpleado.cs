using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class PagoEmpleado
    {
        public int CodPago { get; set; }
        public decimal ValorMensual { get; set; }
        public int CodEmpleados { get; set; }

        public virtual Empleado CodEmpleadosNavigation { get; set; } = null!;
    }
}
