using System;
using System.Collections.Generic;
using System.Drawing;
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
            INotificationService notificationService = new NotificationService();
            Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Release Sprint", DateTime.Now, DateTime.Now.AddDays(14), notificationService);
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


        [Fact]
        public void ReleaseShouldBeCancelledAndNotifiedIfResultsAreNotGoodEnough()
        {
            // Arrange
            INotificationService mockNotificationService = Substitute.For<INotificationService>();
            Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Release Sprint", DateTime.Now, DateTime.Now.AddDays(14), mockNotificationService);

            BacklogItem backlogItem = new BacklogItem("[US-342] - As a user I want to be able to login");
            releaseSprint.AddBacklogItem(backlogItem);

            // Act
            releaseSprint.Finish();

            // Assert
            mockNotificationService.Received().NotifyScrumMaster("[" + releaseSprint.Name + "] release failed: results are not good enough");
            mockNotificationService.Received().NotifyProductOwner("[" + releaseSprint.Name + "] release failed: results are not good enough");
        }
    }
}
