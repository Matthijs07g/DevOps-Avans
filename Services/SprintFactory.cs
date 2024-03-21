using Domain.Models.Notification;
using Domain.Models.SprintModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class SprintFactory
    {
        public static Sprint CreateReleaseSprint(string name, DateTime startDate, DateTime endDate, INotificationService notificationService)
        {
            return new ReleaseSprint(name, startDate, endDate, notificationService);
        }

        public static Sprint CreateReviewSprint(string name, DateTime startDate, DateTime endDate, INotificationService notificationService)
        {
            return new ReviewSprint(name, startDate, endDate, notificationService);
        }
    }
}
