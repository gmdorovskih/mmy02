using System;

namespace UniversityApp.Models
{
    public class PushNotification : Notification
    {
        public string DeviceId { get; set; }
        public bool IsUrgent { get; set; }

        public override string NotificationType => "Push";
        public override string ChannelInfo => DeviceId;

        public PushNotification(string title, string recipient, DateTime createdAt, string deviceId, bool isUrgent)
            : base(title, recipient, createdAt)
        {
            DeviceId = deviceId;
            IsUrgent = isUrgent;
        }

        public override string Send()
        {
            return $"Push-уведомление отправлено на устройство {DeviceId}. Срочное: {(IsUrgent ? "Да" : "Нет")}";
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Срочное: {(IsUrgent ? "Да" : "Нет")}";
        }
    }
}