using System;

namespace UniversityApp.Models
{
    public class EmailNotification : Notification
    {
        public string EmailAddress { get; set; }
        public string Subject { get; set; }

        public override string NotificationType => "Email";
        public override string ChannelInfo => EmailAddress;

        public EmailNotification(string title, string recipient, DateTime createdAt, string emailAddress, string subject)
            : base(title, recipient, createdAt)
        {
            EmailAddress = emailAddress;
            Subject = subject;
        }

        public override string Send()
        {
            return $"Email отправлен на {EmailAddress}. Тема: {Subject}";
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Тема письма: {Subject}";
        }
    }
}