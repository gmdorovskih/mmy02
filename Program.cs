using System;
using static System.Console;
using UniversityApp.Models;
using UniversityApp.DataAccess;

namespace UniversityApp
{
    internal class Program
    {
        private static University university = new("Мой Университет");
        private static StudentsRepository studentsRepository = new("students.txt");
        private static TeachersRepository teachersRepository = new("teachers.txt");

        private static NotificationContainer<EmailNotification> emailNotifications = new();
        private static NotificationContainer<SmsNotification> smsNotifications = new();
        private static PriorityNotificationContainer<PushNotification> pushNotifications = new();

        static void Main(string[] args)
        {
            Title = "Информационно-справочная система университета";
            RunMainMenu();
        }

        static void RunMainMenu()
        {
            while (true)
            {
                Clear();
                PrintHeader("ИНФОРМАЦИОННО-СПРАВОЧНАЯ СИСТЕМА УНИВЕРСИТЕТА");

                WriteLine("1. Работа со студентами");
                WriteLine("2. Работа с преподавателями");
                WriteLine("3. Работа с курсами");
                WriteLine("4. Работа с уведомлениями");
                WriteLine("5. Сохранить данные");
                WriteLine("6. Загрузить данные");
                WriteLine("0. Выход");
                Write("\nВыберите пункт: ");

                string? choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        StudentsMenu();
                        break;
                    case "2":
                        TeachersMenu();
                        break;
                    case "3":
                        CoursesMenu();
                        break;
                    case "4":
                        NotificationsMenu();
                        break;
                    case "5":
                        SaveData();
                        break;
                    case "6":
                        LoadData();
                        break;
                    case "0":
                        return;
                    default:
                        ShowMessage("Неверный выбор.");
                        break;
                }
            }
        }

        static void StudentsMenu()
        {
            while (true)
            {
                Clear();
                PrintHeader("СТУДЕНТЫ");

                WriteLine("1. Добавить студента");
                WriteLine("2. Удалить студента");
                WriteLine("3. Найти студента");
                WriteLine("4. Показать всех студентов");
                WriteLine("0. Назад");
                Write("\nВыберите пункт: ");

                string? choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        RemoveStudent();
                        break;
                    case "3":
                        FindStudent();
                        break;
                    case "4":
                        ShowAllStudents();
                        break;
                    case "0":
                        return;
                    default:
                        ShowMessage("Неверный выбор.");
                        break;
                }
            }
        }

        static void TeachersMenu()
        {
            while (true)
            {
                Clear();
                PrintHeader("ПРЕПОДАВАТЕЛИ");

                WriteLine("1. Добавить преподавателя");
                WriteLine("2. Удалить преподавателя");
                WriteLine("3. Найти преподавателя");
                WriteLine("4. Показать всех преподавателей");
                WriteLine("0. Назад");
                Write("\nВыберите пункт: ");

                string? choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTeacher();
                        break;
                    case "2":
                        RemoveTeacher();
                        break;
                    case "3":
                        FindTeacher();
                        break;
                    case "4":
                        ShowAllTeachers();
                        break;
                    case "0":
                        return;
                    default:
                        ShowMessage("Неверный выбор.");
                        break;
                }
            }
        }

        static void CoursesMenu()
        {
            while (true)
            {
                Clear();
                PrintHeader("КУРСЫ");

                WriteLine("1. Добавить курс");
                WriteLine("2. Показать все курсы");
                WriteLine("0. Назад");
                Write("\nВыберите пункт: ");

                string? choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCourse();
                        break;
                    case "2":
                        ShowAllCourses();
                        break;
                    case "0":
                        return;
                    default:
                        ShowMessage("Неверный выбор.");
                        break;
                }
            }
        }

        static void NotificationsMenu()
        {
            while (true)
            {
                Clear();
                PrintHeader("УВЕДОМЛЕНИЯ");

                WriteLine("1. Создать Email уведомление");
                WriteLine("2. Создать SMS уведомление");
                WriteLine("3. Создать Push уведомление");
                WriteLine("4. Показать все уведомления");
                WriteLine("0. Назад");
                Write("\nВыберите пункт: ");

                string? choice = ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmailNotification();
                        break;
                    case "2":
                        AddSmsNotification();
                        break;
                    case "3":
                        AddPushNotification();
                        break;
                    case "4":
                        ShowAllNotifications();
                        break;
                    case "0":
                        return;
                    default:
                        ShowMessage("Неверный выбор.");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            try
            {
                Clear();
                PrintHeader("ДОБАВЛЕНИЕ СТУДЕНТА");

                Write("Имя: ");
                string firstName = ReadLine() ?? "";

                Write("Фамилия: ");
                string lastName = ReadLine() ?? "";

                Write("Возраст: ");
                int age = int.Parse(ReadLine() ?? "0");

                Write("Средний балл: ");
                double averageGrade = double.Parse(ReadLine() ?? "0");

                Student student = new(firstName, lastName, age, averageGrade);
                university.AddStudent(student);

                ShowMessage("Студент успешно добавлен.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Ошибка: {ex.Message}");
            }
        }

        static void RemoveStudent()
        {
            Clear();
            PrintHeader("УДАЛЕНИЕ СТУДЕНТА");

            Write("Введите фамилию студента: ");
            string lastName = ReadLine() ?? "";

            bool removed = university.RemoveStudent(lastName);
            ShowMessage(removed ? "Студент удалён." : "Студент не найден.");
        }

        static void FindStudent()
        {
            Clear();
            PrintHeader("ПОИСК СТУДЕНТА");

            Write("Введите фамилию студента: ");
            string lastName = ReadLine() ?? "";

            Student? student = university.FindStudent(lastName);

            if (student == null)
                ShowMessage("Студент не найден.");
            else
            {
                WriteLine(student.GetInfo());
                Pause();
            }
        }

        static void ShowAllStudents()
        {
            Clear();
            PrintHeader("СПИСОК СТУДЕНТОВ");

            var students = university.GetAllStudents();

            if (students.Count == 0)
                WriteLine("Список студентов пуст.");
            else
                foreach (var student in students)
                    WriteLine(student.GetInfo());

            Pause();
        }

        static void AddTeacher()
        {
            try
            {
                Clear();
                PrintHeader("ДОБАВЛЕНИЕ ПРЕПОДАВАТЕЛЯ");

                Write("Имя: ");
                string firstName = ReadLine() ?? "";

                Write("Фамилия: ");
                string lastName = ReadLine() ?? "";

                Write("Возраст: ");
                int age = int.Parse(ReadLine() ?? "0");

                Write("Кафедра: ");
                string department = ReadLine() ?? "";

                Write("Должность: ");
                string position = ReadLine() ?? "";

                Teacher teacher = new(firstName, lastName, age, department, position);
                university.AddTeacher(teacher);

                ShowMessage("Преподаватель успешно добавлен.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Ошибка: {ex.Message}");
            }
        }

        static void RemoveTeacher()
        {
            Clear();
            PrintHeader("УДАЛЕНИЕ ПРЕПОДАВАТЕЛЯ");

            Write("Введите фамилию преподавателя: ");
            string lastName = ReadLine() ?? "";

            bool removed = university.RemoveTeacher(lastName);
            ShowMessage(removed ? "Преподаватель удалён." : "Преподаватель не найден.");
        }

        static void FindTeacher()
        {
            Clear();
            PrintHeader("ПОИСК ПРЕПОДАВАТЕЛЯ");

            Write("Введите фамилию преподавателя: ");
            string lastName = ReadLine() ?? "";

            Teacher? teacher = university.FindTeacher(lastName);

            if (teacher == null)
                ShowMessage("Преподаватель не найден.");
            else
            {
                WriteLine(teacher.GetInfo());
                Pause();
            }
        }

        static void ShowAllTeachers()
        {
            Clear();
            PrintHeader("СПИСОК ПРЕПОДАВАТЕЛЕЙ");

            var teachers = university.GetAllTeachers();

            if (teachers.Count == 0)
                WriteLine("Список преподавателей пуст.");
            else
                foreach (var teacher in teachers)
                    WriteLine(teacher.GetInfo());

            Pause();
        }

        static void AddCourse()
        {
            try
            {
                Clear();
                PrintHeader("ДОБАВЛЕНИЕ КУРСА");

                Write("Название курса: ");
                string name = ReadLine() ?? "";

                Write("Описание: ");
                string description = ReadLine() ?? "";

                Write("Количество часов: ");
                int hours = int.Parse(ReadLine() ?? "0");

                Course course = new(name, description, hours);
                university.AddCourse(course);

                ShowMessage("Курс успешно добавлен.");
            }
            catch (Exception ex)
            {
                ShowMessage($"Ошибка: {ex.Message}");
            }
        }

        static void ShowAllCourses()
        {
            Clear();
            PrintHeader("СПИСОК КУРСОВ");

            var courses = university.GetAllCourses();

            if (courses.Count == 0)
                WriteLine("Список курсов пуст.");
            else
                foreach (var course in courses)
                    WriteLine(course.GetInfo());

            Pause();
        }

        static void AddEmailNotification()
        {
            Clear();
            PrintHeader("EMAIL УВЕДОМЛЕНИЕ");

            Write("Заголовок: ");
            string title = ReadLine() ?? "";

            Write("Получатель: ");
            string recipient = ReadLine() ?? "";

            Write("Email: ");
            string email = ReadLine() ?? "";

            Write("Тема: ");
            string subject = ReadLine() ?? "";

            var notification = new EmailNotification(title, recipient, DateTime.Now, email, subject);
            emailNotifications.Add(notification);

            ShowMessage(notification.Send());
        }

        static void AddSmsNotification()
        {
            Clear();
            PrintHeader("SMS УВЕДОМЛЕНИЕ");

            Write("Заголовок: ");
            string title = ReadLine() ?? "";

            Write("Получатель: ");
            string recipient = ReadLine() ?? "";

            Write("Телефон: ");
            string phone = ReadLine() ?? "";

            var notification = new SmsNotification(title, recipient, DateTime.Now, phone, 70);
            smsNotifications.Add(notification);

            ShowMessage(notification.Send());
        }

        static void AddPushNotification()
        {
            Clear();
            PrintHeader("PUSH УВЕДОМЛЕНИЕ");

            Write("Заголовок: ");
            string title = ReadLine() ?? "";

            Write("Получатель: ");
            string recipient = ReadLine() ?? "";

            Write("ID устройства: ");
            string deviceId = ReadLine() ?? "";

            var notification = new PushNotification(title, recipient, DateTime.Now, deviceId, true);
            pushNotifications.Add(notification);

            ShowMessage(notification.Send());
        }

        static void ShowAllNotifications()
        {
            Clear();
            PrintHeader("ВСЕ УВЕДОМЛЕНИЯ");

            WriteLine("--- EMAIL ---");
            foreach (var item in emailNotifications.GetAll())
                WriteLine(item.GetInfo());

            WriteLine("\n--- SMS ---");
            foreach (var item in smsNotifications.GetAll())
                WriteLine(item.GetInfo());

            WriteLine("\n--- PUSH ---");
            foreach (var item in pushNotifications.GetLatestFirst())
                WriteLine(item.GetInfo());

            Pause();
        }

        static void SaveData()
        {
            studentsRepository.SaveStudents(university.GetAllStudents());
            teachersRepository.SaveTeachers(university.GetAllTeachers());

            ShowMessage("Данные успешно сохранены.");
        }

        static void LoadData()
        {
            var students = studentsRepository.LoadStudents();
            foreach (var student in students)
                university.AddStudent(student);

            var teachers = teachersRepository.LoadTeachers();
            foreach (var teacher in teachers)
                university.AddTeacher(teacher);

            ShowMessage("Данные успешно загружены.");
        }

        static void PrintHeader(string title)
        {
            WriteLine("========================================");
            WriteLine($" {title}");
            WriteLine("========================================\n");
        }

        static void ShowMessage(string message)
        {
            WriteLine($"\n{message}");
            Pause();
        }

        static void Pause()
        {
            WriteLine("\nНажмите любую клавишу...");
            ReadKey();
        }
    }
}