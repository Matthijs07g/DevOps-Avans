using Domain.Models.BacklogModels.BacklogStates;
using Domain.Models.BacklogModels;
using Domain.Models.ExportModels;
using Domain.Models.Notification;
using Domain.Models.SprintModels;
using Services;

INotificationService mockNotificationService = new NotificationService();
Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Release Sprint", DateTime.Now, DateTime.Now.AddDays(14), mockNotificationService);

BacklogItem backlogItem = new BacklogItem("[US-342] - As a user I want to be able to login");
BacklogItem backlogActivity = new BacklogItem("[US-342-1 - As a user I want to be able to enter my username");
backlogItem.AddActivity(backlogActivity);
releaseSprint.AddBacklogItem(backlogItem);

backlogItem.CurrentState = new DoneState();