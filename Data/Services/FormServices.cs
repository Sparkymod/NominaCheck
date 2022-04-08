using NominaCheck.Data.Models;

namespace NominaCheck.Data.Services
{
    public class FormServices
    {
        public List<SectionForm> Forms { get; set; } = new();
        public List<SectionForm> FormsExports { get; set; } = new();

        public int Results { get; set; } = 0;

        public void Sum()
        {
            Results = 0;
            Forms.ForEach(x => Results += x.Answer1);
        }
    }
}
