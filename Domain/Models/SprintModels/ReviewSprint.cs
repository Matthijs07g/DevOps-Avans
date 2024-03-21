using Domain.Models.Notification;
using Domain.Models.SprintModels.FinishStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SprintModels
{
    public class ReviewSprint : Sprint
    {
        public ReviewSprint(string name, DateTime startDate, DateTime endDate, INotificationService notificationService)
            : base(name, startDate, endDate, notificationService)
        {
            _finishStrategy = new ReviewFinishStrategy();
        }
    }
}
