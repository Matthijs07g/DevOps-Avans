using Domain.Models.BacklogModels.BacklogStates;
using Domain.Models.ForumModels;
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

        [Fact]
        public void ScrumMasterShouldBeNotifiedWhenPipelineFails()
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
        public void ScrumMasterAndProductOwnerShouldBeNotifiedWhenPipelineSucceeds()
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

        [Fact]
        public void AddPostToForumThreadShouldNotBePossibleWhenStateIsDoneState()
        {
            // Arrange 
            INotificationService mockNotificationService = Substitute.For<INotificationService>();
            Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Forum test", DateTime.Now, DateTime.Now.AddDays(14), mockNotificationService);
            Developer developer = new Developer("Henk");

            BacklogItem backlogItem = new BacklogItem("[US-342] - As a user I want to be able to login");
            releaseSprint.AddBacklogItem(backlogItem);
            backlogItem.CurrentState = new DoingState();

            ForumPost fPost = new ForumPost(developer, "[US-342]", "Cannot login when I enter correct password");
            ForumPost fPost2 = new ForumPost(developer, "[US-342]", "Second post");
            var fThread = releaseSprint.StartForumThread(backlogItem, fPost);

            // Act
            backlogItem.CurrentState = new DoneState();
            fThread.AddPost(fPost2);

            // Assert
            Assert.Single(fThread.Posts);
        }

        [Fact]
        public void StartForumPostShouldNotBePossibleWhenStateIsDoneState()
        {
            // Arrange 
            INotificationService mockNotificationService = Substitute.For<INotificationService>();
            Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Forum test", DateTime.Now, DateTime.Now.AddDays(14), mockNotificationService);
            Developer developer = new Developer("Henk");

            BacklogItem backlogItem = new BacklogItem("[US-342] - As a user I want to be able to login");
            releaseSprint.AddBacklogItem(backlogItem);
            backlogItem.CurrentState = new DoneState();

            ForumPost fPost = new ForumPost(developer, "[US-342]", "Cannot login when I enter correct password");

            // Act
            releaseSprint.StartForumThread(backlogItem, fPost);

            // Assert
            Assert.Empty(releaseSprint.Forum);
        }

        [Fact]
        public void AddPostToForumThreadShouldNotify()
        {
            // Arrange 
            INotificationService mockNotificationService = Substitute.For<INotificationService>();
            Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Forum test", DateTime.Now, DateTime.Now.AddDays(14), mockNotificationService);
            Developer developer = new Developer("Henk");

            BacklogItem backlogItem = new BacklogItem("[US-342] - As a user I want to be able to login");
            releaseSprint.AddBacklogItem(backlogItem);
            backlogItem.CurrentState = new DoingState();

            ForumPost fPost = new ForumPost(developer, "[US-342]", "Cannot login when I enter correct password");
            ForumPost fPost2 = new ForumPost(developer, "[US-342]", "Second post");
            var fThread = releaseSprint.StartForumThread(backlogItem, fPost);

            // Act
            fThread.AddPost(fPost2);

            // Assert
            mockNotificationService.Received().Notify("New post in thread: " + fThread.Title);
        }
    }
}
