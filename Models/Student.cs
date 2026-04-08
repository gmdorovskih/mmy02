using System;

namespace UniversityApp.Models
{
    public class Student : Person
    {
        private double _averageGrade;

        public int StudentRecordBookNumber { get; set; }

        public double AverageGrade
        {
            get => _averageGrade;
            set
            {
                if (value < 0 || value > 5)
                    throw new ArgumentException("Средний балл должен быть от 0 до 5.");
                _averageGrade = value;
            }
        }

        public bool IsExcellent => AverageGrade >= 4.5;

        public Student(string firstName, string lastName, int age, double averageGrade)
            : base(firstName, lastName, age)
        {
            AverageGrade = averageGrade;
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Зачётка: {StudentRecordBookNumber}, Средний балл: {AverageGrade:F2}, Отличник: {(IsExcellent ? "Да" : "Нет")}";
        }
    }
}