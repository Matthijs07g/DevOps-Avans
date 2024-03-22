using Domain.Models.BacklogModels.BacklogStates;
using Domain.Models.ExportModels;
using Domain.Models.ForumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{
    public class ExportTests
    {
        [Fact]
        public void TC401_RapportExportsShouldBePossibleInMultipleFormats()
        {
            // Arrange 
            INotificationService mockNotificationService = Substitute.For<INotificationService>();
            Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Rapport test", DateTime.Now, DateTime.Now.AddDays(14), mockNotificationService);

            // Act
            var pdfReport = releaseSprint.GenerateReport(ExportFormat.PDF, null, null);
            var pngReport = releaseSprint.GenerateReport(ExportFormat.PNG, null, null);
            var formatPDF = pdfReport.Export();
            var formatPNG = pngReport.Export();

            // Assert
            Assert.True(formatPDF is ExportFormat.PDF);
            Assert.True(formatPNG is ExportFormat.PNG);
        }
    }
}
