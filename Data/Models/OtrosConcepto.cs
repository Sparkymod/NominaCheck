using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class OtrosConcepto
    {
        public OtrosConcepto()
        {
            IngresosOtrosconceptos = new HashSet<IngresosOtrosconcepto>();
        }

        public int CodConcepto { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<IngresosOtrosconcepto> IngresosOtrosconceptos { get; set; }
    }
}
