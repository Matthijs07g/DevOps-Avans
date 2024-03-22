using Domain.Models.BacklogModels.BacklogStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{
    public class BacklogTests
    {
        [Fact]
        public void TC201_TestersShouldBeNotifiedWhenStateOfBacklogItemIsSetToReadyForTesting()
        {
            // Arrange
            INotificationService mockNotificationService = Substitute.For<INotificationService>();
            Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Release Sprint", DateTime.Now, DateTime.Now.AddDays(14), mockNotificationService);

            BacklogItem backlogItem = new BacklogItem("[US-342] - As a user I want to be able to login");
            releaseSprint.AddBacklogItem(backlogItem);

            // Act
            backlogItem.CurrentState = new ReadyForTestingState();

            // Assert
            mockNotificationService.Received().NotifyTesters("[" + backlogItem.Title + "] status update: ready for testing");
        }

        [Fact]
        public void TC202_ScrumMasterShouldBeNotifiedWhenStateOfBacklogItemIsSetBackToTodoFromTesting()
        {
            // Arrange
            INotificationService mockNotificationService = Substitute.For<INotificationService>();
            Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Release Sprint", DateTime.Now, DateTime.Now.AddDays(14), mockNotificationService);

            BacklogItem backlogItem = new BacklogItem("[US-342] - As a user I want to be able to login");
            releaseSprint.AddBacklogItem(backlogItem);

            // Act
            backlogItem.CurrentState = new ReadyForTestingState();
            backlogItem.CurrentState = new TodoState();

            // Assert
            mockNotificationService.Received().NotifyScrumMaster("[" + backlogItem.Title + "] status update: back to todo");
        }

        [Fact]
        public void TC203_BacklogItemCanOnlyBeDoneWhenAllActivitiesAreDone()
        {
            {
                // Arrange
                INotificationService mockNotificationService = Substitute.For<INotificationService>();
                Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Release Sprint", DateTime.Now, DateTime.Now.AddDays(14), mockNotificationService);

                BacklogItem backlogItem = new BacklogItem("[US-342] - As a user I want to be able to login");
                BacklogItem backlogActivity = new BacklogItem("[US-342-1 - As a user I want to be able to enter my username");
                backlogItem.AddActivity(backlogActivity);
                releaseSprint.AddBacklogItem(backlogItem);

                // Act
                Exception exc = Record.Exception(() => backlogItem.CurrentState = new DoneState());

                // Assert
                Assert.IsType<InvalidOperationException>(exc);
            }
        }
    }
}
