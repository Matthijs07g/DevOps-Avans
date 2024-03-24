using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ExportModels
{
    public abstract class Report
    {
        private readonly string _divideLine = "===================";
        protected StringBuilder _report = new StringBuilder();
        protected StringBuilder? _header;
        protected StringBuilder? _footer;

        protected Report(string report)
        {
            _report.AppendLine(report);
        }

        public void AddHeader(List<string> lines)
        {
            _header = new StringBuilder();
            _header.AppendLine(_divideLine);
            foreach (string line in lines)
            {
                _header.AppendLine(line);
            }
            _header.AppendLine(_divideLine);
        }

        public void AddFooter(List<string> lines)
        {
            _footer = new StringBuilder();
            _footer.AppendLine(_divideLine);
            foreach (string line in lines)
            {
                _footer.AppendLine(line);
            }
            _footer.AppendLine(_divideLine);
        }

        public abstract ExportFormat Export();
    }
}
