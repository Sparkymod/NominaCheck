using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int CodCargo { get; set; }
        public string Descripcion { get; set; } = null!;
        public int CodDepartamento { get; set; }

        public virtual Departamento CodDepartamentoNavigation { get; set; } = null!;
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
