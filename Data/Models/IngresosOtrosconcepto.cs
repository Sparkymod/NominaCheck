using System;
using System.Collections.Generic;

namespace NominaCheck.Data.Models
{
    public partial class IngresosOtrosconcepto
    {
        public int CodOtrosconceptos { get; set; }
        public decimal Valor { get; set; }
        public int CodConcepto { get; set; }

        public virtual OtrosConcepto CodConceptoNavigation { get; set; } = null!;
    }
}
