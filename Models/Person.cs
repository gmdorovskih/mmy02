using System;

namespace UniversityApp.Models
{
    public class Person
    {
        private static int _globalPersonCounter = 1;

        public int PersonalId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string FullName => $"{LastName} {FirstName}";

        public Person(string firstName, string lastName, int age)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Имя не может быть пустым.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Фамилия не может быть пустой.");

            if (age < 0)
                throw new ArgumentException("Возраст не может быть отрицательным.");

            PersonalId = _globalPersonCounter++;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public virtual string GetInfo()
        {
            return $"Личный номер: {PersonalId}, ФИО: {FullName}, Возраст: {Age}";
        }

        public override string ToString()
        {
            return GetInfo();
        }
    }
}