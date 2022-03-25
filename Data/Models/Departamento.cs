using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Cargos = new HashSet<Cargo>();
        }

        public int CodDepartamento { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}
