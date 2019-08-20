using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyp.Corrida.Application
{
    public class Result : Notifiable
    {
        protected Result()
        {
        }

        protected Result(ICollection<Notification> notifications)
        {
            this.AddNotifications(notifications);
        }

        public void AddNotification(string error)
        {
            this.AddNotification(null, error);
        }

        public ErrorCode? Error { get; set; }
    }
}
