using System.Collections.Generic;

namespace UniversityApp.Models
{
    public interface INotificationReader<out T> where T : Notification
    {
        IEnumerable<T> ReadAll();
    }
}