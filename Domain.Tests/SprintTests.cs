using Domain.Models.SprintModels;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{
    public class SprintTests
    {
        [Fact]
        public void SprintsShouldNotBeEditableAfterStart()
        {
            // Arrange
            Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Release Sprint", DateTime.Now, DateTime.Now.AddDays(14));
            releaseSprint.Start();
            
            // Act
            Exception nameExc = Record.Exception(() => releaseSprint.Name = "Release Sprint naam aangepast");
            Exception startDateExc = Record.Exception(() => releaseSprint.StartDate = DateTime.Now.AddDays(1));
            Exception endDateExc = Record.Exception(() => releaseSprint.EndDate = DateTime.Now.AddDays(15));

            // Assert
            Assert.NotNull(nameExc);
            Assert.NotNull(startDateExc);
            Assert.NotNull(endDateExc);
            
            Assert.IsType<InvalidOperationException>(nameExc);
            Assert.IsType<InvalidOperationException>(startDateExc);
            Assert.IsType<InvalidOperationException>(endDateExc);
        }
    }
}
