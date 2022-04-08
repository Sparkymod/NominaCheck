using System.ComponentModel.DataAnnotations;
using NominaCheck.Data.Extensions;
using SelectPdf;

namespace NominaCheck.Pages
{
    public partial class EvaluacionPersonal
    {
        public DateTime FechaSolicitud { get; set; } = DateTime.Today;
        public DateTime FechaStart { get; set; } = DateTime.Today.AddDays(-30);
        public DateTime FechaEnd { get; set; } = DateTime.Today;

        public string Version { get; set; } = "002";

        public int Results;

        [Required]
        [DataType(DataType.Text)]
        public string Nombre { get; set; } = "";
        [Required]
        [DataType(DataType.Text)]
        public string Cargo { get; set; } = "";
        [Required]
        [DataType(DataType.Text)]
        public string Supervisor { get; set; } = "";
        [Required]
        [DataType(DataType.Text)]
        public string Departamento { get; set; } = "";
        [Required]
        [DataType(DataType.Text)]
        public string Direccion { get; set; } = "";

        public string Habilidad { get; set; } = "";
        public string Oportunidad { get; set; } = "";
        public string ComentarioSupervisor { get; set; } = "";
        public string ComentarioEvaluado { get; set; } = "";

        private void UpdateResults(int value)
        {
            Results = value;
        }


        /// <summary>
        /// Metodo actual pero poco eficiente para exportar a PDF, utilizando URI para obtener un resultado final.
        /// en _Layout utiliza saveAsFile, una funcion java para obtener el documento y guardarlo en byte64/application-pdf
        /// </summary>
        /// <returns></returns>
        protected async Task ExportToPdf()
        {
            SanitizeStrings();

            // Convert the url to pdf //using SelectPdf;
            HtmlToPdf converter = new();
            string date = string.Format("{0,2:00}-{1,2:00}-{2,4:00}", FechaSolicitud.Day, FechaSolicitud.Month, FechaSolicitud.Year);
            string sDate = string.Format("{0,2:00}-{1,2:00}-{2,4:00}", FechaStart.Day, FechaStart.Month, FechaStart.Year);
            string eDate = string.Format("{0,2:00}-{1,2:00}-{2,4:00}", FechaEnd.Day, FechaEnd.Month, FechaEnd.Year);

            // Save selected option an pass the list in the api
            var sn = SelectionNumber();

            // Building the URI
            string general = $"{Nombre}/{Cargo}/{Supervisor}/{Departamento}/{Direccion}";
            string selection1 = $"{sn[0]}/{sn[1]}/{sn[2]}/{sn[3]}/{sn[4]}/{sn[5]}/{sn[6]}/{sn[7]}/{sn[8]}/{sn[9]}/{sn[10]}";
            string selection2 = $"{sn[11]}/{sn[12]}/{sn[13]}/{sn[14]}/{sn[15]}/{sn[16]}/{sn[17]}/{sn[18]}/{sn[19]}";
            string otros = $"{Habilidad}/{Oportunidad}/{ComentarioSupervisor}/{ComentarioEvaluado}";

            // The final url to the api.
            string url = Navigation.Uri +$"FO_RH_EPP/{Version}/{general}/{date}/{selection1}/{selection2}/{Results}/{otros}/{sDate}/{eDate}";

            // Pass the file to a stream and save it into pdf.
            using MemoryStream ms = new();
            PdfDocument doc = converter.ConvertUrl(url);
            converter.Options.CssMediaType = HtmlToPdfCssMediaType.Screen;

            doc.Margins.Left = 0;
            doc.Margins.Right = 0;
            doc.Save(ms);
            doc.Close();

            var bytes = ms.ToArray();
            string filename = $"{Nombre}_{date}.pdf";

            // Extention function for javascript to save data into a file. Extensions/ServiceExtensions
            await JS.SaveAs(filename, bytes);
        }

        private List<int> SelectionNumber()
        {
            var result = new List<int>();
            Service.Forms.ForEach(x => result.Add(x.Selection));

            return result;
        }

        private void SanitizeStrings()
        {
            Nombre = Nombre.RemoveSpecialChars();
            Cargo = Cargo.RemoveSpecialChars();
            Supervisor = Supervisor.RemoveSpecialChars();
            Departamento = Departamento.RemoveSpecialChars();
            Direccion = Direccion.RemoveSpecialChars();
            Habilidad = Habilidad.RemoveSpecialChars();
            Oportunidad = Oportunidad.RemoveSpecialChars();
            ComentarioSupervisor = ComentarioSupervisor.RemoveSpecialChars();
            ComentarioEvaluado = ComentarioEvaluado.RemoveSpecialChars();
        }
    }
}
