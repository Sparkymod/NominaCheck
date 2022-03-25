using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            IngresosServicios = new HashSet<IngresosServicio>();
        }

        public int CodServicio { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<IngresosServicio> IngresosServicios { get; set; }
    }
}
