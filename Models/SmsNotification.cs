using System;

namespace UniversityApp.Models
{
    public class SmsNotification : Notification
    {
        public string PhoneNumber { get; set; }
        public int MaxLength { get; set; }

        public override string NotificationType => "SMS";
        public override string ChannelInfo => PhoneNumber;

        public SmsNotification(string title, string recipient, DateTime createdAt, string phoneNumber, int maxLength)
            : base(title, recipient, createdAt)
        {
            PhoneNumber = phoneNumber;
            MaxLength = maxLength;
        }

        public override string Send()
        {
            return $"SMS отправлено на {PhoneNumber}.";
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Макс. длина: {MaxLength}";
        }
    }
}