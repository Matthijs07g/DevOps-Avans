using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ExportModels
{
    public class PdfReport : Report
    {
        public PdfReport(string report) : base(report)
        {
        }
        
        public override ExportFormat Export()
        {
            Console.WriteLine("PDF EXPORT:");
            if (_header != null) Console.WriteLine(_header.ToString());
            Console.WriteLine(_report.ToString());
            if (_header != null) Console.WriteLine(_footer.ToString());

            return ExportFormat.PDF;
        }
    }
}
