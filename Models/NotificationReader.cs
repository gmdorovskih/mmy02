using System.Collections.Generic;

namespace UniversityApp.Models
{
    public class NotificationReader<T> : INotificationReader<T> where T : Notification
    {
        private readonly NotificationContainer<T> _container;

        public NotificationReader(NotificationContainer<T> container)
        {
            _container = container;
        }

        public IEnumerable<T> ReadAll()
        {
            return _container.GetAll();
        }
    }
}