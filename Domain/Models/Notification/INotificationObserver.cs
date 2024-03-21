using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Notification
{
    public interface INotificationObserver
    {
        void Update(string message);
    }
}
