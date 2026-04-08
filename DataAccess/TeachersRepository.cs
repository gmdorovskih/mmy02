using System;
using System.Collections.Generic;
using System.IO;
using UniversityApp.Models;

namespace UniversityApp.DataAccess
{
    public class TeachersRepository
    {
        private readonly string _filePath;

        public TeachersRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveTeachers(List<Teacher> teachers)
        {
            using StreamWriter writer = new StreamWriter(_filePath, false);

            foreach (var teacher in teachers)
            {
                writer.WriteLine($"{teacher.FirstName};{teacher.LastName};{teacher.Age};{teacher.Department};{teacher.Position}");
            }
        }

        public List<Teacher> LoadTeachers()
        {
            List<Teacher> teachers = new();

            if (!File.Exists(_filePath))
                return teachers;

            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                if (parts.Length == 5)
                {
                    teachers.Add(new Teacher(
                        parts[0],
                        parts[1],
                        int.Parse(parts[2]),
                        parts[3],
                        parts[4]));
                }
            }

            return teachers;
        }
    }
}