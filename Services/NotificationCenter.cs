using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Models;

namespace UniversityApp.Services
{
    public class NotificationCenter
    {
        private readonly List<Notification> _notifications = new();

        public void Add(Notification notification)
        {
            if (notification != null)
            {
                _notifications.Add(notification);
            }
        }

        public string GetStatistics()
        {
            int emailCount = _notifications.OfType<EmailNotification>().Count();
            int smsCount = _notifications.OfType<SmsNotification>().Count();
            int pushCount = _notifications.OfType<PushNotification>().Count();

            return $"EmailNotificationsCount: {emailCount}, SmsNotificationsCount: {smsCount}, PushNotificationsCount: {pushCount}";
        }

        public List<Notification> GetAll()
        {
            return _notifications;
        }
    }
}