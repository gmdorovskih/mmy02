using System;

namespace UniversityApp.Models
{
    public class Course
    {
        private string _courseName = "";
        private int _hours;

        public string CourseName
        {
            get => _courseName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название курса не может быть пустым.");
                _courseName = value;
            }
        }

        public string Description { get; set; }

        public int Hours
        {
            get => _hours;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество часов не может быть отрицательным.");
                _hours = value;
            }
        }

        public bool IsShortCourse => Hours < 25;

        public Course(string courseName, string description, int hours)
        {
            CourseName = courseName;
            Description = description;
            Hours = hours;
        }

        public string GetInfo()
        {
            return $"Курс: {CourseName}, Описание: {Description}, Часы: {Hours}, Короткий курс: {(IsShortCourse ? "Да" : "Нет")}";
        }

        public string GetInfo(bool includeHours)
        {
            if (includeHours)
                return GetInfo();

            return $"Курс: {CourseName}, Описание: {Description}, Короткий курс: {(IsShortCourse ? "Да" : "Нет")}";
        }

        public override string ToString()
        {
            return GetInfo();
        }
    }
}