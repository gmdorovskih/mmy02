using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversityApp.Models
{
    public class University
    {
        private readonly List<Student> _students = new();
        private readonly List<Teacher> _teachers = new();
        private readonly List<Course> _courses = new();

        private int _studentBookCounter = 1;

        public string Name { get; }

        public University(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название университета не может быть пустым.");

            Name = name;
        }

        public void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (!_students.Contains(student))
            {
                if (student.StudentRecordBookNumber == 0)
                {
                    student.StudentRecordBookNumber = _studentBookCounter++;
                }

                _students.Add(student);
            }
        }

        public bool RemoveStudent(string lastName)
        {
            var student = _students.FirstOrDefault(s =>
                s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

            if (student == null)
                return false;

            _students.Remove(student);
            return true;
        }

        public Student? FindStudent(string lastName)
        {
            return _students.FirstOrDefault(s =>
                s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Student> GetAllStudents()
        {
            return new List<Student>(_students);
        }

        public Student? FindStudentByRecordBook(int recordBookNumber)
        {
            return _students.FirstOrDefault(s => s.StudentRecordBookNumber == recordBookNumber);
        }

        public Student? FindStudentByPersonalId(int personalId)
        {
            return _students.FirstOrDefault(s => s.PersonalId == personalId);
        }

        public void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));

            if (!_teachers.Contains(teacher))
                _teachers.Add(teacher);
        }

        public bool RemoveTeacher(string lastName)
        {
            var teacher = _teachers.FirstOrDefault(t =>
                t.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

            if (teacher == null)
                return false;

            _teachers.Remove(teacher);
            return true;
        }

        public Teacher? FindTeacher(string lastName)
        {
            return _teachers.FirstOrDefault(t =>
                t.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Teacher> GetAllTeachers()
        {
            return new List<Teacher>(_teachers);
        }

        public void AddCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            _courses.Add(course);
        }

        public List<Course> GetAllCourses()
        {
            return new List<Course>(_courses);
        }
    }
}