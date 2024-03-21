using Domain.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Account
{
    public abstract class AbstractUser : INotificationObserver
    {
        protected string _name;

        public void Update(string message)
        {
            Console.WriteLine("User " + _name + " received message: " + message);
        }
    }
}
