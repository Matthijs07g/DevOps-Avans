using Domain.Models.BacklogModels.BacklogStates;
using Domain.Models.ForumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{
    public class ForumTests
    {

        [Fact]
        public void TC501_AddPostToForumThreadShouldNotBePossibleWhenStateIsDoneState()
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
        public void TC502_StartForumPostShouldNotBePossibleWhenStateIsDoneState()
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
        public void TC503_AddPostToForumThreadShouldNotify()
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
