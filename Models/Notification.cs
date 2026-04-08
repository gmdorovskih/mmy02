using System;

namespace UniversityApp.Models
{
    public abstract class Notification : IComparable<Notification>
    {
        public string Title { get; set; }
        public string Recipient { get; set; }
        public DateTime CreatedAt { get; set; }

        public abstract string NotificationType { get; }
        public abstract string ChannelInfo { get; }

        protected Notification(string title, string recipient, DateTime createdAt)
        {
            Title = title;
            Recipient = recipient;
            CreatedAt = createdAt;
        }

        public abstract string Send();

        public virtual string GetInfo()
        {
            return $"Тип: {NotificationType}, Заголовок: {Title}, Получатель: {Recipient}, Дата: {CreatedAt}, Канал: {ChannelInfo}";
        }

        public override string ToString()
        {
            return GetInfo();
        }

        public int CompareTo(Notification? other)
        {
            if (other == null)
                return 1;

            return CreatedAt.CompareTo(other.CreatedAt);
        }
    }
}