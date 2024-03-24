using Domain.Models.Account;
using Domain.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NotificationService : INotificationService
    {
        private readonly List<INotificationObserver> _observers = new List<INotificationObserver>();

        public void Attach(INotificationObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(INotificationObserver observer)
        {
            _observers.Remove(observer);
        }

        // nog geen splitsing gemaakt in mail & slack met een design pattern, omdat tijd dringt en we dan design patterns gaan herhalen voor niets
        // mogelijk: strategy pattern voor splitsing van emails of slack notificaties.
        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }

        public void NotifyTesters(string message)
        {
            foreach (var observer in _observers.Where(o => o is Tester))
            {
                observer.Update(message);
            }
        }

        public void NotifyScrumMaster(string message)
        {
            foreach (var observer in _observers.Where(o => o is ScrumMaster))
            {
                observer.Update(message);
            }            
        }

        public void NotifyProductOwner(string message)
        {
            foreach (var observer in _observers.Where(o => o is ProductOwner))
            {
                observer.Update(message);
            }
        }
    }
}
