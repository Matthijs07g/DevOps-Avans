using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ExportModels
{
    public class PngReport : Report
    {
        public PngReport(string report) : base(report)
        {
        }

        public override ExportFormat Export()
        {
            Console.WriteLine("PNG EXPORT:");
            if (_header != null) Console.WriteLine(_header.ToString());
            Console.WriteLine(_report.ToString());
            if (_header != null) Console.WriteLine(_footer.ToString());

            return ExportFormat.PNG;
        }
    }
}
