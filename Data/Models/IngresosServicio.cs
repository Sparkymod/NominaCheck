using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class IngresosServicio
    {
        public int CodIngreso { get; set; }
        public string TipoServicio { get; set; } = null!;
        public decimal Valor { get; set; }
        public int CodServicio { get; set; }

        public virtual Servicio CodServicioNavigation { get; set; } = null!;
    }
}
