using Domain.Models.ExportModels;
using Domain.Models.Notification;
using Domain.Models.SprintModels;
using Services;

INotificationService notificationService = new NotificationService();
Sprint releaseSprint = SprintFactory.CreateReleaseSprint("Export", DateTime.Now, DateTime.Now.AddDays(14), notificationService);

releaseSprint.GenerateReport(ExportOption.PNG);