using System.Collections.Generic;
using System.Linq;

namespace UniversityApp.Models
{
    public class PriorityNotificationContainer<T> : NotificationContainer<T> where T : Notification
    {
        public List<T> GetLatestFirst()
        {
            return _items
                .OrderByDescending(n => n.CreatedAt)
                .ToList();
        }
    }
}