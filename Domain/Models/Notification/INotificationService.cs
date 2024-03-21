using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Notification
{
    public interface INotificationService
    {
        void Notify(string message);
        void NotifyTesters(string message);
        void NotifyScrumMaster(string message);
        void NotifyProductOwner(string message);
        void Attach(INotificationObserver observer);
        void Detach(INotificationObserver observer);
    }
}
