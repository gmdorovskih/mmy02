using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UniversityApp.Models;

namespace UniversityApp.DataAccess
{
    public class StudentsRepository
    {
        private readonly string _filePath;

        public StudentsRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveStudents(List<Student> students)
        {
            using StreamWriter writer = new StreamWriter(_filePath, false);

            foreach (var student in students)
            {
                writer.WriteLine($"{student.FirstName};{student.LastName};{student.Age};{student.AverageGrade.ToString(CultureInfo.InvariantCulture)}");
            }
        }

        public List<Student> LoadStudents()
        {
            List<Student> students = new();

            if (!File.Exists(_filePath))
                return students;

            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                if (parts.Length == 4)
                {
                    string firstName = parts[0];
                    string lastName = parts[1];
                    int age = int.Parse(parts[2]);
                    double averageGrade = double.Parse(parts[3], CultureInfo.InvariantCulture);

                    students.Add(new Student(firstName, lastName, age, averageGrade));
                }
            }

            return students;
        }
    }
}