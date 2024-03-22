using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{
    public class PipelineTests
    {
        [Fact]
        public void TC301_ScrumMasterAndProductOwnerShouldBeNotifiedWhenPipelineFails()
        {
            // Arrange
            INotificationService mockNotificationService = Substitute.For<INotificationService>();
            Sprint releaseSprint = SprintFactory.CreateReleaseSprint("PipelineShouldFail", DateTime.Now, DateTime.Now.AddDays(14), mockNotificationService);

            // Act
            releaseSprint.Finish();

            // Assert
            mockNotificationService.Received().NotifyScrumMaster("Pipeline failed at step: BuildStep");
        }

        [Fact]
        public void TC302_ScrumMasterAndProductOwnerShouldBeNotifiedWhenPipelineSucceeds()
        {
            // Arrange
            INotificationService mockNotificationService = Substitute.For<INotificationService>();
            Sprint releaseSprint = SprintFactory.CreateReleaseSprint("PipelineShouldSucceed", DateTime.Now, DateTime.Now.AddDays(14), mockNotificationService);

            // Act
            releaseSprint.Finish();

            // Assert
            mockNotificationService.Received().NotifyScrumMaster("[" + releaseSprint.Name + "] release succeeded");
            mockNotificationService.Received().NotifyProductOwner("[" + releaseSprint.Name + "] release succeeded");
        }
    }
}
