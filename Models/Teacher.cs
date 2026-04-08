using System;

namespace UniversityApp.Models
{
    public class Teacher : Person
    {
        public string Department { get; set; }
        public string Position { get; set; }

        public Teacher(string firstName, string lastName, int age, string department, string position)
            : base(firstName, lastName, age)
        {
            if (string.IsNullOrWhiteSpace(department))
                throw new ArgumentException("Кафедра не может быть пустой.");

            if (string.IsNullOrWhiteSpace(position))
                throw new ArgumentException("Должность не может быть пустой.");

            Department = department;
            Position = position;
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Кафедра: {Department}, Должность: {Position}";
        }
    }
}